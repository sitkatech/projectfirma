using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class IndexViewData : FirmaViewData
    {
        public readonly PerformanceMeasureGridSpec PerformanceMeasureGridSpec;
        public readonly string PerformanceMeasureGridName;
        public readonly string PerformanceMeasureGridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            PageTitle = MultiTenantHelpers.GetPerformanceMeasureNamePluralized();

            PerformanceMeasureGridSpec = new PerformanceMeasureGridSpec {
                ObjectNameSingular = MultiTenantHelpers.GetPerformanceMeasureName(),
                ObjectNamePlural = MultiTenantHelpers.GetPerformanceMeasureNamePluralized(),
                SaveFiltersInCookie = true
            };

            var hasPerformanceMeasureManagePermissions = new PerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);
            if (hasPerformanceMeasureManagePermissions)
            {
                var contentUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.New());
                PerformanceMeasureGridSpec.CreateEntityModalDialogForm = new ModalDialogForm(contentUrl, "Create a new Performance Measure");
            }

            PerformanceMeasureGridName = "performanceMeasuresGrid";
            PerformanceMeasureGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.PerformanceMeasureGridJsonData());
        }
    }
}