//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityPoolDisbursement]
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
    [Table("[dbo].[CommodityPoolDisbursement]")]
    public partial class CommodityPoolDisbursement : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CommodityPoolDisbursement()
        {
            this.ResidentialAllocations = new HashSet<ResidentialAllocation>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommodityPoolDisbursement(int commodityPoolDisbursementID, int commodityPoolID, string commodityPoolDisbursementTitle, DateTime commodityPoolDisbursementDate, int commodityPoolDisbursementAmount, string commodityPoolDisbursementDescription, DateTime createDate, int createPersonID, DateTime? updateDate, int? updatePersonID) : this()
        {
            this.CommodityPoolDisbursementID = commodityPoolDisbursementID;
            this.CommodityPoolID = commodityPoolID;
            this.CommodityPoolDisbursementTitle = commodityPoolDisbursementTitle;
            this.CommodityPoolDisbursementDate = commodityPoolDisbursementDate;
            this.CommodityPoolDisbursementAmount = commodityPoolDisbursementAmount;
            this.CommodityPoolDisbursementDescription = commodityPoolDisbursementDescription;
            this.CreateDate = createDate;
            this.CreatePersonID = createPersonID;
            this.UpdateDate = updateDate;
            this.UpdatePersonID = updatePersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommodityPoolDisbursement(int commodityPoolID, string commodityPoolDisbursementTitle, DateTime commodityPoolDisbursementDate, int commodityPoolDisbursementAmount, DateTime createDate, int createPersonID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            CommodityPoolDisbursementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CommodityPoolID = commodityPoolID;
            this.CommodityPoolDisbursementTitle = commodityPoolDisbursementTitle;
            this.CommodityPoolDisbursementDate = commodityPoolDisbursementDate;
            this.CommodityPoolDisbursementAmount = commodityPoolDisbursementAmount;
            this.CreateDate = createDate;
            this.CreatePersonID = createPersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CommodityPoolDisbursement(CommodityPool commodityPool, string commodityPoolDisbursementTitle, DateTime commodityPoolDisbursementDate, int commodityPoolDisbursementAmount, DateTime createDate, Person createPerson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CommodityPoolDisbursementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CommodityPoolID = commodityPool.CommodityPoolID;
            this.CommodityPool = commodityPool;
            commodityPool.CommodityPoolDisbursements.Add(this);
            this.CommodityPoolDisbursementTitle = commodityPoolDisbursementTitle;
            this.CommodityPoolDisbursementDate = commodityPoolDisbursementDate;
            this.CommodityPoolDisbursementAmount = commodityPoolDisbursementAmount;
            this.CreateDate = createDate;
            this.CreatePersonID = createPerson.PersonID;
            this.CreatePerson = createPerson;
            createPerson.CommodityPoolDisbursementsWhereYouAreTheCreatePerson.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CommodityPoolDisbursement CreateNewBlank(CommodityPool commodityPool, Person createPerson)
        {
            return new CommodityPoolDisbursement(commodityPool, default(string), default(DateTime), default(int), default(DateTime), createPerson);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ResidentialAllocations.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CommodityPoolDisbursement).Name, typeof(ResidentialAllocation).Name};

        [Key]
        public int CommodityPoolDisbursementID { get; set; }
        public int CommodityPoolID { get; set; }
        public string CommodityPoolDisbursementTitle { get; set; }
        public DateTime CommodityPoolDisbursementDate { get; set; }
        public int CommodityPoolDisbursementAmount { get; set; }
        public string CommodityPoolDisbursementDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatePersonID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatePersonID { get; set; }
        public int PrimaryKey { get { return CommodityPoolDisbursementID; } set { CommodityPoolDisbursementID = value; } }

        public virtual ICollection<ResidentialAllocation> ResidentialAllocations { get; set; }
        public virtual CommodityPool CommodityPool { get; set; }
        public virtual Person CreatePerson { get; set; }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int CommodityPoolDisbursementTitle = 500;
            public const int CommodityPoolDisbursementDescription = 1000;
        }
    }
}