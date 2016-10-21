using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Snapshot
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson) : base(currentPerson)
        {
            PageTitle = "System Snapshot";

            GridSpec = new IndexGridSpec()
            {
                ObjectNameSingular = "Snapshot",
                ObjectNamePlural = "Snapshots",
                SaveFiltersInCookie = true
            };

            GridName = "SnapshotList";
            GridDataUrl = SitkaRoute<SnapshotController>.BuildUrlFromExpression(controller => controller.IndexGridJsonData());
        }
    }
}