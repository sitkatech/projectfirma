using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReleaseNoteModelExtensions
    {
        public static string GetDeleteUrl(this ReleaseNote releaseNote)
        {
            return SitkaRoute<ReleaseNoteController>.BuildUrlFromExpression(c => c.DeleteReleaseNote(releaseNote.ReleaseNoteID));
        }

        public static string GetEditUrl(this ReleaseNote releaseNote)
        {
            return SitkaRoute<ReleaseNoteController>.BuildUrlFromExpression(c => c.Edit(releaseNote.ReleaseNoteID));
        }
    }
}