/*-----------------------------------------------------------------------
<copyright file="ProjectMapCustomization.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectMapCustomization
    {
        public const string FilterByQueryStringParameter = "FilterBy";
        public const string FilterValuesQueryStringParameter = "FilterValues";
        public const string ColorByQueryStringParameter = "ColorBy";

        public static readonly ProjectLocationFilterType DefaultLocationFilterType = ProjectLocationFilterType.ProjectStage;
        public static List<int> GetDefaultLocationFilterValues(bool isCurrentUserAnonymous) => GetProjectStagesForMap(isCurrentUserAnonymous).Select(x => x.ProjectStageID).ToList();
        public static readonly ProjectColorByType DefaultColorByType = ProjectColorByType.ProjectStage;

        public List<int> FilterPropertyValues { get; set; }
        public string FilterPropertyName { get; set; }
        public string ColorByPropertyName { get; set; }

        public readonly ProjectLocationFilterType ProjectLocationFilterType;
        public readonly ProjectColorByType ProjectColorByType;

        public ProjectLocationFilterType GetProjectLocationFilterTypeFromFilterPropertyName()
        {
            var projectLocationFilterTypeFromFilterPropertyName = ProjectLocationFilterType.All.SingleOrDefault(x => x.ProjectLocationFilterTypeNameWithIdentifier == FilterPropertyName);
            Check.RequireNotNull(projectLocationFilterTypeFromFilterPropertyName);
            return projectLocationFilterTypeFromFilterPropertyName;
        }

        //Needed by Model Binder
        public ProjectMapCustomization()
        {
            
        }

        public ProjectMapCustomization(ProjectLocationFilterType projectLocationFilterType, List<int> projectLocationFilterValues)
            : this(projectLocationFilterType, projectLocationFilterValues, DefaultColorByType)
        {
        }

        public ProjectMapCustomization(ProjectColorByType projectColorByType) 
            : this(DefaultLocationFilterType, new List<int>(), projectColorByType)
        {
        }

        public ProjectMapCustomization(ProjectLocationFilterType projectLocationFilterType, List<int> projectLocationFilterValues, ProjectColorByType projectColorByType)
        {
            ProjectLocationFilterType = projectLocationFilterType;
            ProjectColorByType = projectColorByType;
            
            FilterPropertyName = projectLocationFilterType != null ? projectLocationFilterType.ProjectLocationFilterTypeNameWithIdentifier : String.Empty;
            FilterPropertyValues = projectLocationFilterValues;
            ColorByPropertyName = projectColorByType != null ? projectColorByType.ProjectColorByTypeNameWithIdentifier : String.Empty;
        }

        public static string BuildCustomizedUrl(ProjectLocationFilterType filterType, string filterValues)
        {
            return String.Format("{0}?{1}={2}&{3}={4}",
                SitkaRoute<ResultsController>.BuildUrlFromExpression(p => p.ProjectMap()),
                FilterByQueryStringParameter,
                filterType.ProjectLocationFilterTypeName,
                FilterValuesQueryStringParameter,
                filterValues);
        }

        public static string BuildCustomizedUrl(ProjectLocationFilterType filterType, string filterValues, ProjectColorByType colorBy)
        {
            return String.Format("{0}&{1}={2}", BuildCustomizedUrl(filterType, filterValues), ColorByQueryStringParameter, colorBy.ProjectColorByTypeName);
        }

        public static ProjectMapCustomization CreateDefaultCustomization(List<IMappableProject> projects, bool isCurrentUserAnonymous )
        {
            return new ProjectMapCustomization(DefaultLocationFilterType, GetDefaultLocationFilterValues(isCurrentUserAnonymous));
        }

        public string GetCustomizedUrl()
        {
            return BuildCustomizedUrl(ProjectLocationFilterType, FilterPropertyValues.JoinCsv(p => p.ToString(), ","), ProjectColorByType);
        }

        public static List<ProjectStage> GetProjectStagesForMap()
        {
            return GetProjectStagesForMap(false);
        }

        public static List<ProjectStage> GetProjectStagesForMap(bool isCurrentUserAnonymous)
        {
            var includeProposedProjectsOnMap = MultiTenantHelpers.ShowProposalsToThePublic() && !isCurrentUserAnonymous;
            var exceptProposedProjects = includeProposedProjectsOnMap
                ? new List<ProjectStage>()
                : new List<ProjectStage> {ProjectStage.Proposal};
            var projectStagesForMap = (ProjectStage.AllPlusProposed.Where(x => x.ShouldShowOnMap()))
                .Except(exceptProposedProjects).OrderBy(x => x.SortOrder).ToList();
            return projectStagesForMap;
        }

        public static List<IMappableProject> ProjectsForMap(Func<IMappableProject, bool> visibleProjectFilter, bool isCurrentUserAnonymous)
        {
            var allProjects = new List<IMappableProject>(HttpRequestStorage.DatabaseEntities.Projects.AsEnumerable().Where(visibleProjectFilter));
            if (MultiTenantHelpers.ShowProposalsToThePublic() && !isCurrentUserAnonymous)
            {
                allProjects.AddRange(new List<IMappableProject>(HttpRequestStorage.DatabaseEntities.ProposedProjects.Where(x=>x.ProjectID == null)));
            }
            var projectsToShow = allProjects
                .OrderBy(x => x.ProjectStage.ProjectStageID).ToList();
            return projectsToShow;
        }
    }
}
