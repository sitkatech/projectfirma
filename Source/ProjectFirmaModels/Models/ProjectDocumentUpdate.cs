namespace ProjectFirmaModels.Models
{
    public partial class ProjectDocumentUpdate : IEntityDocument
    {
        private string _displayCssClass;

        public string GetDeleteUrl()
        {
            return ProjectDocumentUpdateModelExtensions.GetDeleteUrlImpl(this);
        }

        public string GetEditUrl()
        {
            return ProjectDocumentUpdateModelExtensions.GetEditUrlmpl(this);
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