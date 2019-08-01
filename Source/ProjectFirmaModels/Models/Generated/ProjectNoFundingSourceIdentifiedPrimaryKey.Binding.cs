//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectNoFundingSourceIdentified
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectNoFundingSourceIdentifiedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectNoFundingSourceIdentified>
    {
        public ProjectNoFundingSourceIdentifiedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectNoFundingSourceIdentifiedPrimaryKey(ProjectNoFundingSourceIdentified projectNoFundingSourceIdentified) : base(projectNoFundingSourceIdentified){}

        public static implicit operator ProjectNoFundingSourceIdentifiedPrimaryKey(int primaryKeyValue)
        {
            return new ProjectNoFundingSourceIdentifiedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectNoFundingSourceIdentifiedPrimaryKey(ProjectNoFundingSourceIdentified projectNoFundingSourceIdentified)
        {
            return new ProjectNoFundingSourceIdentifiedPrimaryKey(projectNoFundingSourceIdentified);
        }
    }
}