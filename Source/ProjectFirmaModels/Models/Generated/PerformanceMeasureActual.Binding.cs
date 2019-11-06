//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActual]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[PerformanceMeasureActual] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PerformanceMeasureActual]")]
    public partial class PerformanceMeasureActual : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureActual()
        {
            this.PerformanceMeasureActualSubcategoryOptions = new HashSet<PerformanceMeasureActualSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActual(int performanceMeasureActualID, int projectID, int performanceMeasureID, double actualValue, int performanceMeasureReportingPeriodID) : this()
        {
            this.PerformanceMeasureActualID = performanceMeasureActualID;
            this.ProjectID = projectID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.ActualValue = actualValue;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActual(int projectID, int performanceMeasureID, double actualValue, int performanceMeasureReportingPeriodID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureActualID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.ActualValue = actualValue;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureActual(Project project, PerformanceMeasure performanceMeasure, double actualValue, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureActualID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.PerformanceMeasureActuals.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureActuals.Add(this);
            this.ActualValue = actualValue;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID;
            this.PerformanceMeasureReportingPeriod = performanceMeasureReportingPeriod;
            performanceMeasureReportingPeriod.PerformanceMeasureActuals.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureActual CreateNewBlank(Project project, PerformanceMeasure performanceMeasure, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod)
        {
            return new PerformanceMeasureActual(project, performanceMeasure, default(double), performanceMeasureReportingPeriod);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureActualSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureActual).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPerformanceMeasureActuals.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in PerformanceMeasureActualSubcategoryOptions.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PerformanceMeasureActualID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double ActualValue { get; set; }
        public int PerformanceMeasureReportingPeriodID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureActualID; } set { PerformanceMeasureActualID = value; } }

        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual PerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod { get; set; }

        public static class FieldLengths
        {

        }
    }
}