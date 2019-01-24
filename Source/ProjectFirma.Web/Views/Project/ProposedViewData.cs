/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency">
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

using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Project
{
    public class ProposedViewData : FirmaViewData
    {
        public readonly ProposalsGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly bool HasProposeProjectPermissions;
        public readonly string ProposeNewProjectUrl;

        public ProposedViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized();

            HasProposeProjectPermissions = new ProjectCreateFeature().HasPermissionByPerson(CurrentPerson);
            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null));


            GridSpec = new ProposalsGridSpec(currentPerson) {ObjectNameSingular = $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true};

            if (new ProjectCreateNewFeature().HasPermissionByPerson(CurrentPerson))
            {
                GridSpec.CustomExcelDownloadUrl =
                    SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ProposalsExcelDownload());
            }
            if (new ProjectCreateFeature().HasPermissionByPerson(CurrentPerson))
            {
                GridSpec.CreateEntityActionPhrase = "Propose a New Project";
                GridSpec.CreateEntityModalDialogForm = null;
            }
            GridName = "proposalsGrid";
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ProposedGridJsonData());
        }
    }
}
