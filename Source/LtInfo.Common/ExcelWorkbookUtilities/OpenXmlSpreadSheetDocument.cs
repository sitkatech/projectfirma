/*-----------------------------------------------------------------------
<copyright file="ExcelColumnSpec.cs" company="Sitka Technology Group">
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
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using LtInfo.Common.AgGridWrappers;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    public class OpenXmlSpreadSheetDocument
    {
        /// <summary> 
        /// Default spread sheet name. 
        /// </summary> 
        private const string DefaultSheetName = "Sheet1";

        public static DataTable ExcelWorksheetToDataTable(string fileName, string sheetName, bool useExistingSheetNameIfSingleSheetFound)
        {
            return ExcelWorksheetToDataTable(AbstractReader.StreamFromFile(fileName), sheetName, useExistingSheetNameIfSingleSheetFound);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="sheetName"></param>
        /// <param name="useExistingSheetNameIfSingleSheetFound">If there is only a single sheet in the document, and this is set true, the reader will use that sheet, regardless of what it is named. If there is more than one sheet in the document, then sheetName must be found, no matter what useExistingSheetNameIfSingleSheetFound is set to.</param>
        /// <returns></returns>
        public static DataTable ExcelWorksheetToDataTable(Stream stream, string sheetName, bool useExistingSheetNameIfSingleSheetFound)
        {
            using (var spreadsheetDocument = SpreadsheetDocument.Open(stream, false))
            {
                return GetWorkSheetAsDataTable(spreadsheetDocument, sheetName, useExistingSheetNameIfSingleSheetFound);
            }
        }

        public static WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, string worksheetName)
        {
            IEnumerable<Sheet> source = document.WorkbookPart.Workbook.Descendants<Sheet>().Where<Sheet>((Func<Sheet, bool>)(s => (string)s.Name == worksheetName));
            if (source.Count<Sheet>() == 0)
            {
                return (WorksheetPart)null;
            }
            return (WorksheetPart)document.WorkbookPart.GetPartById((string)source.First<Sheet>().Id);
        }

        private static DataTable GetWorkSheetAsDataTable(SpreadsheetDocument spreadsheetDocument, string sheetName, bool useExistingSheetNameIfSingleSheetFound)
        {
            // Get the Sheets and Sheet Names in this file
            var allWorksheets = spreadsheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().ToList();
            var allWorksheetNames = allWorksheets.Select(ws => ws.Name.ToString()).ToList();

            // If we find just one sheet, and we've been told to be tolerant, use that sheet, no matter what it is named
            if (allWorksheetNames.Count == 1 && useExistingSheetNameIfSingleSheetFound)
            {
                sheetName = allWorksheetNames.Single();
            }

            // If we can't find the WorkSheet name we expect, throw a helpful user-readable error that explains the problem.
            if (!allWorksheetNames.Contains(sheetName))
            {
                var worksheetsWrappedInQuotes = allWorksheetNames.Select(ws => string.Format("\"{0}\"", ws));
                string existingSheetsString = String.Join(", ", worksheetsWrappedInQuotes);
                string errorMessage = string.Format("Could not find Worksheet named \"{0}\". Worksheets found: {1}. When uploading a spreadsheet with more than one WorkSheet, the WorkSheet with the data to upload must be named \"{0}\". Please rename the Worksheet with the data you want to upload to \"{0}\" and try again.", sheetName, existingSheetsString);
                throw new SitkaDisplayErrorException(errorMessage);
            }

            var worksheetPart = GetWorksheetPartByName(spreadsheetDocument, sheetName);
            var sheet = worksheetPart.Worksheet;
            var sheetRows = sheet.Descendants<Row>().Where(row => row.RowIndex > 0).ToList();

            var dt = new DataTable(sheetName);
            if (sheetRows.Any())
            {
                // header row
                foreach (var cell in sheetRows[0].Descendants<Cell>())
                {
                    dt.Columns.Add(new DataColumn(GetColumnName(cell.CellReference), typeof(string)));
                }
                // non-header rows
                for (var i = 0; i < sheetRows.Count(); i++)
                {
                    var row = sheetRows[i];
                    var dr = dt.NewRow();
                    foreach (var cell in row.Descendants<Cell>())
                    {
                        var columnName = GetColumnName(cell.CellReference);
                        // First row of spreadsheet defines the columns of the data table. So we deliberately ignore things that fall outside these columns here.
                        if (dt.Columns.Contains(columnName))
                        {
                            dr[columnName] = GetCellValue(spreadsheetDocument, cell);
                        }
                    }

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            var stringTablePart = document.WorkbookPart.SharedStringTablePart;
            var value = cell.CellValue != null ? cell.CellValue.InnerXml : String.Empty;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            return value;
        }

        private static string GetColumnName(string cellReference)
        {
            var regex = new Regex("[A-Za-z]+");
            var match = regex.Match(cellReference);
            return match.Value;
        }

        public static MemoryStream ObjectListToExcelWorksheet<T>(List<T> modelList, GridSpec<T> spec, string sheetName)
        {
            var xmlStream = SpreadsheetReader.Create();
            using (var spreadsheetDocument = SpreadsheetDocument.Open(xmlStream, true))
            {
                SetSheetName(sheetName, spreadsheetDocument);

                var worksheetPart = GetWorksheetPartByName(spreadsheetDocument, sheetName);
                var modelObjects = modelList.Select(c => c);

                uint rowIndex = 1;

                var sharedStringDictionary = new SharedStringTableDictionary();

                AddExcelRow(spec.ColumnNames, worksheetPart, sharedStringDictionary, rowIndex);
                foreach (var modelObject in modelObjects)
                {
                    rowIndex++;
                    ToExcelRow(modelObject, spec, worksheetPart, sharedStringDictionary, rowIndex);
                }

                // Update the real string table with values
                var sharedStringTablePart = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                sharedStringDictionary.AppendToSharedStringTable(sharedStringTablePart);
                sharedStringTablePart.SharedStringTable.Save();

                // Save to the memory stream 
                Save(spreadsheetDocument);
                spreadsheetDocument.Dispose();
            }
            return xmlStream;
        }

        public static void SetRowSpans(WorksheetPart worksheetPart)
        {
            foreach (Row element in worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>())
            {
                if (element.Elements<Cell>().Count<Cell>() > 0)
                {
                    Cell cell1 = element.Elements<Cell>().First<Cell>();
                    Cell cell2 = element.Elements<Cell>().Last<Cell>();
                    string column1 = SpreadsheetReader.ColumnFromReference((string)cell1.CellReference);
                    string column2 = SpreadsheetReader.ColumnFromReference((string)cell2.CellReference);
                    int columnIndex1 = SpreadsheetReader.GetColumnIndex(column1);
                    int columnIndex2 = SpreadsheetReader.GetColumnIndex(column2);
                    element.Spans = new ListValue<StringValue>()
                    {
                        Items = {
                            new StringValue(string.Format("{0}:{1}", (object) columnIndex1, (object) columnIndex2))
                        }
                    };
                }
            }
        }

        public static SheetDimension SetWorksheetDimension(WorksheetPart worksheetPart)
        {
            IEnumerable<Row> source = worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>();
            string strB1 = string.Empty;
            string strB2 = string.Empty;
            foreach (Row row in source)
            {
                Cell cell1 = row.Elements<Cell>().First<Cell>();
                Cell cell2 = row.Elements<Cell>().Last<Cell>();
                string strA1 = SpreadsheetReader.ColumnFromReference((string)cell1.CellReference);
                string strA2 = SpreadsheetReader.ColumnFromReference((string)cell2.CellReference);
                if (strB1 == string.Empty || string.Compare(strA1, strB1, true) < 0)
                {
                    strB1 = strA1;
                }
                if (strB2 == string.Empty || string.Compare(strA2, strB2, true) > 0)
                {
                    strB2 = strA2;
                }
            }
            SheetDimension firstChild = worksheetPart.Worksheet.GetFirstChild<SheetDimension>();
            if (source.Count<Row>() == 0)
            {
                firstChild.Reference = new StringValue("A1");
            }
            else
            {
                Row row1 = source.First<Row>();
                Row row2 = source.Last<Row>();
                if (object.ReferenceEquals((object)row1, (object)row2) && strB1 == strB2)
                {
                    firstChild.Reference = new StringValue(string.Format("{0}{1}", (object)strB1, (object)row1.RowIndex));
                }
                else
                {
                    firstChild.Reference = new StringValue(string.Format("{0}{1}:{2}{3}", (object)strB1, (object)row1.RowIndex, (object)strB2, (object)row2.RowIndex));
                }
            }
            return firstChild;
        }

        public static WorkbookStylesPart GetWorkbookStyles(SpreadsheetDocument spreadsheet)
        {
            return spreadsheet.WorkbookPart.GetPartsOfType<WorkbookStylesPart>().First<WorkbookStylesPart>();
        }

        public static void Save(SpreadsheetDocument spreadsheet)
        {
            foreach (WorksheetPart worksheetPart in spreadsheet.WorkbookPart.WorksheetParts)
            {
                SetRowSpans(worksheetPart);
                SetWorksheetDimension(worksheetPart);
                worksheetPart.Worksheet.Save();
            }
            GetWorkbookStyles(spreadsheet).Stylesheet.Save();
            if (spreadsheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count<SharedStringTablePart>() > 0)
            {
                spreadsheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First<SharedStringTablePart>().SharedStringTable.Save();
            }
            spreadsheet.WorkbookPart.Workbook.Save();
        }


        private static void ToExcelRow<T>(T thingToRead, IEnumerable<ColumnSpec<T>> gridSpec, WorksheetPart worksheetPart, SharedStringTableDictionary sharedStringTablePart, uint rowIndex)
        {
            var propertyValues = gridSpec.Select((columnSpec, index) => new { CellValue = columnSpec.CalculateStringValue(thingToRead), ColumnIndex = index }).ToList();
            propertyValues.ForEach(p => AddCell(worksheetPart, sharedStringTablePart, p.CellValue, p.ColumnIndex, rowIndex));
        }

        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            var worksheet = worksheetPart.Worksheet;
            var sheetData = worksheet.GetFirstChild<SheetData>();
            var cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Count(r => r.RowIndex == rowIndex) != 0)
            {
                row = sheetData.Elements<Row>().First(r => r.RowIndex == rowIndex);
            }
            else
            {
                row = new Row { RowIndex = rowIndex };
                sheetData.AppendChild(row);
            }

            // If there is not a cell with the specified column name, insert one.
            if (row.Elements<Cell>().Any(c => c.CellReference.Value == columnName + rowIndex))
            {
                return row.Elements<Cell>().First(c => c.CellReference.Value == cellReference);
            }
            var newCell = new Cell { CellReference = cellReference };
            row.InsertBefore(newCell, null);
            return newCell;
        }

        private static void AddExcelRow(IEnumerable<string> values, WorksheetPart worksheetPart, SharedStringTableDictionary sharedStringTablePart, uint rowIndex)
        {
            var headers = values.ToArray();
            for (var i = 0; i < headers.Count(); i++)
            {
                AddCell(worksheetPart, sharedStringTablePart, headers[i], i, rowIndex);
            }
        }

        private static void AddCell(WorksheetPart worksheetPart, SharedStringTableDictionary sharedStringTablePart, string cellValue, int columnIndex, uint rowIndex)
        {
            var index = sharedStringTablePart.AddOrLookupSharedString(cellValue);
            var cell = InsertCellInWorksheet(GetCellReference(columnIndex), rowIndex, worksheetPart);
            cell.CellValue = new CellValue(index.ToString(CultureInfo.InvariantCulture));
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }

        private static string GetCellReference(int columnIndex)
        {
            if (columnIndex >= 26)
            {
                return String.Format("A{0}", Convert.ToString(Convert.ToChar(65 + columnIndex - 26)));
            }
            return Convert.ToString(Convert.ToChar(65 + columnIndex));
        }

        /// <summary> 
        /// Set the name of the spreadsheet. 
        /// </summary> 
        /// <param name="excelSpreadSheetName">Spread sheet name.</param> 
        /// <param name="spreadSheet">Spread sheet.</param> 
        private static void SetSheetName(string excelSpreadSheetName,
                                         SpreadsheetDocument spreadSheet)
        {
            excelSpreadSheetName = excelSpreadSheetName ?? DefaultSheetName;
            var ss = spreadSheet.WorkbookPart.Workbook.Descendants<Sheet>().Single(s => s.Name == DefaultSheetName);
            ss.Name = excelSpreadSheetName;
        }

        /// <summary>
        /// Lookup in the *real* string table can be slow, this class serves as a bridge to allow fast string lookup
        /// </summary>
        private class SharedStringTableDictionary
        {
            private const int EmptyAndNullIndex = 0;
            private readonly Dictionary<string, int> _dict = new Dictionary<string, int>(StringComparer.InvariantCulture) { { String.Empty, EmptyAndNullIndex } };
            private int _nextAvailableIndex = EmptyAndNullIndex + 1;

            public int AddOrLookupSharedString(string sharedString)
            {
                if (String.IsNullOrEmpty(sharedString))
                {
                    return EmptyAndNullIndex;
                }

                if (!_dict.ContainsKey(sharedString))
                {
                    _dict[sharedString] = _nextAvailableIndex;
                    ++_nextAvailableIndex;
                }
                return _dict[sharedString];
            }

            public void AppendToSharedStringTable(SharedStringTablePart sharedStringTablePart)
            {
                _dict.OrderBy(x => x.Value).Select(x => x.Key).ToList().ForEach(x => sharedStringTablePart.SharedStringTable.AppendChild(new SharedStringItem(new Text(x))));
            }
        }
    }
}
