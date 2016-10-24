//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotEIPPerformanceMeasure]
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
    [Table("[dbo].[SnapshotEIPPerformanceMeasure]")]
    public partial class SnapshotEIPPerformanceMeasure : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SnapshotEIPPerformanceMeasure()
        {
            this.SnapshotEIPPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotEIPPerformanceMeasureSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotEIPPerformanceMeasure(int snapshotEIPPerformanceMeasureID, int snapshotID, int eIPPerformanceMeasureID, int calendarYear, double actualValue) : this()
        {
            this.SnapshotEIPPerformanceMeasureID = snapshotEIPPerformanceMeasureID;
            this.SnapshotID = snapshotID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotEIPPerformanceMeasure(int snapshotID, int eIPPerformanceMeasureID, int calendarYear, double actualValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            SnapshotEIPPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SnapshotID = snapshotID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SnapshotEIPPerformanceMeasure(Snapshot snapshot, EIPPerformanceMeasure eIPPerformanceMeasure, int calendarYear, double actualValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotEIPPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SnapshotID = snapshot.SnapshotID;
            this.Snapshot = snapshot;
            snapshot.SnapshotEIPPerformanceMeasures.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.SnapshotEIPPerformanceMeasures.Add(this);
            this.CalendarYear = calendarYear;
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SnapshotEIPPerformanceMeasure CreateNewBlank(Snapshot snapshot, EIPPerformanceMeasure eIPPerformanceMeasure)
        {
            return new SnapshotEIPPerformanceMeasure(snapshot, eIPPerformanceMeasure, default(int), default(double));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SnapshotEIPPerformanceMeasureSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SnapshotEIPPerformanceMeasure).Name, typeof(SnapshotEIPPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int SnapshotEIPPerformanceMeasureID { get; set; }
        public int SnapshotID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public int CalendarYear { get; set; }
        public double ActualValue { get; set; }
        public int PrimaryKey { get { return SnapshotEIPPerformanceMeasureID; } set { SnapshotEIPPerformanceMeasureID = value; } }

        public virtual ICollection<SnapshotEIPPerformanceMeasureSubcategoryOption> SnapshotEIPPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual Snapshot Snapshot { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}