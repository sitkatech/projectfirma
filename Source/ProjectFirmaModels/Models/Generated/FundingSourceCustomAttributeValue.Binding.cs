//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeValue]
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
    // Table [dbo].[FundingSourceCustomAttributeValue] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FundingSourceCustomAttributeValue]")]
    public partial class FundingSourceCustomAttributeValue : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingSourceCustomAttributeValue()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSourceCustomAttributeValue(int fundingSourceCustomAttributeValueID, int fundingSourceCustomAttributeID, string attributeValue) : this()
        {
            this.FundingSourceCustomAttributeValueID = fundingSourceCustomAttributeValueID;
            this.FundingSourceCustomAttributeID = fundingSourceCustomAttributeID;
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSourceCustomAttributeValue(int fundingSourceCustomAttributeID, string attributeValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceCustomAttributeValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FundingSourceCustomAttributeID = fundingSourceCustomAttributeID;
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FundingSourceCustomAttributeValue(FundingSourceCustomAttribute fundingSourceCustomAttribute, string attributeValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceCustomAttributeValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FundingSourceCustomAttributeID = fundingSourceCustomAttribute.FundingSourceCustomAttributeID;
            this.FundingSourceCustomAttribute = fundingSourceCustomAttribute;
            fundingSourceCustomAttribute.FundingSourceCustomAttributeValues.Add(this);
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingSourceCustomAttributeValue CreateNewBlank(FundingSourceCustomAttribute fundingSourceCustomAttribute)
        {
            return new FundingSourceCustomAttributeValue(fundingSourceCustomAttribute, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingSourceCustomAttributeValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFundingSourceCustomAttributeValues.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FundingSourceCustomAttributeValueID { get; set; }
        public int TenantID { get; set; }
        public int FundingSourceCustomAttributeID { get; set; }
        public string AttributeValue { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingSourceCustomAttributeValueID; } set { FundingSourceCustomAttributeValueID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FundingSourceCustomAttribute FundingSourceCustomAttribute { get; set; }

        public static class FieldLengths
        {
            public const int AttributeValue = 1000;
        }
    }
}