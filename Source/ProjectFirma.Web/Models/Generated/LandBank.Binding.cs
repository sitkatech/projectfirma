//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LandBank]
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
    [Table("[dbo].[LandBank]")]
    public partial class LandBank : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected LandBank()
        {
            this.TdrTransactionConversions = new HashSet<TdrTransactionConversion>();
            this.TdrTransactionConversionWithTransfersWhereYouAreTheSendingLandBank = new HashSet<TdrTransactionConversionWithTransfer>();
            this.TdrTransactionECMRetirements = new HashSet<TdrTransactionECMRetirement>();
            this.TdrTransactionLandBankAcquisitions = new HashSet<TdrTransactionLandBankAcquisition>();
            this.TdrTransactionTransfersWhereYouAreTheSendingLandBank = new HashSet<TdrTransactionTransfer>();
            this.TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingLandBank = new HashSet<TdrTransactionTransferWithBonusUnit>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public LandBank(int landBankID, int leadAgencyID, int parcelID) : this()
        {
            this.LandBankID = landBankID;
            this.LeadAgencyID = leadAgencyID;
            this.ParcelID = parcelID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public LandBank(int leadAgencyID, int parcelID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            LandBankID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.LeadAgencyID = leadAgencyID;
            this.ParcelID = parcelID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public LandBank(LeadAgency leadAgency, Parcel parcel) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.LandBankID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.LeadAgencyID = leadAgency.LeadAgencyID;
            this.LeadAgency = leadAgency;
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            parcel.LandBanks.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static LandBank CreateNewBlank(LeadAgency leadAgency, Parcel parcel)
        {
            return new LandBank(leadAgency, parcel);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TdrTransactionConversions.Any() || TdrTransactionConversionWithTransfersWhereYouAreTheSendingLandBank.Any() || TdrTransactionECMRetirements.Any() || TdrTransactionLandBankAcquisitions.Any() || TdrTransactionTransfersWhereYouAreTheSendingLandBank.Any() || TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingLandBank.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(LandBank).Name, typeof(TdrTransactionConversion).Name, typeof(TdrTransactionConversionWithTransfer).Name, typeof(TdrTransactionECMRetirement).Name, typeof(TdrTransactionLandBankAcquisition).Name, typeof(TdrTransactionTransfer).Name, typeof(TdrTransactionTransferWithBonusUnit).Name};

        [Key]
        public int LandBankID { get; set; }
        public int LeadAgencyID { get; set; }
        public int ParcelID { get; set; }
        public int PrimaryKey { get { return LandBankID; } set { LandBankID = value; } }

        public virtual ICollection<TdrTransactionConversion> TdrTransactionConversions { get; set; }
        public virtual ICollection<TdrTransactionConversionWithTransfer> TdrTransactionConversionWithTransfersWhereYouAreTheSendingLandBank { get; set; }
        public virtual ICollection<TdrTransactionECMRetirement> TdrTransactionECMRetirements { get; set; }
        public virtual ICollection<TdrTransactionLandBankAcquisition> TdrTransactionLandBankAcquisitions { get; set; }
        public virtual ICollection<TdrTransactionTransfer> TdrTransactionTransfersWhereYouAreTheSendingLandBank { get; set; }
        public virtual ICollection<TdrTransactionTransferWithBonusUnit> TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingLandBank { get; set; }
        public virtual LeadAgency LeadAgency { get; set; }
        public virtual Parcel Parcel { get; set; }

        public static class FieldLengths
        {

        }
    }
}