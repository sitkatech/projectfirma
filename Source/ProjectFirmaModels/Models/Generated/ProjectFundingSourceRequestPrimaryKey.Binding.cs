//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFundingSourceRequest
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceRequestPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFundingSourceRequest>
    {
        public ProjectFundingSourceRequestPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFundingSourceRequestPrimaryKey(ProjectFundingSourceRequest projectFundingSourceRequest) : base(projectFundingSourceRequest){}

        public static implicit operator ProjectFundingSourceRequestPrimaryKey(int primaryKeyValue)
        {
            return new ProjectFundingSourceRequestPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFundingSourceRequestPrimaryKey(ProjectFundingSourceRequest projectFundingSourceRequest)
        {
            return new ProjectFundingSourceRequestPrimaryKey(projectFundingSourceRequest);
        }
    }
}