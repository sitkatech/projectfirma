//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeTypeRole]
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
    // Table [dbo].[ProjectCustomAttributeTypeRole] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectCustomAttributeTypeRole]")]
    public partial class ProjectCustomAttributeTypeRole : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttributeTypeRole()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeTypeRole(int projectCustomAttributeTypeRoleID, int projectCustomAttributeTypeID, int? roleID, int projectCustomAttributeTypeRolePermissionTypeID) : this()
        {
            this.ProjectCustomAttributeTypeRoleID = projectCustomAttributeTypeRoleID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
            this.RoleID = roleID;
            this.ProjectCustomAttributeTypeRolePermissionTypeID = projectCustomAttributeTypeRolePermissionTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeTypeRole(int projectCustomAttributeTypeID, int projectCustomAttributeTypeRolePermissionTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeTypeRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
            this.ProjectCustomAttributeTypeRolePermissionTypeID = projectCustomAttributeTypeRolePermissionTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectCustomAttributeTypeRole(ProjectCustomAttributeType projectCustomAttributeType, ProjectCustomAttributeTypeRolePermissionType projectCustomAttributeTypeRolePermissionType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectCustomAttributeTypeRoleID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectCustomAttributeTypeID = projectCustomAttributeType.ProjectCustomAttributeTypeID;
            this.ProjectCustomAttributeType = projectCustomAttributeType;
            projectCustomAttributeType.ProjectCustomAttributeTypeRoles.Add(this);
            this.ProjectCustomAttributeTypeRolePermissionTypeID = projectCustomAttributeTypeRolePermissionType.ProjectCustomAttributeTypeRolePermissionTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttributeTypeRole CreateNewBlank(ProjectCustomAttributeType projectCustomAttributeType, ProjectCustomAttributeTypeRolePermissionType projectCustomAttributeTypeRolePermissionType)
        {
            return new ProjectCustomAttributeTypeRole(projectCustomAttributeType, projectCustomAttributeTypeRolePermissionType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttributeTypeRole).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectCustomAttributeTypeRoles.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectCustomAttributeTypeRoleID { get; set; }
        public int TenantID { get; set; }
        public int ProjectCustomAttributeTypeID { get; set; }
        public int? RoleID { get; set; }
        public int ProjectCustomAttributeTypeRolePermissionTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeTypeRoleID; } set { ProjectCustomAttributeTypeRoleID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectCustomAttributeType ProjectCustomAttributeType { get; set; }
        public Role Role { get { return RoleID.HasValue ? Role.AllLookupDictionary[RoleID.Value] : null; } }
        public ProjectCustomAttributeTypeRolePermissionType ProjectCustomAttributeTypeRolePermissionType { get { return ProjectCustomAttributeTypeRolePermissionType.AllLookupDictionary[ProjectCustomAttributeTypeRolePermissionTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}