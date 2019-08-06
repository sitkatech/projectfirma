//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectContact
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectContactPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectContact>
    {
        public ProjectContactPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectContactPrimaryKey(ProjectContact projectContact) : base(projectContact){}

        public static implicit operator ProjectContactPrimaryKey(int primaryKeyValue)
        {
            return new ProjectContactPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectContactPrimaryKey(ProjectContact projectContact)
        {
            return new ProjectContactPrimaryKey(projectContact);
        }
    }
}