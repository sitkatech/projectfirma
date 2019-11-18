/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureTargetsViewModel.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using LtInfo.Common;
using LtInfo.Common.Models;
using MoreLinq;
using Newtonsoft.Json.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditPerformanceMeasureTargetsViewModel : FormViewModel, IValidatableObject
    {
        public List<PerformanceMeasureReportingPeriodSimple> PerformanceMeasureReportingPeriodSimples { get; set; }

        [Required]
        public int PerformanceMeasureTargetValueTypeID { get; set; }
        public double? OverallTargetValue { get; set; }
        public string OverallTargetValueDescription { get; set; }

        public HashSet<string> PerformanceMeasureReportedsWithValidationErrors { get; private set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureTargetsViewModel()
        {
        }

        public EditPerformanceMeasureTargetsViewModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasure.PerformanceMeasureReportingPeriods.Where(x => x.PerformanceMeasureActuals.Any() || x.TargetValue.HasValue));
            PerformanceMeasureTargetValueTypeID = performanceMeasure.PerformanceMeasureReportingPeriods.GetTargetValueType().PerformanceMeasureTargetValueTypeID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ICollection<ProjectFirmaModels.Models.PerformanceMeasureActual> allPerformanceMeasureActuals,
            ICollection<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions, ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {

            if (PerformanceMeasureReportingPeriodSimples != null)
            {
                var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
                List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriodsUpdated = new List<PerformanceMeasureReportingPeriod>();

                //if a reporting period doesn't come back from the front end we want to make sure it doesn't accidentally get deleted in the merge below.
                var updatedIDs = PerformanceMeasureReportingPeriodSimples.Select(x => x.PerformanceMeasureReportingPeriodID);
                var missingPeriods = performanceMeasure.PerformanceMeasureReportingPeriods.Where(x => !updatedIDs.Contains(x.PerformanceMeasureReportingPeriodID) && (x.PerformanceMeasureActuals.Any() || x.PerformanceMeasureActualUpdates.Any()));
                foreach (var missingReportingPeriod in missingPeriods)
                {
                    switch (performanceMeasureTargetValueTypeEnum)
                    {
                        case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                            missingReportingPeriod.TargetValue = OverallTargetValue;
                            missingReportingPeriod.TargetValueLabel = OverallTargetValueDescription;
                            break;
                        case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                        case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                            missingReportingPeriod.TargetValue = null;
                            missingReportingPeriod.TargetValueLabel = null;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
                    }
                    performanceMeasureReportingPeriodsUpdated.Add(missingReportingPeriod);
                }

                PerformanceMeasureReportingPeriodSimples.ForEach(bulk =>
                {
                    var reportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == bulk.PerformanceMeasureReportingPeriodID);
                    if(reportingPeriod == null)
                    { 
                        reportingPeriod = new PerformanceMeasureReportingPeriod(performanceMeasure.PerformanceMeasureID, bulk.PerformanceMeasureReportingPeriodCalendarYear, bulk.PerformanceMeasureReportingPeriodLabel);
                    }

                    switch (performanceMeasureTargetValueTypeEnum)
                    {
                        case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                            reportingPeriod.TargetValue = null;
                            reportingPeriod.TargetValueLabel = null;
                            break;
                        case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                            reportingPeriod.TargetValue = OverallTargetValue;
                            reportingPeriod.TargetValueLabel = OverallTargetValueDescription;
                            break;
                        case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                            reportingPeriod.TargetValue = bulk.TargetValue;
                            reportingPeriod.TargetValueLabel = bulk.TargetValueLabel;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
                    }

                    performanceMeasureReportingPeriodsUpdated.Add(reportingPeriod);

                });

                

                performanceMeasure.PerformanceMeasureReportingPeriods.Merge(
                    performanceMeasureReportingPeriodsUpdated,
                    allPerformanceMeasureReportingPeriods,
                    (x,y) => x.PerformanceMeasureReportingPeriodID == y.PerformanceMeasureReportingPeriodID,
                    (x, y) =>
                    {
                        x.TargetValue = y.TargetValue;
                        x.TargetValueLabel = y.TargetValueLabel;
                        x.PerformanceMeasureReportingPeriodLabel = y.PerformanceMeasureReportingPeriodLabel;
                    }, HttpRequestStorage.DatabaseEntities);


                if (performanceMeasure.PerformanceMeasureReportingPeriods.Any(x => x.TargetValue.HasValue))
                {
                    foreach (var pfSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
                    {
                        var tempChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                        tempChartConfig.Series = GoogleChartSeries.GetGoogleChartSeriesForChartsWithTargets();
                        pfSubcategory.ChartConfigurationJson = JObject.FromObject(tempChartConfig).ToString();
                        pfSubcategory.GoogleChartTypeID = GoogleChartType.ColumnChart.GoogleChartTypeID;
                    }
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            PerformanceMeasureReportedsWithValidationErrors = new HashSet<string>();

            if (PerformanceMeasureReportingPeriodSimples == null)
            {
                return errors;
            }


            return errors.DistinctBy(x => x.ErrorMessage);
        }



    }
}
