//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttribute]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[FundingSourceCustomAttribute] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FundingSourceCustomAttribute]")]
    public partial class FundingSourceCustomAttribute : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingSourceCustomAttribute()
        {
            this.FundingSourceCustomAttributeValues = new HashSet<FundingSourceCustomAttributeValue>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSourceCustomAttribute(int fundingSourceCustomAttributeID, int fundingSourceID, int fundingSourceCustomAttributeTypeID) : this()
        {
            this.FundingSourceCustomAttributeID = fundingSourceCustomAttributeID;
            this.FundingSourceID = fundingSourceID;
            this.FundingSourceCustomAttributeTypeID = fundingSourceCustomAttributeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSourceCustomAttribute(int fundingSourceID, int fundingSourceCustomAttributeTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceCustomAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FundingSourceID = fundingSourceID;
            this.FundingSourceCustomAttributeTypeID = fundingSourceCustomAttributeTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FundingSourceCustomAttribute(FundingSource fundingSource, FundingSourceCustomAttributeType fundingSourceCustomAttributeType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceCustomAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.FundingSourceCustomAttributes.Add(this);
            this.FundingSourceCustomAttributeTypeID = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID;
            this.FundingSourceCustomAttributeType = fundingSourceCustomAttributeType;
            fundingSourceCustomAttributeType.FundingSourceCustomAttributes.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingSourceCustomAttribute CreateNewBlank(FundingSource fundingSource, FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
        {
            return new FundingSourceCustomAttribute(fundingSource, fundingSourceCustomAttributeType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FundingSourceCustomAttributeValues.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingSourceCustomAttribute).Name, typeof(FundingSourceCustomAttributeValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFundingSourceCustomAttributes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in FundingSourceCustomAttributeValues.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FundingSourceCustomAttributeID { get; set; }
        public int TenantID { get; set; }
        public int FundingSourceID { get; set; }
        public int FundingSourceCustomAttributeTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingSourceCustomAttributeID; } set { FundingSourceCustomAttributeID = value; } }

        public virtual ICollection<FundingSourceCustomAttributeValue> FundingSourceCustomAttributeValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FundingSource FundingSource { get; set; }
        public virtual FundingSourceCustomAttributeType FundingSourceCustomAttributeType { get; set; }

        public static class FieldLengths
        {

        }
    }
}