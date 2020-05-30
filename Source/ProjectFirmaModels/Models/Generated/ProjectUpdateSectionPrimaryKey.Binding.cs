//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectUpdateSection
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectUpdateSectionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectUpdateSection>
    {
        public ProjectUpdateSectionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectUpdateSectionPrimaryKey(ProjectUpdateSection projectUpdateSection) : base(projectUpdateSection){}

        public static implicit operator ProjectUpdateSectionPrimaryKey(int primaryKeyValue)
        {
            return new ProjectUpdateSectionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectUpdateSectionPrimaryKey(ProjectUpdateSection projectUpdateSection)
        {
            return new ProjectUpdateSectionPrimaryKey(projectUpdateSection);
        }
    }
}