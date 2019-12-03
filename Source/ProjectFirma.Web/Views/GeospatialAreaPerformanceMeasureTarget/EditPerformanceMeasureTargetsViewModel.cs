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
using LtInfo.Common.Models;
using MoreLinq;
using Newtonsoft.Json.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.GeospatialAreaPerformanceMeasureTarget
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

        public EditPerformanceMeasureTargetsViewModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea, ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasure.GeospatialAreaPerformanceMeasureTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID), performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureTargetValueTypeID = performanceMeasure.GetTargetValueType().PerformanceMeasureTargetValueTypeID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea,
                                ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, 
                                ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods, 
                                ICollection<ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureTarget> allGeospatialAreaPerformanceMeasureTargets)
        {

            if (PerformanceMeasureReportingPeriodSimples != null)
            {
                var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
                List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriodsUpdated = new List<PerformanceMeasureReportingPeriod>();
                List<ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureTarget> geospatialAreaPerformanceMeasureTargets = new List<ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureTarget>();

                // if a reporting period doesn't come back from the front end we want to make sure it doesn't accidentally get deleted in the merge below.
                var updatedIDs = PerformanceMeasureReportingPeriodSimples.Select(x => x.PerformanceMeasureReportingPeriodID);
                List<PerformanceMeasureReportingPeriod> missingPeriods = performanceMeasure.PerformanceMeasureActuals.Select(x => x.PerformanceMeasureReportingPeriod).Where(x => !updatedIDs.Contains(x.PerformanceMeasureReportingPeriodID)).ToList();
                missingPeriods.AddRange(performanceMeasure.PerformanceMeasureActualUpdates.Select(x => x.PerformanceMeasureReportingPeriod).Where(x => !updatedIDs.Contains(x.PerformanceMeasureReportingPeriodID)));
                performanceMeasureReportingPeriodsUpdated.AddRange(missingPeriods);

                foreach (var reportingPeriodSimple in PerformanceMeasureReportingPeriodSimples)
                {
                    

                    // Reporting Period
                    // ----------------

                    var reportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodID == reportingPeriodSimple.PerformanceMeasureReportingPeriodID);
                    if(reportingPeriod == null)
                    { 
                        reportingPeriod = new PerformanceMeasureReportingPeriod(reportingPeriodSimple.PerformanceMeasureReportingPeriodCalendarYear, reportingPeriodSimple.PerformanceMeasureReportingPeriodLabel);
                    }

                    performanceMeasureReportingPeriodsUpdated.Add(reportingPeriod);


                    var performanceMeasureTarget = allGeospatialAreaPerformanceMeasureTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureTargetID == reportingPeriodSimple.GeospatialAreaPerformanceMeasureTargetID);
                    switch (performanceMeasureTargetValueTypeEnum)
                    {
                        case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                            performanceMeasureTarget = null; //just to make sure we don't do anything with this.
                            break;
                        case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                            if (performanceMeasureTarget == null)
                            {
                                performanceMeasureTarget = new ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureTarget(geospatialArea, performanceMeasure)
                                {
                                    PerformanceMeasureReportingPeriodID = reportingPeriod.PerformanceMeasureReportingPeriodID,
                                    GeospatialAreaPerformanceMeasureTargetValue = OverallTargetValue,
                                    GeospatialAreaPerformanceMeasureTargetValueLabel = OverallTargetValueDescription
                                };
                            }
                            else
                            {
                                performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue = OverallTargetValue.Value;
                                performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = OverallTargetValueDescription;
                            }
                            break;
                        case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                            if (performanceMeasureTarget == null)
                            {
                                performanceMeasureTarget = new ProjectFirmaModels.Models.GeospatialAreaPerformanceMeasureTarget(geospatialArea, performanceMeasure)
                                {
                                    PerformanceMeasureReportingPeriodID = reportingPeriod.PerformanceMeasureReportingPeriodID,
                                    GeospatialAreaPerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue,
                                    GeospatialAreaPerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel
                                };
                            }
                            else
                            {
                                performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue = reportingPeriodSimple.TargetValue.Value;
                                performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = reportingPeriodSimple.TargetValueLabel;
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(
                                $"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
                    }

                    geospatialAreaPerformanceMeasureTargets.Add(performanceMeasureTarget);
                    
                }

                // Merge just PerformanceMeasureTarget
                performanceMeasure.GeospatialAreaPerformanceMeasureTargets.Merge(
                    geospatialAreaPerformanceMeasureTargets,
                    allGeospatialAreaPerformanceMeasureTargets,
                    (x,y) => x.GeospatialAreaPerformanceMeasureTargetID == y.GeospatialAreaPerformanceMeasureTargetID,
                    (x, y) =>
                    {
                        x.PerformanceMeasureReportingPeriodID = y.PerformanceMeasureReportingPeriodID;
                        x.GeospatialAreaPerformanceMeasureTargetValue = y.GeospatialAreaPerformanceMeasureTargetValue;
                        x.GeospatialAreaPerformanceMeasureTargetValueLabel = y.GeospatialAreaPerformanceMeasureTargetValueLabel;
                    }, HttpRequestStorage.DatabaseEntities);


                // Google Chart Configuration
                //if (performanceMeasure.PerformanceMeasureTargets.Any())
                //{
                //    foreach (var pfSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
                //    {
                //        var tempChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                //        tempChartConfig.Series = GoogleChartSeries.GetGoogleChartSeriesForChartsWithTargets();
                //        pfSubcategory.ChartConfigurationJson = JObject.FromObject(tempChartConfig).ToString();
                //        pfSubcategory.GoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                //        if (performanceMeasure.CanBeChartedCumulatively)
                //        {
                //            var cumulativeChartConfigurationJson = JObject.FromObject(performanceMeasure.GetDefaultPerformanceMeasureChartConfigurationJson()).ToString();
                //            pfSubcategory.CumulativeChartConfigurationJson = cumulativeChartConfigurationJson;
                //            pfSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                //        }
                //    }
                //}
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
