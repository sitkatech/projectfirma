//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureActualUpdate]
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
    [Table("[dbo].[PerformanceMeasureActualUpdate]")]
    public partial class PerformanceMeasureActualUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureActualUpdate()
        {
            this.PerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<PerformanceMeasureActualSubcategoryOptionUpdate>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualUpdate(int performanceMeasureActualUpdateID, int projectUpdateBatchID, int performanceMeasureID, int calendarYear, double? actualValue) : this()
        {
            this.PerformanceMeasureActualUpdateID = performanceMeasureActualUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualUpdate(int projectUpdateBatchID, int performanceMeasureID, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureActualUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureActualUpdate(ProjectUpdateBatch projectUpdateBatch, PerformanceMeasure performanceMeasure, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureActualUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.PerformanceMeasureActualUpdates.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureActualUpdates.Add(this);
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureActualUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, PerformanceMeasure performanceMeasure)
        {
            return new PerformanceMeasureActualUpdate(projectUpdateBatch, performanceMeasure, default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureActualSubcategoryOptionUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureActualUpdate).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name};

        [Key]
        public int PerformanceMeasureActualUpdateID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectUpdateBatchID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int CalendarYear { get; set; }
        public double? ActualValue { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureActualUpdateID; } set { PerformanceMeasureActualUpdateID = value; } }

        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}