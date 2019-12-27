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
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class EditPerformanceMeasureTargetsViewModel : FormViewModel, IValidatableObject
    {
        public List<PerformanceMeasureReportingPeriodSimple> PerformanceMeasureReportingPeriodSimples { get; set; }

        [Required]
        public int PerformanceMeasureTargetValueTypeID { get; set; }
        public double? FixedTargetValue { get; set; }
        public string FixedTargetValueLabel { get; set; }

        public HashSet<string> PerformanceMeasureReportedsWithValidationErrors { get; private set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureTargetsViewModel()
        {
        }

        public EditPerformanceMeasureTargetsViewModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasure.PerformanceMeasureReportingPeriodTargets, performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureTargetValueTypeID = performanceMeasure.GetTargetValueType().PerformanceMeasureTargetValueTypeID;
            if (performanceMeasure.GetTargetValueType() == PerformanceMeasureTargetValueType.FixedTarget)
            {
                var fixedTarget = performanceMeasure.PerformanceMeasureFixedTargets.First();
                FixedTargetValue = fixedTarget.PerformanceMeasureTargetValue;
                FixedTargetValueLabel = fixedTarget.PerformanceMeasureTargetValueLabel;
            }
        }

        public EditPerformanceMeasureTargetsViewModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea, ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID), performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureTargetValueTypeID = performanceMeasure.GetGeospatialAreaTargetValueType(geospatialArea).PerformanceMeasureTargetValueTypeID;

            if (performanceMeasure.GetGeospatialAreaTargetValueType(geospatialArea) == PerformanceMeasureTargetValueType.FixedTarget)
            {
                var fixedTarget = performanceMeasure.GeospatialAreaPerformanceMeasureFixedTargets.First(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID);
                FixedTargetValue = fixedTarget.GeospatialAreaPerformanceMeasureTargetValue;
                FixedTargetValueLabel = fixedTarget.GeospatialAreaPerformanceMeasureTargetValueLabel;
            }
        }

        public void DeleteOtherPerformanceMeasureTargetValueTypes(
            ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
            PerformanceMeasureTargetValueTypeEnum performanceMeasureTargetValueTypeEnum)
        {
            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.FixedTarget)
            {
                var overallTargetsToDelete = performanceMeasure.PerformanceMeasureFixedTargets.ToList();
                overallTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }

            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.TargetPerYear)
            {
                var reportingPeriodTargetsToDelete = performanceMeasure.PerformanceMeasureReportingPeriodTargets.ToList();
                reportingPeriodTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, 
                                ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods, 
                                ICollection<PerformanceMeasureReportingPeriodTarget> allPerformanceMeasureReportingPeriodTargets)
        {
            var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
            DeleteOtherPerformanceMeasureTargetValueTypes(performanceMeasure, performanceMeasureTargetValueTypeEnum);

            switch (performanceMeasureTargetValueTypeEnum)
            {
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    // Nothing to do here, there are no "No Targets" to be saved in this case. But we still need this so that the ArgumentOutOfRange validation works

                    // need to reset the series for the geospatial json...


                    break;

                case PerformanceMeasureTargetValueTypeEnum.FixedTarget:
                    var fixedTarget = PerformanceMeasureFixedTargetModelExtensions.GetOrCreatePerformanceMeasureFixedTarget(performanceMeasure, FixedTargetValue.Value);
                    fixedTarget.PerformanceMeasureTargetValueLabel = FixedTargetValueLabel;
                    fixedTarget.PerformanceMeasureTargetValue = FixedTargetValue;
                    break;

                case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                    var performanceMeasureReportingPeriodTargetsUpdated = new List<PerformanceMeasureReportingPeriodTarget>();
                    foreach (var pmrpSimple in PerformanceMeasureReportingPeriodSimples)
                    {
                        // Reporting Period
                        // ----------------
                        var reportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == pmrpSimple.PerformanceMeasureReportingPeriodCalendarYear);
                        if (reportingPeriod == null)
                        {
                            reportingPeriod = new PerformanceMeasureReportingPeriod(pmrpSimple.PerformanceMeasureReportingPeriodCalendarYear, pmrpSimple.PerformanceMeasureReportingPeriodLabel);
                        }
                        var performanceMeasureTarget = allPerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodTargetID == pmrpSimple.PerformanceMeasureReportingPeriodTargetID);
                        if (performanceMeasureTarget == null)
                        {
                            // ReSharper disable once RedundantAssignment
                            performanceMeasureTarget = new PerformanceMeasureReportingPeriodTarget(performanceMeasure, reportingPeriod)
                            {
                                PerformanceMeasureTargetValue = pmrpSimple.TargetValue,
                                PerformanceMeasureTargetValueLabel = pmrpSimple.TargetValueLabel
                            };
                        }
                        else
                        {
                            performanceMeasureTarget.PerformanceMeasureTargetValue = pmrpSimple.TargetValue;
                            performanceMeasureTarget.PerformanceMeasureTargetValueLabel = pmrpSimple.TargetValueLabel;
                        }
                        performanceMeasureReportingPeriodTargetsUpdated.Add(performanceMeasureTarget);
                    }

                    performanceMeasure.PerformanceMeasureReportingPeriodTargets.Merge(
                        performanceMeasureReportingPeriodTargetsUpdated, 
                        allPerformanceMeasureReportingPeriodTargets, 
                        (x, y) => x.PerformanceMeasureReportingPeriodTargetID == y.PerformanceMeasureReportingPeriodTargetID, 
                        (x, y) =>
                        {
                            x.PerformanceMeasureReportingPeriodTargetID = y.PerformanceMeasureReportingPeriodTargetID;
                        }, HttpRequestStorage.DatabaseEntities);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");
            }
            SetGoogleChartConfigurationForPerformanceMeasure(performanceMeasure, performanceMeasureTargetValueTypeEnum);
        }

        public void SetGoogleChartConfigurationForPerformanceMeasure(
            ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
            PerformanceMeasureTargetValueTypeEnum performanceMeasureTargetValueTypeEnum)
        {
            var geospatialAreasWithTargets = new List<ProjectFirmaModels.Models.GeospatialArea>();
            geospatialAreasWithTargets.AddRange(performanceMeasure.GeospatialAreaPerformanceMeasureFixedTargets.Select(x => x.GeospatialArea));
            geospatialAreasWithTargets.AddRange(performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Select(x => x.GeospatialArea));
            
            //Google Chart Configuration for the Performance Measure
            foreach (var pfSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
            {
                var tempChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                tempChartConfig.SeriesType = "bars";
                if (performanceMeasure.HasTargets())
                {
                    tempChartConfig.Series = GoogleChartSeries.GetDefaultGoogleChartSeriesForChartsWithTargets();
                    pfSubcategory.GoogleChartTypeID = GoogleChartType.ComboChart.GoogleChartTypeID;
                }
                else
                {
                    tempChartConfig.Series = null;
                    pfSubcategory.GoogleChartTypeID = GoogleChartType.ColumnChart.GoogleChartTypeID;
                }
                pfSubcategory.ChartConfigurationJson = JObject.FromObject(tempChartConfig).ToString();
                if (performanceMeasure.CanBeChartedCumulatively)
                {
                    var cumulativeChartConfigurationJson = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                    cumulativeChartConfigurationJson.SeriesType = "bars";
                    pfSubcategory.CumulativeChartConfigurationJson = JObject.FromObject(cumulativeChartConfigurationJson).ToString();
                    pfSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                }

                // We need to adjust the chart JSON for the the geospatial area as well if there are geospatial area targets for this performance measure by adding an additional line series to the configuration json
                if (geospatialAreasWithTargets.Any())
                {
                    var tempGeospatialChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                    tempGeospatialChartConfig.SeriesType = "bars";
                    tempGeospatialChartConfig.Series = performanceMeasure.HasTargets() ? GoogleChartSeries.GetDefaultGoogleChartSeriesForChartsWithTwoTargets() : GoogleChartSeries.GetDefaultGoogleChartSeriesForChartsWithTargets();
                    pfSubcategory.GeospatialAreaTargetChartConfigurationJson = JObject.FromObject(tempGeospatialChartConfig).ToString();
                    pfSubcategory.GeospatialAreaTargetGoogleChartTypeID = GoogleChartType.ComboChart.GoogleChartTypeID;
                }
            }
        }

        public void DeleteOtherGeospatialAreaPerformanceMeasureTargetValueTypes(
            ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
            ProjectFirmaModels.Models.GeospatialArea geospatialArea,
            PerformanceMeasureTargetValueTypeEnum performanceMeasureTargetValueTypeEnum)
        {
            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.NoTarget)
            {
                var noTargetsToDelete = performanceMeasure.GeospatialAreaPerformanceMeasureNoTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).ToList();
                noTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }

            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.FixedTarget)
            {
                var overallTargetsToDelete = performanceMeasure.GeospatialAreaPerformanceMeasureFixedTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).ToList();
                overallTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }

            if (performanceMeasureTargetValueTypeEnum != PerformanceMeasureTargetValueTypeEnum.TargetPerYear)
            {
                var reportingPeriodTargetsToDelete = performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID == geospatialArea.GeospatialAreaID).ToList();
                reportingPeriodTargetsToDelete.ForEach(oa => oa.DeleteFull(HttpRequestStorage.DatabaseEntities));
            }
        }

        public void UpdateModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea,
                                ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
                                ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods,
                                ICollection<GeospatialAreaPerformanceMeasureNoTarget> allGeospatialAreaPerformanceMeasureNoTargets,
                                ICollection<GeospatialAreaPerformanceMeasureFixedTarget> allGeospatialAreaPerformanceMeasureFixedTargets,
                                ICollection<GeospatialAreaPerformanceMeasureReportingPeriodTarget> allGeospatialAreaPerformanceMeasureReportingPeriodTargets)
        {

            var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
            DeleteOtherGeospatialAreaPerformanceMeasureTargetValueTypes(performanceMeasure, geospatialArea, performanceMeasureTargetValueTypeEnum);

            switch (performanceMeasureTargetValueTypeEnum)
            {
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    // Make a "no target" object.
                    // ReSharper disable once UnusedVariable
                    var noTarget = GeospatialAreaPerformanceMeasureNoTargetModelExtensions.GetOrCreateGeospatialAreaPerformanceMeasureNoTarget(performanceMeasure, geospatialArea);
                    break;

                case PerformanceMeasureTargetValueTypeEnum.FixedTarget:
                    var fixedTarget = performanceMeasure.GetOrCreateGeospatialAreaPerformanceMeasureFixedTarget(geospatialArea, FixedTargetValue.Value);
                    fixedTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = FixedTargetValueLabel;
                    fixedTarget.GeospatialAreaPerformanceMeasureTargetValue = FixedTargetValue.Value;
                    break;

                case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                    var geospatialAreaPerformanceMeasureReportingPeriodTargetsUpdated =
                        new List<GeospatialAreaPerformanceMeasureReportingPeriodTarget>();
                    foreach (var pmrpSimple in PerformanceMeasureReportingPeriodSimples)
                    {
                        // Reporting Period
                        // ----------------
                        var reportingPeriod = allPerformanceMeasureReportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == pmrpSimple.PerformanceMeasureReportingPeriodCalendarYear);
                        if (reportingPeriod == null)
                        {
                            reportingPeriod = new PerformanceMeasureReportingPeriod(pmrpSimple.PerformanceMeasureReportingPeriodCalendarYear,
                                                                                    pmrpSimple.PerformanceMeasureReportingPeriodLabel);
                        }
                        var performanceMeasureTarget = allGeospatialAreaPerformanceMeasureReportingPeriodTargets.SingleOrDefault(x => x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID == pmrpSimple.GeospatialAreaPerformanceMeasureReportingPeriodTargetID);
                        if (performanceMeasureTarget == null)
                        {
                            // ReSharper disable once RedundantAssignment
                            performanceMeasureTarget = new GeospatialAreaPerformanceMeasureReportingPeriodTarget(geospatialArea, performanceMeasure, reportingPeriod)
                                {
                                    GeospatialAreaPerformanceMeasureTargetValue = pmrpSimple.TargetValue,
                                    GeospatialAreaPerformanceMeasureTargetValueLabel = pmrpSimple.TargetValueLabel
                                };
                        }
                        else
                        {
                            performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValue = pmrpSimple.TargetValue;
                            performanceMeasureTarget.GeospatialAreaPerformanceMeasureTargetValueLabel = pmrpSimple.TargetValueLabel;
                        }
                        geospatialAreaPerformanceMeasureReportingPeriodTargetsUpdated.Add(performanceMeasureTarget);
                    }

                    // we need to preserve any Geospatial Area targets for geospatial areas that are not the current one we are editing.
                    geospatialAreaPerformanceMeasureReportingPeriodTargetsUpdated.AddRange(allGeospatialAreaPerformanceMeasureReportingPeriodTargets.Where(x => x.GeospatialAreaID != geospatialArea.GeospatialAreaID));

                    // Perform the merge, which deletes the ones that haven't been submitted
                    performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Merge(geospatialAreaPerformanceMeasureReportingPeriodTargetsUpdated,
                        allGeospatialAreaPerformanceMeasureReportingPeriodTargets,
                        (x, y) => x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID == y.GeospatialAreaPerformanceMeasureReportingPeriodTargetID,
                        (x, y) =>
                        {
                            x.GeospatialAreaPerformanceMeasureReportingPeriodTargetID = y.GeospatialAreaPerformanceMeasureReportingPeriodTargetID;
                        }, HttpRequestStorage.DatabaseEntities);

                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");

            }
            SetGoogleChartConfigurationForGeospatialAreaPerformanceMeasure(performanceMeasure, geospatialArea);
        }

        public void SetGoogleChartConfigurationForGeospatialAreaPerformanceMeasure(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ProjectFirmaModels.Models.GeospatialArea geospatialArea)
        {
            // Google Chart Configuration
            if (performanceMeasure.GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any() || performanceMeasure.GeospatialAreaPerformanceMeasureFixedTargets.Any())
            {
                foreach (var pfSubcategory in performanceMeasure.PerformanceMeasureSubcategories)
                {
                    var tempChartConfig = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                    tempChartConfig.SeriesType = "bars";
                    tempChartConfig.Series =
                        performanceMeasure.HasGeospatialAreaTargets(geospatialArea) && performanceMeasure.HasTargets()
                            ? GoogleChartSeries.GetDefaultGoogleChartSeriesForChartsWithTwoTargets()
                            : GoogleChartSeries.GetDefaultGoogleChartSeriesForChartsWithTargets();

                    pfSubcategory.GeospatialAreaTargetChartConfigurationJson = JObject.FromObject(tempChartConfig).ToString();
                    pfSubcategory.GeospatialAreaTargetGoogleChartTypeID = performanceMeasure.HasGeospatialAreaTargets(geospatialArea) ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    if (performanceMeasure.CanBeChartedCumulatively)
                    {
                        var cumulativeChartConfigurationJson = GoogleChartConfiguration.GetGoogleChartConfigurationFromJsonObject(pfSubcategory.ChartConfigurationJson);
                        cumulativeChartConfigurationJson.SeriesType = "bars";
                        pfSubcategory.CumulativeChartConfigurationJson = JObject.FromObject(cumulativeChartConfigurationJson).ToString();
                        pfSubcategory.CumulativeGoogleChartTypeID = performanceMeasure.HasTargets() ? GoogleChartType.ComboChart.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    }
                }
            }
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;

            switch (performanceMeasureTargetValueTypeEnum)
            {
                case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                    break;
                case PerformanceMeasureTargetValueTypeEnum.FixedTarget:
                    if (!FixedTargetValue.HasValue)
                    {
                        errors.Add(new ValidationResult("If you are submitting an overall target, you must set a target value. Otherwise choose \"No Target\"."));
                    }

                    break;
                case PerformanceMeasureTargetValueTypeEnum.TargetPerYear:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return errors;

        }
        
    }
}