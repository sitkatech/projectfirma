using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirma.Web.Views.ProjectFinder;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{

    public class ProjectFinderController : FirmaBaseController
    {
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        [HttpGet]
        public ViewResult Index()
        {
            var organization = CurrentFirmaSession.Person.Organization;
            var projectFinderGridSpec = new ProjectFinderGridSpec();
            var projectMatchmakerScoresForOrganization = new ProjectOrganizationMatchmaker().GetPartnerOrganizationMatchMakerScoresForParticularOrganization(CurrentFirmaSession, organization);
            var viewData = new IndexViewData(CurrentFirmaSession, organization, projectMatchmakerScoresForOrganization,  projectFinderGridSpec);
            return RazorView<Index, IndexViewData>(viewData);
        }


        // All projects that match with the organization
        [LoggedInAndNotUnassignedRoleUnclassifiedFeature]
        public GridJsonNetJObjectResult<PartnerOrganizationMatchMakerScore> ProjectFinderGridFullJsonData()
        {
            var organization = CurrentFirmaSession.Person.Organization;
            var gridSpec = new ProjectFinderGridSpec();
            var projectMatchmakerScoresForOrganization = new ProjectOrganizationMatchmaker().GetPartnerOrganizationMatchMakerScoresForParticularOrganization(CurrentFirmaSession, organization);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PartnerOrganizationMatchMakerScore>(projectMatchmakerScoresForOrganization, gridSpec);
            return gridJsonNetJObjectResult;
        }
       
    }

}