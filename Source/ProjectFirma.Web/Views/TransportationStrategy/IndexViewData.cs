using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.TransportationStrategy
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Transportation Strategies";

            var hasTransportationStrategyManagePermissions = new TransportationStrategyManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTransportationStrategyManagePermissions)
            {
                ObjectNameSingular = "Transportation Strategy",
                ObjectNamePlural = "Transportation Strategies",
                SaveFiltersInCookie = true
            };

            if (hasTransportationStrategyManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(t => t.New()), "Create a new Transportation Strategy");
            }

            GridName = "transportationStrategiesGrid";
            GridDataUrl = SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}