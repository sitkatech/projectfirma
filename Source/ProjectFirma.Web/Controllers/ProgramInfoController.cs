using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ProgramInfo;

namespace ProjectFirma.Web.Controllers
{
    public class ProgramInfoController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        public ViewResult Taxonomy()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.Taxonomy);
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList();
            var taxonomyTierThreesAsFancyTreeNodes = taxonomyTierThrees.Select(x => x.ToFancyTreeNode()).ToList();
            var viewData = new TaxonomyViewData(CurrentPerson, firmaPage, taxonomyTierThreesAsFancyTreeNodes);
            return RazorView<Taxonomy, TaxonomyViewData>(viewData);        }
    }
}