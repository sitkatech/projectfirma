//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFundingSourceRequestUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceRequestUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFundingSourceRequestUpdate>
    {
        public ProjectFundingSourceRequestUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFundingSourceRequestUpdatePrimaryKey(ProjectFundingSourceRequestUpdate projectFundingSourceRequestUpdate) : base(projectFundingSourceRequestUpdate){}

        public static implicit operator ProjectFundingSourceRequestUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectFundingSourceRequestUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFundingSourceRequestUpdatePrimaryKey(ProjectFundingSourceRequestUpdate projectFundingSourceRequestUpdate)
        {
            return new ProjectFundingSourceRequestUpdatePrimaryKey(projectFundingSourceRequestUpdate);
        }
    }
}