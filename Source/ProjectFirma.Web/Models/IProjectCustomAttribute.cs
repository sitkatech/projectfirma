using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IProjectCustomAttribute
    {
        int IProjectID { get; set; }
        int IProjectCustomAttributeID { get; set; }
        int ProjectCustomAttributeTypeID { get; set; }
        ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }
        IEnumerable<IProjectCustomAttributeValue> Values { get; set; }
    }
}
