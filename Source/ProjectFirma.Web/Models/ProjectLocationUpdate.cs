/*-----------------------------------------------------------------------
<copyright file="ProjectLocationUpdate.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using Microsoft.SqlServer.Types;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationUpdate : IAuditableEntity, IProjectLocation, IHaveSqlGeometry
    {
        public ProjectLocationUpdate(ProjectUpdateBatch projectUpdateBatch, DbGeometry projectLocationGeometry, string annotation) : this(projectUpdateBatch, projectLocationGeometry)
        {
            Annotation = annotation;
        }

        public string AuditDescriptionString
        {
            get
            {
                return "Shape deleted";
            }
        }

        public DbGeometry ProjectLocationGeometry
        {
            get { return ProjectLocationUpdateGeometry; }
            set { ProjectLocationUpdateGeometry = value; }
        }

        public DbGeometry DbGeometry
        {
            get { return ProjectLocationUpdateGeometry; }
            set { ProjectLocationUpdateGeometry = value; }
        }

        public SqlGeometry SqlGeometry
        {
            get { return ProjectLocationUpdateGeometry.ToSqlGeometry(); }
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
                    var projectLocation = new ProjectLocation(project, x.ProjectLocationGeometry, x.Annotation);
                    allProjectLocations.Add(projectLocation);
                });
            }
        }
    }
}
