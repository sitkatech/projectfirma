//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasure]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[EIPPerformanceMeasure]")]
    public partial class EIPPerformanceMeasure : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasure()
        {
            this.EIPPerformanceMeasureActuals = new HashSet<EIPPerformanceMeasureActual>();
            this.EIPPerformanceMeasureActualSubcategoryOptions = new HashSet<EIPPerformanceMeasureActualSubcategoryOption>();
            this.EIPPerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<EIPPerformanceMeasureActualSubcategoryOptionUpdate>();
            this.EIPPerformanceMeasureActualUpdates = new HashSet<EIPPerformanceMeasureActualUpdate>();
            this.EIPPerformanceMeasureExpecteds = new HashSet<EIPPerformanceMeasureExpected>();
            this.EIPPerformanceMeasureExpectedProposeds = new HashSet<EIPPerformanceMeasureExpectedProposed>();
            this.EIPPerformanceMeasureExpectedSubcategoryOptions = new HashSet<EIPPerformanceMeasureExpectedSubcategoryOption>();
            this.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<EIPPerformanceMeasureExpectedSubcategoryOptionProposed>();
            this.IndicatorSubcategories = new HashSet<IndicatorSubcategory>();
            this.ProgramEIPPerformanceMeasures = new HashSet<ProgramEIPPerformanceMeasure>();
            this.SnapshotEIPPerformanceMeasures = new HashSet<SnapshotEIPPerformanceMeasure>();
            this.SnapshotEIPPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotEIPPerformanceMeasureSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasure(int eIPPerformanceMeasureID, int indicatorID, int eIPPerformanceMeasureTypeID, string criticalDefinitions, string accountingPeriodAndScale, string projectReporting, string eIPContext) : this()
        {
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IndicatorID = indicatorID;
            this.EIPPerformanceMeasureTypeID = eIPPerformanceMeasureTypeID;
            this.CriticalDefinitions = criticalDefinitions;
            this.AccountingPeriodAndScale = accountingPeriodAndScale;
            this.ProjectReporting = projectReporting;
            this.EIPContext = eIPContext;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasure(int indicatorID, int eIPPerformanceMeasureTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorID = indicatorID;
            this.EIPPerformanceMeasureTypeID = eIPPerformanceMeasureTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasure(Indicator indicator, EIPPerformanceMeasureType eIPPerformanceMeasureType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorID = indicator.IndicatorID;
            this.Indicator = indicator;
            this.EIPPerformanceMeasureTypeID = eIPPerformanceMeasureType.EIPPerformanceMeasureTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasure CreateNewBlank(Indicator indicator, EIPPerformanceMeasureType eIPPerformanceMeasureType)
        {
            return new EIPPerformanceMeasure(indicator, eIPPerformanceMeasureType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EIPPerformanceMeasureActuals.Any() || EIPPerformanceMeasureActualSubcategoryOptions.Any() || EIPPerformanceMeasureActualSubcategoryOptionUpdates.Any() || EIPPerformanceMeasureActualUpdates.Any() || EIPPerformanceMeasureExpecteds.Any() || EIPPerformanceMeasureExpectedProposeds.Any() || EIPPerformanceMeasureExpectedSubcategoryOptions.Any() || EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Any() || IndicatorSubcategories.Any() || ProgramEIPPerformanceMeasures.Any() || SnapshotEIPPerformanceMeasures.Any() || SnapshotEIPPerformanceMeasureSubcategoryOptions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasure).Name, typeof(EIPPerformanceMeasureActual).Name, typeof(EIPPerformanceMeasureActualSubcategoryOption).Name, typeof(EIPPerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(EIPPerformanceMeasureActualUpdate).Name, typeof(EIPPerformanceMeasureExpected).Name, typeof(EIPPerformanceMeasureExpectedProposed).Name, typeof(EIPPerformanceMeasureExpectedSubcategoryOption).Name, typeof(EIPPerformanceMeasureExpectedSubcategoryOptionProposed).Name, typeof(IndicatorSubcategory).Name, typeof(ProgramEIPPerformanceMeasure).Name, typeof(SnapshotEIPPerformanceMeasure).Name, typeof(SnapshotEIPPerformanceMeasureSubcategoryOption).Name};

        [Key]
        public int EIPPerformanceMeasureID { get; set; }
        public int IndicatorID { get; set; }
        public int EIPPerformanceMeasureTypeID { get; set; }
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
        [NotMapped]
        private string EIPContext { get; set; }
        public HtmlString EIPContextHtmlString
        { 
            get { return EIPContext == null ? null : new HtmlString(EIPContext); }
            set { EIPContext = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return EIPPerformanceMeasureID; } set { EIPPerformanceMeasureID = value; } }

        public virtual ICollection<EIPPerformanceMeasureActual> EIPPerformanceMeasureActuals { get; set; }
        public virtual ICollection<EIPPerformanceMeasureActualSubcategoryOption> EIPPerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<EIPPerformanceMeasureActualSubcategoryOptionUpdate> EIPPerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<EIPPerformanceMeasureActualUpdate> EIPPerformanceMeasureActualUpdates { get; set; }
        public virtual ICollection<EIPPerformanceMeasureExpected> EIPPerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<EIPPerformanceMeasureExpectedProposed> EIPPerformanceMeasureExpectedProposeds { get; set; }
        public virtual ICollection<EIPPerformanceMeasureExpectedSubcategoryOption> EIPPerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> EIPPerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ICollection<IndicatorSubcategory> IndicatorSubcategories { get; set; }
        public virtual ICollection<ProgramEIPPerformanceMeasure> ProgramEIPPerformanceMeasures { get; set; }
        public virtual ICollection<SnapshotEIPPerformanceMeasure> SnapshotEIPPerformanceMeasures { get; set; }
        public virtual ICollection<SnapshotEIPPerformanceMeasureSubcategoryOption> SnapshotEIPPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual Indicator Indicator { get; set; }
        public EIPPerformanceMeasureType EIPPerformanceMeasureType { get { return EIPPerformanceMeasureType.AllLookupDictionary[EIPPerformanceMeasureTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}