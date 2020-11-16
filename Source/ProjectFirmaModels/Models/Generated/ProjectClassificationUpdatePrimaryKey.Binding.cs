//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectClassificationUpdate
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectClassificationUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectClassificationUpdate>
    {
        public ProjectClassificationUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectClassificationUpdatePrimaryKey(ProjectClassificationUpdate projectClassificationUpdate) : base(projectClassificationUpdate){}

        public static implicit operator ProjectClassificationUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectClassificationUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectClassificationUpdatePrimaryKey(ProjectClassificationUpdate projectClassificationUpdate)
        {
            return new ProjectClassificationUpdatePrimaryKey(projectClassificationUpdate);
        }
    }
}