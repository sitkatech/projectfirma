using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectStewardOrganization;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectStewardOrganizationController : FirmaBaseController
    {
        [OrganizationViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPage.GetFirmaPageByPageType(FirmaPageType.ProjectStewardOrganizationList);
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Where(x => x.CanBeAnApprovingOrganization()).OrderBy(x => x.GetDisplayName())
                .ToList();
            var viewData = new IndexViewData(CurrentPerson, organizations, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<Organization> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentPerson);
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Where(x => x.CanBeAnApprovingOrganization()).OrderBy(x => x.GetDisplayName())
                .ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Organization>(organizations, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}