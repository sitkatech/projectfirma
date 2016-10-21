//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityPool]
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
    [Table("[dbo].[CommodityPool]")]
    public partial class CommodityPool : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CommodityPool()
        {
            this.CommodityPoolDisbursements = new HashSet<CommodityPoolDisbursement>();
            this.ResidentialAllocations = new HashSet<ResidentialAllocation>();
            this.TdrTransactionAllocationsWhereYouAreTheSendingAllocationPool = new HashSet<TdrTransactionAllocation>();
            this.TdrTransactionAllocationAssignmentsWhereYouAreTheSendingAllocationPool = new HashSet<TdrTransactionAllocationAssignment>();
            this.TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingBonusPool = new HashSet<TdrTransactionTransferWithBonusUnit>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommodityPool(int commodityPoolID, string commodityPoolName, int jurisdictionID, string comments, bool isActive, DateTime? inactivatedDate, int? inactivatedByPersonID, int commodityID) : this()
        {
            this.CommodityPoolID = commodityPoolID;
            this.CommodityPoolName = commodityPoolName;
            this.JurisdictionID = jurisdictionID;
            this.Comments = comments;
            this.IsActive = isActive;
            this.InactivatedDate = inactivatedDate;
            this.InactivatedByPersonID = inactivatedByPersonID;
            this.CommodityID = commodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommodityPool(string commodityPoolName, int jurisdictionID, bool isActive, int commodityID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            CommodityPoolID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CommodityPoolName = commodityPoolName;
            this.JurisdictionID = jurisdictionID;
            this.IsActive = isActive;
            this.CommodityID = commodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CommodityPool(string commodityPoolName, Jurisdiction jurisdiction, bool isActive, Commodity commodity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CommodityPoolID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CommodityPoolName = commodityPoolName;
            this.JurisdictionID = jurisdiction.JurisdictionID;
            this.Jurisdiction = jurisdiction;
            jurisdiction.CommodityPools.Add(this);
            this.IsActive = isActive;
            this.CommodityID = commodity.CommodityID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CommodityPool CreateNewBlank(Jurisdiction jurisdiction, Commodity commodity)
        {
            return new CommodityPool(default(string), jurisdiction, default(bool), commodity);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return CommodityPoolDisbursements.Any() || ResidentialAllocations.Any() || TdrTransactionAllocationsWhereYouAreTheSendingAllocationPool.Any() || TdrTransactionAllocationAssignmentsWhereYouAreTheSendingAllocationPool.Any() || TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingBonusPool.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CommodityPool).Name, typeof(CommodityPoolDisbursement).Name, typeof(ResidentialAllocation).Name, typeof(TdrTransactionAllocation).Name, typeof(TdrTransactionAllocationAssignment).Name, typeof(TdrTransactionTransferWithBonusUnit).Name};

        [Key]
        public int CommodityPoolID { get; set; }
        public string CommodityPoolName { get; set; }
        public int JurisdictionID { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InactivatedDate { get; set; }
        public int? InactivatedByPersonID { get; set; }
        public int CommodityID { get; set; }
        public int PrimaryKey { get { return CommodityPoolID; } set { CommodityPoolID = value; } }

        public virtual ICollection<CommodityPoolDisbursement> CommodityPoolDisbursements { get; set; }
        public virtual ICollection<ResidentialAllocation> ResidentialAllocations { get; set; }
        public virtual ICollection<TdrTransactionAllocation> TdrTransactionAllocationsWhereYouAreTheSendingAllocationPool { get; set; }
        public virtual ICollection<TdrTransactionAllocationAssignment> TdrTransactionAllocationAssignmentsWhereYouAreTheSendingAllocationPool { get; set; }
        public virtual ICollection<TdrTransactionTransferWithBonusUnit> TdrTransactionTransferWithBonusUnitsWhereYouAreTheSendingBonusPool { get; set; }
        public virtual Jurisdiction Jurisdiction { get; set; }
        public virtual Person InactivatedByPerson { get; set; }
        public Commodity Commodity { get { return Commodity.AllLookupDictionary[CommodityID]; } }

        public static class FieldLengths
        {
            public const int CommodityPoolName = 300;
            public const int Comments = 4000;
        }
    }
}