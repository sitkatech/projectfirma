//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFundingSourceExpenditureUpdate
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectFundingSourceExpenditureUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFundingSourceExpenditureUpdate>
    {
        public ProjectFundingSourceExpenditureUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFundingSourceExpenditureUpdatePrimaryKey(ProjectFundingSourceExpenditureUpdate projectFundingSourceExpenditureUpdate) : base(projectFundingSourceExpenditureUpdate){}

        public static implicit operator ProjectFundingSourceExpenditureUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectFundingSourceExpenditureUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFundingSourceExpenditureUpdatePrimaryKey(ProjectFundingSourceExpenditureUpdate projectFundingSourceExpenditureUpdate)
        {
            return new ProjectFundingSourceExpenditureUpdatePrimaryKey(projectFundingSourceExpenditureUpdate);
        }
    }
}