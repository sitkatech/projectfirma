using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectStatus : IAuditableEntity, IHaveASortOrder
    {
        public string GetAuditDescriptionString()
        {
            var projectStatusProjectStatusDisplayName = ProjectStatusDisplayName;
            var tenantID = TenantID;
            return $"Project Status: Project Status - {projectStatusProjectStatusDisplayName}, Tenant - {tenantID}";
        }

        string IHaveASortOrder.GetDisplayName() => ProjectStatusDisplayName;
        

        public void SetSortOrder(int? value) => ProjectStatusSortOrder = value;
        public int? GetSortOrder() => ProjectStatusSortOrder;
        public int GetID() => ProjectStatusID;
      
    }
}