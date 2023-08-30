/*-----------------------------------------------------------------------
<copyright file="ProjectDashboardViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomGrid;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectDashboardViewData : FirmaViewData
    {
        public const string ProjectStagesQueryStringParameter = "ProjectStages";
        public static string ProjectStagesQueryStringValuePlaceholder = "ProjectStagesPlaceholder";
        public const string SolutionsQueryStringParameter = "Solutions";
        public static string SolutionsQueryStringValuePlaceholder = "SolutionsPlaceholder";

        public List<SelectListItem> Solutions { get; }
        public List<ProjectStage> ProjectStages { get; }
        public int TotalProjects { get; }
        public int TotalPartners { get; }
        public int TotalProjectsInUnderservedCommunities { get; }
        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }
        public string ProjectDashboardSummaryUrl { get; }
        public string ReloadProjectGridDataUrl { get; }

        public ProjectDashboardViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage,
            int projectCount,
            int partnerCount,
            int projectsInUnderservedCommunitiesCount,
            ProjectCustomGridSpec projectGridSpec,
            List<SelectListItem> solutionSelectListItems) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "Project Dashboard";

            ProjectStages = new List<ProjectStage>()
            {
                ProjectStage.PlanningDesign,
                ProjectStage.Implementation,
                ProjectStage.PostImplementation,
                ProjectStage.Completed
            };
            Solutions = solutionSelectListItems;

            TotalProjects = projectCount;
            TotalPartners = partnerCount;
            TotalProjectsInUnderservedCommunities = projectsInUnderservedCommunitiesCount;

            ProjectCustomDefaultGridSpec = projectGridSpec;
            ProjectCustomDefaultGridName = "projectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(tc => tc.ProjectDashboardProjectsGridJsonData());

            ProjectDashboardSummaryUrl = $"{SitkaRoute<ResultsController>.BuildUrlFromExpression(p => p.ProjectDashboardProjectSummary())}?" +
                                         $"{ProjectStagesQueryStringParameter}={ProjectStagesQueryStringValuePlaceholder}&{SolutionsQueryStringParameter}={SolutionsQueryStringValuePlaceholder}";
            ReloadProjectGridDataUrl = $"{SitkaRoute<ResultsController>.BuildUrlFromExpression(p => p.ProjectDashboardProjectsGridJsonData())}?" +
                                       $"{ProjectStagesQueryStringParameter}={ProjectStagesQueryStringValuePlaceholder}&{SolutionsQueryStringParameter}={SolutionsQueryStringValuePlaceholder}";
        }
    }
}
