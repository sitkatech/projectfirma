/*-----------------------------------------------------------------------
<copyright file="ExcelWorkbookSheetDescriptorFactory.cs" company="Sitka Technology Group">
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
using ClosedXML.Excel;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    public static class ExcelWorkbookSheetDescriptorFactory
    {
        private const int MaximumWorksheetNameLength = 31;

        public static ExcelWorkbookSheetDescriptor<T> MakeWorksheet<T>(string worksheetName, ExcelWorksheetSpec<T> spec, IList<T> dataObjectListForWorksheet)
        {
            return new ExcelWorkbookSheetDescriptor<T>(worksheetName, spec, dataObjectListForWorksheet);
        }

        public static string TruncateWorksheetName(string worksheetName)
        {
            // Worksheet names cannot be more than 31 characters
            if (worksheetName.Length > MaximumWorksheetNameLength)
            {
                worksheetName = worksheetName.Substring(0, MaximumWorksheetNameLength);
            }
            return worksheetName;
        }
    }
    public class ExcelWorkbookSheetDescriptor<T> : IExcelWorkbookSheetDescriptor
    {
        private readonly IList<T> _dataObjectListForWorksheet;
        private readonly string _worksheetName;
        private readonly ExcelWorksheetSpec<T> _spec;

        public string WorksheetName => _worksheetName;


        public ExcelWorkbookSheetDescriptor(string worksheetName, ExcelWorksheetSpec<T> spec, IList<T> dataObjectListForWorksheet)
        {
            _dataObjectListForWorksheet = dataObjectListForWorksheet;
            _worksheetName = ExcelWorkbookSheetDescriptorFactory.TruncateWorksheetName(worksheetName);
            _spec = spec;
        }

        public void AddWorksheetToWorkbook(XLWorkbook wb)
        {
            var ws = wb.Worksheets.Add(_worksheetName);

            var col = 1;
            var row = 1;

            foreach (var column in _spec.Columnns)
            {
                var titleCell = ws.Cell(row, col);
                titleCell.SetValue(column.ColumnName);
                titleCell.SetDataType(XLDataType.Text);
                titleCell.Style.Font.SetBold();
                col++;
            }

            row = 2;
            foreach (var dataObject in _dataObjectListForWorksheet)
            {
                col = 1;
                foreach (var column in _spec.Columnns)
                {
                    var cell = ws.Cell(row, col);
                    column.SetValue(cell, dataObject);
                    col++;
                }
                row++;
            }
            ws.Columns().AdjustToContents();
        }

        //        public void AddWorksheetToWorkbook(XLWorkbook wb)
        //{
        //    var ws = wb.Worksheets.Add(_worksheetName);

        //    var col = 1;
        //    var row = 1;

        //    var propNames = ToCsvExtensionMethods.PropertyNames(_dataObjectListForWorksheet);
        //    var propNameToFormatter = ToCsvExtensionMethods.OrderedPropertiesForType<T>()
        //                                                   .ToDictionary(pi => pi.Name, FormatterFor);
        //    foreach (var prop in propNames)
        //    {
        //        var titleCell = ws.Cell(row, col);
        //        titleCell.SetValue(prop);
        //        titleCell.SetDataType(XLCellValues.Text);
        //        titleCell.Style.Font.SetBold();
        //        col++;
        //    }

        //    row = 2;
        //    var theType = typeof(T);
        //    foreach (var datum in _dataObjectListForWorksheet)
        //    {
        //        col = 1;
        //        foreach (var propName in propNames)
        //        {
        //            var pi = theType.GetProperty(propName);
        //            Check.RequireNotNull(pi,
        //                                 String.Format("Could not find property \"{0}\" on object of type \"{1}\"", propName,
        //                                               theType));
        //            var theVal = pi.GetValue(datum, null);
        //            var cell = ws.Cell(row, col);
        //            cell.SetValue(theVal ?? string.Empty);
        //            propNameToFormatter[propName].ApplyFormatting(cell);
        //            col++;
        //        }
        //        row++;
        //    }
        //    ws.Columns().AdjustToContents();
        //}
        //private static IXLCellFormatter FormatterFor(PropertyInfo pi)
        //{
        //    var attrs = pi.GetCustomAttributes(true);
        //    var theMark = attrs.FirstOrDefault(o => o is ExcelTypeAttribute);
        //    return theMark == null ? new DefaultXlCellFormatter() : ((IXLCellFormatter)theMark);
        //}
    }

}
