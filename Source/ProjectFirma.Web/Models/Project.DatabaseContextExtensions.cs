/*-----------------------------------------------------------------------
<copyright file="Project.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency">
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
using System.Data.Entity;
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<Project> GetProjectsWithGeoSpatialProperties(this IQueryable<Project> projects,
            List<Watershed> watersheds,
            Func<Project, bool> filterFunction,
            List<StateProvince> stateProvinces)
        {
            var projectsList = projects.Include(x => x.ProjectOrganizations.Select(y => y.Organization)).Include(x => x.ProjectFundingSourceExpenditures).ToList();
            if (filterFunction != null)
            {
                projectsList = projectsList.Where(filterFunction).ToList();
            }
            projectsList.ForEach(x =>
            {
                x.SetProjectLocationStateProvince(stateProvinces);
                x.SetProjectLocationWatershed(watersheds);
            });
            return projectsList.OrderBy(x => x.DisplayName).ToList();
        }

        public static List<Project> GetUpdatableProjectsThatHaveNotBeenSubmitted(this IQueryable<Project> projects)
        {
            return projects.ToList().GetUpdatableProjectsThatHaveNotBeenSubmitted();
        }

        public static List<Project> GetUpdatableProjectsThatHaveNotBeenSubmitted(this IList<Project> projects)
        {
            return projects.Where(x => x.IsUpdateMandatory && x.GetLatestUpdateState() != ProjectUpdateState.Submitted).ToList();
        }

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
    }
}
