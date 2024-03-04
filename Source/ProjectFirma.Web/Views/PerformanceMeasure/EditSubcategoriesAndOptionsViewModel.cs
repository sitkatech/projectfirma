/*-----------------------------------------------------------------------
<copyright file="EditSubcategoriesAndOptionsViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

            List<PerformanceMeasureSubcategory> performanceMeasureSubcategoriesToUpdate;
            if (PerformanceMeasureSubcategorySimples == null)
            {
                // add the default subcategory/option
                var defaultSubcategory = new PerformanceMeasureSubcategory(performanceMeasure, "Default")
                    { GoogleChartTypeID = GoogleChartType.ColumnChart.GoogleChartTypeID };
                var defaultSubcategoryChartConfigurationJson =
                    performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson();
                defaultSubcategory.ChartConfigurationJson =
                    JObject.FromObject(defaultSubcategoryChartConfigurationJson).ToString();
                if (performanceMeasure.CanBeChartedCumulatively)
                {
                    var defaultPerformanceMeasureChartConfigurationJson =
                        performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson();
                    defaultSubcategory.CumulativeChartConfigurationJson =
                        JObject.FromObject(defaultPerformanceMeasureChartConfigurationJson).ToString();
                    defaultSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets()
                        ? GoogleChartType.ComboChart.GoogleChartTypeID
                        : GoogleChartType.ColumnChart.GoogleChartTypeID;
                }

                new PerformanceMeasureSubcategoryOption(defaultSubcategory, "Default", false, false);
                performanceMeasureSubcategoriesToUpdate = new List<PerformanceMeasureSubcategory> { defaultSubcategory };
            }
            else
            {
                performanceMeasureSubcategoriesToUpdate = PerformanceMeasureSubcategorySimples.Select(x =>
                {
                    var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(new ProjectFirmaModels.Models.PerformanceMeasure(String.Empty, default(int), default(int), false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID, false),
                        x.PerformanceMeasureSubcategoryDisplayName);
                    performanceMeasureSubcategory.PerformanceMeasure = performanceMeasure;
                    performanceMeasureSubcategory.PerformanceMeasureSubcategoryID = x.PerformanceMeasureSubcategoryID;
                    var performanceMeasureSubcategoryOptions = 
                        x.PerformanceMeasureSubcategoryOptions.OrderBy(y => y.SortOrder).Select(
                            (y, index) =>
                                new PerformanceMeasureSubcategoryOption(
                                    new PerformanceMeasureSubcategory(new ProjectFirmaModels.Models.PerformanceMeasure(String.Empty, default(int), default(int), false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID, false), String.Empty),
                                    y.PerformanceMeasureSubcategoryOptionName,
                                    false, false)
                                {
                                    PerformanceMeasureSubcategory =
                                        performanceMeasure.PerformanceMeasureSubcategories.SingleOrDefault(z => z.PerformanceMeasureSubcategoryID == x.PerformanceMeasureSubcategoryID),
                                    PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID,
                                    SortOrder = index + 1,
                                    ShowOnFactSheet = y.ShowOnFactSheet
                                }).ToList();
                    if (x.ArchivedPerformanceMeasureSubcategoryOptions != null)
                    {
                        var maxSortOrder = performanceMeasureSubcategoryOptions.Max(y => y.SortOrder ?? 0);
                        var archivedPerformanceMeasureSubcategoryOptions = x.ArchivedPerformanceMeasureSubcategoryOptions.OrderBy(y => y.SortOrder).Select(
                            (y, index) =>
                                new PerformanceMeasureSubcategoryOption(
                                    new PerformanceMeasureSubcategory(new ProjectFirmaModels.Models.PerformanceMeasure(String.Empty, default(int), default(int), false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID, false), String.Empty),
                                    y.PerformanceMeasureSubcategoryOptionName,
                                    false, false)
                                {
                                    PerformanceMeasureSubcategory =
                                        performanceMeasure.PerformanceMeasureSubcategories.SingleOrDefault(z => z.PerformanceMeasureSubcategoryID == x.PerformanceMeasureSubcategoryID),
                                    PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID,
                                    SortOrder = maxSortOrder + index + 1,
                                    ShowOnFactSheet = y.ShowOnFactSheet,
                                    IsArchived = y.IsArchived
                                }).ToList();
                        performanceMeasureSubcategoryOptions.AddRange(archivedPerformanceMeasureSubcategoryOptions);
                    }
                    
                    performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions = performanceMeasureSubcategoryOptions;
                    var chartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
                    performanceMeasureSubcategory.ChartConfigurationJson = chartConfigurationJson;
                    performanceMeasureSubcategory.GoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    if (performanceMeasure.CanBeChartedCumulatively)
                    {
                        var cumulativeChartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
                        performanceMeasureSubcategory.CumulativeChartConfigurationJson = cumulativeChartConfigurationJson;
                        performanceMeasureSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    }
                    return performanceMeasureSubcategory;
                }).ToList();
            }

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
                    x.IsArchived = y.IsArchived;
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
