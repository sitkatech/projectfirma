//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFirmaPageType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectFirmaPageTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFirmaPageType>
    {
        public ProjectFirmaPageTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFirmaPageTypePrimaryKey(ProjectFirmaPageType projectFirmaPageType) : base(projectFirmaPageType){}

        public static implicit operator ProjectFirmaPageTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectFirmaPageTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFirmaPageTypePrimaryKey(ProjectFirmaPageType projectFirmaPageType)
        {
            return new ProjectFirmaPageTypePrimaryKey(projectFirmaPageType);
        }
    }
}