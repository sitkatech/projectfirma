using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProgramInfo;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class ProgramInfoController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult EipTaxonomy()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.EIPTaxonomy);
            var focusAreas = HttpRequestStorage.DatabaseEntities.FocusAreas.ToList();
            var focusAreasAsFancyTreeNodes = focusAreas.Select(x => x.ToFancyTreeNode()).ToList();
            var viewData = new EipTaxonomyViewData(CurrentPerson, firmaPage, focusAreasAsFancyTreeNodes);
            return RazorView<EipTaxonomy, EipTaxonomyViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult TransportationTaxonomy()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.TransportationTaxonomy);
            var transportationStrategies = HttpRequestStorage.DatabaseEntities.TransportationStrategies.OrderBy(x => x.SortOrder).ToList();
            var transportationStrategiesAsFancyNodes = transportationStrategies.Select(x => x.ToFancyTreeNode()).ToList();
            var viewData = new TransportationTaxonomyViewData(CurrentPerson, firmaPage, transportationStrategiesAsFancyNodes);
            return RazorView<TransportationTaxonomy, TransportationTaxonomyViewData>(viewData);
        }
    }
}