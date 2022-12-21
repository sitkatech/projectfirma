//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectUpdateBatchClassificationSystem]
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
    // Table [dbo].[ProjectUpdateBatchClassificationSystem] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectUpdateBatchClassificationSystem]")]
    public partial class ProjectUpdateBatchClassificationSystem : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectUpdateBatchClassificationSystem()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateBatchClassificationSystem(int projectUpdateBatchClassificationSystemID, int projectUpdateBatchID, int classificationSystemID, string projectClassificationsDiffLog, string projectClassificationsComment) : this()
        {
            this.ProjectUpdateBatchClassificationSystemID = projectUpdateBatchClassificationSystemID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ClassificationSystemID = classificationSystemID;
            this.ProjectClassificationsDiffLog = projectClassificationsDiffLog;
            this.ProjectClassificationsComment = projectClassificationsComment;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectUpdateBatchClassificationSystem(int projectUpdateBatchID, int classificationSystemID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateBatchClassificationSystemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ClassificationSystemID = classificationSystemID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectUpdateBatchClassificationSystem(ProjectUpdateBatch projectUpdateBatch, ClassificationSystem classificationSystem) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectUpdateBatchClassificationSystemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectUpdateBatchClassificationSystems.Add(this);
            this.ClassificationSystemID = classificationSystem.ClassificationSystemID;
            this.ClassificationSystem = classificationSystem;
            classificationSystem.ProjectUpdateBatchClassificationSystems.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectUpdateBatchClassificationSystem CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, ClassificationSystem classificationSystem)
        {
            return new ProjectUpdateBatchClassificationSystem(projectUpdateBatch, classificationSystem);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectUpdateBatchClassificationSystem).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectUpdateBatchClassificationSystems.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectUpdateBatchClassificationSystemID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int ClassificationSystemID { get; set; }
        public string ProjectClassificationsDiffLog { get; set; }
        [NotMapped]
        public HtmlString ProjectClassificationsDiffLogHtmlString
        { 
            get { return ProjectClassificationsDiffLog == null ? null : new HtmlString(ProjectClassificationsDiffLog); }
            set { ProjectClassificationsDiffLog = value?.ToString(); }
        }
        public string ProjectClassificationsComment { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectUpdateBatchClassificationSystemID; } set { ProjectUpdateBatchClassificationSystemID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual ClassificationSystem ClassificationSystem { get; set; }

        public static class FieldLengths
        {
            public const int ProjectClassificationsComment = 1000;
        }
    }
}