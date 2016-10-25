using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class AboutController : FirmaBaseController
    {
        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult AboutClackamasPartnership()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.AboutClackamasPartnership);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult Meetings()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(FirmaPageTypeEnum.Meetings);
        }
    }
}