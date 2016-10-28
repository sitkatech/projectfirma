//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Indicator]
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
    [Table("[dbo].[Indicator]")]
    public partial class Indicator : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Indicator()
        {
            this.IndicatorMonitoringPrograms = new HashSet<IndicatorMonitoringProgram>();
            this.IndicatorNotes = new HashSet<IndicatorNote>();
            this.IndicatorRelationships = new HashSet<IndicatorRelationship>();
            this.IndicatorRelationshipsWhereYouAreTheRelatedIndicator = new HashSet<IndicatorRelationship>();
            this.IndicatorSubcategories = new HashSet<IndicatorSubcategory>();
            this.PerformanceMeasures = new HashSet<PerformanceMeasure>();
            this.ThresholdCategoryIndicators = new HashSet<ThresholdCategoryIndicator>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Indicator(int indicatorID, string indicatorName, string indicatorDisplayName, int measurementUnitTypeID, string indicatorDefinition, string indicatorPublicDescription, string dataSourceText, string externalDataSourceUrl, int displayOrder, string associatedPrograms, int indicatorTypeID, string chartTitle, string chartCaption) : this()
        {
            this.IndicatorID = indicatorID;
            this.IndicatorName = indicatorName;
            this.IndicatorDisplayName = indicatorDisplayName;
            this.MeasurementUnitTypeID = measurementUnitTypeID;
            this.IndicatorDefinition = indicatorDefinition;
            this.IndicatorPublicDescription = indicatorPublicDescription;
            this.DataSourceText = dataSourceText;
            this.ExternalDataSourceUrl = externalDataSourceUrl;
            this.DisplayOrder = displayOrder;
            this.AssociatedPrograms = associatedPrograms;
            this.IndicatorTypeID = indicatorTypeID;
            this.ChartTitle = chartTitle;
            this.ChartCaption = chartCaption;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Indicator(string indicatorName, string indicatorDisplayName, int measurementUnitTypeID, int displayOrder, int indicatorTypeID, string chartTitle) : this()
        {
            // Mark this as a new object by setting primary key with special value
            IndicatorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorName = indicatorName;
            this.IndicatorDisplayName = indicatorDisplayName;
            this.MeasurementUnitTypeID = measurementUnitTypeID;
            this.DisplayOrder = displayOrder;
            this.IndicatorTypeID = indicatorTypeID;
            this.ChartTitle = chartTitle;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Indicator(string indicatorName, string indicatorDisplayName, MeasurementUnitType measurementUnitType, int displayOrder, IndicatorType indicatorType, string chartTitle) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.IndicatorID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorName = indicatorName;
            this.IndicatorDisplayName = indicatorDisplayName;
            this.MeasurementUnitTypeID = measurementUnitType.MeasurementUnitTypeID;
            this.DisplayOrder = displayOrder;
            this.IndicatorTypeID = indicatorType.IndicatorTypeID;
            this.ChartTitle = chartTitle;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Indicator CreateNewBlank(MeasurementUnitType measurementUnitType, IndicatorType indicatorType)
        {
            return new Indicator(default(string), default(string), measurementUnitType, default(int), indicatorType, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return IndicatorMonitoringPrograms.Any() || IndicatorNotes.Any() || IndicatorRelationships.Any() || IndicatorRelationshipsWhereYouAreTheRelatedIndicator.Any() || IndicatorSubcategories.Any() || (PerformanceMeasure != null) || ThresholdCategoryIndicators.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Indicator).Name, typeof(IndicatorMonitoringProgram).Name, typeof(IndicatorNote).Name, typeof(IndicatorRelationship).Name, typeof(IndicatorSubcategory).Name, typeof(PerformanceMeasure).Name, typeof(ThresholdCategoryIndicator).Name};

        [Key]
        public int IndicatorID { get; set; }
        public string IndicatorName { get; set; }
        public string IndicatorDisplayName { get; set; }
        public int MeasurementUnitTypeID { get; set; }
        public string IndicatorDefinition { get; set; }
        [NotMapped]
        private string IndicatorPublicDescription { get; set; }
        public HtmlString IndicatorPublicDescriptionHtmlString
        { 
            get { return IndicatorPublicDescription == null ? null : new HtmlString(IndicatorPublicDescription); }
            set { IndicatorPublicDescription = value == null ? null : value.ToString(); }
        }
        public string DataSourceText { get; set; }
        public string ExternalDataSourceUrl { get; set; }
        public int DisplayOrder { get; set; }
        [NotMapped]
        private string AssociatedPrograms { get; set; }
        public HtmlString AssociatedProgramsHtmlString
        { 
            get { return AssociatedPrograms == null ? null : new HtmlString(AssociatedPrograms); }
            set { AssociatedPrograms = value == null ? null : value.ToString(); }
        }
        public int IndicatorTypeID { get; set; }
        public string ChartTitle { get; set; }
        public string ChartCaption { get; set; }
        public int PrimaryKey { get { return IndicatorID; } set { IndicatorID = value; } }

        public virtual ICollection<IndicatorMonitoringProgram> IndicatorMonitoringPrograms { get; set; }
        public virtual ICollection<IndicatorNote> IndicatorNotes { get; set; }
        public virtual ICollection<IndicatorRelationship> IndicatorRelationships { get; set; }
        public virtual ICollection<IndicatorRelationship> IndicatorRelationshipsWhereYouAreTheRelatedIndicator { get; set; }
        public virtual ICollection<IndicatorSubcategory> IndicatorSubcategories { get; set; }
        protected virtual ICollection<PerformanceMeasure> PerformanceMeasures { get; set; }
        public PerformanceMeasure PerformanceMeasure { get { return PerformanceMeasures.SingleOrDefault(); } set { PerformanceMeasures = new List<PerformanceMeasure>{value};} }
        public virtual ICollection<ThresholdCategoryIndicator> ThresholdCategoryIndicators { get; set; }
        public MeasurementUnitType MeasurementUnitType { get { return MeasurementUnitType.AllLookupDictionary[MeasurementUnitTypeID]; } }
        public IndicatorType IndicatorType { get { return IndicatorType.AllLookupDictionary[IndicatorTypeID]; } }

        public static class FieldLengths
        {
            public const int IndicatorName = 200;
            public const int IndicatorDisplayName = 200;
            public const int DataSourceText = 200;
            public const int ExternalDataSourceUrl = 200;
            public const int ChartTitle = 500;
            public const int ChartCaption = 1000;
        }
    }
}