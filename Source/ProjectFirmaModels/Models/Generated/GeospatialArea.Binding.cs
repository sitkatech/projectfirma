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
using CodeFirstStoreFunctions;
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
            this.GeospatialAreaPerformanceMeasureFixedTargets = new HashSet<GeospatialAreaPerformanceMeasureFixedTarget>();
            this.GeospatialAreaPerformanceMeasureNoTargets = new HashSet<GeospatialAreaPerformanceMeasureNoTarget>();
            this.GeospatialAreaPerformanceMeasureReportingPeriodTargets = new HashSet<GeospatialAreaPerformanceMeasureReportingPeriodTarget>();
            this.PersonStewardGeospatialAreas = new HashSet<PersonStewardGeospatialArea>();
            this.ProjectGeospatialAreas = new HashSet<ProjectGeospatialArea>();
            this.ProjectGeospatialAreaUpdates = new HashSet<ProjectGeospatialAreaUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialArea(int geospatialAreaID, string geospatialAreaName, DbGeometry geospatialAreaFeature, int geospatialAreaTypeID, string geospatialAreaDescriptionContent, string geospatialAreaShortName) : this()
        {
            this.GeospatialAreaID = geospatialAreaID;
            this.GeospatialAreaName = geospatialAreaName;
            this.GeospatialAreaFeature = geospatialAreaFeature;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.GeospatialAreaDescriptionContent = geospatialAreaDescriptionContent;
            this.GeospatialAreaShortName = geospatialAreaShortName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public GeospatialArea(string geospatialAreaName, int geospatialAreaTypeID, string geospatialAreaShortName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.GeospatialAreaName = geospatialAreaName;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
            this.GeospatialAreaShortName = geospatialAreaShortName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public GeospatialArea(string geospatialAreaName, GeospatialAreaType geospatialAreaType, string geospatialAreaShortName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.GeospatialAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.GeospatialAreaName = geospatialAreaName;
            this.GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            this.GeospatialAreaType = geospatialAreaType;
            geospatialAreaType.GeospatialAreas.Add(this);
            this.GeospatialAreaShortName = geospatialAreaShortName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static GeospatialArea CreateNewBlank(GeospatialAreaType geospatialAreaType)
        {
            return new GeospatialArea(default(string), geospatialAreaType, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return GeospatialAreaImages.Any() || GeospatialAreaPerformanceMeasureFixedTargets.Any() || GeospatialAreaPerformanceMeasureNoTargets.Any() || GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any() || PersonStewardGeospatialAreas.Any() || ProjectGeospatialAreas.Any() || ProjectGeospatialAreaUpdates.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(GeospatialAreaImages.Any())
            {
                dependentObjects.Add(typeof(GeospatialAreaImage).Name);
            }

            if(GeospatialAreaPerformanceMeasureFixedTargets.Any())
            {
                dependentObjects.Add(typeof(GeospatialAreaPerformanceMeasureFixedTarget).Name);
            }

            if(GeospatialAreaPerformanceMeasureNoTargets.Any())
            {
                dependentObjects.Add(typeof(GeospatialAreaPerformanceMeasureNoTarget).Name);
            }

            if(GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any())
            {
                dependentObjects.Add(typeof(GeospatialAreaPerformanceMeasureReportingPeriodTarget).Name);
            }

            if(PersonStewardGeospatialAreas.Any())
            {
                dependentObjects.Add(typeof(PersonStewardGeospatialArea).Name);
            }

            if(ProjectGeospatialAreas.Any())
            {
                dependentObjects.Add(typeof(ProjectGeospatialArea).Name);
            }

            if(ProjectGeospatialAreaUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectGeospatialAreaUpdate).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(GeospatialArea).Name, typeof(GeospatialAreaImage).Name, typeof(GeospatialAreaPerformanceMeasureFixedTarget).Name, typeof(GeospatialAreaPerformanceMeasureNoTarget).Name, typeof(GeospatialAreaPerformanceMeasureReportingPeriodTarget).Name, typeof(PersonStewardGeospatialArea).Name, typeof(ProjectGeospatialArea).Name, typeof(ProjectGeospatialAreaUpdate).Name};


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

            foreach(var x in GeospatialAreaPerformanceMeasureFixedTargets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GeospatialAreaPerformanceMeasureNoTargets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GeospatialAreaPerformanceMeasureReportingPeriodTargets.ToList())
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
        public string GeospatialAreaShortName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return GeospatialAreaID; } set { GeospatialAreaID = value; } }

        public virtual ICollection<GeospatialAreaImage> GeospatialAreaImages { get; set; }
        public virtual ICollection<GeospatialAreaPerformanceMeasureFixedTarget> GeospatialAreaPerformanceMeasureFixedTargets { get; set; }
        public virtual ICollection<GeospatialAreaPerformanceMeasureNoTarget> GeospatialAreaPerformanceMeasureNoTargets { get; set; }
        public virtual ICollection<GeospatialAreaPerformanceMeasureReportingPeriodTarget> GeospatialAreaPerformanceMeasureReportingPeriodTargets { get; set; }
        public virtual ICollection<PersonStewardGeospatialArea> PersonStewardGeospatialAreas { get; set; }
        public virtual ICollection<ProjectGeospatialArea> ProjectGeospatialAreas { get; set; }
        public virtual ICollection<ProjectGeospatialAreaUpdate> ProjectGeospatialAreaUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual GeospatialAreaType GeospatialAreaType { get; set; }

        public static class FieldLengths
        {
            public const int GeospatialAreaName = 100;
            public const int GeospatialAreaShortName = 200;
        }
    }
}