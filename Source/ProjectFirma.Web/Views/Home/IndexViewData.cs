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
using LtInfo.Common.BootstrapWrappers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.Home
{
    public class IndexViewData : FirmaViewData
    {
        public readonly ViewPageContentViewData CustomHomePageTextViewData;
        public readonly ViewPageContentViewData CustomHomePageAdditionalInfoTextViewData;
        public readonly ViewPageContentViewData CustomHomePageMapTextViewData;
        public readonly FeaturedProjectsViewData FeaturedProjectsViewData;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly string FullMapUrl;
        public readonly List<Models.FirmaHomePageImage> FirmaHomePageCarouselImages;
        public readonly string ProposeNewProjectUrl;
        public readonly string ProjectUpdatesUrl;
        public readonly bool DisplayActionButtons;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPageHomePage, Models.FirmaPage firmaPageAdditionalInfo, Models.FirmaPage firmaPageMapInfo,
            FeaturedProjectsViewData featuredProjectsViewData, ProjectLocationsMapViewData projectLocationsMapViewData, ProjectLocationsMapInitJson projectLocationsMapInitJson,
            List<Models.FirmaHomePageImage> firmaHomePageImages) : base(currentPerson, firmaPageHomePage)
        {
            PageTitle = MultiTenantHelpers.GetToolDisplayName();

            CustomHomePageTextViewData = new ViewPageContentViewData(firmaPageHomePage, new FirmaPageManageFeature().HasPermission(currentPerson, firmaPageHomePage).HasPermission);
            CustomHomePageAdditionalInfoTextViewData = new ViewPageContentViewData(firmaPageAdditionalInfo, new FirmaPageManageFeature().HasPermission(currentPerson, firmaPageAdditionalInfo).HasPermission);
            CustomHomePageMapTextViewData = new ViewPageContentViewData(firmaPageMapInfo, new FirmaPageManageFeature().HasPermission(currentPerson, firmaPageMapInfo).HasPermission);
            FeaturedProjectsViewData = featuredProjectsViewData;
            FullMapUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ProjectMap());
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            FirmaHomePageCarouselImages = firmaHomePageImages;
            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null));
            ProjectUpdatesUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
            DisplayActionButtons = !currentPerson.IsAnonymousOrUnassigned();
        }
    }
}
