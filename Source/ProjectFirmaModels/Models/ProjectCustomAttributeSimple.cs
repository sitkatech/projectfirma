using System.Collections.Generic;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeSimple
    {
        public int ProjectCustomAttributeTypeID { get; set; }
        public IList<string> ProjectCustomAttributeValues { get; set; }
    }
}
