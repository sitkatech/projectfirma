//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationArea
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectLocationAreaPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationArea>
    {
        public ProjectLocationAreaPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationAreaPrimaryKey(ProjectLocationArea projectLocationArea) : base(projectLocationArea){}

        public static implicit operator ProjectLocationAreaPrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationAreaPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationAreaPrimaryKey(ProjectLocationArea projectLocationArea)
        {
            return new ProjectLocationAreaPrimaryKey(projectLocationArea);
        }
    }
}