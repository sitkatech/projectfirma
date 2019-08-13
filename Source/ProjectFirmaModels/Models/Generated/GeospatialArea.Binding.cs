//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialArea]
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
    // Table [dbo].[GeospatialArea] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialArea]")]
    public partial class GeospatialArea : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialArea()
        {
            this.GeospatialAreaImages = new HashSet<GeospatialAreaImage>();
            this.PersonStewardGeospatialAreas = new HashSet<PersonStewardGeospatialArea>();
            this.ProjectGeospatialAreas = new HashSet<ProjectGeospatialArea>();
            this.ProjectGeospatialAreaUpdates = new HashSet<ProjectGeospatialAreaUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialArea(int geospatialAreaID, string geospatialAreaName, DbGeometry geospatialAreaFeature, int geospatialAreaTypeID, string geospatialAreaDescriptionContent) : this()
        {
            this.GeospatialAreaID = geospatialAreaID;
            this.GeospatialAreaName = geospatialAreaName;
            this.GeospatialAreaFeature = geospatialAreaFeature;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.GeospatialAreaDescriptionContent = geospatialAreaDescriptionContent;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialArea(string geospatialAreaName, int geospatialAreaTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaName = geospatialAreaName;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public GeospatialArea(string geospatialAreaName, GeospatialAreaType geospatialAreaType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GeospatialAreaName = geospatialAreaName;
            this.GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            this.GeospatialAreaType = geospatialAreaType;
            geospatialAreaType.GeospatialAreas.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialArea CreateNewBlank(GeospatialAreaType geospatialAreaType)
        {
            return new GeospatialArea(default(string), geospatialAreaType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return GeospatialAreaImages.Any() || PersonStewardGeospatialAreas.Any() || ProjectGeospatialAreas.Any() || ProjectGeospatialAreaUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialArea).Name, typeof(GeospatialAreaImage).Name, typeof(PersonStewardGeospatialArea).Name, typeof(ProjectGeospatialArea).Name, typeof(ProjectGeospatialAreaUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreas.Remove(this);
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

            foreach(var x in GeospatialAreaImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PersonStewardGeospatialAreas.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectGeospatialAreas.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectGeospatialAreaUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int GeospatialAreaID { get; set; }
        public int TenantID { get; set; }
        public string GeospatialAreaName { get; set; }
        public DbGeometry GeospatialAreaFeature { get; set; }
        public int GeospatialAreaTypeID { get; set; }
        public string GeospatialAreaDescriptionContent { get; set; }
        [NotMapped]
        public HtmlString GeospatialAreaDescriptionContentHtmlString
        { 
            get { return GeospatialAreaDescriptionContent == null ? null : new HtmlString(GeospatialAreaDescriptionContent); }
            set { GeospatialAreaDescriptionContent = value?.ToString(); }
        }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaID; } set { GeospatialAreaID = value; } }

        public virtual ICollection<GeospatialAreaImage> GeospatialAreaImages { get; set; }
        public virtual ICollection<PersonStewardGeospatialArea> PersonStewardGeospatialAreas { get; set; }
        public virtual ICollection<ProjectGeospatialArea> ProjectGeospatialAreas { get; set; }
        public virtual ICollection<ProjectGeospatialAreaUpdate> ProjectGeospatialAreaUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialAreaType GeospatialAreaType { get; set; }

        public static class FieldLengths
        {
            public const int GeospatialAreaName = 100;
        }
    }
}