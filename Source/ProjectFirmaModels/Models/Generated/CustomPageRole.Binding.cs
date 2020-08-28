//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CustomPageRole]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[CustomPageRole] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[CustomPageRole]")]
    public partial class CustomPageRole : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CustomPageRole()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPageRole(int customPageRoleID, int customPageID, int? roleID) : this()
        {
            this.CustomPageRoleID = customPageRoleID;
            this.CustomPageID = customPageID;
            this.RoleID = roleID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CustomPageRole(int customPageID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CustomPageID = customPageID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CustomPageRole(CustomPage customPage) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CustomPageRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CustomPageID = customPage.CustomPageID;
            this.CustomPage = customPage;
            customPage.CustomPageRoles.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CustomPageRole CreateNewBlank(CustomPage customPage)
        {
            return new CustomPageRole(customPage);
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CustomPageRole).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllCustomPageRoles.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int CustomPageRoleID { get; set; }
        public int TenantID { get; set; }
        public int CustomPageID { get; set; }
        public int? RoleID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CustomPageRoleID; } set { CustomPageRoleID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual CustomPage CustomPage { get; set; }
        public Role Role { get { return RoleID.HasValue ? Role.AllLookupDictionary[RoleID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}