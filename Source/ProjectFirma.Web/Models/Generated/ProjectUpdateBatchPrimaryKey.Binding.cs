//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectUpdateBatch
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectUpdateBatchPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectUpdateBatch>
    {
        public ProjectUpdateBatchPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectUpdateBatchPrimaryKey(ProjectUpdateBatch projectUpdateBatch) : base(projectUpdateBatch){}

        public static implicit operator ProjectUpdateBatchPrimaryKey(int primaryKeyValue)
        {
            return new ProjectUpdateBatchPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectUpdateBatchPrimaryKey(ProjectUpdateBatch projectUpdateBatch)
        {
            return new ProjectUpdateBatchPrimaryKey(projectUpdateBatch);
        }
    }
}