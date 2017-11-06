/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceRequestsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectFundingSourceRequest
{
    public class EditProjectFundingSourceRequestsViewModel : FormViewModel, IValidatableObject
    {
        public List<ProjectFundingSourceRequestSimple> ProjectFundingSourceRequests { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectFundingSourceRequestsViewModel()
        {
        }

        public EditProjectFundingSourceRequestsViewModel(List<Models.ProjectFundingSourceRequest> projectFundingSourceRequests)
        {
            ProjectFundingSourceRequests = projectFundingSourceRequests.Select(x => new ProjectFundingSourceRequestSimple(x)).ToList();
        }

        public void UpdateModel(List<Models.ProjectFundingSourceRequest> currentProjectFundingSourceRequests, IList<Models.ProjectFundingSourceRequest> allProjectFundingSourceRequests)
        {
            var projectFundingSourceRequestsUpdated = new List<Models.ProjectFundingSourceRequest>();
            if (ProjectFundingSourceRequests != null)
            {
                // Completely rebuild the list
                projectFundingSourceRequestsUpdated = ProjectFundingSourceRequests.Where(x => x.UnsecuredAmount.HasValue || x.SecuredAmount.HasValue).Select(x => x.ToProjectFundingSourceRequest()).ToList();
            }

            currentProjectFundingSourceRequests.Merge(projectFundingSourceRequestsUpdated,
                allProjectFundingSourceRequests,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.UnsecuredAmount = y.UnsecuredAmount;
                });
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (ProjectFundingSourceRequests != null)
            {
                if (ProjectFundingSourceRequests.GroupBy(x => x.FundingSourceID).Any(x => x.Count() > 1))
                {
                    validationResults.Add(new ValidationResult("Each funding source can only be used once."));
                }

                if (ProjectFundingSourceRequests.Any(x => x.AreBothValuesZeroOrEmpty()))
                {
                    validationResults.Add(new ValidationResult("Enter a Secured or Unsecured amount for each Funding Source, or remove Funding Sources with no funding amounts."));
                }
            }
            return validationResults;
        }
    }
}
