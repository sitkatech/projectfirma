using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Snapshot
{
    public class IndexGridSpec : GridSpec<Models.Snapshot>
    {
        public IndexGridSpec()
        {
            Add(string.Empty,
                snapshot => UrlTemplate.MakeHrefString(snapshot.GetSummaryUrl(), "View", new Dictionary<string, string>() {{"class", "gridButton"}}),
                50,
                DhtmlxGridColumnFilterType.None);
            
            Add("Snapshot Date", snapshot => snapshot.SnapshotDate, 125, DhtmlxGridColumnFormatType.Date);
            Add("Snapshot Note", snapshot => snapshot.SnapshotNote, 300);
            Add("Projects Added", snapshot => snapshot.SnapshotProjects.Count(snapshotProject => snapshotProject.SnapshotProjectType == SnapshotProjectType.Added), 75);
            Add("Projects Updated", snapshot => snapshot.SnapshotProjects.Count(snapshotProject => snapshotProject.SnapshotProjectType == SnapshotProjectType.Updated), 75);
            Add("Total Projects", snapshot => snapshot.ProjectCount, 75);
        }
    }
}