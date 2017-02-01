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
    public partial class PerformanceMeasure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasure()
        {
            this.ClassificationPerformanceMeasures = new HashSet<ClassificationPerformanceMeasure>();
            this.PerformanceMeasureActuals = new HashSet<PerformanceMeasureActual>();
            this.PerformanceMeasureActualSubcategoryOptions = new HashSet<PerformanceMeasureActualSubcategoryOption>();
            this.PerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<PerformanceMeasureActualSubcategoryOptionUpdate>();
            this.PerformanceMeasureActualUpdates = new HashSet<PerformanceMeasureActualUpdate>();
            this.PerformanceMeasureExpecteds = new HashSet<PerformanceMeasureExpected>();
            this.PerformanceMeasureExpectedProposeds = new HashSet<PerformanceMeasureExpectedProposed>();
            this.PerformanceMeasureExpectedSubcategoryOptions = new HashSet<PerformanceMeasureExpectedSubcategoryOption>();
            this.PerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<PerformanceMeasureExpectedSubcategoryOptionProposed>();
            this.PerformanceMeasureMonitoringPrograms = new HashSet<PerformanceMeasureMonitoringProgram>();
            this.PerformanceMeasureNotes = new HashSet<PerformanceMeasureNote>();
            this.PerformanceMeasureSubcategories = new HashSet<PerformanceMeasureSubcategory>();
            this.SnapshotPerformanceMeasures = new HashSet<SnapshotPerformanceMeasure>();
            this.SnapshotPerformanceMeasureSubcategoryOptions = new HashSet<SnapshotPerformanceMeasureSubcategoryOption>();
            this.TaxonomyTierTwoPerformanceMeasures = new HashSet<TaxonomyTierTwoPerformanceMeasure>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasure(int performanceMeasureID, string criticalDefinitions, string projectReporting, string performanceMeasureDisplayName, int measurementUnitTypeID, int performanceMeasureTypeID, string performanceMeasureDefinition, string dataSourceText, string externalDataSourceUrl, string chartTitle, string chartCaption) : this()
        {
            this.PerformanceMeasureID = performanceMeasureID;
            this.CriticalDefinitions = criticalDefinitions;
            this.ProjectReporting = projectReporting;
            this.PerformanceMeasureDisplayName = performanceMeasureDisplayName;
            this.MeasurementUnitTypeID = measurementUnitTypeID;
            this.PerformanceMeasureTypeID = performanceMeasureTypeID;
            this.PerformanceMeasureDefinition = performanceMeasureDefinition;
            this.DataSourceText = dataSourceText;
            this.ExternalDataSourceUrl = externalDataSourceUrl;
            this.ChartTitle = chartTitle;
            this.ChartCaption = chartCaption;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasure(string performanceMeasureDisplayName, int measurementUnitTypeID, int performanceMeasureTypeID, string chartTitle) : this()
        {
            // Mark this as a new object by setting primary key with special value
            PerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureDisplayName = performanceMeasureDisplayName;
            this.MeasurementUnitTypeID = measurementUnitTypeID;
            this.PerformanceMeasureTypeID = performanceMeasureTypeID;
            this.ChartTitle = chartTitle;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasure(string performanceMeasureDisplayName, MeasurementUnitType measurementUnitType, PerformanceMeasureType performanceMeasureType, string chartTitle) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureDisplayName = performanceMeasureDisplayName;
            this.MeasurementUnitTypeID = measurementUnitType.MeasurementUnitTypeID;
            this.PerformanceMeasureTypeID = performanceMeasureType.PerformanceMeasureTypeID;
            this.ChartTitle = chartTitle;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasure CreateNewBlank(MeasurementUnitType measurementUnitType, PerformanceMeasureType performanceMeasureType)
        {
            return new PerformanceMeasure(default(string), measurementUnitType, performanceMeasureType, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ClassificationPerformanceMeasures.Any() || PerformanceMeasureActuals.Any() || PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureActualSubcategoryOptionUpdates.Any() || PerformanceMeasureActualUpdates.Any() || PerformanceMeasureExpecteds.Any() || PerformanceMeasureExpectedProposeds.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any() || PerformanceMeasureExpectedSubcategoryOptionProposeds.Any() || PerformanceMeasureMonitoringPrograms.Any() || PerformanceMeasureNotes.Any() || PerformanceMeasureSubcategories.Any() || SnapshotPerformanceMeasures.Any() || SnapshotPerformanceMeasureSubcategoryOptions.Any() || TaxonomyTierTwoPerformanceMeasures.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasure).Name, typeof(ClassificationPerformanceMeasure).Name, typeof(PerformanceMeasureActual).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureActualUpdate).Name, typeof(PerformanceMeasureExpected).Name, typeof(PerformanceMeasureExpectedProposed).Name, typeof(PerformanceMeasureExpectedSubcategoryOption).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionProposed).Name, typeof(PerformanceMeasureMonitoringProgram).Name, typeof(PerformanceMeasureNote).Name, typeof(PerformanceMeasureSubcategory).Name, typeof(SnapshotPerformanceMeasure).Name, typeof(SnapshotPerformanceMeasureSubcategoryOption).Name, typeof(TaxonomyTierTwoPerformanceMeasure).Name};

        [Key]
        public int PerformanceMeasureID { get; set; }
        [NotMapped]
        private string CriticalDefinitions { get; set; }
        public HtmlString CriticalDefinitionsHtmlString
        { 
            get { return CriticalDefinitions == null ? null : new HtmlString(CriticalDefinitions); }
            set { CriticalDefinitions = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string ProjectReporting { get; set; }
        public HtmlString ProjectReportingHtmlString
        { 
            get { return ProjectReporting == null ? null : new HtmlString(ProjectReporting); }
            set { ProjectReporting = value == null ? null : value.ToString(); }
        }
        public string PerformanceMeasureDisplayName { get; set; }
        public int MeasurementUnitTypeID { get; set; }
        public int PerformanceMeasureTypeID { get; set; }
        public string PerformanceMeasureDefinition { get; set; }
        public string DataSourceText { get; set; }
        public string ExternalDataSourceUrl { get; set; }
        public string ChartTitle { get; set; }
        public string ChartCaption { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureID; } set { PerformanceMeasureID = value; } }

        public virtual ICollection<ClassificationPerformanceMeasure> ClassificationPerformanceMeasures { get; set; }
        public virtual ICollection<PerformanceMeasureActual> PerformanceMeasureActuals { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureActualUpdate> PerformanceMeasureActualUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpected> PerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedProposed> PerformanceMeasureExpectedProposeds { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionProposed> PerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ICollection<PerformanceMeasureMonitoringProgram> PerformanceMeasureMonitoringPrograms { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotes { get; set; }
        public virtual ICollection<PerformanceMeasureSubcategory> PerformanceMeasureSubcategories { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasure> SnapshotPerformanceMeasures { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasureSubcategoryOption> SnapshotPerformanceMeasureSubcategoryOptions { get; set; }
        public virtual ICollection<TaxonomyTierTwoPerformanceMeasure> TaxonomyTierTwoPerformanceMeasures { get; set; }
        public MeasurementUnitType MeasurementUnitType { get { return MeasurementUnitType.AllLookupDictionary[MeasurementUnitTypeID]; } }
        public PerformanceMeasureType PerformanceMeasureType { get { return PerformanceMeasureType.AllLookupDictionary[PerformanceMeasureTypeID]; } }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {
            public const int PerformanceMeasureDisplayName = 200;
            public const int DataSourceText = 200;
            public const int ExternalDataSourceUrl = 200;
            public const int ChartTitle = 500;
            public const int ChartCaption = 1000;
        }
    }
}