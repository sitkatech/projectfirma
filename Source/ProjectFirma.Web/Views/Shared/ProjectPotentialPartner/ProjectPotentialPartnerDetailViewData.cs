/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationsDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectPotentialPartner
{
    public class ProjectPotentialPartnerDetailViewData : FirmaUserControlViewData
    {
        // Number of matches to show before we offer a "show more" link.
        public int NumberOfMatchesToShow = 5;

        public bool ShouldShowPotentialPartnerPanel { get; }
        public List<PartnerOrganizationMatchMakerScore> RelevantPartnerOrganizationMatchMakerScores { get; }

        public ProjectPotentialPartnerDetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project)
        {
            ShouldShowPotentialPartnerPanel = FirmaWebConfiguration.FeatureMatchMakerEnabled &&
                                              new MatchMakerViewPotentialPartnersFeature().HasPermissionByFirmaSession(currentFirmaSession);

            // Don't bother doing this work if we aren't going to show it
            if (ShouldShowPotentialPartnerPanel)
            {
                ProjectOrganizationMatchmaker matchMaker = new ProjectOrganizationMatchmaker();
                RelevantPartnerOrganizationMatchMakerScores = matchMaker.GetPartnerOrganizationMatchMakerScoresForParticularProject(currentFirmaSession, project);
            }
        }
    }
}
