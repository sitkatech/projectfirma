//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AttachmentTypeRole]
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
    // Table [dbo].[AttachmentTypeRole] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[AttachmentTypeRole]")]
    public partial class AttachmentTypeRole : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AttachmentTypeRole()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentTypeRole(int attachmentTypeRoleID, int attachmentTypeID, int? roleID) : this()
        {
            this.AttachmentTypeRoleID = attachmentTypeRoleID;
            this.AttachmentTypeID = attachmentTypeID;
            this.RoleID = roleID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AttachmentTypeRole(int attachmentTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentTypeRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AttachmentTypeID = attachmentTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AttachmentTypeRole(AttachmentType attachmentType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AttachmentTypeRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.AttachmentTypeID = attachmentType.AttachmentTypeID;
            this.AttachmentType = attachmentType;
            attachmentType.AttachmentTypeRoles.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AttachmentTypeRole CreateNewBlank(AttachmentType attachmentType)
        {
            return new AttachmentTypeRole(attachmentType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AttachmentTypeRole).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllAttachmentTypeRoles.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int AttachmentTypeRoleID { get; set; }
        public int TenantID { get; set; }
        public int AttachmentTypeID { get; set; }
        public int? RoleID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AttachmentTypeRoleID; } set { AttachmentTypeRoleID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual AttachmentType AttachmentType { get; set; }
        public Role Role { get { return RoleID.HasValue ? Role.AllLookupDictionary[RoleID.Value] : null; } }

        public static class FieldLengths
        {

        }
    }
}