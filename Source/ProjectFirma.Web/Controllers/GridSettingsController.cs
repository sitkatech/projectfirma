/*-----------------------------------------------------------------------
<copyright file="GridSettingsController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Helpers;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office.Word;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class GridColumn
    {
        public GridColumn()
        {
        }

        public GridColumn(PersonSettingGridColumnSetting columnSetting)
        {
            ColumnName = columnSetting.PersonSettingGridColumn.ColumnName;
            FilterTextArray = columnSetting.PersonSettingGridColumnSettingFilters.Select(f => f.FilterText).ToArray();
        }

        public string ColumnName { get; set; }
        public string[] FilterTextArray { get; set; }
        public int? Width { get; set; }


        public bool? IsSorted { get; set; }
        public string SortType { get; set; }

    }
    /// <summary>
    ///     A json class used to communicate PersonSettingGridColumnSettings to sitka.grid.js.  Any renames of properties should also be done to GridTable.js
    /// </summary>
    public class GridTable
    {
        public GridTable()
        {
            Columns = new List<GridColumn>();
        }

        public GridTable(string gridName, IEnumerable<PersonSettingGridColumnSetting> columnSettings)
        {
            GridName = gridName;
            Columns = columnSettings.Select(c => new GridColumn(c)).ToList();

        }

        public string GridName { get; set; }
        public List<GridColumn> Columns { get; set; }
        public double? WidthX { get; set; }
        public double? HeightY { get; set; }
    }

    public class GridSettingsViewModel : FormViewModel, IValidatableObject
    {
        public GridTable GridTable { get; set; }

        /// <summary>
        /// This is a static dictionary of objects for serializing requests to <see cref="SaveGridColumnSettings"/>
        /// Theoretically we could lock at a lower level per PersonSetting per Grid, but PersonSetting is easier
        /// </summary>
        private static readonly Dictionary<int, object> SaveGridColumnSettingsLockDict = new Dictionary<int, object>();

        public GridSettingsViewModel()
        {

        }

        public GridSettingsViewModel(GridTable gridTable)
        {
            GridTable = gridTable;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        public void Save(FirmaSession currentFirmaSession)
        {
            if (currentFirmaSession.IsAnonymousOrUnassigned())
            {
                // todo: return something else?
                return;
            }

            int personID = currentFirmaSession.Person.PersonID;

            object saveGridColumnSettingsLock;

            // Quick global lock - Only access/update the dict serially
            lock (SaveGridColumnSettingsLockDict)
            {
                if (!SaveGridColumnSettingsLockDict.ContainsKey(personID))
                {
                    // Just a blank little lockable object, indexed by PersonSettingID
                    SaveGridColumnSettingsLockDict[personID] = new object();
                }
                saveGridColumnSettingsLock = SaveGridColumnSettingsLockDict[personID];
            }

            // Local lock for this Person updating a grid
            // Attempting to cut down on contention problems with simultaneous requests -- SLG
            lock (saveGridColumnSettingsLock)
            {

                if (!currentFirmaSession.IsAnonymousOrUnassigned())
                {
                    // This is the main function that can lead to exceptions from contention if simultaneous updates come through
                    currentFirmaSession.Person.UpdatePersonSettingGridColumns(GridTable);
                }
                
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges();
        }

    }

    public class GridSettingsController : FirmaBaseController
    {
        [HttpPost]
        [AnonymousUnclassifiedFeature]
        public JsonResult SaveGridSettings()
        {
            var gridTable = JsonTools.DeserializeObject<GridTable>(Request.Form["Data"]);
            var gridSettingsViewModel = new GridSettingsViewModel(gridTable);
            gridSettingsViewModel.Save(CurrentFirmaSession);
            return new JsonResult();
        }
    }
}