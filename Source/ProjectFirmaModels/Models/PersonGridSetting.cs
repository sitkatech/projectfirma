using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class PersonGridSetting : IAuditableEntity
    {
        public string GetAuditDescriptionString() => $"PersonGridSettingID:{PersonGridSettingID} PersonID:{PersonID} GridName:{GridName}";
    }
}