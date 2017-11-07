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
using System.Collections.Generic;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpectedFundingViewData : ProjectCreateViewData
    {
        public readonly string RequestFundingSourceUrl;
        public readonly ViewDataForAngularClass ViewDataForAngular;

        public ExpectedFundingViewData(Person currentPerson,
            Models.Project project,
            ProposalSectionsStatus proposalSectionsStatus,
            ViewDataForAngularClass viewDataForAngularClass) : base(currentPerson, project, ProposalSectionEnum.ExpectedFunding, proposalSectionsStatus)
        {
            ViewDataForAngular = viewDataForAngularClass;
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
        }

        public class ViewDataForAngularClass
        {
            public readonly List<FundingSourceSimple> AllFundingSources;
            // Actually a ProjectID
            public readonly int ProjectID;
            public readonly decimal EstimatedTotalCost;

            public ViewDataForAngularClass(Models.Project projectProposedBatch,
                List<FundingSourceSimple> allFundingSources,
                decimal estimatedTotalCost)
            {
                AllFundingSources = allFundingSources;
                ProjectID = projectProposedBatch.ProjectID;
                EstimatedTotalCost = estimatedTotalCost;
            }
        }
    }
}
