//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Parcel]
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
    [Table("[dbo].[Parcel]")]
    public partial class Parcel : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Parcel()
        {
            this.BankedCommodities = new HashSet<BankedCommodity>();
            this.LandBanks = new HashSet<LandBank>();
            this.ParcelAccelaCAPRecords = new HashSet<ParcelAccelaCAPRecord>();
            this.ParcelCommodityBaileyRatingConfirmations = new HashSet<ParcelCommodityBaileyRatingConfirmation>();
            this.ParcelDistanceFromTownCenters = new HashSet<ParcelDistanceFromTownCenter>();
            this.ParcelExistingPhysicalInventories = new HashSet<ParcelExistingPhysicalInventory>();
            this.ParcelGeometries = new HashSet<ParcelGeometry>();
            this.ParcelImages = new HashSet<ParcelImage>();
            this.ParcelLandCapabilities = new HashSet<ParcelLandCapability>();
            this.TdrTransactionAllocationsWhereYouAreTheReceivingParcel = new HashSet<TdrTransactionAllocation>();
            this.TdrTransactionAllocationAssignmentsWhereYouAreTheReceivingParcel = new HashSet<TdrTransactionAllocationAssignment>();
            this.TdrTransactionAllocationAssignmentsWhereYouAreTheRetiredSensitiveParcel = new HashSet<TdrTransactionAllocationAssignment>();
            this.TdrTransactionConversions = new HashSet<TdrTransactionConversion>();
            this.TdrTransactionConversionWithTransfersWhereYouAreTheReceivingParcel = new HashSet<TdrTransactionConversionWithTransfer>();
            this.TdrTransactionConversionWithTransfersWhereYouAreTheSendingParcel = new HashSet<TdrTransactionConversionWithTransfer>();
            this.TdrTransactionECMRetirementsWhereYouAreTheSendingParcel = new HashSet<TdrTransactionECMRetirement>();
            this.TdrTransactionLandBankAcquisitionsWhereYouAreTheSendingParcel = new HashSet<TdrTransactionLandBankAcquisition>();
            this.TdrTransactionTransfersWhereYouAreTheReceivingParcel = new HashSet<TdrTransactionTransfer>();
            this.TdrTransactionTransfersWhereYouAreTheSendingParcel = new HashSet<TdrTransactionTransfer>();
            this.TdrTransactionTransferWithBonusUnitsWhereYouAreTheReceivingParcel = new HashSet<TdrTransactionTransferWithBonusUnit>();
            this.TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingParcel = new HashSet<TdrTransactionTransferWithBonusUnit>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Parcel(int parcelID, string parcelNumber, string geometryXml, string parcelStreetAddress, string parcelCity, string parcelState, string parcelZipCode, string parcelNickname, string parcelNotes, string ownerName, int jurisdictionID, int? parcelSize, int? verifiedParcelSize, string localPlan, string hRA, string fireDistrict, string bMPStatus, int? watershedID, int parcelStatusID, bool autoImported) : this()
        {
            this.ParcelID = parcelID;
            this.ParcelNumber = parcelNumber;
            this.GeometryXml = geometryXml;
            this.ParcelStreetAddress = parcelStreetAddress;
            this.ParcelCity = parcelCity;
            this.ParcelState = parcelState;
            this.ParcelZipCode = parcelZipCode;
            this.ParcelNickname = parcelNickname;
            this.ParcelNotes = parcelNotes;
            this.OwnerName = ownerName;
            this.JurisdictionID = jurisdictionID;
            this.ParcelSize = parcelSize;
            this.VerifiedParcelSize = verifiedParcelSize;
            this.LocalPlan = localPlan;
            this.HRA = hRA;
            this.FireDistrict = fireDistrict;
            this.BMPStatus = bMPStatus;
            this.WatershedID = watershedID;
            this.ParcelStatusID = parcelStatusID;
            this.AutoImported = autoImported;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Parcel(string parcelNumber, int jurisdictionID, int parcelStatusID, bool autoImported) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ParcelNumber = parcelNumber;
            this.JurisdictionID = jurisdictionID;
            this.ParcelStatusID = parcelStatusID;
            this.AutoImported = autoImported;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Parcel(string parcelNumber, Jurisdiction jurisdiction, ParcelStatus parcelStatus, bool autoImported) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ParcelID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ParcelNumber = parcelNumber;
            this.JurisdictionID = jurisdiction.JurisdictionID;
            this.Jurisdiction = jurisdiction;
            jurisdiction.Parcels.Add(this);
            this.ParcelStatusID = parcelStatus.ParcelStatusID;
            this.AutoImported = autoImported;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Parcel CreateNewBlank(Jurisdiction jurisdiction, ParcelStatus parcelStatus)
        {
            return new Parcel(default(string), jurisdiction, parcelStatus, default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return BankedCommodities.Any() || LandBanks.Any() || ParcelAccelaCAPRecords.Any() || ParcelCommodityBaileyRatingConfirmations.Any() || ParcelDistanceFromTownCenters.Any() || ParcelExistingPhysicalInventories.Any() || ParcelGeometries.Any() || ParcelImages.Any() || (ParcelLandCapability != null) || TdrTransactionAllocationsWhereYouAreTheReceivingParcel.Any() || TdrTransactionAllocationAssignmentsWhereYouAreTheReceivingParcel.Any() || TdrTransactionAllocationAssignmentsWhereYouAreTheRetiredSensitiveParcel.Any() || TdrTransactionConversions.Any() || TdrTransactionConversionWithTransfersWhereYouAreTheReceivingParcel.Any() || TdrTransactionConversionWithTransfersWhereYouAreTheSendingParcel.Any() || TdrTransactionECMRetirementsWhereYouAreTheSendingParcel.Any() || TdrTransactionLandBankAcquisitionsWhereYouAreTheSendingParcel.Any() || TdrTransactionTransfersWhereYouAreTheReceivingParcel.Any() || TdrTransactionTransfersWhereYouAreTheSendingParcel.Any() || TdrTransactionTransferWithBonusUnitsWhereYouAreTheReceivingParcel.Any() || TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingParcel.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Parcel).Name, typeof(BankedCommodity).Name, typeof(LandBank).Name, typeof(ParcelAccelaCAPRecord).Name, typeof(ParcelCommodityBaileyRatingConfirmation).Name, typeof(ParcelDistanceFromTownCenter).Name, typeof(ParcelExistingPhysicalInventory).Name, typeof(ParcelGeometry).Name, typeof(ParcelImage).Name, typeof(ParcelLandCapability).Name, typeof(TdrTransactionAllocation).Name, typeof(TdrTransactionAllocationAssignment).Name, typeof(TdrTransactionConversion).Name, typeof(TdrTransactionConversionWithTransfer).Name, typeof(TdrTransactionECMRetirement).Name, typeof(TdrTransactionLandBankAcquisition).Name, typeof(TdrTransactionTransfer).Name, typeof(TdrTransactionTransferWithBonusUnit).Name};

        [Key]
        public int ParcelID { get; set; }
        public string ParcelNumber { get; set; }
        public string GeometryXml { get; set; }
        public string ParcelStreetAddress { get; set; }
        public string ParcelCity { get; set; }
        public string ParcelState { get; set; }
        public string ParcelZipCode { get; set; }
        public string ParcelNickname { get; set; }
        public string ParcelNotes { get; set; }
        public string OwnerName { get; set; }
        public int JurisdictionID { get; set; }
        public int? ParcelSize { get; set; }
        public int? VerifiedParcelSize { get; set; }
        public string LocalPlan { get; set; }
        public string HRA { get; set; }
        public string FireDistrict { get; set; }
        public string BMPStatus { get; set; }
        public int? WatershedID { get; set; }
        public int ParcelStatusID { get; set; }
        public bool AutoImported { get; set; }
        public int PrimaryKey { get { return ParcelID; } set { ParcelID = value; } }

        public virtual ICollection<BankedCommodity> BankedCommodities { get; set; }
        public virtual ICollection<LandBank> LandBanks { get; set; }
        public virtual ICollection<ParcelAccelaCAPRecord> ParcelAccelaCAPRecords { get; set; }
        public virtual ICollection<ParcelCommodityBaileyRatingConfirmation> ParcelCommodityBaileyRatingConfirmations { get; set; }
        public virtual ICollection<ParcelDistanceFromTownCenter> ParcelDistanceFromTownCenters { get; set; }
        public virtual ICollection<ParcelExistingPhysicalInventory> ParcelExistingPhysicalInventories { get; set; }
        public virtual ICollection<ParcelGeometry> ParcelGeometries { get; set; }
        public virtual ICollection<ParcelImage> ParcelImages { get; set; }
        protected virtual ICollection<ParcelLandCapability> ParcelLandCapabilities { get; set; }
        public ParcelLandCapability ParcelLandCapability { get { return ParcelLandCapabilities.SingleOrDefault(); } set { ParcelLandCapabilities = new List<ParcelLandCapability>{value};} }
        public virtual ICollection<TdrTransactionAllocation> TdrTransactionAllocationsWhereYouAreTheReceivingParcel { get; set; }
        public virtual ICollection<TdrTransactionAllocationAssignment> TdrTransactionAllocationAssignmentsWhereYouAreTheReceivingParcel { get; set; }
        public virtual ICollection<TdrTransactionAllocationAssignment> TdrTransactionAllocationAssignmentsWhereYouAreTheRetiredSensitiveParcel { get; set; }
        public virtual ICollection<TdrTransactionConversion> TdrTransactionConversions { get; set; }
        public virtual ICollection<TdrTransactionConversionWithTransfer> TdrTransactionConversionWithTransfersWhereYouAreTheReceivingParcel { get; set; }
        public virtual ICollection<TdrTransactionConversionWithTransfer> TdrTransactionConversionWithTransfersWhereYouAreTheSendingParcel { get; set; }
        public virtual ICollection<TdrTransactionECMRetirement> TdrTransactionECMRetirementsWhereYouAreTheSendingParcel { get; set; }
        public virtual ICollection<TdrTransactionLandBankAcquisition> TdrTransactionLandBankAcquisitionsWhereYouAreTheSendingParcel { get; set; }
        public virtual ICollection<TdrTransactionTransfer> TdrTransactionTransfersWhereYouAreTheReceivingParcel { get; set; }
        public virtual ICollection<TdrTransactionTransfer> TdrTransactionTransfersWhereYouAreTheSendingParcel { get; set; }
        public virtual ICollection<TdrTransactionTransferWithBonusUnit> TdrTransactionTransferWithBonusUnitsWhereYouAreTheReceivingParcel { get; set; }
        public virtual ICollection<TdrTransactionTransferWithBonusUnit> TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingParcel { get; set; }
        public virtual Jurisdiction Jurisdiction { get; set; }
        public virtual Watershed Watershed { get; set; }
        public ParcelStatus ParcelStatus { get { return ParcelStatus.AllLookupDictionary[ParcelStatusID]; } }

        public static class FieldLengths
        {
            public const int ParcelNumber = 30;
            public const int ParcelStreetAddress = 100;
            public const int ParcelCity = 50;
            public const int ParcelState = 2;
            public const int ParcelZipCode = 15;
            public const int ParcelNickname = 100;
            public const int ParcelNotes = 1000;
            public const int OwnerName = 300;
            public const int LocalPlan = 100;
            public const int HRA = 100;
            public const int FireDistrict = 100;
            public const int BMPStatus = 100;
        }
    }
}