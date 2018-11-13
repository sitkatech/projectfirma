//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectStewardshipAreaType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectStewardshipAreaTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectStewardshipAreaType>
    {
        public ProjectStewardshipAreaTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectStewardshipAreaTypePrimaryKey(ProjectStewardshipAreaType projectStewardshipAreaType) : base(projectStewardshipAreaType){}

        public static implicit operator ProjectStewardshipAreaTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectStewardshipAreaTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectStewardshipAreaTypePrimaryKey(ProjectStewardshipAreaType projectStewardshipAreaType)
        {
            return new ProjectStewardshipAreaTypePrimaryKey(projectStewardshipAreaType);
        }
    }
}