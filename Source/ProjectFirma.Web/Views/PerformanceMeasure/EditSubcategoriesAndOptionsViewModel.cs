/*-----------------------------------------------------------------------
<copyright file="EditSubcategoriesAndOptionsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using Newtonsoft.Json.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditSubcategoriesAndOptionsViewModel
    {
        public List<PerformanceMeasureSubcategorySimple> PerformanceMeasureSubcategorySimples { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditSubcategoriesAndOptionsViewModel()
        {
        }

        public EditSubcategoriesAndOptionsViewModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureSubcategorySimples = performanceMeasure.PerformanceMeasureSubcategories.ToList().Select(x => new PerformanceMeasureSubcategorySimple(x)).ToList();
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            var performanceMeasureSubcategoriesFromDatabase = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategories.Local;
            var performanceMeasureSubcategoryOptionsFromDatabase = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategoryOptions.Local;

            var performanceMeasureSubcategoriesToUpdate = PerformanceMeasureSubcategorySimples.Select(x =>
            {
                var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(new ProjectFirmaModels.Models.PerformanceMeasure(String.Empty, default(int), default(int), false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID),
                    x.PerformanceMeasureSubcategoryDisplayName);
                performanceMeasureSubcategory.PerformanceMeasure = performanceMeasure;
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryID = x.PerformanceMeasureSubcategoryID;
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions =
                    x.PerformanceMeasureSubcategoryOptions.OrderBy(y => y.SortOrder).Select(
                        (y, index) =>
                            new PerformanceMeasureSubcategoryOption(
                                new PerformanceMeasureSubcategory(new ProjectFirmaModels.Models.PerformanceMeasure(String.Empty, default(int), default(int), false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID), String.Empty),
                                y.PerformanceMeasureSubcategoryOptionName,
                                false)
                            {
                                PerformanceMeasureSubcategory =
                                    performanceMeasure.PerformanceMeasureSubcategories.SingleOrDefault(z => z.PerformanceMeasureSubcategoryID == x.PerformanceMeasureSubcategoryID),
                                PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID,
                                SortOrder = index + 1,
                                ShowOnFactSheet = y.ShowOnFactSheet
                            }).ToList();
                var chartConfigurationJson = JObject.FromObject(PerformanceMeasureModelExtensions.GetDefaultPerformanceMeasureChartConfigurationJson(performanceMeasure)).ToString();
                performanceMeasureSubcategory.ChartConfigurationJson = chartConfigurationJson;
                performanceMeasureSubcategory.GoogleChartTypeID = GoogleChartType.ColumnChart.GoogleChartTypeID;
                return performanceMeasureSubcategory;
            }).ToList();

            var performanceMeasureSubcategoryOptionsToUpdate = performanceMeasureSubcategoriesToUpdate.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList();
            performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList().Merge(
                performanceMeasureSubcategoryOptionsToUpdate,
                performanceMeasureSubcategoryOptionsFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryOptionID == y.PerformanceMeasureSubcategoryOptionID,
                (x, y) =>
                {
                    x.PerformanceMeasureSubcategoryOptionName = y.PerformanceMeasureSubcategoryOptionName;
                    x.SortOrder = y.SortOrder;
                    x.ShowOnFactSheet = y.ShowOnFactSheet;
                }, HttpRequestStorage.DatabaseEntities);

            performanceMeasure.PerformanceMeasureSubcategories.Merge(performanceMeasureSubcategoriesToUpdate,
                performanceMeasureSubcategoriesFromDatabase,
                (x, y) => x.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategoryID,
                (x, y) =>
                {
                    x.PerformanceMeasureSubcategoryDisplayName = y.PerformanceMeasureSubcategoryDisplayName;
                }, HttpRequestStorage.DatabaseEntities);
        }
    }
}
