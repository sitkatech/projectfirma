//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationAreaWatershed
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectLocationAreaWatershedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationAreaWatershed>
    {
        public ProjectLocationAreaWatershedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationAreaWatershedPrimaryKey(ProjectLocationAreaWatershed projectLocationAreaWatershed) : base(projectLocationAreaWatershed){}

        public static implicit operator ProjectLocationAreaWatershedPrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationAreaWatershedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationAreaWatershedPrimaryKey(ProjectLocationAreaWatershed projectLocationAreaWatershed)
        {
            return new ProjectLocationAreaWatershedPrimaryKey(projectLocationAreaWatershed);
        }
    }
}