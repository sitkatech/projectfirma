//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelDistanceFromTownCenter]
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
    [Table("[dbo].[ParcelDistanceFromTownCenter]")]
    public partial class ParcelDistanceFromTownCenter : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ParcelDistanceFromTownCenter()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelDistanceFromTownCenter(int parcelDistanceFromTownCenterID, int townCenterID, int parcelID, decimal? distanceInMiles, int distanceFromTownCenterSummaryTypeID) : this()
        {
            this.ParcelDistanceFromTownCenterID = parcelDistanceFromTownCenterID;
            this.TownCenterID = townCenterID;
            this.ParcelID = parcelID;
            this.DistanceInMiles = distanceInMiles;
            this.DistanceFromTownCenterSummaryTypeID = distanceFromTownCenterSummaryTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelDistanceFromTownCenter(int townCenterID, int parcelID, int distanceFromTownCenterSummaryTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelDistanceFromTownCenterID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TownCenterID = townCenterID;
            this.ParcelID = parcelID;
            this.DistanceFromTownCenterSummaryTypeID = distanceFromTownCenterSummaryTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ParcelDistanceFromTownCenter(TownCenter townCenter, Parcel parcel, DistanceFromTownCenterSummaryType distanceFromTownCenterSummaryType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ParcelDistanceFromTownCenterID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TownCenterID = townCenter.TownCenterID;
            this.TownCenter = townCenter;
            townCenter.ParcelDistanceFromTownCenters.Add(this);
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            parcel.ParcelDistanceFromTownCenters.Add(this);
            this.DistanceFromTownCenterSummaryTypeID = distanceFromTownCenterSummaryType.DistanceFromTownCenterSummaryTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ParcelDistanceFromTownCenter CreateNewBlank(TownCenter townCenter, Parcel parcel, DistanceFromTownCenterSummaryType distanceFromTownCenterSummaryType)
        {
            return new ParcelDistanceFromTownCenter(townCenter, parcel, distanceFromTownCenterSummaryType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ParcelDistanceFromTownCenter).Name};

        [Key]
        public int ParcelDistanceFromTownCenterID { get; set; }
        public int TownCenterID { get; set; }
        public int ParcelID { get; set; }
        public decimal? DistanceInMiles { get; set; }
        public int DistanceFromTownCenterSummaryTypeID { get; set; }
        public int PrimaryKey { get { return ParcelDistanceFromTownCenterID; } set { ParcelDistanceFromTownCenterID = value; } }

        public virtual TownCenter TownCenter { get; set; }
        public virtual Parcel Parcel { get; set; }
        public DistanceFromTownCenterSummaryType DistanceFromTownCenterSummaryType { get { return DistanceFromTownCenterSummaryType.AllLookupDictionary[DistanceFromTownCenterSummaryTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}