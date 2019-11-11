/*-----------------------------------------------------------------------
<copyright file="InstructionsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class InstructionsProposalViewData : ProjectCreateViewData
    {

        public readonly bool IsNewProjectCreate;

        public readonly ViewPageContentViewData InstructionsViewPageContentViewData;
        public InstructionsProposalViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, bool isNewProjectCreate) : base(currentFirmaSession, "Instructions", SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null)))
        {
            PageTitle = $"Propose {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}";
            InstructionsViewPageContentViewData = new ViewPageContentViewData(firmaPage, new FirmaPageManageFeature().HasPermission(currentFirmaSession, firmaPage).HasPermission);
            IsNewProjectCreate = isNewProjectCreate;
        }

        public InstructionsProposalViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project, ProposalSectionsStatus proposalSectionsStatus, ProjectFirmaModels.Models.FirmaPage firmaPage, bool isNewProjectCreate) : base(currentFirmaSession, project,  "Instructions", proposalSectionsStatus)
        {
            InstructionsViewPageContentViewData = new ViewPageContentViewData(firmaPage, new FirmaPageManageFeature().HasPermission(currentFirmaSession, firmaPage).HasPermission);
            IsNewProjectCreate = isNewProjectCreate;
        }
    }
}
