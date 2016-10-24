using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdCategory : IAuditableEntity
    {
        public List<Project> AssociatedProjects
        {
            get { return ProjectThresholdCategories.Select(ptc => ptc.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }

        public string KeyImageUrlSmall
        {
            get { return string.Format("/Areas/Threshold/content/img/ThresholdCategory_{0}_sm.jpg", ThresholdCategoryName); }
        }

        public string KeyImageUrlLarge
        {
            get { return string.Format("/Areas/Threshold/content/img/ThresholdCategory_{0}_lg.jpg", ThresholdCategoryName); }
        }

        public string AuditDescriptionString
        {
            get { return ThresholdCategoryName; }
        }
    }
}