/*-----------------------------------------------------------------------
<copyright file="ExpectedFundingViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectFunding;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpectedFundingViewData : ProjectCreateViewData
    {
        public string RequestFundingSourceUrl { get; }
        public ProjectFundingCalculatedCosts ProjectFundingCalculatedCosts { get; }

        public ViewDataForAngularClass ViewDataForAngular { get; }

        public ExpectedFundingViewData(Person currentPerson,
            ProjectFirmaModels.Models.Project project,
            ProposalSectionsStatus proposalSectionsStatus,
            ViewDataForAngularClass viewDataForAngularClass
            ) : base(currentPerson, project, ProjectCreateSection.Budget.ProjectCreateSectionDisplayName, proposalSectionsStatus)
        {
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ProjectFundingCalculatedCosts = new ProjectFundingCalculatedCosts(project);
            ViewDataForAngular = viewDataForAngularClass;
        }

        public class ViewDataForAngularClass
        {
            public List<FundingSourceSimple> AllFundingSources { get; }
            // Actually a ProjectID
            public int ProjectID { get; }
            public decimal EstimatedTotalCost { get; }
            public decimal EstimatedAnnualOperatingCost { get; }

            public IEnumerable<SelectListItem> FundingTypes { get; }

            public ViewDataForAngularClass(ProjectFirmaModels.Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                IEnumerable<SelectListItem> fundingTypes)
            {
                AllFundingSources = allFundingSources;
                ProjectID = project.ProjectID;
                EstimatedTotalCost = project.EstimatedTotalCost ?? 0;
                EstimatedAnnualOperatingCost = project.EstimatedAnnualOperatingCost ?? 0;
                FundingTypes = fundingTypes;
            }
        }
    }
}
