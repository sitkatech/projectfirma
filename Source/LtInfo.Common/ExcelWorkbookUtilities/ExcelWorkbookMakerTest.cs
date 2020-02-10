/*-----------------------------------------------------------------------
<copyright file="ExcelWorkbookMakerTest.cs" company="Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using NUnit.Framework;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    [TestFixture]
    public class ExcelWorkbookMakerTest
    {
        [Test]
        public void CanMakeMultipleSheetWorkbook()
        {
            var objectList1 = new List<TestObject1>
                {
                    new TestObject1("Test1-1", 1),
                    new TestObject1("Test1-2", 2)
                };

            var objectList2 = new List<TestObject2>
                {
                    new TestObject2("Test2-1", 1),
                    new TestObject2("Test2-2", 2)
                };

            var sheet1Spec = new ExcelWorksheetSpec<TestObject1>();
            sheet1Spec.AddColumn("Object Name", x => x.ObjectName);
            sheet1Spec.AddColumn("Object Int", x => x.ObjectInt);
            sheet1Spec.AddColumn("Object Date", x => x.ObjectDate);
            sheet1Spec.AddColumn("Object Decimal", x => x.ObjectDecimal);
            sheet1Spec.AddColumn("Object Bool", x => x.ObjectBool);
            var sheetDescription1 = new ExcelWorkbookSheetDescriptor<TestObject1>("SheetName1", sheet1Spec, objectList1);

            var sheet2Spec = new ExcelWorksheetSpec<TestObject2>();
            sheet2Spec.AddColumn("Object Name", x => x.ObjectName);
            sheet2Spec.AddColumn("Object Int", x => x.ObjectInt);
            var sheetDescription2 = new ExcelWorkbookSheetDescriptor<TestObject2>("SheetName2", sheet2Spec, objectList2);

            var sheets = new List<IExcelWorkbookSheetDescriptor> {sheetDescription1, sheetDescription2};
            var excelWorkbook = new ExcelWorkbookMaker(sheets);

            var wb = excelWorkbook.ToXLWorkbook();

            Assert.That(wb.Worksheets.Count, Is.EqualTo(sheets.Count));
            Assert.That(wb.Worksheets.Select(x => x.Name).ToList(), Is.EquivalentTo(sheets.Select(x => x.WorksheetName).ToList()));

            var xlWorksheets = wb.Worksheets.Select(x => x).ToList();
            var workSheet1 = xlWorksheets[0];

            var firstDataRow = workSheet1.Row(2);

            Assert.That(firstDataRow.Cells().Select(x => x.DataType).ToList(),
                        Is.EquivalentTo(
                            new[]
                                {
                                    XLDataType.Text, XLDataType.Number, XLDataType.DateTime, XLDataType.Number,
                                    XLDataType.Boolean
                                }.ToList()), "Data types should match up");

        }

        internal class TestObject1
        {
            public readonly int ObjectInt;
            public readonly string ObjectName;
            public readonly DateTime ObjectDate;
            public readonly Decimal ObjectDecimal;
            public readonly bool ObjectBool;

            public TestObject1(string objectName, int objectInt)
            {
                ObjectName = objectName;
                ObjectInt = objectInt;
                ObjectDate = DateTime.Now;
                ObjectDecimal = ObjectInt/.33333m;
                ObjectBool = true;
            }
        }

        internal class TestObject2
        {
            public readonly string ObjectName;
            public readonly int ObjectInt;

            public TestObject2(string objectName, int objectInt)
            {
                ObjectName = objectName;
                ObjectInt = objectInt;
            }
        }
    }
}
