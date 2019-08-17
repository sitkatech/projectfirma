//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectRelevantCostType]
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
    // Table [dbo].[ProjectRelevantCostType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectRelevantCostType]")]
    public partial class ProjectRelevantCostType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectRelevantCostType()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectRelevantCostType(int projectRelevantCostTypeID, int projectID, int costTypeID, int projectRelevantCostTypeGroupID) : this()
        {
            this.ProjectRelevantCostTypeID = projectRelevantCostTypeID;
            this.ProjectID = projectID;
            this.CostTypeID = costTypeID;
            this.ProjectRelevantCostTypeGroupID = projectRelevantCostTypeGroupID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectRelevantCostType(int projectID, int costTypeID, int projectRelevantCostTypeGroupID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectRelevantCostTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.CostTypeID = costTypeID;
            this.ProjectRelevantCostTypeGroupID = projectRelevantCostTypeGroupID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectRelevantCostType(Project project, CostType costType, ProjectRelevantCostTypeGroup projectRelevantCostTypeGroup) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectRelevantCostTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectRelevantCostTypes.Add(this);
            this.CostTypeID = costType.CostTypeID;
            this.CostType = costType;
            costType.ProjectRelevantCostTypes.Add(this);
            this.ProjectRelevantCostTypeGroupID = projectRelevantCostTypeGroup.ProjectRelevantCostTypeGroupID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectRelevantCostType CreateNewBlank(Project project, CostType costType, ProjectRelevantCostTypeGroup projectRelevantCostTypeGroup)
        {
            return new ProjectRelevantCostType(project, costType, projectRelevantCostTypeGroup);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectRelevantCostType).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectRelevantCostTypes.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectRelevantCostTypeID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int CostTypeID { get; set; }
        public int ProjectRelevantCostTypeGroupID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectRelevantCostTypeID; } set { ProjectRelevantCostTypeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual CostType CostType { get; set; }
        public ProjectRelevantCostTypeGroup ProjectRelevantCostTypeGroup { get { return ProjectRelevantCostTypeGroup.AllLookupDictionary[ProjectRelevantCostTypeGroupID]; } }

        public static class FieldLengths
        {

        }
    }
}