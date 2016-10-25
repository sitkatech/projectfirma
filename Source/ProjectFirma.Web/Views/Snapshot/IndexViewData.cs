using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Snapshot
{
    public class IndexViewData : FirmaViewData
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