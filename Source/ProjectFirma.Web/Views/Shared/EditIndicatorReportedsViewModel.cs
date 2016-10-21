using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using MoreLinq;

namespace ProjectFirma.Web.Views.Shared
{
    public class EditIndicatorReportedsViewModel : FormViewModel, IValidatableObject
    {
        public List<IndicatorReportedBulk> IndicatorReportedBulks { get; set; }
        [Required]
        public bool UseCustomDateRange { get; set; }
        [Required]
        public int IndicatorTargetValueTypeID { get; set; }
        public double? OverallTargetValue { get; set; }
        public string OverallTargetValueDescription { get; set; }

        public HashSet<string> IndicatorReportedsWithValidationErrors { get; private set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditIndicatorReportedsViewModel()
        {
        }

        public EditIndicatorReportedsViewModel(IIndicatorWithOnlyOneSubcategoryAndNotReportedInEIP sustainabilityIndicator)
        {
            IndicatorReportedBulks = IndicatorReportedBulk.MakeFromList(sustainabilityIndicator.GetIndicatorReportedValues());
            UseCustomDateRange = sustainabilityIndicator.UseCustomDateRange;
            IndicatorTargetValueTypeID = IndicatorSubcategory.GetTargetValueType(sustainabilityIndicator).IndicatorTargetValueTypeID;
        }

        public void UpdateModel(SustainabilityIndicator sustainabilityIndicator, ICollection<SustainabilityIndicatorReported> allSustainabilityIndicatorReporteds,
            ICollection<SustainabilityIndicatorReportedSubcategoryOption> allSustainabilityIndicatorReportedSubcategoryOptions, ICollection<SustainabilityIndicatorReportingPeriod> allReportingPeriods)
        {
            ClearModel(sustainabilityIndicator, allSustainabilityIndicatorReporteds, allSustainabilityIndicatorReportedSubcategoryOptions, allReportingPeriods);
            sustainabilityIndicator.UseCustomDateRange = UseCustomDateRange;

            if (IndicatorReportedBulks != null)
            {
                UpdateReportedValues(sustainabilityIndicator, allSustainabilityIndicatorReporteds, allSustainabilityIndicatorReportedSubcategoryOptions, allReportingPeriods);
            }
        }

        private static void ClearModel(SustainabilityIndicator sustainabilityIndicator, ICollection<SustainabilityIndicatorReported> allSustainabilityIndicatorReporteds,
            ICollection<SustainabilityIndicatorReportedSubcategoryOption> allSustainabilityIndicatorReportedSubcategoryOptions,
            ICollection<SustainabilityIndicatorReportingPeriod> allReportingPeriods)
        {
            // Remove all existing associations
            allSustainabilityIndicatorReportedSubcategoryOptions.Where(x => x.SustainabilityIndicatorID == sustainabilityIndicator.SustainabilityIndicatorID).ToList().ForEach(x => allSustainabilityIndicatorReportedSubcategoryOptions.Remove(x));
            allSustainabilityIndicatorReporteds.Where(x => x.SustainabilityIndicatorID == sustainabilityIndicator.SustainabilityIndicatorID).ToList().ForEach(x => allSustainabilityIndicatorReporteds.Remove(x));
            allReportingPeriods.Where(x => x.SustainabilityIndicatorID == sustainabilityIndicator.SustainabilityIndicatorID).ToList().ForEach(x => allReportingPeriods.Remove(x));            
        }

        private void UpdateReportedValues(SustainabilityIndicator sustainabilityIndicator, ICollection<SustainabilityIndicatorReported> allSustainabilityIndicatorReporteds, ICollection<SustainabilityIndicatorReportedSubcategoryOption> allSustainabilityIndicatorReportedSubcategoryOptions, ICollection<SustainabilityIndicatorReportingPeriod> allReportingPeriods)
        {
            // Completely rebuild the list

            var indicatorTargetValueTypeEnum = IndicatorTargetValueType.AllLookupDictionary[IndicatorTargetValueTypeID].ToEnum;
            IndicatorReportedBulks.ForEach(bulk =>
            {
                var reportingPeriod = new SustainabilityIndicatorReportingPeriod(sustainabilityIndicator.SustainabilityIndicatorID, DateTime.Parse(bulk.IndicatorReportingPeriodBeginDate), bulk.IndicatorReportingPeriodLabel)
                {
                    SustainabilityIndicatorReportingPeriodEndDate = DateTime.Parse(bulk.IndicatorReportingPeriodEndDate),
                };

                switch (indicatorTargetValueTypeEnum)
                {
                    case IndicatorTargetValueTypeEnum.NoTarget:
                        reportingPeriod.TargetValue = null;
                        reportingPeriod.TargetValueDescription = null;
                        break;
                    case IndicatorTargetValueTypeEnum.OverallTarget:
                        reportingPeriod.TargetValue = OverallTargetValue;
                        reportingPeriod.TargetValueDescription = OverallTargetValueDescription;
                        break;
                    case IndicatorTargetValueTypeEnum.TargetPerReportingPeriod:
                        reportingPeriod.TargetValue = bulk.TargetValue;
                        reportingPeriod.TargetValueDescription = bulk.TargetValueDescription;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("Invalid Target Value Type {0}", indicatorTargetValueTypeEnum));
                }

                allReportingPeriods.Add(reportingPeriod);

                bulk.ReportedValuesForDisplay.ForEach(reportedValueForDisplay =>
                {
                    var irv = new SustainabilityIndicatorReported(sustainabilityIndicator.SustainabilityIndicatorID, reportingPeriod.SustainabilityIndicatorReportingPeriodID, reportedValueForDisplay.ReportedValue.Value);
                    allSustainabilityIndicatorReporteds.Add(irv);

                    if (reportedValueForDisplay.IndicatorSubcategoryOptionID.HasValue && bulk.IndicatorSubcategoryID.HasValue)
                    {
                        var irviso = new SustainabilityIndicatorReportedSubcategoryOption(irv.SustainabilityIndicatorReportedID, reportedValueForDisplay.IndicatorSubcategoryOptionID.Value, sustainabilityIndicator.SustainabilityIndicatorID, bulk.IndicatorSubcategoryID.Value);
                        allSustainabilityIndicatorReportedSubcategoryOptions.Add(irviso);
                    }
                    else if (reportedValueForDisplay.IndicatorSubcategoryOptionID.HasValue ^ bulk.IndicatorSubcategoryID.HasValue)
                    {
                        throw new Exception("Inconsistent indicator reported value entered.");
                    }
                });
            });
        }

