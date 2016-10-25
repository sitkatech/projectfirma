using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.TransportationCostParameterSet
{
    public class SummaryViewData : FirmaViewData
    {
        public readonly string EditTransportationCostParameterSet;
        public readonly Models.TransportationCostParameterSet TransportationCostParameterSet;
        public readonly bool HasEditPermissions;

        public SummaryViewData(Person currentPerson, Models.FirmaPage firmaPage, Models.TransportationCostParameterSet transportationCostParameterSet)
            : base(currentPerson, firmaPage)
        {
            PageTitle = "Transportation Cost Parameters";
            TransportationCostParameterSet = transportationCostParameterSet;            
            HasEditPermissions = new TransportationManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTransportationCostParameterSet = SitkaRoute<TransportationCostParameterSetController>.BuildUrlFromExpression(c => c.New());
        }        
    }
}