/*-----------------------------------------------------------------------
<copyright file="ProjectViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Project
{
    public abstract class ProjectViewData : FirmaViewData
    {
        public readonly Models.Project Project;
        public readonly ProjectUpdateState LatestUpdateState;
        public readonly bool CurrentPersonIsApprover;
        public readonly bool CurrentPersonIsSubmitter;

        protected ProjectViewData(Person currentPerson, Models.Project project) : base(currentPerson, null)
        {
            Project = project;
            HtmlPageTitle = project.ProjectName;
            EntityName = $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()}";
            LatestUpdateState = project.GetLatestUpdateState();
            CurrentPersonIsSubmitter = new ProjectCreateFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonIsApprover = new ProjectApproveFeature().HasPermissionByPerson(CurrentPerson);
            CurrentPersonCanEditProposal =
                new ProjectCreateFeature().HasPermission(CurrentPerson, Project).HasPermission;

            ProposalBasicsUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID));
        }

        public bool CurrentPersonCanEditProposal { get; set; }

        public string ProposalBasicsUrl { get; set; }
    }
}
