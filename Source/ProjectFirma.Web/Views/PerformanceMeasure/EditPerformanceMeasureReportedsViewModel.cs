/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureReportedsViewModel.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditPerformanceMeasureReportedsViewModel : FormViewModel, IValidatableObject
    {
        public List<PerformanceMeasureReportedBulk> PerformanceMeasureReportedBulks { get; set; }

        [Required]
        public int PerformanceMeasureTypeID { get; set; }
        public double? OverallTargetValue { get; set; }
        public string OverallTargetValueDescription { get; set; }

        public HashSet<string> PerformanceMeasureReportedsWithValidationErrors { get; private set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureReportedsViewModel()
        {
        }

        public EditPerformanceMeasureReportedsViewModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            var performanceMeasureReporteds = PerformanceMeasureReportedValue.MakeFromList(performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureReportedBulks = PerformanceMeasureReportedBulk.MakeFromList(performanceMeasureReporteds);
            PerformanceMeasureTypeID = performanceMeasure.PerformanceMeasureTypeID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ICollection<PerformanceMeasureReportedValue> allPerformanceMeasureReportedValues,
            ICollection<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions, ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {
            ClearModel(performanceMeasure, allPerformanceMeasureReportedValues, allPerformanceMeasureActualSubcategoryOptions, allPerformanceMeasureReportingPeriods);

            if (PerformanceMeasureReportedBulks != null)
            {
                UpdateReportedValues(performanceMeasure, allPerformanceMeasureReportedValues, allPerformanceMeasureActualSubcategoryOptions, allPerformanceMeasureReportingPeriods);
            }
        }

        private static void ClearModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ICollection<PerformanceMeasureReportedValue> allPerformanceMeasureReportedValues,
            ICollection<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureReportedValueSubcategoryOptions,
            ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {
            // Remove all existing associations
            allPerformanceMeasureReportedValueSubcategoryOptions.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).ToList().ForEach(x => allPerformanceMeasureReportedValueSubcategoryOptions.Remove(x));
            allPerformanceMeasureReportedValues.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).ToList().ForEach(x => allPerformanceMeasureReportedValues.Remove(x));
            allPerformanceMeasureReportingPeriods.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).ToList().ForEach(x => allPerformanceMeasureReportingPeriods.Remove(x));            
        }

        private void UpdateReportedValues(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ICollection<PerformanceMeasureReportedValue> allPerformanceMeasureReportedValues, ICollection<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureReportedValueSubcategoryOptions, ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {
            // Completely rebuild the list

            var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTypeID].ToEnum;
            PerformanceMeasureReportedBulks.ForEach(bulk =>
            {
                var reportingPeriod = new PerformanceMeasureReportingPeriod(performanceMeasure.PerformanceMeasureID, DateTime.Parse(bulk.PerformanceMeasureReportingPeriodBeginDate), bulk.PerformanceMeasureReportingPeriodLabel)
                {
                    PerformanceMeasureReportingPeriodEndDate = DateTime.Parse(bulk.PerformanceMeasureReportingPeriodEndDate),
                };

                switch (performanceMeasureTargetValueTypeEnum)
                {
                    case PerformanceMeasureTargetValueTypeEnum.NoTarget:
                        reportingPeriod.TargetValue = null;
                        reportingPeriod.TargetValueDescription = null;
                        break;
                    case PerformanceMeasureTargetValueTypeEnum.OverallTarget:
                        reportingPeriod.TargetValue = OverallTargetValue;
                        reportingPeriod.TargetValueDescription = OverallTargetValueDescription;
                        break;
                    case PerformanceMeasureTargetValueTypeEnum.TargetPerReportingPeriod:
                        reportingPeriod.TargetValue = bulk.TargetValue;
                        reportingPeriod.TargetValueDescription = bulk.TargetValueDescription;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Invalid Target Value Type {performanceMeasureTargetValueTypeEnum}");    
                }

                allPerformanceMeasureReportingPeriods.Add(reportingPeriod);

                bulk.ReportedValuesForDisplay.ForEach(reportedValueForDisplay =>
                {
                    //new PerformanceMeasureReportedValue(performanceMeasure.PerformanceMeasureID, reportingPeriod.PerformanceMeasureReportingPeriodID, reportedValueForDisplay.ReportedValue.Value);
                    //todo: 11/4/2019 TK - check this out
                    //var irv = new ProjectFirmaModels.Models.PerformanceMeasureActual( );
                    //allPerformanceMeasureReportedValues.Add(irv);

                    //if (reportedValueForDisplay.PerformanceMeasureSubcategoryOptionID.HasValue && bulk.PerformanceMeasureSubcategoryID.HasValue)
                    //{
                    //    var irviso = new PerformanceMeasureActualSubcategoryOption(irv.PerformanceMeasureReportedValueID, reportedValueForDisplay.PerformanceMeasureSubcategoryOptionID.Value, performanceMeasure.PerformanceMeasureID, bulk.PerformanceMeasureSubcategoryID.Value);
                    //    allPerformanceMeasureReportedValueSubcategoryOptions.Add(irviso);
                    //}
                    //else
                    //{
                    //    throw new Exception("Inconsistent performanceMeasure reported value entered.");
                    //}
                });
            });
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            PerformanceMeasureReportedsWithValidationErrors = new HashSet<string>();

            if (PerformanceMeasureReportedBulks == null)
            {
                return errors;
            }

            var orderedBulks = PerformanceMeasureReportedBulks.OrderBy(x => DateTime.Parse(x.PerformanceMeasureReportingPeriodBeginDate));
            for (var i = 0; i < PerformanceMeasureReportedBulks.Count; i++)
            {
                var bulk = orderedBulks.ElementAt(i);
                CheckForMissingReportedValuesAddToErrorsList(bulk, errors);
                CheckForInvalidDateRangeAddToErrorsList(bulk, errors);

                if (i >= PerformanceMeasureReportedBulks.Count - 1)
                {
                    continue;
                }
                CheckForOverlappingDateRangeAndAddToErrorsList(bulk, orderedBulks.ElementAt(i + 1), errors);
            }

            return errors.DistinctBy(x => x.ErrorMessage);
        }

        private void CheckForOverlappingDateRangeAndAddToErrorsList(PerformanceMeasureReportedBulk bulk, PerformanceMeasureReportedBulk nextBulk, List<ValidationResult> errors)
        {
            var endDate = DateTime.Parse(bulk.PerformanceMeasureReportingPeriodEndDate);
            var nextBeginDate = DateTime.Parse(nextBulk.PerformanceMeasureReportingPeriodBeginDate);

            if (nextBeginDate.IsDateOnOrBefore(endDate))
            {
                var overlappingDateRangeMessage = $"Reporting Period {nextBulk.PerformanceMeasureReportingPeriodLabel}: Overlaps with Reporting Period {bulk.PerformanceMeasureReportingPeriodLabel}";
                PerformanceMeasureReportedsWithValidationErrors.Add(bulk.PerformanceMeasureReportingPeriodLabel);
                errors.Add(new ValidationResult(overlappingDateRangeMessage));
            }
        }

        private void CheckForInvalidDateRangeAddToErrorsList(PerformanceMeasureReportedBulk bulk, List<ValidationResult> errors)
        {
            var beginDate = DateTime.Parse(bulk.PerformanceMeasureReportingPeriodBeginDate);
            var endDate = DateTime.Parse(bulk.PerformanceMeasureReportingPeriodEndDate);


            if (endDate.IsDateOnOrBefore(beginDate))
            {
                var outOfOrderDateRangeMessage = $"Reporting Period {bulk.PerformanceMeasureReportingPeriodLabel}: Begin Date must be before End Date";
                PerformanceMeasureReportedsWithValidationErrors.Add(bulk.PerformanceMeasureReportingPeriodLabel);
                errors.Add(new ValidationResult(outOfOrderDateRangeMessage));
            }

            if (PerformanceMeasureReportedBulks.Count(x => x.PerformanceMeasureReportingPeriodLabel == bulk.PerformanceMeasureReportingPeriodLabel) > 1)
            {
                var outOfOrderDateRangeMessage = $"Reporting Period {bulk.PerformanceMeasureReportingPeriodLabel}: Duplicate Label";
                PerformanceMeasureReportedsWithValidationErrors.Add(bulk.PerformanceMeasureReportingPeriodLabel);
                errors.Add(new ValidationResult(outOfOrderDateRangeMessage));
            }
        }

        private void CheckForMissingReportedValuesAddToErrorsList(PerformanceMeasureReportedBulk bulk, List<ValidationResult> errors)
        {
            if (bulk.ReportedValuesForDisplay.Any(x => !x.ReportedValue.HasValue))
            {
                errors.Add(new ValidationResult($"Reporting Period {bulk.PerformanceMeasureReportingPeriodLabel}: Missing value(s)"));
                PerformanceMeasureReportedsWithValidationErrors.Add(bulk.PerformanceMeasureReportingPeriodLabel);
            }
        }
    }
}
