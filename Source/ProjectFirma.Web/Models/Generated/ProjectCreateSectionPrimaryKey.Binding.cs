//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectCreateSection
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectCreateSectionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectCreateSection>
    {
        public ProjectCreateSectionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectCreateSectionPrimaryKey(ProjectCreateSection projectCreateSection) : base(projectCreateSection){}

        public static implicit operator ProjectCreateSectionPrimaryKey(int primaryKeyValue)
        {
            return new ProjectCreateSectionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectCreateSectionPrimaryKey(ProjectCreateSection projectCreateSection)
        {
            return new ProjectCreateSectionPrimaryKey(projectCreateSection);
        }
    }
}