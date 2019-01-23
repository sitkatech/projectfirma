using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class GeospatialAreaType : IFirmaPage, IAuditableEntity
    {
        public HtmlString GetFirmaPageContentHtmlString() => GeospatialAreaIntroContentHtmlString;

        public string GetFirmaPageDisplayName() => GeospatialAreaTypeName;
        public bool HasPageContent() => !string.IsNullOrWhiteSpace(GeospatialAreaIntroContent);

        public string GetEditPageContentUrl()
        {
            return string.Empty;
        }

        public string GetEditGeospatialAreasUrl(Project project)
        {
            return SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(x =>
                x.EditProjectGeospatialAreas(project.ProjectID, GeospatialAreaTypeID));
        }

        public string GetAuditDescriptionString() => GeospatialAreaTypeName;
    }
}