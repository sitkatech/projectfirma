/*-----------------------------------------------------------------------
<copyright file="Project.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<Person> GetPrimaryContactPeople(this IList<Project> projects)
        {
            return projects.Where(x => x.GetPrimaryContact() != null).Select(x => x.GetPrimaryContact()).Distinct(new HavePrimaryKeyComparer<Person>()).ToList();
        }

        public static List<Project> GetProjectFindResultsForProjectNameAndDescriptionAndNumber(this IQueryable<Project> projects, string projectKeyword)
        {
            return
                projects.Where(x => x.ProjectName.Contains(projectKeyword) || x.ProjectDescription.Contains(projectKeyword))
                    .OrderBy(x => x.ProjectName)
                    .ToList();
        }

        public static List<Project> GetActiveProjectsAndProposals(this IList<Project> projects, bool showProposals)
        {
            var activeProjects = projects.GetActiveProjects();
            var activeProposals = projects.GetActiveProposals(showProposals);
            return activeProjects.Union(activeProposals, new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList();
        }

        public static List<Project> GetActiveProjects(this IList<Project> projects)
        {
            return projects.Where(x => x.IsActiveProject()).OrderBy(x => x.DisplayName).ToList();
        }

        public static List<Project> GetActiveProposals(this IList<Project> projects, bool showProposals)
        {
            return showProposals ? projects.Where(x => x.IsActiveProposal()).OrderBy(x => x.DisplayName).ToList() : new List<Project>();
        }
        public static List<Project> GetAllProposals(this IList<Project> projects, bool showProposals)
        {
            return showProposals ? projects.Where(x => x.IsProposal()).OrderBy(x => x.DisplayName).ToList() : new List<Project>();
        }
        public static List<Project> GetNotRejectedProposals(this IList<Project> projects, bool showProposals)
        {
            return showProposals ? projects.Where(x => x.IsPendingProposal()).OrderBy(x => x.DisplayName).ToList() : new List<Project>();
        }
        public static List<Project> GetPendingProjects(this IList<Project> projects, bool showProposals)
        {
            return showProposals? projects.Where(x => x.IsPendingProject()).OrderBy(x => x.DisplayName).ToList() : new List<Project>();
        }
    }
}
