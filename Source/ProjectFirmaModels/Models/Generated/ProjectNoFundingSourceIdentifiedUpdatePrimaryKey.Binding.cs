//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectNoFundingSourceIdentifiedUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectNoFundingSourceIdentifiedUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectNoFundingSourceIdentifiedUpdate>
    {
        public ProjectNoFundingSourceIdentifiedUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectNoFundingSourceIdentifiedUpdatePrimaryKey(ProjectNoFundingSourceIdentifiedUpdate projectNoFundingSourceIdentifiedUpdate) : base(projectNoFundingSourceIdentifiedUpdate){}

        public static implicit operator ProjectNoFundingSourceIdentifiedUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectNoFundingSourceIdentifiedUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectNoFundingSourceIdentifiedUpdatePrimaryKey(ProjectNoFundingSourceIdentifiedUpdate projectNoFundingSourceIdentifiedUpdate)
        {
            return new ProjectNoFundingSourceIdentifiedUpdatePrimaryKey(projectNoFundingSourceIdentifiedUpdate);
        }
    }
}