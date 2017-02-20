//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationPerformanceMeasure]
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
    [Table("[dbo].[ClassificationPerformanceMeasure]")]
    public partial class ClassificationPerformanceMeasure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ClassificationPerformanceMeasure()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationPerformanceMeasure(int classificationPerformanceMeasureID, int classificationID, int performanceMeasureID, bool isPrimaryChart) : this()
        {
            this.ClassificationPerformanceMeasureID = classificationPerformanceMeasureID;
            this.ClassificationID = classificationID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationPerformanceMeasure(int classificationID, int performanceMeasureID, bool isPrimaryChart) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ClassificationID = classificationID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ClassificationPerformanceMeasure(Classification classification, PerformanceMeasure performanceMeasure, bool isPrimaryChart) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ClassificationID = classification.ClassificationID;
            this.Classification = classification;
            classification.ClassificationPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.ClassificationPerformanceMeasures.Add(this);
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ClassificationPerformanceMeasure CreateNewBlank(Classification classification, PerformanceMeasure performanceMeasure)
        {
            return new ClassificationPerformanceMeasure(classification, performanceMeasure, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ClassificationPerformanceMeasure).Name};

        [Key]
        public int ClassificationPerformanceMeasureID { get; set; }
        public int TenantID { get; private set; }
        public int ClassificationID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryChart { get; set; }
        public int PrimaryKey { get { return ClassificationPerformanceMeasureID; } set { ClassificationPerformanceMeasureID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Classification Classification { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}