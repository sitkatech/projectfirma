/*-----------------------------------------------------------------------
<copyright file="ProjectLocationUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common.DbSpatial;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectLocationUpdate : IAuditableEntity, IProjectLocation, IHaveDbGeometry
    {
        public ProjectLocationUpdate(ProjectUpdateBatch projectUpdateBatch, DbGeometry projectLocationGeometry, string annotation) : this(projectUpdateBatch, projectLocationGeometry)
        {
            Annotation = annotation;
        }

        public string GetAuditDescriptionString()
        {
            return "Shape deleted";
        }

        public DbGeometry GetProjectLocationGeometry() => ProjectLocationUpdateGeometry;

        public void SetDbGeometry(DbGeometry value)
        {
            ProjectLocationUpdateGeometry = value;
        }

        public DbGeometry GetDbGeometry()
        {
            return ProjectLocationUpdateGeometry;
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectLocationUpdates =
                project.ProjectLocations.Select(
                    projectLocationToClone => new ProjectLocationUpdate(projectUpdateBatch, projectLocationToClone.ProjectLocationGeometry, projectLocationToClone.Annotation)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectLocation> allProjectLocations)
        {
            var project = projectUpdateBatch.Project;
            var currentProjectLocations = project.ProjectLocations.ToList();
            currentProjectLocations.ForEach(projectLocation =>
            {
                allProjectLocations.Remove(projectLocation);
            });
            currentProjectLocations.Clear();

            if (projectUpdateBatch.ProjectLocationUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.ProjectLocationUpdates.ToList().ForEach(x =>
                {
                    var projectLocation = new ProjectLocation(project, x.ProjectLocationUpdateGeometry, x.Annotation);
                    allProjectLocations.Add(projectLocation);
                });
            }
        }
    }
}
