//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectGeospatialAreaUpdate]
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
    // Table [dbo].[ProjectGeospatialAreaUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectGeospatialAreaUpdate]")]
    public partial class ProjectGeospatialAreaUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectGeospatialAreaUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectGeospatialAreaUpdate(int projectGeospatialAreaUpdateID, int projectUpdateBatchID, int geospatialAreaID) : this()
        {
            this.ProjectGeospatialAreaUpdateID = projectGeospatialAreaUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.GeospatialAreaID = geospatialAreaID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectGeospatialAreaUpdate(int projectUpdateBatchID, int geospatialAreaID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectGeospatialAreaUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.GeospatialAreaID = geospatialAreaID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectGeospatialAreaUpdate(ProjectUpdateBatch projectUpdateBatch, GeospatialArea geospatialArea) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectGeospatialAreaUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectGeospatialAreaUpdates.Add(this);
            this.GeospatialAreaID = geospatialArea.GeospatialAreaID;
            this.GeospatialArea = geospatialArea;
            geospatialArea.ProjectGeospatialAreaUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectGeospatialAreaUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, GeospatialArea geospatialArea)
        {
            return new ProjectGeospatialAreaUpdate(projectUpdateBatch, geospatialArea);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectGeospatialAreaUpdate).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            dbContext.AllProjectGeospatialAreaUpdates.Remove(this);
        }

        [Key]
        public int ProjectGeospatialAreaUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int GeospatialAreaID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectGeospatialAreaUpdateID; } set { ProjectGeospatialAreaUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual GeospatialArea GeospatialArea { get; set; }

        public static class FieldLengths
        {

        }
    }
}