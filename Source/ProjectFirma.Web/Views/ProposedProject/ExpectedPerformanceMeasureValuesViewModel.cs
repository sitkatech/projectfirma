/*-----------------------------------------------------------------------
<copyright file="ExpectedPerformanceMeasureValuesViewModel.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class ExpectedPerformanceMeasureValuesViewModel : EditPerformanceMeasureExpectedViewModel, IValidatableObject
    {
        [StringLength(Models.ProposedProject.FieldLengths.PerformanceMeasureNotes)]
        public string PerformanceMeasureNotes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpectedPerformanceMeasureValuesViewModel()
        {
        }

        public ExpectedPerformanceMeasureValuesViewModel(Models.ProposedProject proposedProject)
            : base(proposedProject.PerformanceMeasureExpectedProposeds.OrderBy(pam => pam.PerformanceMeasureID).Select(x => new PerformanceMeasureExpectedSimple(x)).ToList())
        {
            PerformanceMeasureNotes = proposedProject.PerformanceMeasureNotes;
        }

        public void UpdateModel(List<PerformanceMeasureExpectedProposed> currentPerformanceMeasureExpectedProposeds,
            IList<PerformanceMeasureExpectedProposed> allPerformanceMeasureExpectedProposeds,
            IList<PerformanceMeasureExpectedSubcategoryOptionProposed> allPerformanceMeasureExpectedSubcategoryOptionProposeds,
            Models.ProposedProject proposedProject)
        {
            //Save our note
            proposedProject.PerformanceMeasureNotes = PerformanceMeasureNotes;

            // Remove all existing associations
            currentPerformanceMeasureExpectedProposeds.ForEach(pmav =>
            {
                pmav.PerformanceMeasureExpectedSubcategoryOptionProposeds.ToList().ForEach(pmavso => allPerformanceMeasureExpectedSubcategoryOptionProposeds.Remove(pmavso));
                allPerformanceMeasureExpectedProposeds.Remove(pmav);
            });
            currentPerformanceMeasureExpectedProposeds.Clear();

            if (PerformanceMeasureExpecteds != null)
            {
                // Completely rebuild the list
                PerformanceMeasureExpecteds.ForEach(x =>
                {
                    var proposedProjectPerformanceMeasureExpected = new PerformanceMeasureExpectedProposed(x.ProjectID, x.PerformanceMeasureID) { ExpectedValue = x.ExpectedValue };
                    allPerformanceMeasureExpectedProposeds.Add(proposedProjectPerformanceMeasureExpected);
                    if (x.PerformanceMeasureExpectedSubcategoryOptions != null)
                    {
                        x.PerformanceMeasureExpectedSubcategoryOptions.Where(y => ModelObjectHelpers.IsRealPrimaryKeyValue(y.PerformanceMeasureSubcategoryOptionID))
                            .ToList()
                            .ForEach(
                                y =>
                                    allPerformanceMeasureExpectedSubcategoryOptionProposeds.Add(
                                        new PerformanceMeasureExpectedSubcategoryOptionProposed(proposedProjectPerformanceMeasureExpected.PerformanceMeasureExpectedProposedID,
                                            y.PerformanceMeasureSubcategoryOptionID,
                                            y.PerformanceMeasureID,
                                            y.PerformanceMeasureSubcategoryID)));
                    }
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            if ((PerformanceMeasureExpecteds == null || !PerformanceMeasureExpecteds.Any()) && string.IsNullOrWhiteSpace(PerformanceMeasureNotes))
            {
                var errorMessage = string.Format("You must provide one or more expected {0}, or provide a brief note describing why the {0} are not yet known for this proposal.", MultiTenantHelpers.GetPerformanceMeasureNamePluralized());
                validationResults.Add(new SitkaValidationResult<ExpectedPerformanceMeasureValuesViewModel, string>(errorMessage, x => x.PerformanceMeasureNotes));
            }
            return validationResults;
        }
    }
}
