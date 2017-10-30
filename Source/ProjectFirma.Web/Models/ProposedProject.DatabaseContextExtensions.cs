/*-----------------------------------------------------------------------
<copyright file="ProposedProject.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<ProposedProject> GetProposedProjectsWithGeoSpatialProperties(this IQueryable<ProposedProject> proposedProjects,
            List<Watershed> watersheds,
            List<StateProvince> stateProvinces,
            Func<ProposedProject, bool> filterFunction)
        {
            var projectsList = proposedProjects.ToList();
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
    }
}
