//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TdrTransactionAllocationAssignment]
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
    [Table("[dbo].[TdrTransactionAllocationAssignment]")]
    public partial class TdrTransactionAllocationAssignment : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TdrTransactionAllocationAssignment()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionAllocationAssignment(int tdrTransactionAllocationAssignmentID, int tdrTransactionID, int sendingAllocationPoolID, int retiredSensitiveOwnershipID, int retiredSensitiveParcelID, int receivingOwnershipID, int receivingParcelID, int allocatedQuantity, short? receivingIPESScore, int? receivingBaileyRatingID, bool? residentialAllocationFeeReceived) : this()
        {
            this.TdrTransactionAllocationAssignmentID = tdrTransactionAllocationAssignmentID;
            this.TdrTransactionID = tdrTransactionID;
            this.SendingAllocationPoolID = sendingAllocationPoolID;
            this.RetiredSensitiveOwnershipID = retiredSensitiveOwnershipID;
            this.RetiredSensitiveParcelID = retiredSensitiveParcelID;
            this.ReceivingOwnershipID = receivingOwnershipID;
            this.ReceivingParcelID = receivingParcelID;
            this.AllocatedQuantity = allocatedQuantity;
            this.ReceivingIPESScore = receivingIPESScore;
            this.ReceivingBaileyRatingID = receivingBaileyRatingID;
            this.ResidentialAllocationFeeReceived = residentialAllocationFeeReceived;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TdrTransactionAllocationAssignment(int tdrTransactionID, int sendingAllocationPoolID, int retiredSensitiveOwnershipID, int retiredSensitiveParcelID, int receivingOwnershipID, int receivingParcelID, int allocatedQuantity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TdrTransactionAllocationAssignmentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TdrTransactionID = tdrTransactionID;
            this.SendingAllocationPoolID = sendingAllocationPoolID;
            this.RetiredSensitiveOwnershipID = retiredSensitiveOwnershipID;
            this.RetiredSensitiveParcelID = retiredSensitiveParcelID;
            this.ReceivingOwnershipID = receivingOwnershipID;
            this.ReceivingParcelID = receivingParcelID;
            this.AllocatedQuantity = allocatedQuantity;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TdrTransactionAllocationAssignment(TdrTransaction tdrTransaction, CommodityPool sendingAllocationPool, Ownership retiredSensitiveOwnership, Parcel retiredSensitiveParcel, Ownership receivingOwnership, Parcel receivingParcel, int allocatedQuantity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TdrTransactionAllocationAssignmentID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TdrTransactionID = tdrTransaction.TdrTransactionID;
            this.TdrTransaction = tdrTransaction;
            this.SendingAllocationPoolID = sendingAllocationPool.CommodityPoolID;
            this.SendingAllocationPool = sendingAllocationPool;
            sendingAllocationPool.TdrTransactionAllocationAssignmentsWhereYouAreTheSendingAllocationPool.Add(this);
            this.RetiredSensitiveOwnershipID = retiredSensitiveOwnership.OwnershipID;
            this.RetiredSensitiveParcelID = retiredSensitiveParcel.ParcelID;
            this.RetiredSensitiveParcel = retiredSensitiveParcel;
            retiredSensitiveParcel.TdrTransactionAllocationAssignmentsWhereYouAreTheRetiredSensitiveParcel.Add(this);
            this.ReceivingOwnershipID = receivingOwnership.OwnershipID;
            this.ReceivingParcelID = receivingParcel.ParcelID;
            this.ReceivingParcel = receivingParcel;
            receivingParcel.TdrTransactionAllocationAssignmentsWhereYouAreTheReceivingParcel.Add(this);
            this.AllocatedQuantity = allocatedQuantity;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TdrTransactionAllocationAssignment CreateNewBlank(TdrTransaction tdrTransaction, CommodityPool sendingAllocationPool, Ownership retiredSensitiveOwnership, Parcel retiredSensitiveParcel, Ownership receivingOwnership, Parcel receivingParcel)
        {
            return new TdrTransactionAllocationAssignment(tdrTransaction, sendingAllocationPool, retiredSensitiveOwnership, retiredSensitiveParcel, receivingOwnership, receivingParcel, default(int));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TdrTransactionAllocationAssignment).Name};

        [Key]
        public int TdrTransactionAllocationAssignmentID { get; set; }
        public int TdrTransactionID { get; set; }
        public int SendingAllocationPoolID { get; set; }
        public int RetiredSensitiveOwnershipID { get; set; }
        public int RetiredSensitiveParcelID { get; set; }
        public int ReceivingOwnershipID { get; set; }
        public int ReceivingParcelID { get; set; }
        public int AllocatedQuantity { get; set; }
        public short? ReceivingIPESScore { get; set; }
        public int? ReceivingBaileyRatingID { get; set; }
        public bool? ResidentialAllocationFeeReceived { get; set; }
        public int PrimaryKey { get { return TdrTransactionAllocationAssignmentID; } set { TdrTransactionAllocationAssignmentID = value; } }

        public virtual TdrTransaction TdrTransaction { get; set; }
        public virtual CommodityPool SendingAllocationPool { get; set; }
        public Ownership ReceivingOwnership { get { return Ownership.AllLookupDictionary[ReceivingOwnershipID]; } }
        public Ownership RetiredSensitiveOwnership { get { return Ownership.AllLookupDictionary[RetiredSensitiveOwnershipID]; } }
        public virtual Parcel ReceivingParcel { get; set; }
        public virtual Parcel RetiredSensitiveParcel { get; set; }
        public BaileyRating ReceivingBaileyRating { get { return ReceivingBaileyRatingID.HasValue ? BaileyRating.AllLookupDictionary[ReceivingBaileyRatingID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}