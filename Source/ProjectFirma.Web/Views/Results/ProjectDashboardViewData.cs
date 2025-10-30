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

using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.ProjectCustomGrid;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectDashboardViewData : FirmaViewData
    {
        public const string ProjectStagesQueryStringParameter = "ProjectStages";
        public static string ProjectStagesQueryStringValuePlaceholder = "ProjectStagesPlaceholder";
        public const string ProjectTypesQueryStringParameter = "ProjectTypes";
        public static string ProjectTypesQueryStringValuePlaceholder = "ProjectTypesPlaceholder";
        public const string ProjectCategoriesQueryStringParameter = "ProjectCategories";
        public static string ProjectCategoriesQueryStringValuePlaceholder = "ProjectCategoriesPlaceholder";

        public IEnumerable<SelectListItem> ProjectTypes { get; }
        public IEnumerable<SelectListItem> ProjectCategories { get; }
        public List<ProjectStage> ProjectStages { get; }
        public int TotalProjects { get; }
        public int TotalPartners { get; }
        public decimal TotalAwarded { get; }
        public decimal TotalMatched { get; }
        public decimal TotalInvestment { get; }


        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }
        public string ProjectDashboardSummaryUrl { get; }
        public string ReloadProjectGridDataUrl { get; }
        public string ProjectDashboardChartsUrl { get; }
        public decimal TotalLeveraged { get; }
        public int JobsCreatedOrMaintained { get; }

        public ProjectDashboardChartsViewData ProjectDashboardChartsViewData { get; }

        public ProjectDashboardViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage,
            int projectCount,
            int partnerCount,
            decimal totalAwarded,
            decimal totalMatched,
            decimal totalInvestment,
            ProjectCustomGridSpec projectGridSpec,
            IEnumerable<SelectListItem> projectTypeSelectListItems,
            IEnumerable<SelectListItem> projectCategories,
            ProjectDashboardChartsViewData projectDashboardChartsViewData,
            double totalLeveraged, double totalJobsCreated) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "Project Summary Dashboard";

            ProjectStages = new List<ProjectStage>()
            {
                ProjectStage.PlanningDesign,
                ProjectStage.Implementation,
                ProjectStage.PostImplementation,
                ProjectStage.Completed
            };
            ProjectTypes = projectTypeSelectListItems;
            ProjectCategories = projectCategories;

            TotalProjects = projectCount;
            TotalPartners = partnerCount;
            TotalAwarded = totalAwarded;
            TotalMatched = totalMatched;
            TotalInvestment = totalInvestment;
            TotalLeveraged = (decimal)totalLeveraged;
            JobsCreatedOrMaintained = (int)totalJobsCreated;

            ProjectCustomDefaultGridSpec = projectGridSpec;
            ProjectCustomDefaultGridName = "projectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(tc => tc.ProjectDashboardProjectsGridJsonData());

            ProjectDashboardSummaryUrl = $"{SitkaRoute<ResultsController>.BuildUrlFromExpression(p => p.ProjectDashboardProjectSummary())}?" +
                                         $"{ProjectStagesQueryStringParameter}={ProjectStagesQueryStringValuePlaceholder}" +
                                         $"&{ProjectTypesQueryStringParameter}={ProjectTypesQueryStringValuePlaceholder}" +
                                         $"&{ProjectCategoriesQueryStringParameter}={ProjectCategoriesQueryStringValuePlaceholder}";
            ReloadProjectGridDataUrl = $"{SitkaRoute<ResultsController>.BuildUrlFromExpression(p => p.ProjectDashboardProjectsGridJsonData())}?" +
                                       $"{ProjectStagesQueryStringParameter}={ProjectStagesQueryStringValuePlaceholder}" +
                                       $"&{ProjectTypesQueryStringParameter}={ProjectTypesQueryStringValuePlaceholder}" +
                                       $"&{ProjectCategoriesQueryStringParameter}={ProjectCategoriesQueryStringValuePlaceholder}";
            ProjectDashboardChartsUrl = $"{SitkaRoute<ResultsController>.BuildUrlFromExpression(p => p.ProjectDashboardCharts())}?" +
                                        $"{ProjectStagesQueryStringParameter}={ProjectStagesQueryStringValuePlaceholder}" +
                                        $"&{ProjectTypesQueryStringParameter}={ProjectTypesQueryStringValuePlaceholder}" +
                                        $"&{ProjectCategoriesQueryStringParameter}={ProjectCategoriesQueryStringValuePlaceholder}";


            ProjectDashboardChartsViewData = projectDashboardChartsViewData;
        }
    }
}
