//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFirmaPageRenderType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectFirmaPageRenderTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFirmaPageRenderType>
    {
        public ProjectFirmaPageRenderTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFirmaPageRenderTypePrimaryKey(ProjectFirmaPageRenderType projectFirmaPageRenderType) : base(projectFirmaPageRenderType){}

        public static implicit operator ProjectFirmaPageRenderTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectFirmaPageRenderTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFirmaPageRenderTypePrimaryKey(ProjectFirmaPageRenderType projectFirmaPageRenderType)
        {
            return new ProjectFirmaPageRenderTypePrimaryKey(projectFirmaPageRenderType);
        }
    }
}