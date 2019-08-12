using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared
{
    public class ViewPageContentViewData
    {
        public readonly HtmlString FirmaPageContentHtmlString;
        public readonly string FirmaPageDisplayName;
        public readonly bool ShowEditButton;
        public readonly bool HasPageContent;
        public readonly string EditPageContentUrl;

        public ViewPageContentViewData(ProjectFirmaModels.Models.FirmaPage firmaPage, bool showEditButton)
        {
            FirmaPageContentHtmlString = firmaPage.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = firmaPage.GetFirmaPageDisplayName();
            ShowEditButton = showEditButton;
            HasPageContent = firmaPage.HasPageContent();
            EditPageContentUrl = SitkaRoute<FirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(firmaPage));
        }

        public ViewPageContentViewData(ProjectFirmaModels.Models.CustomPage customPage, bool showEditButton)
        {
            FirmaPageContentHtmlString = customPage.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = customPage.GetFirmaPageDisplayName();
            ShowEditButton = showEditButton;
            HasPageContent = customPage.HasPageContent();
            EditPageContentUrl = SitkaRoute<CustomPageController>.BuildUrlFromExpression(t => t.EditInDialog(customPage));
        }

        public ViewPageContentViewData(GeospatialAreaType geospatialAreaType, Person currentPerson)
        {
            FirmaPageContentHtmlString = geospatialAreaType.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = geospatialAreaType.GetFirmaPageDisplayName();
            ShowEditButton = new GeospatialAreaManageFeature().HasPermissionByPerson(currentPerson);
            HasPageContent = geospatialAreaType.HasPageContent();
            EditPageContentUrl = SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.EditInDialog(geospatialAreaType));
        }

        public ViewPageContentViewData(ProjectFirmaModels.Models.GeospatialArea geospatialArea, Person currentPerson)
        {
            FirmaPageContentHtmlString = geospatialArea.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = geospatialArea.GetFirmaPageDisplayName();
            ShowEditButton = new GeospatialAreaManageFeature().HasPermissionByPerson(currentPerson);
            HasPageContent = geospatialArea.HasPageContent();
            EditPageContentUrl = SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(t => t.EditDescriptionInDialog(geospatialArea));
        }

        public ViewPageContentViewData(ProjectFirmaModels.Models.FirmaPage firmaPage, Person currentPerson)
            : this(firmaPage, new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage).HasPermission)
        {
        }
    }
}
