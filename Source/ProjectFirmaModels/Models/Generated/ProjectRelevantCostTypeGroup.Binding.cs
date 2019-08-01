//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostTypeGroup]
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
    // Table [dbo].[ProjectRelevantCostTypeGroup] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ProjectRelevantCostTypeGroup]")]
    public partial class ProjectRelevantCostTypeGroup : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectRelevantCostTypeGroup()
        {
            this.ProjectRelevantCostTypes = new HashSet<ProjectRelevantCostType>();
            this.ProjectRelevantCostTypeUpdates = new HashSet<ProjectRelevantCostTypeUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectRelevantCostTypeGroup(int projectRelevantCostTypeGroupID, string projectRelevantCostTypeGroupName, string projectRelevantCostTypeGroupDisplayName) : this()
        {
            this.ProjectRelevantCostTypeGroupID = projectRelevantCostTypeGroupID;
            this.ProjectRelevantCostTypeGroupName = projectRelevantCostTypeGroupName;
            this.ProjectRelevantCostTypeGroupDisplayName = projectRelevantCostTypeGroupDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectRelevantCostTypeGroup(string projectRelevantCostTypeGroupName, string projectRelevantCostTypeGroupDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectRelevantCostTypeGroupID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectRelevantCostTypeGroupName = projectRelevantCostTypeGroupName;
            this.ProjectRelevantCostTypeGroupDisplayName = projectRelevantCostTypeGroupDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectRelevantCostTypeGroup CreateNewBlank()
        {
            return new ProjectRelevantCostTypeGroup(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectRelevantCostTypes.Any() || ProjectRelevantCostTypeUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectRelevantCostTypeGroup).Name, typeof(ProjectRelevantCostType).Name, typeof(ProjectRelevantCostTypeUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ProjectRelevantCostTypeGroups.Remove(this);
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

            foreach(var x in ProjectRelevantCostTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectRelevantCostTypeUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectRelevantCostTypeGroupID { get; set; }
        public string ProjectRelevantCostTypeGroupName { get; set; }
        public string ProjectRelevantCostTypeGroupDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectRelevantCostTypeGroupID; } set { ProjectRelevantCostTypeGroupID = value; } }

        public virtual ICollection<ProjectRelevantCostType> ProjectRelevantCostTypes { get; set; }
        public virtual ICollection<ProjectRelevantCostTypeUpdate> ProjectRelevantCostTypeUpdates { get; set; }

        public static class FieldLengths
        {
            public const int ProjectRelevantCostTypeGroupName = 50;
            public const int ProjectRelevantCostTypeGroupDisplayName = 50;
        }
    }
}