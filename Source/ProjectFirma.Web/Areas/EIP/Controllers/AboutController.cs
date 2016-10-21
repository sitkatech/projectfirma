using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    public class AboutController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult EIPOverview()
        {
            var con = new HomeController() { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.EIPOverview);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult HistoryOfTheEIP()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.HistoryOfTheEIP);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult EIPPartners()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.EIPPartners);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult Faq()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.EIPFaq);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ActionResult ThisTool()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.ThisTool);
        }

        [HttpGet]
        [DemoScriptManageFeature]
        public ActionResult DemoScript()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.DemoScript);
        }

        [HttpGet]
        [ProjectUpdateAdminFeature]
        public ActionResult AnnualApprovalProcess()
        {
            var con = new HomeController { ControllerContext = ControllerContext };
            return con.ViewPageContent(ProjectFirmaPageTypeEnum.AnnualApprovalProcess);
        }
    }
}