using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views
{
    public abstract class LakeTahoeInfoBaseViewData
    {
        public string PageTitle;
        public string HtmlPageTitle;
        public string BreadCrumbTitle; //TODO: For story 108, change to "public abstract string BreadCrumbTitle { get; protected set; }"
        public string EntityName;

        public readonly Models.ProjectFirmaPage ProjectFirmaPage;

        public readonly Person CurrentPerson;
        public readonly string EipHomeUrl;
        public readonly string LakeTahoeInfoHomeUrl;
        public readonly string DataCenterUrl;

        public readonly string LogInUrl;
        public readonly string LogOutUrl;

        public readonly string RequestSupportUrl;

        public readonly LakeTahoeInfoSiteExplorerViewData LakeTahoeInfoSiteExplorerViewData;

        protected LakeTahoeInfoBaseViewData(Person currentPerson, LTInfoArea ltInfoArea) : this(currentPerson, null, ltInfoArea)
        {
        }

        protected LakeTahoeInfoBaseViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage, LTInfoArea ltInfoArea)
        {
            ProjectFirmaPage = projectFirmaPage;

            CurrentPerson = currentPerson;
            LakeTahoeInfoHomeUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index());

            LogInUrl = ProjectFirmaHelpers.GenerateLogInUrlWithReturnUrl();
            LogOutUrl = ProjectFirmaHelpers.GenerateLogOutUrlWithReturnUrl();

            RequestSupportUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(c => c.Support());

            LakeTahoeInfoSiteExplorerViewData = new LakeTahoeInfoSiteExplorerViewData(ltInfoArea);
        }

        public string GetBreadCrumbTitle()
        {
            if (!string.IsNullOrWhiteSpace(BreadCrumbTitle))
            {
                return string.Format(" | {0}", BreadCrumbTitle);
            }
            else if (!string.IsNullOrWhiteSpace(PageTitle))
            {
                return string.Format(" | {0}", PageTitle);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}