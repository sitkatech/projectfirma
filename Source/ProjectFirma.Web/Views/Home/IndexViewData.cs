/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.Home
{
    public class IndexViewData : FirmaViewData
    {
        public ViewPageContentViewData CustomHomePageTextViewData { get; }
        public ViewPageContentViewData CustomHomePageAdditionalInfoTextViewData { get; }
        public ViewPageContentViewData CustomHomePageMapTextViewData { get; }
        public FeaturedProjectsViewData FeaturedProjectsViewData { get; }
        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }
        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public string FullMapUrl { get; }
        public List<ProjectFirmaModels.Models.FirmaHomePageImage> FirmaHomePageCarouselImages { get; }
        public string ProposeNewProjectUrl { get; }
        public string ProjectUpdatesUrl { get; }
        public bool DisplayActionButtons { get; }

        public IndexViewData(FirmaSession firmaSession, ProjectFirmaModels.Models.FirmaPage firmaPageHomePage, ProjectFirmaModels.Models.FirmaPage firmaPageAdditionalInfo, ProjectFirmaModels.Models.FirmaPage firmaPageMapInfo,
            FeaturedProjectsViewData featuredProjectsViewData, ProjectLocationsMapViewData projectLocationsMapViewData, ProjectLocationsMapInitJson projectLocationsMapInitJson,
            List<ProjectFirmaModels.Models.FirmaHomePageImage> firmaHomePageImages) : base(firmaSession, firmaPageHomePage)
        {
            PageTitle = MultiTenantHelpers.GetToolDisplayName();

            Check.EnsureNotNull(firmaPageHomePage, "firmaPageHomePage not found; is one defined?");
            bool hasPermissionToManageHomePage = new FirmaPageManageFeature().HasPermission(firmaSession, firmaPageHomePage).HasPermission;

            Check.EnsureNotNull(firmaPageAdditionalInfo, "firmaPageAdditionalInfo not found; is one defined?");
            bool hasPermissionToManageAdditionalInfo = new FirmaPageManageFeature().HasPermission(firmaSession, firmaPageAdditionalInfo).HasPermission;

            Check.EnsureNotNull(firmaPageMapInfo, "firmaPageMapInfo not found; is one defined?");
            bool hasPermissionToManagePageMapInfo = new FirmaPageManageFeature().HasPermission(firmaSession, firmaPageMapInfo).HasPermission;

            CustomHomePageTextViewData = new ViewPageContentViewData(firmaPageHomePage, hasPermissionToManageHomePage);
            CustomHomePageAdditionalInfoTextViewData = new ViewPageContentViewData(firmaPageAdditionalInfo, hasPermissionToManageAdditionalInfo);
            CustomHomePageMapTextViewData = new ViewPageContentViewData(firmaPageMapInfo, hasPermissionToManagePageMapInfo);
            FeaturedProjectsViewData = featuredProjectsViewData;
            FullMapUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ProjectMap());
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            FirmaHomePageCarouselImages = firmaHomePageImages;
            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null));
            ProjectUpdatesUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
            DisplayActionButtons = !firmaSession.IsAnonymousOrUnassigned();
        }
    }
}
