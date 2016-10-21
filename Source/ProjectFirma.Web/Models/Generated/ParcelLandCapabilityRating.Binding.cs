//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelLandCapabilityRating]
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
    [Table("[dbo].[ParcelLandCapabilityRating]")]
    public partial class ParcelLandCapabilityRating : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ParcelLandCapabilityRating()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelLandCapabilityRating(int parcelLandCapabilityRatingID, int parcelLandCapabilityID, int landCapabilityTypeID, int? baileyRatingID, short? iPESScore, int? squareFootage) : this()
        {
            this.ParcelLandCapabilityRatingID = parcelLandCapabilityRatingID;
            this.ParcelLandCapabilityID = parcelLandCapabilityID;
            this.LandCapabilityTypeID = landCapabilityTypeID;
            this.BaileyRatingID = baileyRatingID;
            this.IPESScore = iPESScore;
            this.SquareFootage = squareFootage;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelLandCapabilityRating(int parcelLandCapabilityID, int landCapabilityTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelLandCapabilityRatingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ParcelLandCapabilityID = parcelLandCapabilityID;
            this.LandCapabilityTypeID = landCapabilityTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ParcelLandCapabilityRating(ParcelLandCapability parcelLandCapability, LandCapabilityType landCapabilityType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ParcelLandCapabilityRatingID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ParcelLandCapabilityID = parcelLandCapability.ParcelLandCapabilityID;
            this.ParcelLandCapability = parcelLandCapability;
            parcelLandCapability.ParcelLandCapabilityRatings.Add(this);
            this.LandCapabilityTypeID = landCapabilityType.LandCapabilityTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ParcelLandCapabilityRating CreateNewBlank(ParcelLandCapability parcelLandCapability, LandCapabilityType landCapabilityType)
        {
            return new ParcelLandCapabilityRating(parcelLandCapability, landCapabilityType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ParcelLandCapabilityRating).Name};

        [Key]
        public int ParcelLandCapabilityRatingID { get; set; }
        public int ParcelLandCapabilityID { get; set; }
        public int LandCapabilityTypeID { get; set; }
        public int? BaileyRatingID { get; set; }
        public short? IPESScore { get; set; }
        public int? SquareFootage { get; set; }
        public int PrimaryKey { get { return ParcelLandCapabilityRatingID; } set { ParcelLandCapabilityRatingID = value; } }

        public virtual ParcelLandCapability ParcelLandCapability { get; set; }
        public LandCapabilityType LandCapabilityType { get { return LandCapabilityType.AllLookupDictionary[LandCapabilityTypeID]; } }
        public BaileyRating BaileyRating { get { return BaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[BaileyRatingID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}