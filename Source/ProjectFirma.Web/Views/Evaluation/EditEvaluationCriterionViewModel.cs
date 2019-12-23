/*-----------------------------------------------------------------------
<copyright file="EditEvaluationCriterionViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using Newtonsoft.Json.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EditEvaluationCriterionViewModel
    {
        public List<EvaluationCriterionSimple> EvaluationCriterionSimples { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditEvaluationCriterionViewModel()
        {
        }

        public EditEvaluationCriterionViewModel(ProjectFirmaModels.Models.Evaluation evaluation)
        {
            EvaluationCriterionSimples = evaluation.EvaluationCriterions.Select(x => new EvaluationCriterionSimple(x)).ToList();
        }

        //public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        //{
        //    var performanceMeasureSubcategoriesFromDatabase = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategories.Local;
        //    var performanceMeasureSubcategoryOptionsFromDatabase = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategoryOptions.Local;

        //    var performanceMeasureSubcategoriesToUpdate = EvaluationCriterionSimples.Select(x =>
        //    {
        //        var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(new ProjectFirmaModels.Models.PerformanceMeasure(String.Empty, default(int), default(int), false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID, false),
        //            x.PerformanceMeasureSubcategoryDisplayName);
        //        performanceMeasureSubcategory.PerformanceMeasure = performanceMeasure;
        //        performanceMeasureSubcategory.PerformanceMeasureSubcategoryID = x.PerformanceMeasureSubcategoryID;
        //        performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions =
        //            x.PerformanceMeasureSubcategoryOptions.OrderBy(y => y.SortOrder).Select(
        //                (y, index) =>
        //                    new PerformanceMeasureSubcategoryOption(
        //                        new PerformanceMeasureSubcategory(new ProjectFirmaModels.Models.PerformanceMeasure(String.Empty, default(int), default(int), false, PerformanceMeasureDataSourceType.Project.PerformanceMeasureDataSourceTypeID, false), String.Empty),
        //                        y.PerformanceMeasureSubcategoryOptionName,
        //                        false)
        //                    {
        //                        PerformanceMeasureSubcategory =
        //                            performanceMeasure.PerformanceMeasureSubcategories.SingleOrDefault(z => z.PerformanceMeasureSubcategoryID == x.PerformanceMeasureSubcategoryID),
        //                        PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID,
        //                        SortOrder = index + 1,
        //                        ShowOnFactSheet = y.ShowOnFactSheet
        //                    }).ToList();
        //        var chartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
        //        performanceMeasureSubcategory.ChartConfigurationJson = chartConfigurationJson;
        //        performanceMeasureSubcategory.GoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
        //        if (performanceMeasure.CanBeChartedCumulatively)
        //        {
        //            var cumulativeChartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
        //            performanceMeasureSubcategory.CumulativeChartConfigurationJson = cumulativeChartConfigurationJson;
        //            performanceMeasureSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
        //        }
        //        return performanceMeasureSubcategory;
        //    }).ToList();

        //    var performanceMeasureSubcategoryOptionsToUpdate = performanceMeasureSubcategoriesToUpdate.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList();
        //    performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList().Merge(
        //        performanceMeasureSubcategoryOptionsToUpdate,
        //        performanceMeasureSubcategoryOptionsFromDatabase,
        //        (x, y) => x.PerformanceMeasureSubcategoryOptionID == y.PerformanceMeasureSubcategoryOptionID,
        //        (x, y) =>
        //        {
        //            x.PerformanceMeasureSubcategoryOptionName = y.PerformanceMeasureSubcategoryOptionName;
        //            x.SortOrder = y.SortOrder;
        //            x.ShowOnFactSheet = y.ShowOnFactSheet;
        //        }, HttpRequestStorage.DatabaseEntities);

        //    performanceMeasure.PerformanceMeasureSubcategories.Merge(performanceMeasureSubcategoriesToUpdate,
        //        performanceMeasureSubcategoriesFromDatabase,
        //        (x, y) => x.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategoryID,
        //        (x, y) =>
        //        {
        //            x.PerformanceMeasureSubcategoryDisplayName = y.PerformanceMeasureSubcategoryDisplayName;
        //        }, HttpRequestStorage.DatabaseEntities);
        //}
    }
}
