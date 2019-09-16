//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectCustomAttributeGroup]
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
    // Table [dbo].[ProjectCustomAttributeGroup] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectCustomAttributeGroup]")]
    public partial class ProjectCustomAttributeGroup : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectCustomAttributeGroup()
        {
            this.ProjectCustomAttributeTypes = new HashSet<ProjectCustomAttributeType>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCustomAttributeGroup(int projectCustomAttributeGroupID, string projectCustomAttributeGroupName, int? sortOrder) : this()
        {
            this.ProjectCustomAttributeGroupID = projectCustomAttributeGroupID;
            this.ProjectCustomAttributeGroupName = projectCustomAttributeGroupName;
            this.SortOrder = sortOrder;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectCustomAttributeGroup CreateNewBlank()
        {
            return new ProjectCustomAttributeGroup();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectCustomAttributeTypes.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectCustomAttributeGroup).Name, typeof(ProjectCustomAttributeType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectCustomAttributeGroups.Remove(this);
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

            foreach(var x in ProjectCustomAttributeTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectCustomAttributeGroupID { get; set; }
        public int TenantID { get; set; }
        public string ProjectCustomAttributeGroupName { get; set; }
        public int? SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectCustomAttributeGroupID; } set { ProjectCustomAttributeGroupID = value; } }

        public virtual ICollection<ProjectCustomAttributeType> ProjectCustomAttributeTypes { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int ProjectCustomAttributeGroupName = 100;
        }
    }
}