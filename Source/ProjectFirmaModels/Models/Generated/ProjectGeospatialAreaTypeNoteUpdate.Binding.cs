//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaTypeNoteUpdate]
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
    // Table [dbo].[ProjectGeospatialAreaTypeNoteUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectGeospatialAreaTypeNoteUpdate]")]
    public partial class ProjectGeospatialAreaTypeNoteUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectGeospatialAreaTypeNoteUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectGeospatialAreaTypeNoteUpdate(int projectGeospatialAreaTypeNoteUpdateID, int projectUpdateBatchID, int geospatialAreaTypeID, string notes) : this()
        {
            this.ProjectGeospatialAreaTypeNoteUpdateID = projectGeospatialAreaTypeNoteUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.Notes = notes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectGeospatialAreaTypeNoteUpdate(int projectUpdateBatchID, int geospatialAreaTypeID, string notes) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectGeospatialAreaTypeNoteUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.Notes = notes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectGeospatialAreaTypeNoteUpdate(ProjectUpdateBatch projectUpdateBatch, GeospatialAreaType geospatialAreaType, string notes) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectGeospatialAreaTypeNoteUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates.Add(this);
            this.GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            this.GeospatialAreaType = geospatialAreaType;
            geospatialAreaType.ProjectGeospatialAreaTypeNoteUpdates.Add(this);
            this.Notes = notes;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectGeospatialAreaTypeNoteUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, GeospatialAreaType geospatialAreaType)
        {
            return new ProjectGeospatialAreaTypeNoteUpdate(projectUpdateBatch, geospatialAreaType, default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectGeospatialAreaTypeNoteUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectGeospatialAreaTypeNoteUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectGeospatialAreaTypeNoteUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int GeospatialAreaTypeID { get; set; }
        public string Notes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectGeospatialAreaTypeNoteUpdateID; } set { ProjectGeospatialAreaTypeNoteUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual GeospatialAreaType GeospatialAreaType { get; set; }

        public static class FieldLengths
        {
            public const int Notes = 4000;
        }
    }
}