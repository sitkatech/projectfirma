namespace ProjectFirmaModels.Models
{
    public partial class ProjectDocument : IAuditableEntity, IEntityDocument
    {
        private string _displayCssClass;

        public string GetAuditDescriptionString() =>
            $"{Models.FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} \" {Project?.ProjectName ?? "<Not Found>"}\" document \"{DisplayName ?? "<Not Found>"}\"";

        public string GetDeleteUrl()
        {
            return ProjectDocumentModelExtensions.GetDeleteUrl(this);
        }

        public string GetEditUrl()
        {
            return ProjectDocumentModelExtensions.GetEditUrl(this);
        }

        public void SetDisplayCssClass(string value)
        {
            _displayCssClass = value;
        }

        public string GetDisplayCssClass()
        {
            return _displayCssClass;
        }
    }
}
