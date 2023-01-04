/*-----------------------------------------------------------------------
<copyright file="TrainingVideoViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Home
{
    public class TrainingVideoViewData : FirmaViewData
    {

        public List<ProjectFirmaModels.Models.TrainingVideo> TrainingVideos { get; }
        public bool UserHasAdminPermissions { get; }
        public string ManageTrainingVideosUrl { get; }

        public TrainingVideoViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, List<ProjectFirmaModels.Models.TrainingVideo> trainingVideos) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "Training";
            EntityName = "Stormwater Tools";
            TrainingVideos = trainingVideos;
            UserHasAdminPermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            ManageTrainingVideosUrl = SitkaRoute<TrainingVideoController>.BuildUrlFromExpression(tc => tc.ManageTrainingVideos());
        }
    }
}


