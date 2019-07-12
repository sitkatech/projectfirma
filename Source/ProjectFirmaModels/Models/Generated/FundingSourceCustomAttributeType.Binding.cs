//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeType]
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
    // Table [dbo].[FundingSourceCustomAttributeType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FundingSourceCustomAttributeType]")]
    public partial class FundingSourceCustomAttributeType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingSourceCustomAttributeType()
        {
            this.FundingSourceCustomAttributes = new HashSet<FundingSourceCustomAttribute>();
            this.FundingSourceCustomAttributeTypeRoles = new HashSet<FundingSourceCustomAttributeTypeRole>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSourceCustomAttributeType(int fundingSourceCustomAttributeTypeID, string fundingSourceCustomAttributeTypeName, int fundingSourceCustomAttributeDataTypeID, int? measurementUnitTypeID, bool isRequired, string fundingSourceCustomAttributeTypeDescription, string fundingSourceCustomAttributeTypeOptionsSchema, bool includeInFundingSourceGrid) : this()
        {
            this.FundingSourceCustomAttributeTypeID = fundingSourceCustomAttributeTypeID;
            this.FundingSourceCustomAttributeTypeName = fundingSourceCustomAttributeTypeName;
            this.FundingSourceCustomAttributeDataTypeID = fundingSourceCustomAttributeDataTypeID;
            this.MeasurementUnitTypeID = measurementUnitTypeID;
            this.IsRequired = isRequired;
            this.FundingSourceCustomAttributeTypeDescription = fundingSourceCustomAttributeTypeDescription;
            this.FundingSourceCustomAttributeTypeOptionsSchema = fundingSourceCustomAttributeTypeOptionsSchema;
            this.IncludeInFundingSourceGrid = includeInFundingSourceGrid;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSourceCustomAttributeType(string fundingSourceCustomAttributeTypeName, int fundingSourceCustomAttributeDataTypeID, bool isRequired, bool includeInFundingSourceGrid) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceCustomAttributeTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FundingSourceCustomAttributeTypeName = fundingSourceCustomAttributeTypeName;
            this.FundingSourceCustomAttributeDataTypeID = fundingSourceCustomAttributeDataTypeID;
            this.IsRequired = isRequired;
            this.IncludeInFundingSourceGrid = includeInFundingSourceGrid;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FundingSourceCustomAttributeType(string fundingSourceCustomAttributeTypeName, FundingSourceCustomAttributeDataType fundingSourceCustomAttributeDataType, bool isRequired, bool includeInFundingSourceGrid) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceCustomAttributeTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FundingSourceCustomAttributeTypeName = fundingSourceCustomAttributeTypeName;
            this.FundingSourceCustomAttributeDataTypeID = fundingSourceCustomAttributeDataType.FundingSourceCustomAttributeDataTypeID;
            this.IsRequired = isRequired;
            this.IncludeInFundingSourceGrid = includeInFundingSourceGrid;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingSourceCustomAttributeType CreateNewBlank(FundingSourceCustomAttributeDataType fundingSourceCustomAttributeDataType)
        {
            return new FundingSourceCustomAttributeType(default(string), fundingSourceCustomAttributeDataType, default(bool), default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FundingSourceCustomAttributes.Any() || FundingSourceCustomAttributeTypeRoles.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingSourceCustomAttributeType).Name, typeof(FundingSourceCustomAttribute).Name, typeof(FundingSourceCustomAttributeTypeRole).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFundingSourceCustomAttributeTypes.Remove(this);
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

            foreach(var x in FundingSourceCustomAttributes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in FundingSourceCustomAttributeTypeRoles.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int FundingSourceCustomAttributeTypeID { get; set; }
        public int TenantID { get; set; }
        public string FundingSourceCustomAttributeTypeName { get; set; }
        public int FundingSourceCustomAttributeDataTypeID { get; set; }
        public int? MeasurementUnitTypeID { get; set; }
        public bool IsRequired { get; set; }
        public string FundingSourceCustomAttributeTypeDescription { get; set; }
        public string FundingSourceCustomAttributeTypeOptionsSchema { get; set; }
        public bool IncludeInFundingSourceGrid { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingSourceCustomAttributeTypeID; } set { FundingSourceCustomAttributeTypeID = value; } }

        public virtual ICollection<FundingSourceCustomAttribute> FundingSourceCustomAttributes { get; set; }
        public virtual ICollection<FundingSourceCustomAttributeTypeRole> FundingSourceCustomAttributeTypeRoles { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public FundingSourceCustomAttributeDataType FundingSourceCustomAttributeDataType { get { return FundingSourceCustomAttributeDataType.AllLookupDictionary[FundingSourceCustomAttributeDataTypeID]; } }
        public MeasurementUnitType MeasurementUnitType { get { return MeasurementUnitTypeID.HasValue ? MeasurementUnitType.AllLookupDictionary[MeasurementUnitTypeID.Value] : null; } }

        public static class FieldLengths
        {
            public const int FundingSourceCustomAttributeTypeName = 100;
            public const int FundingSourceCustomAttributeTypeDescription = 200;
        }
    }
}