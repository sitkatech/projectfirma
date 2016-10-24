//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationAreaGroup
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectLocationAreaGroupPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationAreaGroup>
    {
        public ProjectLocationAreaGroupPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationAreaGroupPrimaryKey(ProjectLocationAreaGroup projectLocationAreaGroup) : base(projectLocationAreaGroup){}

        public static implicit operator ProjectLocationAreaGroupPrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationAreaGroupPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationAreaGroupPrimaryKey(ProjectLocationAreaGroup projectLocationAreaGroup)
        {
            return new ProjectLocationAreaGroupPrimaryKey(projectLocationAreaGroup);
        }
    }
}