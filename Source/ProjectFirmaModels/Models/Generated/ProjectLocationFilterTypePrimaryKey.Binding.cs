//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationFilterType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectLocationFilterTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationFilterType>
    {
        public ProjectLocationFilterTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationFilterTypePrimaryKey(ProjectLocationFilterType projectLocationFilterType) : base(projectLocationFilterType){}

        public static implicit operator ProjectLocationFilterTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationFilterTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationFilterTypePrimaryKey(ProjectLocationFilterType projectLocationFilterType)
        {
            return new ProjectLocationFilterTypePrimaryKey(projectLocationFilterType);
        }
    }
}