        public void UpdateModel(ThresholdIndicator thresholdIndicator, ICollection<ThresholdIndicatorReported> allThresholdIndicatorReporteds,
            ICollection<ThresholdIndicatorReportedSubcategoryOption> allThresholdIndicatorReportedSubcategoryOptions, ICollection<ThresholdIndicatorReportingPeriod> allReportingPeriods)
        {
            ClearModel(thresholdIndicator, allThresholdIndicatorReporteds, allThresholdIndicatorReportedSubcategoryOptions, allReportingPeriods);
            thresholdIndicator.UseCustomDateRange = UseCustomDateRange;

            if (IndicatorReportedBulks != null)
            {
                UpdateReportedValues(thresholdIndicator, allThresholdIndicatorReporteds, allThresholdIndicatorReportedSubcategoryOptions, allReportingPeriods);
            }
        }

        private static void ClearModel(ThresholdIndicator thresholdIndicator, ICollection<ThresholdIndicatorReported> allThresholdIndicatorReporteds,
            ICollection<ThresholdIndicatorReportedSubcategoryOption> allThresholdIndicatorReportedSubcategoryOptions,
            ICollection<ThresholdIndicatorReportingPeriod> allReportingPeriods)
        {
            // Remove all existing associations
            allThresholdIndicatorReportedSubcategoryOptions.Where(x => x.ThresholdIndicatorID == thresholdIndicator.ThresholdIndicatorID).ToList().ForEach(x => allThresholdIndicatorReportedSubcategoryOptions.Remove(x));
            allThresholdIndicatorReporteds.Where(x => x.ThresholdIndicatorID == thresholdIndicator.ThresholdIndicatorID).ToList().ForEach(x => allThresholdIndicatorReporteds.Remove(x));
            allReportingPeriods.Where(x => x.ThresholdIndicatorID == thresholdIndicator.ThresholdIndicatorID).ToList().ForEach(x => allReportingPeriods.Remove(x));            
        }

        private void UpdateReportedValues(ThresholdIndicator thresholdIndicator, ICollection<ThresholdIndicatorReported> allThresholdIndicatorReporteds, ICollection<ThresholdIndicatorReportedSubcategoryOption> allThresholdIndicatorReportedSubcategoryOptions, ICollection<ThresholdIndicatorReportingPeriod> allReportingPeriods)
        {
            // Completely rebuild the list

            var indicatorTargetValueTypeEnum = IndicatorTargetValueType.AllLookupDictionary[IndicatorTargetValueTypeID].ToEnum;
            IndicatorReportedBulks.ForEach(bulk =>
            {
                var reportingPeriod = new ThresholdIndicatorReportingPeriod(thresholdIndicator.ThresholdIndicatorID, DateTime.Parse(bulk.IndicatorReportingPeriodBeginDate), bulk.IndicatorReportingPeriodLabel)
                {
                    ThresholdIndicatorReportingPeriodEndDate = DateTime.Parse(bulk.IndicatorReportingPeriodEndDate),
                };

                switch (indicatorTargetValueTypeEnum)
                {
                    case IndicatorTargetValueTypeEnum.NoTarget:
                        reportingPeriod.TargetValue = null;
                        reportingPeriod.TargetValueDescription = null;
                        break;
                    case IndicatorTargetValueTypeEnum.OverallTarget:
                        reportingPeriod.TargetValue = OverallTargetValue;
                        reportingPeriod.TargetValueDescription = OverallTargetValueDescription;
                        break;
                    case IndicatorTargetValueTypeEnum.TargetPerReportingPeriod:
                        reportingPeriod.TargetValue = bulk.TargetValue;
                        reportingPeriod.TargetValueDescription = bulk.TargetValueDescription;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("Invalid Target Value Type {0}", indicatorTargetValueTypeEnum));
                }

                allReportingPeriods.Add(reportingPeriod);

                bulk.ReportedValuesForDisplay.ForEach(reportedValueForDisplay =>
                {
                    var irv = new ThresholdIndicatorReported(thresholdIndicator.ThresholdIndicatorID, reportingPeriod.ThresholdIndicatorReportingPeriodID, reportedValueForDisplay.ReportedValue.Value);
                    allThresholdIndicatorReporteds.Add(irv);

                    if (reportedValueForDisplay.IndicatorSubcategoryOptionID.HasValue && bulk.IndicatorSubcategoryID.HasValue)
                    {
                        var irviso = new ThresholdIndicatorReportedSubcategoryOption(irv.ThresholdIndicatorReportedID, reportedValueForDisplay.IndicatorSubcategoryOptionID.Value, thresholdIndicator.ThresholdIndicatorID, bulk.IndicatorSubcategoryID.Value);
                        allThresholdIndicatorReportedSubcategoryOptions.Add(irviso);
                    }
                    else if (reportedValueForDisplay.IndicatorSubcategoryOptionID.HasValue ^ bulk.IndicatorSubcategoryID.HasValue)
                    {
                        throw new Exception("Inconsistent indicator reported value entered.");
                    }
                });
            });
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            IndicatorReportedsWithValidationErrors = new HashSet<string>();

