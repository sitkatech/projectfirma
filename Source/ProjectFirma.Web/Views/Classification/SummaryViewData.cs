using LtInfo.Common;
using ProjectFirma.Web.Views;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Classification
{
    public class SummaryViewData : FirmaViewData
    {
        public readonly Models.Classification Classification;
        public readonly string EditClassificationUrl;
        public readonly string IndexUrl;
        public readonly bool UserHasClassificationManagePermissions;

        public SummaryViewData(Person currentPerson, Models.Classification classification)
            : base(currentPerson)
        {
            PageTitle = classification.DisplayName;
            Classification = classification;
            EditClassificationUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.Edit(classification));
            IndexUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index());

            UserHasClassificationManagePermissions = new PerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);
        }
    }
}