//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelLandCapability]
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
    [Table("[dbo].[ParcelLandCapability]")]
    public partial class ParcelLandCapability : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ParcelLandCapability()
        {
            this.ParcelLandCapabilityRatings = new HashSet<ParcelLandCapabilityRating>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelLandCapability(int parcelLandCapabilityID, int parcelID, int parcelLandCapabilityDeterminationTypeID, DateTime determinationDate, int? sitePlanFileResourceID, int? accelaCAPRecordID, string landCapabilityNotes, DateTime lastUpdateDate, int lastUpdatePersonID) : this()
        {
            this.ParcelLandCapabilityID = parcelLandCapabilityID;
            this.ParcelID = parcelID;
            this.ParcelLandCapabilityDeterminationTypeID = parcelLandCapabilityDeterminationTypeID;
            this.DeterminationDate = determinationDate;
            this.SitePlanFileResourceID = sitePlanFileResourceID;
            this.AccelaCAPRecordID = accelaCAPRecordID;
            this.LandCapabilityNotes = landCapabilityNotes;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelLandCapability(int parcelID, int parcelLandCapabilityDeterminationTypeID, DateTime determinationDate, DateTime lastUpdateDate, int lastUpdatePersonID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelLandCapabilityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ParcelID = parcelID;
            this.ParcelLandCapabilityDeterminationTypeID = parcelLandCapabilityDeterminationTypeID;
            this.DeterminationDate = determinationDate;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ParcelLandCapability(Parcel parcel, ParcelLandCapabilityDeterminationType parcelLandCapabilityDeterminationType, DateTime determinationDate, DateTime lastUpdateDate, Person lastUpdatePerson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ParcelLandCapabilityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            this.ParcelLandCapabilityDeterminationTypeID = parcelLandCapabilityDeterminationType.ParcelLandCapabilityDeterminationTypeID;
            this.DeterminationDate = determinationDate;
            this.LastUpdateDate = lastUpdateDate;
            this.LastUpdatePersonID = lastUpdatePerson.PersonID;
            this.LastUpdatePerson = lastUpdatePerson;
            lastUpdatePerson.ParcelLandCapabilitiesWhereYouAreTheLastUpdatePerson.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ParcelLandCapability CreateNewBlank(Parcel parcel, ParcelLandCapabilityDeterminationType parcelLandCapabilityDeterminationType, Person lastUpdatePerson)
        {
            return new ParcelLandCapability(parcel, parcelLandCapabilityDeterminationType, default(DateTime), default(DateTime), lastUpdatePerson);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ParcelLandCapabilityRatings.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ParcelLandCapability).Name, typeof(ParcelLandCapabilityRating).Name};

        [Key]
        public int ParcelLandCapabilityID { get; set; }
        public int ParcelID { get; set; }
        public int ParcelLandCapabilityDeterminationTypeID { get; set; }
        public DateTime DeterminationDate { get; set; }
        public int? SitePlanFileResourceID { get; set; }
        public int? AccelaCAPRecordID { get; set; }
        public string LandCapabilityNotes { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LastUpdatePersonID { get; set; }
        public int PrimaryKey { get { return ParcelLandCapabilityID; } set { ParcelLandCapabilityID = value; } }

        public virtual ICollection<ParcelLandCapabilityRating> ParcelLandCapabilityRatings { get; set; }
        public virtual Parcel Parcel { get; set; }
        public ParcelLandCapabilityDeterminationType ParcelLandCapabilityDeterminationType { get { return ParcelLandCapabilityDeterminationType.AllLookupDictionary[ParcelLandCapabilityDeterminationTypeID]; } }
        public virtual FileResource SitePlanFileResource { get; set; }
        public virtual AccelaCAPRecord AccelaCAPRecord { get; set; }
        public virtual Person LastUpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int LandCapabilityNotes = 500;
        }
    }
}