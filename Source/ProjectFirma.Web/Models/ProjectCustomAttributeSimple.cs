using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public class ProjectCustomAttributeSimple
    {
        public int ProjectCustomAttributeTypeID { get; set; }
        public IList<string> ProjectCustomAttributeValues { get; set; }
    }
}
