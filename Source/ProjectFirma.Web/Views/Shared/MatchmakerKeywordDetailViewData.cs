/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.MatchmakerKeyword
{
    public class MatchmakerKeywordDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.MatchmakerKeyword MatchmakerKeyword { get; }
        public string EditMatchmakerKeywordUrl { get; }
        public string ManageMatchmakerKeywordUrl { get; }
        public bool UserHasMatchmakerKeywordManagePermissions { get; }
        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicOrganizationInfoGridName { get; }
        public string BasicProjectInfoGridDataUrl { get; }

        public MatchmakerKeywordDetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.MatchmakerKeyword matchmakerKeyword) : base(currentFirmaSession)
        {
            MatchmakerKeyword = matchmakerKeyword;
            PageTitle = matchmakerKeyword.MatchmakerKeywordName;
            EntityName = "MatchmakerKeyword";

            EditMatchmakerKeywordUrl = SitkaRoute<KeywordController>.BuildUrlFromExpression(c => c.Edit(matchmakerKeyword));
            // TODO
            //ManageMatchmakerKeywordUrl = SitkaRoute<KeywordController>.BuildUrlFromExpression(c => c.Index());
            UserHasMatchmakerKeywordManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            //BasicProjectInfoGridName = "tagProjectListGrid";
            BasicOrganizationInfoGridName = "matchmakerKeywordOrganizationListGrid";



            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(currentFirmaSession, true)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} with this Tag",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} with this Tag",
                SaveFiltersInCookie = true
            };
            
            // TODO
            //BasicProjectInfoGridDataUrl = SitkaRoute<TagController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(tag));
        }
    }
}
