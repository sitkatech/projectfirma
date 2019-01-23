using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class EntityDocument : IEntityDocument
    {
        private readonly string _deleteUrl;
        private readonly string _editUrl;
        private string _displayCssClass;

        public string GetDeleteUrl()
        {
            return _deleteUrl;
        }

        public string GetEditUrl()
        {
            return _editUrl;
        }

        public FileResource FileResource { get; set; }

        public void SetDisplayCssClass(string value)
        {
            _displayCssClass = value;
        }

        public string GetDisplayCssClass()
        {
            return _displayCssClass;
        }

        public string DisplayName { get; set; }
        public string Description { get; set; }

        public EntityDocument(string deleteUrl, string editUrl, FileResource fileResource, string displayCssClass,
            string displayName, string description)
        {
            _deleteUrl = deleteUrl;
            _editUrl = editUrl;
            FileResource = fileResource;
            SetDisplayCssClass(displayCssClass);
            DisplayName = displayName;
            Description = description;
        }

        public static List<EntityDocument> CreateFromEntityDocument(List<IEntityDocument> entityDocuments)
        {
            return entityDocuments.Select(x => new EntityDocument(x.GetDeleteUrl(), x.GetEditUrl(), x.FileResource, null, x.DisplayName, x.Description)).ToList();
        }
    }
}