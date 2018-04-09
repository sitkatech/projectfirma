using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class EntityDocument : IEntityDocument
    {
        public string DeleteUrl { get; }
        public string EditUrl { get; }
        public FileResource FileResource { get; set; }
        public string DisplayCssClass { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public EntityDocument(string deleteUrl, string editUrl, FileResource fileResource, string displayCssClass,
            string displayName, string description)
        {
            DeleteUrl = deleteUrl;
            EditUrl = editUrl;
            FileResource = fileResource;
            DisplayCssClass = displayCssClass;
            DisplayName = displayName;
            Description = description;
        }

        public static List<EntityDocument> CreateFromEntityDocument(List<IEntityDocument> entityDocuments)
        {
            return entityDocuments.Select(x => new EntityDocument(x.DeleteUrl, x.EditUrl, x.FileResource, null, x.DisplayName, x.Description)).ToList();
        }
    }
}