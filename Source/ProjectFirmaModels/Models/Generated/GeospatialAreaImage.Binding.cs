//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaImage]
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
    // Table [dbo].[GeospatialAreaImage] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialAreaImage]")]
    public partial class GeospatialAreaImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialAreaImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaImage(int geospatialAreaImageID, int geospatialAreaID, int fileResourceID) : this()
        {
            this.GeospatialAreaImageID = geospatialAreaImageID;
            this.GeospatialAreaID = geospatialAreaID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaImage(int geospatialAreaID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaID = geospatialAreaID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public GeospatialAreaImage(GeospatialArea geospatialArea, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GeospatialAreaID = geospatialArea.GeospatialAreaID;
            this.GeospatialArea = geospatialArea;
            geospatialArea.GeospatialAreaImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.GeospatialAreaImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialAreaImage CreateNewBlank(GeospatialArea geospatialArea, FileResource fileResource)
        {
            return new GeospatialAreaImage(geospatialArea, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialAreaImage).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreaImages.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int GeospatialAreaImageID { get; set; }
        public int TenantID { get; set; }
        public int GeospatialAreaID { get; set; }
        public int FileResourceID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaImageID; } set { GeospatialAreaImageID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialArea GeospatialArea { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}