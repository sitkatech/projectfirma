//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectWatershedUpdate
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectWatershedUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectWatershedUpdate>
    {
        public ProjectWatershedUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectWatershedUpdatePrimaryKey(ProjectWatershedUpdate projectWatershedUpdate) : base(projectWatershedUpdate){}

        public static implicit operator ProjectWatershedUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectWatershedUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectWatershedUpdatePrimaryKey(ProjectWatershedUpdate projectWatershedUpdate)
        {
            return new ProjectWatershedUpdatePrimaryKey(projectWatershedUpdate);
        }
    }
}