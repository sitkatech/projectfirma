using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class Classification : IAuditableEntity
    {
        public List<Project> AssociatedProjects
        {
            get { return ProjectClassifications.Select(ptc => ptc.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }

        public string KeyImageUrlLarge
        {
            get
            {
                return this.KeyImageFileResource != null ? KeyImageFileResource.FileResourceUrlScaledForPrint : "http://placehold.it/280x210";
            }
        }

        public string AuditDescriptionString
        {
            get { return ClassificationName; }
        }
    }
}