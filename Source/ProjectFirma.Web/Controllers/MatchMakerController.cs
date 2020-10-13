using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.MatchMaker;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class MatchMakerController : FirmaBaseController
    {
        public ActionResult ProjectPotentialPartners(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            new MatchMakerViewPotentialPartnersFeature().DemandPermission(CurrentFirmaSession, project);

            var viewData = new ProjectPotentialPartnersViewData(CurrentFirmaSession, project);
            return RazorView<ProjectPotentialPartners, ProjectPotentialPartnersViewData>(viewData);
        }
    }
}