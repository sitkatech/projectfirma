﻿/*-----------------------------------------------------------------------
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
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
            var performanceMeasureReporteds = PerformanceMeasureReportedValue.MakeFromList(performanceMeasure.PerformanceMeasureActuals);
            PerformanceMeasureReportingPeriodSimples = PerformanceMeasureReportingPeriodSimple.MakeFromList(performanceMeasureReporteds);
            PerformanceMeasureTargetValueTypeID = performanceMeasure.PerformanceMeasureReportingPeriods.GetTargetValueType().PerformanceMeasureTargetValueTypeID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ICollection<ProjectFirmaModels.Models.PerformanceMeasureActual> allPerformanceMeasureActuals,
            ICollection<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureActualSubcategoryOptions, ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {
            //ClearModel(performanceMeasure, allPerformanceMeasureActuals, allPerformanceMeasureActualSubcategoryOptions, allPerformanceMeasureReportingPeriods);

            if (PerformanceMeasureReportingPeriodSimples != null)
            {
                var performanceMeasureTargetValueTypeEnum = PerformanceMeasureTargetValueType.AllLookupDictionary[PerformanceMeasureTargetValueTypeID].ToEnum;
                List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriodsUpdated = new List<PerformanceMeasureReportingPeriod>();
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

                    performanceMeasureReportingPeriodsUpdated.Add(reportingPeriod);

                });

                //performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x => x.PerformanceMeasureSubcategoryOptions).ToList().Merge(
                //    performanceMeasureSubcategoryOptionsToUpdate,
                //    performanceMeasureSubcategoryOptionsFromDatabase,
                //    (x, y) => x.PerformanceMeasureSubcategoryOptionID == y.PerformanceMeasureSubcategoryOptionID,
                //    (x, y) =>
                //    {
                //        x.PerformanceMeasureSubcategoryOptionName = y.PerformanceMeasureSubcategoryOptionName;
                //        x.SortOrder = y.SortOrder;
                //        x.ShowOnFactSheet = y.ShowOnFactSheet;
                //    }, HttpRequestStorage.DatabaseEntities);

                performanceMeasure.PerformanceMeasureReportingPeriods.Merge(
                    performanceMeasureReportingPeriodsUpdated,
                    allPerformanceMeasureReportingPeriods,
                    (x,y) => x.PerformanceMeasureReportingPeriodID == y.PerformanceMeasureReportingPeriodID,
                    (x, y) =>
                    {
                        x.TargetValue = y.TargetValue;
                        x.TargetValueDescription = y.TargetValueDescription;
                        x.PerformanceMeasureReportingPeriodLabel = y.PerformanceMeasureReportingPeriodLabel;
                    }, HttpRequestStorage.DatabaseEntities);


            }
        }

        //private static void ClearModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ICollection<ProjectFirmaModels.Models.PerformanceMeasureActual> allPerformanceMeasureActuals,
        //    ICollection<PerformanceMeasureActualSubcategoryOption> allPerformanceMeasureReportedValueSubcategoryOptions,
        //    ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        //{
        //    // Remove all existing associations
        //    allPerformanceMeasureReportedValueSubcategoryOptions.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).ToList().ForEach(x => allPerformanceMeasureReportedValueSubcategoryOptions.Remove(x));
        //    allPerformanceMeasureActuals.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).ToList().ForEach(x => allPerformanceMeasureActuals.Remove(x));
        //    allPerformanceMeasureReportingPeriods.Where(x => x.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID).ToList().ForEach(x => allPerformanceMeasureReportingPeriods.Remove(x));            
        //}

        private void UpdateReportedValues(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, ICollection<PerformanceMeasureReportingPeriod> allPerformanceMeasureReportingPeriods)
        {
            // Completely rebuild the list

            
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