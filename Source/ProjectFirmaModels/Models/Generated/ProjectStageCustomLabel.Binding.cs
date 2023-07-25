//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectStageCustomLabel]
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
    // Table [dbo].[ProjectStageCustomLabel] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectStageCustomLabel]")]
    public partial class ProjectStageCustomLabel : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectStageCustomLabel()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectStageCustomLabel(int projectStageCustomLabelID, int projectStageID, string projectStageLabel) : this()
        {
            this.ProjectStageCustomLabelID = projectStageCustomLabelID;
            this.ProjectStageID = projectStageID;
            this.ProjectStageLabel = projectStageLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectStageCustomLabel(int projectStageID, string projectStageLabel) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectStageCustomLabelID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectStageID = projectStageID;
            this.ProjectStageLabel = projectStageLabel;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectStageCustomLabel(ProjectStage projectStage, string projectStageLabel) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectStageCustomLabelID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectStageID = projectStage.ProjectStageID;
            this.ProjectStageLabel = projectStageLabel;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectStageCustomLabel CreateNewBlank(ProjectStage projectStage)
        {
            return new ProjectStageCustomLabel(projectStage, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectStageCustomLabel).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectStageCustomLabels.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectStageCustomLabelID { get; set; }
        public int TenantID { get; set; }
        public int ProjectStageID { get; set; }
        public string ProjectStageLabel { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectStageCustomLabelID; } set { ProjectStageCustomLabelID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public ProjectStage ProjectStage { get { return ProjectStage.AllLookupDictionary[ProjectStageID]; } }

        public static class FieldLengths
        {
            public const int ProjectStageLabel = 300;
        }
    }
}