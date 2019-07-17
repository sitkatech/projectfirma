//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FundingSourceCustomAttributeTypeRole]
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
    // Table [dbo].[FundingSourceCustomAttributeTypeRole] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[FundingSourceCustomAttributeTypeRole]")]
    public partial class FundingSourceCustomAttributeTypeRole : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FundingSourceCustomAttributeTypeRole()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSourceCustomAttributeTypeRole(int fundingSourceCustomAttributeTypeRoleID, int fundingSourceCustomAttributeTypeID, int roleID, int fundingSourceCustomAttributeTypeRolePermissionTypeID) : this()
        {
            this.FundingSourceCustomAttributeTypeRoleID = fundingSourceCustomAttributeTypeRoleID;
            this.FundingSourceCustomAttributeTypeID = fundingSourceCustomAttributeTypeID;
            this.RoleID = roleID;
            this.FundingSourceCustomAttributeTypeRolePermissionTypeID = fundingSourceCustomAttributeTypeRolePermissionTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FundingSourceCustomAttributeTypeRole(int fundingSourceCustomAttributeTypeID, int roleID, int fundingSourceCustomAttributeTypeRolePermissionTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceCustomAttributeTypeRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FundingSourceCustomAttributeTypeID = fundingSourceCustomAttributeTypeID;
            this.RoleID = roleID;
            this.FundingSourceCustomAttributeTypeRolePermissionTypeID = fundingSourceCustomAttributeTypeRolePermissionTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FundingSourceCustomAttributeTypeRole(FundingSourceCustomAttributeType fundingSourceCustomAttributeType, Role role, FundingSourceCustomAttributeTypeRolePermissionType fundingSourceCustomAttributeTypeRolePermissionType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FundingSourceCustomAttributeTypeRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FundingSourceCustomAttributeTypeID = fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID;
            this.FundingSourceCustomAttributeType = fundingSourceCustomAttributeType;
            fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeRoles.Add(this);
            this.RoleID = role.RoleID;
            this.FundingSourceCustomAttributeTypeRolePermissionTypeID = fundingSourceCustomAttributeTypeRolePermissionType.FundingSourceCustomAttributeTypeRolePermissionTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FundingSourceCustomAttributeTypeRole CreateNewBlank(FundingSourceCustomAttributeType fundingSourceCustomAttributeType, Role role, FundingSourceCustomAttributeTypeRolePermissionType fundingSourceCustomAttributeTypeRolePermissionType)
        {
            return new FundingSourceCustomAttributeTypeRole(fundingSourceCustomAttributeType, role, fundingSourceCustomAttributeTypeRolePermissionType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FundingSourceCustomAttributeTypeRole).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllFundingSourceCustomAttributeTypeRoles.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int FundingSourceCustomAttributeTypeRoleID { get; set; }
        public int TenantID { get; set; }
        public int FundingSourceCustomAttributeTypeID { get; set; }
        public int RoleID { get; set; }
        public int FundingSourceCustomAttributeTypeRolePermissionTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return FundingSourceCustomAttributeTypeRoleID; } set { FundingSourceCustomAttributeTypeRoleID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual FundingSourceCustomAttributeType FundingSourceCustomAttributeType { get; set; }
        public Role Role { get { return Role.AllLookupDictionary[RoleID]; } }
        public FundingSourceCustomAttributeTypeRolePermissionType FundingSourceCustomAttributeTypeRolePermissionType { get { return FundingSourceCustomAttributeTypeRolePermissionType.AllLookupDictionary[FundingSourceCustomAttributeTypeRolePermissionTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}