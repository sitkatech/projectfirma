using System.Collections.Generic;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public interface IProjectCustomAttribute : ICanDeleteFull
    {
        int ProjectCustomAttributeTypeID { get; set; }
        ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }
        void SetCustomAttributeValues(IEnumerable<IProjectCustomAttributeValue> value);
        IEnumerable<IProjectCustomAttributeValue> GetCustomAttributeValues();
    }
}
