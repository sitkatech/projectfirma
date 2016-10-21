//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectImageUpdate
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectImageUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectImageUpdate>
    {
        public ProjectImageUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectImageUpdatePrimaryKey(ProjectImageUpdate projectImageUpdate) : base(projectImageUpdate){}

        public static implicit operator ProjectImageUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectImageUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectImageUpdatePrimaryKey(ProjectImageUpdate projectImageUpdate)
        {
            return new ProjectImageUpdatePrimaryKey(projectImageUpdate);
        }
    }
}