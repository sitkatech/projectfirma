//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasure]
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
    [Table("[dbo].[PerformanceMeasure]")]
    public partial class PerformanceMeasure : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasure()
        {
            this.IndicatorSubcategories = new HashSet<IndicatorSubcategory>();
            this.PerformanceMeasureActuals = new HashSet<PerformanceMeasureActual>();
            this.PerformanceMeasureActualSubcategoryOptions = new HashSet<PerformanceMeasureActualSubcategoryOption>();
            this.PerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<PerformanceMeasureActualSubcategoryOptionUpdate>();
            this.PerformanceMeasureActualUpdates = new HashSet<PerformanceMeasureActualUpdate>();
            this.PerformanceMeasureExpecteds = new HashSet<PerformanceMeasureExpected>();
            this.PerformanceMeasureExpectedProposeds = new HashSet<PerformanceMeasureExpectedProposed>();
            this.PerformanceMeasureExpectedSubcategoryOptions = new HashSet<PerformanceMeasureExpectedSubcategoryOption>();
            this.PerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<PerformanceMeasureExpectedSubcategoryOptionProposed>();
            this.ProgramPerformanceMeasures = new HashSet<ProgramPerformanceMeasure>();
            this.SnapshotPerformanceMeasures = new HashSet<SnapshotPerformanceMeasure>();
            this.SnapshotPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotPerformanceMeasureSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasure(int performanceMeasureID, int indicatorID, string criticalDefinitions, string accountingPeriodAndScale, string projectReporting) : this()
        {
            this.PerformanceMeasureID = performanceMeasureID;
            this.IndicatorID = indicatorID;
            this.CriticalDefinitions = criticalDefinitions;
            this.AccountingPeriodAndScale = accountingPeriodAndScale;
            this.ProjectReporting = projectReporting;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasure(int indicatorID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            PerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorID = indicatorID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasure(Indicator indicator) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorID = indicator.IndicatorID;
            this.Indicator = indicator;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasure CreateNewBlank(Indicator indicator)
        {
            return new PerformanceMeasure(indicator);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return IndicatorSubcategories.Any() || PerformanceMeasureActuals.Any() || PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureActualSubcategoryOptionUpdates.Any() || PerformanceMeasureActualUpdates.Any() || PerformanceMeasureExpecteds.Any() || PerformanceMeasureExpectedProposeds.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any() || PerformanceMeasureExpectedSubcategoryOptionProposeds.Any() || ProgramPerformanceMeasures.Any() || SnapshotPerformanceMeasures.Any() || SnapshotPerformanceMeasureSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasure).Name, typeof(IndicatorSubcategory).Name, typeof(PerformanceMeasureActual).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureActualUpdate).Name, typeof(PerformanceMeasureExpected).Name, typeof(PerformanceMeasureExpectedProposed).Name, typeof(PerformanceMeasureExpectedSubcategoryOption).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionProposed).Name, typeof(ProgramPerformanceMeasure).Name, typeof(SnapshotPerformanceMeasure).Name, typeof(SnapshotPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int PerformanceMeasureID { get; set; }
        public int IndicatorID { get; set; }
        [NotMapped]
        private string CriticalDefinitions { get; set; }
        public HtmlString CriticalDefinitionsHtmlString
        { 
            get { return CriticalDefinitions == null ? null : new HtmlString(CriticalDefinitions); }
            set { CriticalDefinitions = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string AccountingPeriodAndScale { get; set; }
        public HtmlString AccountingPeriodAndScaleHtmlString
        { 
            get { return AccountingPeriodAndScale == null ? null : new HtmlString(AccountingPeriodAndScale); }
            set { AccountingPeriodAndScale = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string ProjectReporting { get; set; }
        public HtmlString ProjectReportingHtmlString
        { 
            get { return ProjectReporting == null ? null : new HtmlString(ProjectReporting); }
            set { ProjectReporting = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return PerformanceMeasureID; } set { PerformanceMeasureID = value; } }

        public virtual ICollection<IndicatorSubcategory> IndicatorSubcategories { get; set; }
        public virtual ICollection<PerformanceMeasureActual> PerformanceMeasureActuals { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureActualUpdate> PerformanceMeasureActualUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpected> PerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedProposed> PerformanceMeasureExpectedProposeds { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionProposed> PerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ICollection<ProgramPerformanceMeasure> ProgramPerformanceMeasures { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasure> SnapshotPerformanceMeasures { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasureSubcategoryOption> SnapshotPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual Indicator Indicator { get; set; }

        public static class FieldLengths
        {

        }
    }
}