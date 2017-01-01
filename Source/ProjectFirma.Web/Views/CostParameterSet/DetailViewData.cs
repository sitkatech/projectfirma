using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.CostParameterSet
{
    public class DetailViewData : FirmaViewData
    {
        public readonly string EditCostParameterSet;
        public readonly Models.CostParameterSet CostParameterSet;
        public readonly bool HasEditPermissions;

        public DetailViewData(Person currentPerson, Models.FirmaPage firmaPage, Models.CostParameterSet costParameterSet)
            : base(currentPerson, firmaPage)
        {
            PageTitle = " Cost Parameters";
            CostParameterSet = costParameterSet;            
            HasEditPermissions = new AssessmentManageFeature().HasPermissionByPerson(CurrentPerson);
            EditCostParameterSet = SitkaRoute<CostParameterSetController>.BuildUrlFromExpression(c => c.New());
        }        
    }
}