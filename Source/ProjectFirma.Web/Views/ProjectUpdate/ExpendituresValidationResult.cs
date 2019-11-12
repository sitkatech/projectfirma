/*-----------------------------------------------------------------------
<copyright file="ExpendituresValidationResult.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpendituresValidationResult
    {
        public static List<string> Validate(List<ProjectFundingSourceExpenditureBulk> projectFundingSourceExpenditureBulks, string notes, List<int> expectedYears, bool hasExpenditures)
        {
            var errors = new List<string>();
            var emptyRows = projectFundingSourceExpenditureBulks?.Where(x => x.CalendarYearExpenditures.All(y => !y.MonetaryAmount.HasValue));

            if (projectFundingSourceExpenditureBulks == null)
            {
                projectFundingSourceExpenditureBulks = new List<ProjectFundingSourceExpenditureBulk>();
            }

            if (emptyRows?.Any() ?? false)
            {
                errors.Add($"The {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} could not be saved because there are blank rows. Enter a value in all fields or delete funding sources for which there is no expenditure data to report.");
            }

            // Expenditures note is required if no expenditures to enter is selected
            if (!hasExpenditures && string.IsNullOrWhiteSpace(notes))
            {
                errors.Add($"The {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} could not be saved, Expenditures Notes are required if no expenditures are entered.");
            }

            // get distinct Funding Sources
            var projectFundingSourceExpenditures = projectFundingSourceExpenditureBulks.SelectMany(x => x.ToProjectFundingSourceExpenditures()).ToList();
            if (hasExpenditures)
            {
                errors.AddRange(ValidateImpl(notes, expectedYears, new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures)));
            }
            return errors;
        }

        public static List<string> ValidateImpl(string explanation, List<int> expectedYears,
            List<IFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            var errors = new List<string>();
            // Need to get FundingSources by IDs because we may have unsaved projectFundingSourceExpenditures that won't have a reference to the entity
            var fundingSourcesIDs = projectFundingSourceExpenditures.Select(x => x.FundingSourceID).Distinct().ToList();
            var fundingSources =
                HttpRequestStorage.DatabaseEntities.FundingSources.Where(x => fundingSourcesIDs.Contains(x.FundingSourceID));

            var missingFundingSourceYears = new Dictionary<ProjectFirmaModels.Models.FundingSource, IEnumerable<int>>();
            foreach (var fundingSource in fundingSources)
            {
                var currentFundingSource = fundingSource;
                var missingYears =
                    expectedYears
                        .GetMissingYears(projectFundingSourceExpenditures
                            .Where(x => x.FundingSourceID == currentFundingSource.FundingSourceID)
                            .Select(x => x.CalendarYear)).ToList();

                if (missingYears.Any())
                {
                    missingFundingSourceYears.Add(currentFundingSource, missingYears);
                }
            }

            foreach (var fundingSource in missingFundingSourceYears)
            {
                var yearsForErrorDisplay = string.Join(", ", FirmaHelpers.CalculateYearRanges(fundingSource.Value));
                errors.Add($"Missing Expenditures for {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} '{fundingSource.Key.GetDisplayName()}' for the following years: {string.Join(", ", yearsForErrorDisplay)}");
            }                    

            return errors;
        }
    }
}
