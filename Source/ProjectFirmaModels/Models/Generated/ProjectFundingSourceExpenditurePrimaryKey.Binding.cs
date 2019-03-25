//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFundingSourceExpenditure
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceExpenditurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFundingSourceExpenditure>
    {
        public ProjectFundingSourceExpenditurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFundingSourceExpenditurePrimaryKey(ProjectFundingSourceExpenditure projectFundingSourceExpenditure) : base(projectFundingSourceExpenditure){}

        public static implicit operator ProjectFundingSourceExpenditurePrimaryKey(int primaryKeyValue)
        {
            return new ProjectFundingSourceExpenditurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFundingSourceExpenditurePrimaryKey(ProjectFundingSourceExpenditure projectFundingSourceExpenditure)
        {
            return new ProjectFundingSourceExpenditurePrimaryKey(projectFundingSourceExpenditure);
        }
    }
}