/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.Snapshot
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Snapshot Snapshot;
        public readonly List<Models.Project> ProjectsAdded;
        public readonly List<Models.Project> ProjectsUpdated;

        public readonly SnapshotProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public readonly List<Models.OrganizationType> OrganizationTypes;
        public readonly List<int> OrganizationTypeExpenditureCalendarYears;
        public readonly List<int> PerformanceMeasureCalendarYears;

        public readonly string SnapshotEditUrl;
        public readonly string SnapshotIndexUrl;

        public readonly bool UserHasSnapshotManagePermissions;

        public readonly PerformanceMeasureReportedValuesGroupedViewData SnapshotPerformanceMeasureReportedValuesGroupedViewData;

        public DetailViewData(Person currentPerson, Models.Snapshot snapshot, SnapshotProjectGridSpec gridSpec, PerformanceMeasureReportedValuesGroupedViewData snapshotPerformanceMeasureReportedValuesGroupedViewData) : base(currentPerson)
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

            OrganizationTypes = snapshot.SnapshotOrganizationTypeExpenditures.Select(x => x.OrganizationType).Distinct().OrderBy(x => x.OrganizationTypeName).ToList();
            OrganizationTypeExpenditureCalendarYears = snapshot.SnapshotOrganizationTypeExpenditures.Select(x => x.CalendarYear).Distinct().OrderBy(x => x).ToList();
            PerformanceMeasureCalendarYears = snapshot.SnapshotPerformanceMeasures.Select(x => x.CalendarYear).Distinct().OrderBy(x => x).ToList();

            SnapshotEditUrl = SitkaRoute<SnapshotController>.BuildUrlFromExpression(controller => controller.Edit(Snapshot.SnapshotID));
            SnapshotIndexUrl = SitkaRoute<SnapshotController>.BuildUrlFromExpression(controller => controller.Index());

            UserHasSnapshotManagePermissions = true;

            SnapshotPerformanceMeasureReportedValuesGroupedViewData = snapshotPerformanceMeasureReportedValuesGroupedViewData;
        }
    }
}
