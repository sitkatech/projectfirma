using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectStewardOrganization;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectStewardOrganizationController : FirmaBaseController
    {
        [OrganizationViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.ProjectStewardOrganizationList.GetFirmaPage();
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Where(x => x.CanBeAnApprovingOrganization()).OrderBy(x => x.GetDisplayName())
                .ToList();
            var viewData = new IndexViewData(CurrentFirmaSession, organizations, firmaPage);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<Organization> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentFirmaSession);
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Where(x => x.CanBeAnApprovingOrganization()).OrderBy(x => x.GetDisplayName())
                .ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Organization>(organizations, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}