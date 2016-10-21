using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public abstract class SiteLayoutViewData : LakeTahoeInfoBaseViewData
    {
        public readonly LakeTahoeInfoNavBarViewData LakeTahoeInfoNavBarViewData;
        public readonly bool ShowPageTitle;

        protected SiteLayoutViewData(Person currentPerson, bool isLogInPage, Models.ProjectFirmaPage projectFirmaPage, bool showPageTitle)
            : base(currentPerson, projectFirmaPage, LTInfoArea.LTInfo)
        {
            LakeTahoeInfoNavBarViewData = new LakeTahoeInfoNavBarViewData(currentPerson, isLogInPage, false, LogInUrl, LogOutUrl, RequestSupportUrl);
            ShowPageTitle = showPageTitle;
        }

        protected SiteLayoutViewData(Person currentPerson, bool isLogInPage)
            : this(currentPerson, isLogInPage, null, true)
        {
        }

        protected SiteLayoutViewData(Person currentPerson) : this(currentPerson, false, null, true)
        {
        }
    }
}