using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class AboutController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult AboutClackamasPartnership()
        {
            var con = new HomeController() { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.AboutClackamasPartnership);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult Meetings()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.Meetings);
        }
    }
}