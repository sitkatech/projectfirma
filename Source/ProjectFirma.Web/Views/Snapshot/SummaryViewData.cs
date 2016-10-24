using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Snapshot
{
    public class SummaryViewData : EIPViewData
    {
        public readonly Models.Snapshot Snapshot;
        public readonly List<Models.Project> ProjectsAdded;
        public readonly List<Models.Project> ProjectsUpdated;

        public readonly SnapshotProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public readonly List<Sector> Sectors;
        public readonly List<int> SectorExpenditureCalendarYears;
        public readonly List<int> PerformanceMeasureCalendarYears;

        public readonly string SnapshotEditUrl;
        public readonly string SnapshotIndexUrl;

        public readonly bool UserHasSnapshotManagePermissions;

        public readonly EIPPerformanceMeasureReportedValuesGroupedViewData SnapshotPerformanceMeasureReportedValuesGroupedViewData;

        public SummaryViewData(Person currentPerson, Models.Snapshot snapshot, SnapshotProjectGridSpec gridSpec, EIPPerformanceMeasureReportedValuesGroupedViewData snapshotPerformanceMeasureReportedValuesGroupedViewData) : base(currentPerson)
        {
            Snapshot = snapshot;
            ProjectsAdded =
                Snapshot.SnapshotProjects.Where(snapshotProject => snapshotProject.SnapshotProjectType == SnapshotProjectType.Added).Select(snapshotProject => snapshotProject.Project).ToList();
            ProjectsUpdated =
                Snapshot.SnapshotProjects.Where(snapshotProject => snapshotProject.SnapshotProjectType == SnapshotProjectType.Updated).Select(snapshotProject => snapshotProject.Project).ToList();
            
            GridSpec = gridSpec;
            GridName = "SnapshotProjectGrid";
            GridDataUrl = SitkaRoute<SnapshotController>.BuildUrlFromExpression(controller => controller.SnapshotProjectGridJsonData(Snapshot.SnapshotID));

            PageTitle = snapshot.GetDisplayName();
            EntityName = "Snapshot";

            Sectors = snapshot.SnapshotSectorExpenditures.Select(x => x.Sector).Distinct().OrderBy(x => x.SectorDisplayName).ToList();
            SectorExpenditureCalendarYears = snapshot.SnapshotSectorExpenditures.Select(x => x.CalendarYear).Distinct().OrderBy(x => x).ToList();
            PerformanceMeasureCalendarYears = snapshot.SnapshotEIPPerformanceMeasures.Select(x => x.CalendarYear).Distinct().OrderBy(x => x).ToList();

            SnapshotEditUrl = SitkaRoute<SnapshotController>.BuildUrlFromExpression(controller => controller.Edit(Snapshot.SnapshotID));
            SnapshotIndexUrl = SitkaRoute<SnapshotController>.BuildUrlFromExpression(controller => controller.Index());

            UserHasSnapshotManagePermissions = true;

            SnapshotPerformanceMeasureReportedValuesGroupedViewData = snapshotPerformanceMeasureReportedValuesGroupedViewData;
        }
    }
}