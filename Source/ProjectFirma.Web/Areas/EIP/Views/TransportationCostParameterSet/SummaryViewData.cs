using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationCostParameterSet
{
    public class SummaryViewData : EIPViewData
    {
        public readonly string EditTransportationCostParameterSet;
        public readonly Models.TransportationCostParameterSet TransportationCostParameterSet;
        public readonly bool HasEditPermissions;

        public SummaryViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage, Models.TransportationCostParameterSet transportationCostParameterSet)
            : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Transportation Cost Parameters";
            TransportationCostParameterSet = transportationCostParameterSet;            
            HasEditPermissions = new TransportationManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTransportationCostParameterSet = SitkaRoute<TransportationCostParameterSetController>.BuildUrlFromExpression(c => c.New());
        }        
    }
}