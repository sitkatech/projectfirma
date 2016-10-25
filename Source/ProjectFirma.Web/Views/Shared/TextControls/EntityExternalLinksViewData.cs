using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.TextControls
{
    public class EntityExternalLinksViewData : FirmaUserControlViewData
    {
        public readonly List<ExternalLink> ExternalLinks;

        public EntityExternalLinksViewData(List<ExternalLink> externalLinks)
        {
            ExternalLinks = externalLinks;
        }
    }
}