namespace ProjectFirmaModels.Models
{
    public partial class AttachmentTypeTaxonomyTrunk : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        { 
            return $"AttachmentTypeTaxonomyTrunkID: {AttachmentTypeTaxonomyTrunkID}";
        }

    }

    public partial class PersonSettingGridTable : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"PersonSettingGridTable: {PersonSettingGridTableID}";
        }
    }

    public partial class PersonSettingGridColumn : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"PersonSettingGridColumn: {PersonSettingGridColumnID}";
        }
    }

    public partial class PersonSettingGridColumnSetting : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"PersonSettingGridColumnSetting: {PersonSettingGridColumnSettingID}";
        }
    }

    public partial class PersonSettingGridColumnSettingFilter : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"PersonSettingGridColumnSettingFilter: {PersonSettingGridColumnSettingFilterID}";
        }
    }

}