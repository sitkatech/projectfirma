//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectExemptReportingType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectExemptReportingTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectExemptReportingType>
    {
        public ProjectExemptReportingTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectExemptReportingTypePrimaryKey(ProjectExemptReportingType projectExemptReportingType) : base(projectExemptReportingType){}

        public static implicit operator ProjectExemptReportingTypePrimaryKey(int primaryKeyValue)
        {
            return new ProjectExemptReportingTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectExemptReportingTypePrimaryKey(ProjectExemptReportingType projectExemptReportingType)
        {
            return new ProjectExemptReportingTypePrimaryKey(projectExemptReportingType);
        }
    }
}