/*-----------------------------------------------------------------------
<copyright file="FileResourceTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using LtInfo.Common;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirmaModels.UnitTestCommon;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class FileResourceTest
    {
        private ProjectFirmaSqlDatabase _db;
        private bool _projectFirmaDatabaseIsSetUp = false;
        private readonly object _setupLockObject = new Object();

        [OneTimeSetUpAttribute]
        public void TestFixtureSetup()
        {
            lock (_setupLockObject)
            {
                if (!_projectFirmaDatabaseIsSetUp)
                {
                    _db = new ProjectFirmaSqlDatabase();
                    _projectFirmaDatabaseIsSetUp = true;
                }
            }
        }

        [Test]
        public void CreateNewFromHttpPostedFileTest()
        {
            // Arrange
            var testImageFile = new TestImageFile();
            var person = TestFramework.TestPerson.Create();

            // Act
            var fileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFile(testImageFile, person);

            // Assert
            //Assert.That(fileResource.FileResourceData, Is.EqualTo(testImageFile.InputStream));
            Assert.That(fileResource.FileResourceMimeType, Is.EqualTo(testImageFile.FileResourceMimeType));
            Assert.That(fileResource.GetOriginalCompleteFileName(), Is.EqualTo(testImageFile.FileName));
            Assert.That(fileResource.CreatePersonID, Is.EqualTo(person.PersonID));
        }

        [Test]
        public void GuidRegexWorksTest()
        {
            var a = TestFramework.TestFileResource.Create();
            var results = FileResourceModelExtensions.FindAllFileResourceGuidsFromStringContainingFileResourceUrls(a.GetFileResourceUrl());

            Assert.That(results, Is.EquivalentTo(new[] {a.FileResourceGUID}));
        }

        static FileResourceTest()
        {
            var sampleGuid = Guid.Empty;
            var typicalUrlForFileResources = SitkaRoute<FileResourceController>.BuildUrlFromExpression(c => c.DisplayResource(sampleGuid.ToString()));
            ControllerPartOfUri = Regex.Match(typicalUrlForFileResources, "^/(?<controller>.*?)/").Groups["controller"].Value;
            NonServerRootRelativeUrlRegex = new Regex($"(?<!((\"/)|(^/))){Regex.Escape(ControllerPartOfUri)}", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        }

        private readonly Lazy<List<FileResource>> _allFileResources = new Lazy<List<FileResource>>(HttpRequestStorage.DatabaseEntities.AllFileResources.ToList);
        private static readonly Regex NonServerRootRelativeUrlRegex;
        public static readonly string ControllerPartOfUri;

        private class ResultRow
        {
            public readonly string ColumnName;
            public readonly string ColumnValue;
            public readonly string TableCatalog;
            public readonly string TableName;
            public readonly string TableSchema;

            public ResultRow(string tableCatalog, string tableSchema, string tableName, string columnName, string columnValue)
            {
                TableCatalog = tableCatalog;
                TableSchema = tableSchema;
                TableName = tableName;
                ColumnName = columnName;
                ColumnValue = columnValue;
            }
        }

        private static void AssertThatAllUrlsAreServerRootRelative(IEnumerable<ResultRow> dataFromRowsAndColumnsWithUrls)
        {
            var htmlWithMalformedUrls = dataFromRowsAndColumnsWithUrls.Where(x => DoesHtmlStringContainNonServerRootRelativeUrl(x.ColumnValue)).ToList();
            var malformedUrls = htmlWithMalformedUrls.Select(x => $"TableCatalog: {x.TableCatalog}, TableSchema: {x.TableSchema}, TableName: {x.TableName}, ColumnName: {x.ColumnName}, ColumnValue:\r\n{x.ColumnValue}");
            var errorString = string.Join("\r\n", malformedUrls);
            Assert.That(htmlWithMalformedUrls, Is.Empty, $"Found some URLs that aren't server root relative:\r\n{errorString}");
        }

        private static void AssertThatAllUrlsDoNotContainAbsoluteUrlsToProdOrQa(IEnumerable<ResultRow> dataFromRowsAndColumnsWithUrls)
        {
            var htmlWithMalformedUrls = dataFromRowsAndColumnsWithUrls.Where(x => x.ColumnValue.DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference()).ToList();
            var malformedUrls = htmlWithMalformedUrls.Select(x => $"TableCatalog: {x.TableCatalog}, TableSchema: {x.TableSchema}, TableName: {x.TableName}, ColumnName: {x.ColumnName}, ColumnValue:\r\n{x.ColumnValue}").ToList();
            var errorString = string.Join("\r\n", malformedUrls);
            Assert.That(htmlWithMalformedUrls, Is.Empty, $"Found some URLs that aren't server root relative (absolute urls to Prod or QA):\r\n{errorString}");
        }

        /// <summary>
        /// Does a given HTML string contain a non-server root relative URL? 
        /// (This is bad & undesirable, by the way.)
        /// </summary>
        /// <param name="htmlString"></param>
        /// <returns></returns>
        public static bool DoesHtmlStringContainNonServerRootRelativeUrl(string htmlString)
        {
            return NonServerRootRelativeUrlRegex.IsMatch(htmlString);
        }

        private void AssertThatAllReferencedFileResourceGuidsExist(IEnumerable<ResultRow> dataFromRowsAndColumnsWithUrls)
        {
            var fileResourceGuidsInUrls = new List<Guid>();
            foreach (var resultRow in dataFromRowsAndColumnsWithUrls)
            {
                fileResourceGuidsInUrls.AddRange(FindAllFileResourceGuidsFromStringContainingFileResourceUrls(resultRow.ColumnValue));
            }
            var fileResourceGuidsInDb = _allFileResources.Value.Select(x => x.FileResourceGUID);
            var missing = fileResourceGuidsInUrls.Except(fileResourceGuidsInDb);
            Assert.That(missing, Is.Empty, "Found at least one URL in text columns in the database referring to a FileResourceGuid that is not in the FileResource table.");
        }

        /// <summary>
        /// Based on a string that has embedded file resource URLs in it, parse out the URLs and look up the corresponding FileResource stuff
        /// Made public for testing purposes.
        /// </summary>
        public static List<Guid> FindAllFileResourceGuidsFromStringContainingFileResourceUrls(string textWithReferences)
        {
            var guidCaptures = FileResourceModelExtensions.FileResourceUrlRegEx.Matches(textWithReferences).Cast<Match>().Select(x => x.Groups["fileResourceGuidCapture"].Value).ToList();
            var theseGuids = guidCaptures.Select(x => new Guid(x)).Distinct().ToList();
            return theseGuids;
        }

        [Test]
        public void IsRegexToFindNonServerRootRelativeUrlsWorking()
        {
            Trace.WriteLine($"Non-server root relative Regex string: {NonServerRootRelativeUrlRegex}");
            Assert.That(DoesHtmlStringContainNonServerRootRelativeUrl(""), Is.False, "Empty string - can't be bad");
            Assert.That(DoesHtmlStringContainNonServerRootRelativeUrl("ABC"), Is.False, "Simple string - can't be bad");
            Assert.That(DoesHtmlStringContainNonServerRootRelativeUrl($"\"../../{ControllerPartOfUri}"), Is.True, "should be bad - not server root relative");
            Assert.That(DoesHtmlStringContainNonServerRootRelativeUrl(ControllerPartOfUri), Is.True, "should be bad - not server root relative");
            Assert.That(DoesHtmlStringContainNonServerRootRelativeUrl("/FileResource/DisplayResource/9d73b8cf-1108-43c3-a7f7-e0625033adde"), Is.False, "Should be fine -- is server root relative");
            Assert.That(DoesHtmlStringContainNonServerRootRelativeUrl("http://www.sitkatech.com"), Is.False, "Should be fine -- this is a site external to the ProjectFirma one being served. This kind of URL in fact *MUST* be fully qualified.");
            Assert.That(DoesHtmlStringContainNonServerRootRelativeUrl("http://www.sitkatech.com/products/ProjectFirma/"), Is.False, "Should be fine -- this is a site external to the ProjectFirma one being served. This kind of URL in fact *MUST* be fully qualified.");
            Assert.That(DoesHtmlStringContainNonServerRootRelativeUrl("blah blah balh file:///FileResource/DisplayResource/291562b9-d7dd-4fc5-a57a-5a3dec2fd6cd"), Is.True, "A specific example of something found at least once in real-world data that should be illegal.");
        }

        [Test]
        public void UrlsInTextColumnsInDatabaseMatchDatabaseRecords()
        {
            //TODO: Not sure if ProjectUpdateBatch should be in the exception list, but not clear how to correct data that has already posted that is breaking this test.
            const string findAnyColumnsThatCouldContainUrls = @"
select c.TABLE_CATALOG, c.TABLE_SCHEMA, c.TABLE_NAME, c.COLUMN_NAME
from INFORMATION_SCHEMA.COLUMNS c
     join INFORMATION_SCHEMA.TABLES t on c.TABLE_CATALOG = t.TABLE_CATALOG and c.TABLE_SCHEMA = t.TABLE_SCHEMA and c.TABLE_NAME = t.TABLE_NAME
where c.DATA_TYPE in ('char','nvarchar','text','ntext','varchar')
      and t.TABLE_TYPE = 'BASE TABLE'  and t.TABLE_NAME not in ('AuditLog', 'FirmaPage', 'ProjectUpdateBatch')
";
            List<string> sqlQueriesToGatherDataWithUrls;
            using (var command = new SqlCommand(findAnyColumnsThatCouldContainUrls))
            {
                var sqlConnection = _db.CreateConnection();
                using (var conn = sqlConnection)
                {
                    command.Connection = conn;
                    using (var dt = ProjectFirmaSqlDatabase.ExecuteSqlCommand(command).Tables[0])
                    {
                        sqlQueriesToGatherDataWithUrls =
                            dt.Rows.Cast<DataRow>()
                                .Select(
                                    x =>
                                        String.Format(
                                            "select '{0}' as TableCatalog, '{1}' as TableSchema, '{2}' as TableName, '{3}' as ColumnName, [{3}] as ColumnValue from [{0}].[{1}].[{2}] where [{3}] like '%{4}%' or [{3}] like '%{5}%'",
                                            x["TABLE_CATALOG"],
                                            x["TABLE_SCHEMA"],
                                            x["TABLE_NAME"],
                                            x["COLUMN_NAME"],
                                            SitkaWebConfiguration.ApplicationDomain,
                                            ControllerPartOfUri))
                                .ToList();
                    }
                }
            }

            var dataFromRowsAndColumnsWithUrls = sqlQueriesToGatherDataWithUrls.AsParallel().SelectMany(query =>
            {
                List<ResultRow> thisColumnData;
                using (var command = new SqlCommand(query))
                {
                    var sqlConnection = _db.CreateConnection();
                    using (var conn = sqlConnection)
                    {
                        command.Connection = conn;
                        using (var dt = ProjectFirmaSqlDatabase.ExecuteSqlCommand(command).Tables[0])
                        {
                            thisColumnData =
                                dt.Rows.Cast<DataRow>()
                                    .Select(x => new ResultRow((string) x["TableCatalog"], (string) x["TableSchema"], (string) x["TableName"], (string) x["ColumnName"], (string) x["ColumnValue"]))
                                    .ToList();
                        }
                    }
                }
                return thisColumnData;
            }).ToList();
            AssertThatAllReferencedFileResourceGuidsExist(dataFromRowsAndColumnsWithUrls);
            AssertThatAllUrlsAreServerRootRelative(dataFromRowsAndColumnsWithUrls);
            AssertThatAllUrlsDoNotContainAbsoluteUrlsToProdOrQa(dataFromRowsAndColumnsWithUrls);
        }
    }
}
