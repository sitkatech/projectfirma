//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaType]
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
    // Table [dbo].[GeospatialAreaType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[GeospatialAreaType]")]
    public partial class GeospatialAreaType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected GeospatialAreaType()
        {
            this.GeospatialAreas = new HashSet<GeospatialArea>();
            this.ProjectCustomGridConfigurations = new HashSet<ProjectCustomGridConfiguration>();
            this.ProjectGeospatialAreaTypeNotes = new HashSet<ProjectGeospatialAreaTypeNote>();
            this.ProjectGeospatialAreaTypeNoteUpdates = new HashSet<ProjectGeospatialAreaTypeNoteUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaType(int geospatialAreaTypeID, string geospatialAreaTypeName, string geospatialAreaTypeNamePluralized, string geospatialAreaIntroContent, string geospatialAreaTypeDefinition, string mapServiceUrl, string geospatialAreaLayerName) : this()
        {
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.GeospatialAreaTypeName = geospatialAreaTypeName;
            this.GeospatialAreaTypeNamePluralized = geospatialAreaTypeNamePluralized;
            this.GeospatialAreaIntroContent = geospatialAreaIntroContent;
            this.GeospatialAreaTypeDefinition = geospatialAreaTypeDefinition;
            this.MapServiceUrl = mapServiceUrl;
            this.GeospatialAreaLayerName = geospatialAreaLayerName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialAreaType(string geospatialAreaTypeName, string geospatialAreaTypeNamePluralized, string mapServiceUrl, string geospatialAreaLayerName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaTypeName = geospatialAreaTypeName;
            this.GeospatialAreaTypeNamePluralized = geospatialAreaTypeNamePluralized;
            this.MapServiceUrl = mapServiceUrl;
            this.GeospatialAreaLayerName = geospatialAreaLayerName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialAreaType CreateNewBlank()
        {
            return new GeospatialAreaType(default(string), default(string), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return GeospatialAreas.Any() || ProjectCustomGridConfigurations.Any() || ProjectGeospatialAreaTypeNotes.Any() || ProjectGeospatialAreaTypeNoteUpdates.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialAreaType).Name, typeof(GeospatialArea).Name, typeof(ProjectCustomGridConfiguration).Name, typeof(ProjectGeospatialAreaTypeNote).Name, typeof(ProjectGeospatialAreaTypeNoteUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllGeospatialAreaTypes.Remove(this);
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

            foreach(var x in GeospatialAreas.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectCustomGridConfigurations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectGeospatialAreaTypeNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectGeospatialAreaTypeNoteUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int GeospatialAreaTypeID { get; set; }
        public int TenantID { get; set; }
        public string GeospatialAreaTypeName { get; set; }
        public string GeospatialAreaTypeNamePluralized { get; set; }
        public string GeospatialAreaIntroContent { get; set; }
        [NotMapped]
        public HtmlString GeospatialAreaIntroContentHtmlString
        { 
            get { return GeospatialAreaIntroContent == null ? null : new HtmlString(GeospatialAreaIntroContent); }
            set { GeospatialAreaIntroContent = value?.ToString(); }
        }
        public string GeospatialAreaTypeDefinition { get; set; }
        [NotMapped]
        public HtmlString GeospatialAreaTypeDefinitionHtmlString
        { 
            get { return GeospatialAreaTypeDefinition == null ? null : new HtmlString(GeospatialAreaTypeDefinition); }
            set { GeospatialAreaTypeDefinition = value?.ToString(); }
        }
        public string MapServiceUrl { get; set; }
        public string GeospatialAreaLayerName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaTypeID; } set { GeospatialAreaTypeID = value; } }

        public virtual ICollection<GeospatialArea> GeospatialAreas { get; set; }
        public virtual ICollection<ProjectCustomGridConfiguration> ProjectCustomGridConfigurations { get; set; }
        public virtual ICollection<ProjectGeospatialAreaTypeNote> ProjectGeospatialAreaTypeNotes { get; set; }
        public virtual ICollection<ProjectGeospatialAreaTypeNoteUpdate> ProjectGeospatialAreaTypeNoteUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int GeospatialAreaTypeName = 200;
            public const int GeospatialAreaTypeNamePluralized = 200;
            public const int MapServiceUrl = 255;
            public const int GeospatialAreaLayerName = 255;
        }
    }
}