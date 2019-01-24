//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectExemptReportingYearUpdate
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectExemptReportingYearUpdatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectExemptReportingYearUpdate>
    {
        public ProjectExemptReportingYearUpdatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectExemptReportingYearUpdatePrimaryKey(ProjectExemptReportingYearUpdate projectExemptReportingYearUpdate) : base(projectExemptReportingYearUpdate){}

        public static implicit operator ProjectExemptReportingYearUpdatePrimaryKey(int primaryKeyValue)
        {
            return new ProjectExemptReportingYearUpdatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectExemptReportingYearUpdatePrimaryKey(ProjectExemptReportingYearUpdate projectExemptReportingYearUpdate)
        {
            return new ProjectExemptReportingYearUpdatePrimaryKey(projectExemptReportingYearUpdate);
        }
    }
}