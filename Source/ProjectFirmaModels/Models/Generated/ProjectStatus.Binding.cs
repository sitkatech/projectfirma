//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStatus]
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
    // Table [dbo].[ProjectStatus] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectStatus]")]
    public partial class ProjectStatus : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectStatus()
        {
            this.ProjectProjectStatuses = new HashSet<ProjectProjectStatus>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectStatus(int projectStatusID, string projectStatusName, string projectStatusDescription, string projectStatusDisplayName, int? projectStatusSortOrder, string projectStatusColor) : this()
        {
            this.ProjectStatusID = projectStatusID;
            this.ProjectStatusName = projectStatusName;
            this.ProjectStatusDescription = projectStatusDescription;
            this.ProjectStatusDisplayName = projectStatusDisplayName;
            this.ProjectStatusSortOrder = projectStatusSortOrder;
            this.ProjectStatusColor = projectStatusColor;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectStatus(string projectStatusName, string projectStatusDisplayName, string projectStatusColor) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectStatusID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectStatusName = projectStatusName;
            this.ProjectStatusDisplayName = projectStatusDisplayName;
            this.ProjectStatusColor = projectStatusColor;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectStatus CreateNewBlank()
        {
            return new ProjectStatus(default(string), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectProjectStatuses.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectStatus).Name, typeof(ProjectProjectStatus).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectStatuses.Remove(this);
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

            foreach(var x in ProjectProjectStatuses.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectStatusID { get; set; }
        public int TenantID { get; set; }
        public string ProjectStatusName { get; set; }
        public string ProjectStatusDescription { get; set; }
        public string ProjectStatusDisplayName { get; set; }
        public int? ProjectStatusSortOrder { get; set; }
        public string ProjectStatusColor { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectStatusID; } set { ProjectStatusID = value; } }

        public virtual ICollection<ProjectProjectStatus> ProjectProjectStatuses { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int ProjectStatusName = 100;
            public const int ProjectStatusDescription = 100;
            public const int ProjectStatusDisplayName = 100;
            public const int ProjectStatusColor = 20;
        }
    }
}