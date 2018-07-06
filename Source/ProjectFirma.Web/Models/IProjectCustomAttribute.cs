using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IProjectCustomAttribute
    {
        int ProjectCustomAttributeTypeID { get; set; }
        ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }
        IEnumerable<IProjectCustomAttributeValue> Values { get; set; }
    }
}
