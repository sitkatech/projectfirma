//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYear]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ProjectExemptReportingYear]")]
    public partial class ProjectExemptReportingYear : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectExemptReportingYear()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExemptReportingYear(int projectExemptReportingYearID, int projectID, int calendarYear) : this()
        {
            this.ProjectExemptReportingYearID = projectExemptReportingYearID;
            this.ProjectID = projectID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExemptReportingYear(int projectID, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectExemptReportingYearID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectExemptReportingYear(Project project, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectExemptReportingYearID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectExemptReportingYears.Add(this);
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectExemptReportingYear CreateNewBlank(Project project)
        {
            return new ProjectExemptReportingYear(project, default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectExemptReportingYear).Name};

        [Key]
        public int ProjectExemptReportingYearID { get; set; }
        public int ProjectID { get; set; }
        public int CalendarYear { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProjectExemptReportingYearID; } set { ProjectExemptReportingYearID = value; } }

        public virtual Project Project { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}