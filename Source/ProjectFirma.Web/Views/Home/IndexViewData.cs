using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Home
{
    public class IndexViewData : LakeTahoeInfoBaseViewData
    {
        public readonly LakeTahoeInfoNavBarViewData LakeTahoeInfoNavBarViewData;

        public IndexViewData(Person currentPerson) : base(currentPerson, LTInfoArea.LTInfo)
        {
            PageTitle = "Lake Tahoe Info";
            LakeTahoeInfoNavBarViewData = new LakeTahoeInfoNavBarViewData(currentPerson, false, true, LogInUrl, LogOutUrl, RequestSupportUrl);
        }
    }
}