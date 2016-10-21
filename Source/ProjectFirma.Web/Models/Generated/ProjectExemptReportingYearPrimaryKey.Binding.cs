//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProjectExemptReportingYear
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectExemptReportingYearPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProjectExemptReportingYear>
    {
        public ProjectExemptReportingYearPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProjectExemptReportingYearPrimaryKey(ProjectExemptReportingYear projectExemptReportingYear) : base(projectExemptReportingYear){}

        public static implicit operator ProjectExemptReportingYearPrimaryKey(int primaryKeyValue)
        {
            return new ProjectExemptReportingYearPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProjectExemptReportingYearPrimaryKey(ProjectExemptReportingYear projectExemptReportingYear)
        {
            return new ProjectExemptReportingYearPrimaryKey(projectExemptReportingYear);
        }
    }
}