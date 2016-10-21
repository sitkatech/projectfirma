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