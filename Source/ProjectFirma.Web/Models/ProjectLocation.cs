using System.Data.Entity.Spatial;
using LtInfo.Common.DbSpatial;
using Microsoft.SqlServer.Types;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocation : IAuditableEntity, IProjectLocation, IHaveSqlGeometry
    {
        public ProjectLocation(Project project, DbGeometry projectLocationGeometry, string annotation) : this(project, projectLocationGeometry)
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

        public DbGeometry DbGeometry
        {
            get { return ProjectLocationGeometry; }
            set { ProjectLocationGeometry = value; }
        }

        public SqlGeometry SqlGeometry
        {
            get { return ProjectLocationGeometry.ToSqlGeometry(); }
        }
    }
}