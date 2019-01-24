using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureNoteModelExtensions
    {
        public static string GetDeleteUrl(PerformanceMeasureNote performanceMeasureNote)
        {
            return SitkaRoute<PerformanceMeasureNoteController>.BuildUrlFromExpression(c =>
                c.DeletePerformanceMeasureNote(performanceMeasureNote.PerformanceMeasureNoteID));
        }

        public static string GetEditUrl(PerformanceMeasureNote performanceMeasureNote)
        {
            return SitkaRoute<PerformanceMeasureNoteController>.BuildUrlFromExpression(c => c.Edit(performanceMeasureNote.PerformanceMeasureNoteID));
        }
    }
}