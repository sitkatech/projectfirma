//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectFirmaPage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectFirmaPagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectFirmaPage>
    {
        public ProjectFirmaPagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectFirmaPagePrimaryKey(ProjectFirmaPage projectFirmaPage) : base(projectFirmaPage){}

        public static implicit operator ProjectFirmaPagePrimaryKey(int primaryKeyValue)
        {
            return new ProjectFirmaPagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectFirmaPagePrimaryKey(ProjectFirmaPage projectFirmaPage)
        {
            return new ProjectFirmaPagePrimaryKey(projectFirmaPage);
        }
    }
}