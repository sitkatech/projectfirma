//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LeadAgencyRightOfWayCoverage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class LeadAgencyRightOfWayCoveragePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LeadAgencyRightOfWayCoverage>
    {
        public LeadAgencyRightOfWayCoveragePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LeadAgencyRightOfWayCoveragePrimaryKey(LeadAgencyRightOfWayCoverage leadAgencyRightOfWayCoverage) : base(leadAgencyRightOfWayCoverage){}

        public static implicit operator LeadAgencyRightOfWayCoveragePrimaryKey(int primaryKeyValue)
        {
            return new LeadAgencyRightOfWayCoveragePrimaryKey(primaryKeyValue);
        }

        public static implicit operator LeadAgencyRightOfWayCoveragePrimaryKey(LeadAgencyRightOfWayCoverage leadAgencyRightOfWayCoverage)
        {
            return new LeadAgencyRightOfWayCoveragePrimaryKey(leadAgencyRightOfWayCoverage);
        }
    }
}