            if (IndicatorReportedBulks == null)
            {
                return errors;
            }

            var orderedBulks = IndicatorReportedBulks.OrderBy(x => DateTime.Parse(x.IndicatorReportingPeriodBeginDate));
            for (var i = 0; i < IndicatorReportedBulks.Count; i++)
            {
                var bulk = orderedBulks.ElementAt(i);
                CheckForMissingReportedValuesAddToErrorsList(bulk, errors);
                CheckForInvalidDateRangeAddToErrorsList(bulk, errors);

                if (i >= IndicatorReportedBulks.Count - 1)
                {
                    continue;
                }
                CheckForOverlappingDateRangeAndAddToErrorsList(bulk, orderedBulks.ElementAt(i + 1), errors);
            }

            return errors.DistinctBy(x => x.ErrorMessage);
        }

        private void CheckForOverlappingDateRangeAndAddToErrorsList(IndicatorReportedBulk bulk, IndicatorReportedBulk nextBulk, List<ValidationResult> errors)
        {
            var endDate = DateTime.Parse(bulk.IndicatorReportingPeriodEndDate);
            var nextBeginDate = DateTime.Parse(nextBulk.IndicatorReportingPeriodBeginDate);

            if (nextBeginDate.IsDateOnOrBefore(endDate))
            {
                var overlappingDateRangeMessage = string.Format("Reporting Period {0}: Overlaps with Reporting Period {1}", nextBulk.IndicatorReportingPeriodLabel, bulk.IndicatorReportingPeriodLabel);
                IndicatorReportedsWithValidationErrors.Add(bulk.IndicatorReportingPeriodLabel);
                errors.Add(new ValidationResult(overlappingDateRangeMessage));
            }
        }

        private void CheckForInvalidDateRangeAddToErrorsList(IndicatorReportedBulk bulk, List<ValidationResult> errors)
        {
            var beginDate = DateTime.Parse(bulk.IndicatorReportingPeriodBeginDate);
            var endDate = DateTime.Parse(bulk.IndicatorReportingPeriodEndDate);


            if (endDate.IsDateOnOrBefore(beginDate))
            {
                var outOfOrderDateRangeMessage = string.Format("Reporting Period {0}: Begin Date must be before End Date", bulk.IndicatorReportingPeriodLabel);
                IndicatorReportedsWithValidationErrors.Add(bulk.IndicatorReportingPeriodLabel);
                errors.Add(new ValidationResult(outOfOrderDateRangeMessage));
            }

            if (IndicatorReportedBulks.Count(x => x.IndicatorReportingPeriodLabel == bulk.IndicatorReportingPeriodLabel) > 1)
            {
                var outOfOrderDateRangeMessage = string.Format("Reporting Period {0}: Duplicate Label", bulk.IndicatorReportingPeriodLabel);
                IndicatorReportedsWithValidationErrors.Add(bulk.IndicatorReportingPeriodLabel);
                errors.Add(new ValidationResult(outOfOrderDateRangeMessage));
            }
        }

        private void CheckForMissingReportedValuesAddToErrorsList(IndicatorReportedBulk bulk, List<ValidationResult> errors)
        {
            if (bulk.ReportedValuesForDisplay.Any(x => !x.ReportedValue.HasValue))
            {
                errors.Add(new ValidationResult(string.Format("Reporting Period {0}: Missing value(s)", bulk.IndicatorReportingPeriodLabel)));
                IndicatorReportedsWithValidationErrors.Add(bulk.IndicatorReportingPeriodLabel);
            }
        }
    }
}