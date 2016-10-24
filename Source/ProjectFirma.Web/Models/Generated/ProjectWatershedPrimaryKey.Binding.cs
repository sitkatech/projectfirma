//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectWatershed
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectWatershedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectWatershed>
    {
        public ProjectWatershedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectWatershedPrimaryKey(ProjectWatershed projectWatershed) : base(projectWatershed){}

        public static implicit operator ProjectWatershedPrimaryKey(int primaryKeyValue)
        {
            return new ProjectWatershedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectWatershedPrimaryKey(ProjectWatershed projectWatershed)
        {
            return new ProjectWatershedPrimaryKey(projectWatershed);
        }
    }
}