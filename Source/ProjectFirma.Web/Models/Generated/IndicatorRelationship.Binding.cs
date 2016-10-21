//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorRelationship]
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
    [Table("[dbo].[IndicatorRelationship]")]
    public partial class IndicatorRelationship : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected IndicatorRelationship()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorRelationship(int indicatorRelationshipID, int indicatorID, int relatedIndicatorID, int indicatorRelationshipTypeID) : this()
        {
            this.IndicatorRelationshipID = indicatorRelationshipID;
            this.IndicatorID = indicatorID;
            this.RelatedIndicatorID = relatedIndicatorID;
            this.IndicatorRelationshipTypeID = indicatorRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorRelationship(int indicatorID, int relatedIndicatorID, int indicatorRelationshipTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            IndicatorRelationshipID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorID = indicatorID;
            this.RelatedIndicatorID = relatedIndicatorID;
            this.IndicatorRelationshipTypeID = indicatorRelationshipTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public IndicatorRelationship(Indicator indicator, Indicator relatedIndicator, IndicatorRelationshipType indicatorRelationshipType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.IndicatorRelationshipID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorID = indicator.IndicatorID;
            this.Indicator = indicator;
            indicator.IndicatorRelationships.Add(this);
            this.RelatedIndicatorID = relatedIndicator.IndicatorID;
            this.RelatedIndicator = relatedIndicator;
            relatedIndicator.IndicatorRelationshipsWhereYouAreTheRelatedIndicator.Add(this);
            this.IndicatorRelationshipTypeID = indicatorRelationshipType.IndicatorRelationshipTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static IndicatorRelationship CreateNewBlank(Indicator indicator, Indicator relatedIndicator, IndicatorRelationshipType indicatorRelationshipType)
        {
            return new IndicatorRelationship(indicator, relatedIndicator, indicatorRelationshipType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(IndicatorRelationship).Name};

        [Key]
        public int IndicatorRelationshipID { get; set; }
        public int IndicatorID { get; set; }
        public int RelatedIndicatorID { get; set; }
        public int IndicatorRelationshipTypeID { get; set; }
        public int PrimaryKey { get { return IndicatorRelationshipID; } set { IndicatorRelationshipID = value; } }

        public virtual Indicator Indicator { get; set; }
        public virtual Indicator RelatedIndicator { get; set; }
        public IndicatorRelationshipType IndicatorRelationshipType { get { return IndicatorRelationshipType.AllLookupDictionary[IndicatorRelationshipTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}