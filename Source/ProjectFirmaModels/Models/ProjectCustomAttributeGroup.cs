using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectCustomAttributeGroup : IAuditableEntity, IHaveASortOrder, ISortingGroup
    {
        public string GetAuditDescriptionString() => ProjectCustomAttributeGroupName;

        public string GetDisplayName() => ProjectCustomAttributeGroupName;
        public List<IHaveASortOrder> GetSortableList()
        {
            return new List<IHaveASortOrder>(this.ProjectCustomAttributeTypes);
        }

        public void SetSortOrder(int? value) =>  SortOrder = value;
        public int? GetSortOrder() => SortOrder;
        public int GetID() => ProjectCustomAttributeGroupID;
    }
}