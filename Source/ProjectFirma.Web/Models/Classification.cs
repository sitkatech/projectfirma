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

        public string KeyImageUrlSmall
        {
            get { return string.Format("/Areas/Threshold/content/img/Classification_{0}_sm.jpg", ClassificationName); }
        }

        public string KeyImageUrlLarge
        {
            get { return string.Format("/Areas/Threshold/content/img/Classification_{0}_lg.jpg", ClassificationName); }
        }

        public string AuditDescriptionString
        {
            get { return ClassificationName; }
        }
    }
}