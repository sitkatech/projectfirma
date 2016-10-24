using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProposedProjectImage
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.ProposedProjectImage ProposedProjectImage;

        public EditViewData(Models.ProposedProjectImage proposedProjectImage)
        {
            ProposedProjectImage = proposedProjectImage;
        }
    }
}