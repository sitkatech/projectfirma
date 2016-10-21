using ProjectFirma.Web.Areas.Threshold.Views.Shared;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views
{
    public abstract class ThresholdViewData : LakeTahoeInfoBaseViewData
    {
        public readonly ThresholdNavBarViewData ThresholdNavBarViewData;

        protected ThresholdViewData(Person currentPerson, ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage, LTInfoArea.Threshold)
        {
            ThresholdNavBarViewData = new ThresholdNavBarViewData(currentPerson, false, false, LogInUrl, LogOutUrl, RequestSupportUrl);
        }

        protected ThresholdViewData(Person currentPerson) : this(currentPerson, null)
        {
        }
    }
}