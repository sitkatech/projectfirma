//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectUpdateBatchClassificationSystem
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateBatchClassificationSystemPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectUpdateBatchClassificationSystem>
    {
        public ProjectUpdateBatchClassificationSystemPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectUpdateBatchClassificationSystemPrimaryKey(ProjectUpdateBatchClassificationSystem projectUpdateBatchClassificationSystem) : base(projectUpdateBatchClassificationSystem){}

        public static implicit operator ProjectUpdateBatchClassificationSystemPrimaryKey(int primaryKeyValue)
        {
            return new ProjectUpdateBatchClassificationSystemPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectUpdateBatchClassificationSystemPrimaryKey(ProjectUpdateBatchClassificationSystem projectUpdateBatchClassificationSystem)
        {
            return new ProjectUpdateBatchClassificationSystemPrimaryKey(projectUpdateBatchClassificationSystem);
        }
    }
}