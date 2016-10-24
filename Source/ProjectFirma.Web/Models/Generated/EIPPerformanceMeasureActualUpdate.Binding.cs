//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureActualUpdate]
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
    [Table("[dbo].[EIPPerformanceMeasureActualUpdate]")]
    public partial class EIPPerformanceMeasureActualUpdate : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasureActualUpdate()
        {
            this.EIPPerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<EIPPerformanceMeasureActualSubcategoryOptionUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualUpdate(int eIPPerformanceMeasureActualUpdateID, int projectUpdateBatchID, int eIPPerformanceMeasureID, int calendarYear, double? actualValue) : this()
        {
            this.EIPPerformanceMeasureActualUpdateID = eIPPerformanceMeasureActualUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureActualUpdate(int projectUpdateBatchID, int eIPPerformanceMeasureID, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureActualUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasureActualUpdate(ProjectUpdateBatch projectUpdateBatch, EIPPerformanceMeasure eIPPerformanceMeasure, int calendarYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureActualUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.EIPPerformanceMeasureActualUpdates.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.EIPPerformanceMeasureActualUpdates.Add(this);
            this.CalendarYear = calendarYear;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasureActualUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, EIPPerformanceMeasure eIPPerformanceMeasure)
        {
            return new EIPPerformanceMeasureActualUpdate(projectUpdateBatch, eIPPerformanceMeasure, default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EIPPerformanceMeasureActualSubcategoryOptionUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasureActualUpdate).Name, typeof(EIPPerformanceMeasureActualSubcategoryOptionUpdate).Name};

        [Key]
        public int EIPPerformanceMeasureActualUpdateID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int CalendarYear { get; set; }
        public double? ActualValue { get; set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureActualUpdateID; } set { EIPPerformanceMeasureActualUpdateID = value; } }

        public virtual ICollection<EIPPerformanceMeasureActualSubcategoryOptionUpdate> EIPPerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}