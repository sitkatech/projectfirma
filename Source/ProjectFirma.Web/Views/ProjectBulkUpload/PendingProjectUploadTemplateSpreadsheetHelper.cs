using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectBulkUpload
{
    public class PendingProjectUploadTemplateSpreadsheetHelper
    {
        public static byte[] GetPrepopulatedTemplateSpreadsheet()
        {

            // Get location of template file to copy
            var templateFileName = string.Format(FirmaWebConfiguration.PendingProjectsUploadExcelTemplate, MultiTenantHelpers.GetTenantName());
            // Get unique name for temp file
            var tempFileName = Path.GetTempFileName();
            // Copy template spreadsheet to temp file for modification
            File.Copy(templateFileName, tempFileName, true);

            //  Open the temp file to modify it's contents
            using (FileStream fs = new FileStream(tempFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Open(fs, true))
                {
                    // Prep spreadsheet for row insertion
                    var workbookPart = spreadsheetDoc.WorkbookPart;
                    var sharedStringTablePart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();

                    //REFERENCE SHEETS

                    // Taxonomy Reference worksheet
                    var sheetName = string.Format(PendingProjectStageImportsHelper.SourcesSheetNameTemplate,
                        PendingProjectStageImportsHelper.TenantLabels[MultiTenantHelpers.GetTenantName()]["TaxonomyLeafDisplayNameForProject"]);
                    var taxonomyLeavesReferencesWorksheetPart = GetWorksheetPart(workbookPart, sheetName);
                    AppendRowsToTaxonomyLeavesReferenceWorksheet(taxonomyLeavesReferencesWorksheetPart.Worksheet, sharedStringTablePart);

                    // Organization Reference worksheet
                    var organizationsReferenceWorksheetPart = GetWorksheetPart(workbookPart, PendingProjectStageImportsHelper.OrganizationSourcesSheetName);
                    AppendRowsToOrganizationsReferenceWorksheet(organizationsReferenceWorksheetPart.Worksheet, sharedStringTablePart);

                    // Contacts Reference worksheet
                    sheetName = string.Format(PendingProjectStageImportsHelper.SourcesSheetNameTemplate,
                        PendingProjectStageImportsHelper.TenantLabels[MultiTenantHelpers.GetTenantName()]["ProjectPrimaryContact"]);
                    var primaryContactsReferencesWorksheetPart = GetWorksheetPart(workbookPart, sheetName);
                    AppendRowsToPrimaryContactsReferenceWorksheet(primaryContactsReferencesWorksheetPart.Worksheet, sharedStringTablePart);


                    // Close the document.  
                    spreadsheetDoc.Dispose();
                }
            }
            // Return the modified temp file
            var content = File.ReadAllBytes(tempFileName);
            return content;
        }

        private static void AppendRowsToTaxonomyLeavesReferenceWorksheet(Worksheet worksheet, SharedStringTablePart sharedStringTablePart)
        {
            var sheetData = worksheet.GetFirstChild<SheetData>();
            var activityTypes = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList().Select(x => x.GetDisplayName()).OrderBy(x => x).ToList();
            // Start writing on the second row
            var rowIndex = 2;
            // Insert rows
            foreach (var activityType in activityTypes)
            {
                HandleInsertingCell("A", rowIndex, activityType, sheetData, sharedStringTablePart);
                rowIndex += 1;
            }
            // Save the changes
            worksheet.Save();
        }

        private static void AppendRowsToOrganizationsReferenceWorksheet(Worksheet worksheet, SharedStringTablePart sharedStringTablePart)
        {
            var sheetData = worksheet.GetFirstChild<SheetData>();
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Where(x => !x.IsUnknown()).Select(x => x.OrganizationName).OrderBy(x => x);
            // Start writing on the second row
            var rowIndex = 2;
            // Insert rows
            foreach (var organization in organizations)
            {
                HandleInsertingCell("A", rowIndex, organization, sheetData, sharedStringTablePart);
                rowIndex += 1;
            }
            // Save the changes
            worksheet.Save();
        }

        private static void AppendRowsToPrimaryContactsReferenceWorksheet(Worksheet worksheet, SharedStringTablePart sharedStringTablePart)
        {
            var sheetData = worksheet.GetFirstChild<SheetData>();
            var people = HttpRequestStorage.DatabaseEntities.People.Where(x => x.IsActive && x.RoleID != ProjectFirmaModels.Models.Role.Unassigned.RoleID).ToList().Select(x => x.GetFullNameFirstLastAndOrg()).OrderBy(x => x).Distinct();
            // Start writing on the second row
            var rowIndex = 2;
            // Insert rows
            foreach (var person in people)
            {
                HandleInsertingCell("A", rowIndex, person, sheetData, sharedStringTablePart);
                rowIndex += 1;
            }
            // Save the changes
            worksheet.Save();
        }

        private static WorksheetPart GetWorksheetPart(WorkbookPart workbookPart, string sheetName)
        {
            string relId = workbookPart.Workbook.Descendants<Sheet>().First(x => x.Name == sheetName).Id;
            workbookPart.Workbook.Save();
            return (WorksheetPart)workbookPart.GetPartById(relId);
        }

        public static void HandleInsertingCell(string columnName, int rowIndex, string text, SheetData sheetData, SharedStringTablePart sharedStringTablePart)
        {
            // Insert the text into the SharedStringTablePart.
            int sharedStringIndex = InsertSharedStringItem(text, sharedStringTablePart);


            // Insert cell A1 into the new worksheet.
            Cell newCell = InsertCellInWorksheet(columnName, (uint)rowIndex, sheetData);
            newCell.CellValue = new CellValue(sharedStringIndex.ToString());
            newCell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }

        // Given a column name, a row index, and a WorksheetPart, inserts a cell into the worksheet. 
        // If the cell already exists, returns it. 
        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, SheetData sheetData)
        {
            string cellReference = columnName + rowIndex;

            // TODO: (?)  All this checking for then creating seems excessive but my early attempts to eliminate it was causing problems
            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Any(r => r.RowIndex == rowIndex))
            {
                row = sheetData.Elements<Row>().First(r => r.RowIndex == rowIndex);
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
            Cell refCell = null;
            foreach (Cell cell in row.Elements<Cell>())
            {
                if (cell.CellReference.Value.Length == cellReference.Length)
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true, CultureInfo.InvariantCulture) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }
            }

            Cell newCell = new Cell() { CellReference = cellReference };
            row.InsertBefore(newCell, refCell);

            return newCell;

        }


        // Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text 
        // and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }
    }
}