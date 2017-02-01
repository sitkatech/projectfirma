//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYearUpdate]
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
    [Table("[dbo].[ProjectExemptReportingYearUpdate]")]
    public partial class ProjectExemptReportingYearUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectExemptReportingYearUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExemptReportingYearUpdate(int projectExemptReportingYearUpdateID, int projectUpdateBatchID, int calendarYear) : this()
        {
            this.ProjectExemptReportingYearUpdateID = projectExemptReportingYearUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectExemptReportingYearUpdate(int projectUpdateBatchID, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectExemptReportingYearUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectExemptReportingYearUpdate(ProjectUpdateBatch projectUpdateBatch, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectExemptReportingYearUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectExemptReportingYearUpdates.Add(this);
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectExemptReportingYearUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch)
        {
            return new ProjectExemptReportingYearUpdate(projectUpdateBatch, default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectExemptReportingYearUpdate).Name};

        [Key]
        public int ProjectExemptReportingYearUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int CalendarYear { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProjectExemptReportingYearUpdateID; } set { ProjectExemptReportingYearUpdateID = value; } }

        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}