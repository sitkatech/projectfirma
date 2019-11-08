/*-----------------------------------------------------------------------
<copyright file="FileResource.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FileResourceModelExtensions
    {
        public static int MaxUploadFileSizeInBytes = FirmaWebConfiguration.MaximumAllowedUploadFileSize;

        public static readonly UrlTemplate<string> FileResourceByGuidUrlTemplate =
            new UrlTemplate<string>(SitkaRoute<FileResourceController>.BuildUrlFromExpression(t => t.DisplayResource(UrlTemplate.Parameter1String)));

        public static string GetFileResourceUrl(this FileResource fileResource)
        {
            return FileResourceByGuidUrlTemplate.ParameterReplace(fileResource.GetFileResourceGUIDAsString());
        }

        public static string FileResourceUrlScaledThumbnail(this FileResource fileResource, int maxHeight)
        {
            return SitkaRoute<FileResourceController>.BuildUrlFromExpression(x => x.GetFileResourceResized(fileResource.GetFileResourceGUIDAsString(), maxHeight, maxHeight));
        }

        public static string GetFileResourceUrlScaledForPrint(this FileResource fileResource)
        {
            return SitkaRoute<FileResourceController>.BuildUrlFromExpression(x =>
                x.GetFileResourceResized(fileResource.GetFileResourceGUIDAsString(), 500, 500));
        }

        public static string GetFileResourceDataLengthString(this FileResource fileResource)
        {
            return $"(~{(fileResource.FileResourceData.Length / 1000).ToGroupedNumeric()} KB)";
        }

        public static string MaxFileSizeHumanReadable
        {
            get { return $"{MaxUploadFileSizeInBytes / (1024 ^ 2):0.0} KB"; }
        }

        /// <summary>
        /// Prepare the file bytes for going into the database
        /// </summary>
        /// <param name="httpPostedFileBase"></param>
        /// <returns></returns>
        private static byte[] ConvertHttpPostedFileToByteArray(HttpPostedFileBase httpPostedFileBase)
        {
            byte[] fileResourceData;
            using (var binaryReader = new BinaryReader(httpPostedFileBase.InputStream))
            {
                fileResourceData = binaryReader.ReadBytes(httpPostedFileBase.ContentLength);
                binaryReader.Close();
            }
            return fileResourceData;
        }

        public static FileResourceMimeType GetFileResourceMimeTypeForFile(HttpPostedFileBase file)
        {
            var fileResourceMimeTypeForFile = FileResourceMimeType.All.SingleOrDefault(mt => mt.FileResourceMimeTypeContentTypeName == file.ContentType);
            Check.RequireNotNull(fileResourceMimeTypeForFile, $"Unhandled MIME type: {file.ContentType}");
            return fileResourceMimeTypeForFile;
        }

        public static FileResource CreateNewFromHttpPostedFileAndSave(HttpPostedFileBase httpPostedFileBase, FirmaSession currentFirmaSession)
        {
            var fileResource = CreateNewFromHttpPostedFile(httpPostedFileBase, currentFirmaSession.Person);
            HttpRequestStorage.DatabaseEntities.AllFileResources.Add(fileResource);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return fileResource;
        }

        //Only public for unit testing
        public static FileResource CreateNewFromHttpPostedFile(HttpPostedFileBase httpPostedFileBase, Person currentPerson)
        {
            var originalFilenameInfo = new FileInfo(httpPostedFileBase.FileName);
            var baseFilenameWithoutExtension = originalFilenameInfo.Name.Remove(originalFilenameInfo.Name.Length - originalFilenameInfo.Extension.Length, originalFilenameInfo.Extension.Length);
            var fileResourceData = ConvertHttpPostedFileToByteArray(httpPostedFileBase);
            var fileResourceMimeTypeID = GetFileResourceMimeTypeForFile(httpPostedFileBase).FileResourceMimeTypeID;
            var fileResource = new FileResource(fileResourceMimeTypeID, baseFilenameWithoutExtension, originalFilenameInfo.Extension, Guid.NewGuid(), fileResourceData, currentPerson.PersonID, DateTime.Now);
            return fileResource;
        }

        public static void ValidateFileSize(HttpPostedFileBase httpPostedFileBase, List<ValidationResult> errors, string propertyName)
        {
            if (httpPostedFileBase.ContentLength > MaxUploadFileSizeInBytes)
            {
                var formattedUploadSize = $"~{(httpPostedFileBase.ContentLength / 1000).ToGroupedNumeric()} KB";
                errors.Add(new ValidationResult(
                    $"File is too large - must be less than {MaxFileSizeHumanReadable} [Provided file was {formattedUploadSize}]", new[] { propertyName }));
            }
        }

        public static readonly Regex FileResourceUrlRegEx =
            new Regex(@"FileResource\/DisplayResource\/(?<fileResourceGuidCapture>[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Based on a string that has embedded file resource URLs in it, parse out the URLs and look up the corresponding FileResource stuff
        /// Made public for testing purposes.
        /// </summary>
        public static List<Guid> FindAllFileResourceGuidsFromStringContainingFileResourceUrls(string textWithReferences)
        {
            if (String.IsNullOrWhiteSpace(textWithReferences))
            {
                return new List<Guid>();
            }
            var guidCaptures = FileResourceUrlRegEx.Matches(textWithReferences).Cast<Match>().Select(x => x.Groups["fileResourceGuidCapture"].Value).ToList();
            var theseGuids = guidCaptures.Select(x => new Guid(x)).Distinct().ToList();
            return theseGuids;
        }
    }
}
