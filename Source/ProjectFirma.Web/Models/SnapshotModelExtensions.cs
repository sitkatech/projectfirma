using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class SnapshotModelExtensions
    {
        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<SnapshotController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));

        public static string GetSummaryUrl(this Snapshot snapshot)
        {
            return SummaryUrlTemplate.ParameterReplace(snapshot.SnapshotID);
        }

        public static string GetDisplayName(this Snapshot snapshot)
        {
            return string.Format("Snapshot Summary - {0}", snapshot.SnapshotDate.ToLongDateString());
        }
    }
}