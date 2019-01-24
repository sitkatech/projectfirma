using System.Collections.Generic;

namespace ProjectFirmaModels.Models
{
    public interface IProjectCustomAttribute : ICanDeleteFull
    {
        int ProjectCustomAttributeTypeID { get; set; }
        ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }
        void SetCustomAttributeValues(IEnumerable<IProjectCustomAttributeValue> value);
        IEnumerable<IProjectCustomAttributeValue> GetCustomAttributeValues();
    }
}
