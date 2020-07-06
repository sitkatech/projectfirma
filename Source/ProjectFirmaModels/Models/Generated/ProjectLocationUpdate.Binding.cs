//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationUpdate]
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
    // Table [dbo].[ProjectLocationUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectLocationUpdate]")]
    public partial class ProjectLocationUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocationUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationUpdate(int projectLocationUpdateID, int projectUpdateBatchID, DbGeometry projectLocationUpdateGeometry, string annotation) : this()
        {
            this.ProjectLocationUpdateID = projectLocationUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectLocationUpdateGeometry = projectLocationUpdateGeometry;
            this.Annotation = annotation;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationUpdate(int projectUpdateBatchID, DbGeometry projectLocationUpdateGeometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.ProjectLocationUpdateGeometry = projectLocationUpdateGeometry;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocationUpdate(ProjectUpdateBatch projectUpdateBatch, DbGeometry projectLocationUpdateGeometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectLocationUpdates.Add(this);
            this.ProjectLocationUpdateGeometry = projectLocationUpdateGeometry;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocationUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch)
        {
            return new ProjectLocationUpdate(projectUpdateBatch, default(DbGeometry));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocationUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectLocationUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectLocationUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public DbGeometry ProjectLocationUpdateGeometry { get; set; }
        public string Annotation { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectLocationUpdateID; } set { ProjectLocationUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }

        public static class FieldLengths
        {
            public const int Annotation = 255;
        }
    }
}