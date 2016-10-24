//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectLocationAreaJurisdiction
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectLocationAreaJurisdictionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectLocationAreaJurisdiction>
    {
        public ProjectLocationAreaJurisdictionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectLocationAreaJurisdictionPrimaryKey(ProjectLocationAreaJurisdiction projectLocationAreaJurisdiction) : base(projectLocationAreaJurisdiction){}

        public static implicit operator ProjectLocationAreaJurisdictionPrimaryKey(int primaryKeyValue)
        {
            return new ProjectLocationAreaJurisdictionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectLocationAreaJurisdictionPrimaryKey(ProjectLocationAreaJurisdiction projectLocationAreaJurisdiction)
        {
            return new ProjectLocationAreaJurisdictionPrimaryKey(projectLocationAreaJurisdiction);
        }
    }
}