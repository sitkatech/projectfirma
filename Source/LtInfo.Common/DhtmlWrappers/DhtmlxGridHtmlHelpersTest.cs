/*-----------------------------------------------------------------------
<copyright file="DhtmlxGridHtmlHelpersTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using NUnit.Framework;

namespace LtInfo.Common.DhtmlWrappers
{
    [TestFixture]
    public class DhtmlxGridHtmlHelpersTest
    {
        protected const string TestControllerName = "TestController";

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void BuildGridColumnsTest()
        {
            const string indent = "";
            var gridSpec = new TestGridSpec();
            var result = DhtmlxGridHtmlHelpers.BuildGridColumns(gridSpec, indent);
            Approvals.Verify(result);
        }

        [Test]
        public void IsUsingSmartRenderingWithColumnsThatHaveTotalsTest()
        {
            var gridSpec = new TestGridSpec();
            Assert.That(DhtmlxGridHtmlHelpers.IsUsingSmartRendering(gridSpec), Is.False, "Should not be using smart rendering because we have a grid spec that has a total column");
        }

        [Test]
        public void IsUsingSmartRenderingWithColumnsThatHaveNoTotalsTest()
        {
            var gridSpec = new TestGridSpecWithNoTotalColumns();
            Assert.That(DhtmlxGridHtmlHelpers.IsUsingSmartRendering(gridSpec), Is.True, "Should be using smart rendering because we have a grid spec that has a total column");
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void VerifyJavascriptForDhtmlxGrid()
        {
            var gridSpec = new TestGridSpec();
            const string gridName = "testGridName";


            var testGridSpecClasses = new List<TestGridSpecClass>();
            testGridSpecClasses.Add(new TestGridSpecClass(1, "One", true, 1000m));
            testGridSpecClasses.Add(new TestGridSpecClass(2, "Two", true, 2000m));
            testGridSpecClasses.Add(new TestGridSpecClass(3, "Three", false, 3000m));
            testGridSpecClasses.Add(new TestGridSpecClass(4, "Four", true, 4000m));
            testGridSpecClasses.Add(new TestGridSpecClass(5, "Five", false, 5000m));
            testGridSpecClasses.Add(new TestGridSpecClass(6, "Six", true, 6000m));

            var result = DhtmlxGridHtmlHelpers.DhtmlxGrid(gridSpec,
                                                          gridName,
                                                          string.Format("{0}/ListGridDataXml", TestControllerName),
                                                          "height:250px;");
            Approvals.Verify(result);
        }

        private class TestGridSpecClass
        {
            public readonly int PrimaryKey;
            public readonly string DisplayName;
            public readonly bool IsActive;
            public readonly decimal? Amount;

            public TestGridSpecClass(int primaryKey, string displayName, bool isActive, decimal? amount)
            {
                PrimaryKey = primaryKey;
                DisplayName = displayName;
                IsActive = isActive;
                Amount = amount;
            }
        }

        private class TestGridSpec : GridSpec<TestGridSpecClass>
        {
            public TestGridSpec()
            {
                ObjectNameSingular = "SOY";
                ObjectNamePlural = "SOYs";
                GridInstructionsWhenEmpty = "I am empty";

                // Edit SOY
                Add(string.Empty,
                    m =>
                    {
                        // Edit button
                        // -----------
                        var contentUrl = string.Format("{0}/EditAction/{1}", TestControllerName, m.PrimaryKey);
                        var dialogTitle = string.Format("Edit this {0}", m.DisplayName);
                        var dialogForm = new ModalDialogForm(contentUrl, 350, dialogTitle);
                        return DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(dialogForm);

                    },
                    35);

                // Delete SOY
                Add(string.Empty,
                    m =>
                    {
                        var contentUrl = string.Format("{0}/DeleteAction/{1}", TestControllerName, m.PrimaryKey);
                        var deleteLink = DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(contentUrl, true);
                        return deleteLink;
                    },
                    35);

                Add("Display Name", m => m.DisplayName, 200);
                Add("Is Active", m => m.IsActive.ToYesNo(), 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
                Add("Amount", m => m.Amount, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
        }

        private class TestGridSpecWithNoTotalColumns : GridSpec<TestGridSpecClass>
        {
            public TestGridSpecWithNoTotalColumns()
            {
                ObjectNameSingular = "SOY";
                ObjectNamePlural = "SOYs";
                GridInstructionsWhenEmpty = "I am empty";

                // Edit SOY
                Add(string.Empty,
                    m =>
                    {
                        // Edit button
                        // -----------
                        var contentUrl = string.Format("{0}/EditAction/{1}", TestControllerName, m.PrimaryKey);
                        var dialogTitle = string.Format("Edit this {0}", m.DisplayName);
                        var dialogForm = new ModalDialogForm(contentUrl, 350, dialogTitle);
                        return DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(dialogForm);

                    },
                    35);

                // Delete SOY
                Add(string.Empty,
                    m =>
                    {
                        var contentUrl = string.Format("{0}/DeleteAction/{1}", TestControllerName, m.PrimaryKey);
                        var deleteLink = DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(contentUrl, true);
                        return deleteLink;
                    },
                    35);

                Add("Display Name", m => m.DisplayName, 200);
                Add("Is Active", m => m.IsActive.ToYesNo(), 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
                Add("Amount", m => m.Amount, 100, DhtmlxGridColumnFormatType.Currency);
            }
        }
    }
}
