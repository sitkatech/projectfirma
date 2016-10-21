//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ResidentialAllocation]
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
    [Table("[dbo].[ResidentialAllocation]")]
    public partial class ResidentialAllocation : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ResidentialAllocation()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ResidentialAllocation(int residentialAllocationID, int jurisdictionID, int issuanceYear, int residentialAllocationTypeID, int allocationSequence, int commodityPoolDisbursementID, int? tdrTransactionID, int? withdrawnTdrTransactionID, bool isAllocatedButNoTransactionRecord, int commodityPoolID, int? assignedToJurisdictionID) : this()
        {
            this.ResidentialAllocationID = residentialAllocationID;
            this.JurisdictionID = jurisdictionID;
            this.IssuanceYear = issuanceYear;
            this.ResidentialAllocationTypeID = residentialAllocationTypeID;
            this.AllocationSequence = allocationSequence;
            this.CommodityPoolDisbursementID = commodityPoolDisbursementID;
            this.TdrTransactionID = tdrTransactionID;
            this.WithdrawnTdrTransactionID = withdrawnTdrTransactionID;
            this.IsAllocatedButNoTransactionRecord = isAllocatedButNoTransactionRecord;
            this.CommodityPoolID = commodityPoolID;
            this.AssignedToJurisdictionID = assignedToJurisdictionID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ResidentialAllocation(int jurisdictionID, int issuanceYear, int residentialAllocationTypeID, int allocationSequence, int commodityPoolDisbursementID, bool isAllocatedButNoTransactionRecord, int commodityPoolID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ResidentialAllocationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.JurisdictionID = jurisdictionID;
            this.IssuanceYear = issuanceYear;
            this.ResidentialAllocationTypeID = residentialAllocationTypeID;
            this.AllocationSequence = allocationSequence;
            this.CommodityPoolDisbursementID = commodityPoolDisbursementID;
            this.IsAllocatedButNoTransactionRecord = isAllocatedButNoTransactionRecord;
            this.CommodityPoolID = commodityPoolID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ResidentialAllocation(Jurisdiction jurisdiction, int issuanceYear, ResidentialAllocationType residentialAllocationType, int allocationSequence, CommodityPoolDisbursement commodityPoolDisbursement, bool isAllocatedButNoTransactionRecord, CommodityPool commodityPool) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ResidentialAllocationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.JurisdictionID = jurisdiction.JurisdictionID;
            this.Jurisdiction = jurisdiction;
            jurisdiction.ResidentialAllocations.Add(this);
            this.IssuanceYear = issuanceYear;
            this.ResidentialAllocationTypeID = residentialAllocationType.ResidentialAllocationTypeID;
            this.AllocationSequence = allocationSequence;
            this.CommodityPoolDisbursementID = commodityPoolDisbursement.CommodityPoolDisbursementID;
            this.CommodityPoolDisbursement = commodityPoolDisbursement;
            commodityPoolDisbursement.ResidentialAllocations.Add(this);
            this.IsAllocatedButNoTransactionRecord = isAllocatedButNoTransactionRecord;
            this.CommodityPoolID = commodityPool.CommodityPoolID;
            this.CommodityPool = commodityPool;
            commodityPool.ResidentialAllocations.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ResidentialAllocation CreateNewBlank(Jurisdiction jurisdiction, ResidentialAllocationType residentialAllocationType, CommodityPoolDisbursement commodityPoolDisbursement, CommodityPool commodityPool)
        {
            return new ResidentialAllocation(jurisdiction, default(int), residentialAllocationType, default(int), commodityPoolDisbursement, default(bool), commodityPool);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ResidentialAllocation).Name};

        [Key]
        public int ResidentialAllocationID { get; set; }
        public int JurisdictionID { get; set; }
        public int IssuanceYear { get; set; }
        public int ResidentialAllocationTypeID { get; set; }
        public int AllocationSequence { get; set; }
        public int CommodityPoolDisbursementID { get; set; }
        public int? TdrTransactionID { get; set; }
        public int? WithdrawnTdrTransactionID { get; set; }
        public bool IsAllocatedButNoTransactionRecord { get; set; }
        public int CommodityPoolID { get; set; }
        public int? AssignedToJurisdictionID { get; set; }
        public int PrimaryKey { get { return ResidentialAllocationID; } set { ResidentialAllocationID = value; } }

        public virtual Jurisdiction AssignedToJurisdiction { get; set; }
        public virtual Jurisdiction Jurisdiction { get; set; }
        public ResidentialAllocationType ResidentialAllocationType { get { return ResidentialAllocationType.AllLookupDictionary[ResidentialAllocationTypeID]; } }
        public virtual CommodityPoolDisbursement CommodityPoolDisbursement { get; set; }
        public virtual TdrTransaction TdrTransaction { get; set; }
        public virtual TdrTransaction WithdrawnTdrTransaction { get; set; }
        public virtual CommodityPool CommodityPool { get; set; }

        public static class FieldLengths
        {

        }
    }
}