//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Watershed]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[Watershed]")]
    public partial class Watershed : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Watershed()
        {
            this.ProjectLocationAreas = new HashSet<ProjectLocationArea>();
            this.ProjectLocationAreaWatersheds = new HashSet<ProjectLocationAreaWatershed>();
            this.ProjectWatersheds = new HashSet<ProjectWatershed>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Watershed(int watershedID, string watershedName, DbGeometry watershedFeature) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.WatershedID = watershedID;
            this.WatershedName = watershedName;
            this.WatershedFeature = watershedFeature;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Watershed(string watershedName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WatershedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.WatershedName = watershedName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Watershed CreateNewBlank()
        {
            return new Watershed(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectLocationAreas.Any() || ProjectLocationAreaWatersheds.Any() || ProjectWatersheds.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Watershed).Name, typeof(ProjectLocationArea).Name, typeof(ProjectLocationAreaWatershed).Name, typeof(ProjectWatershed).Name};

        [Key]
        public int WatershedID { get; set; }
        public string WatershedName { get; set; }
        public DbGeometry WatershedFeature { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return WatershedID; } set { WatershedID = value; } }

        public virtual ICollection<ProjectLocationArea> ProjectLocationAreas { get; set; }
        public virtual ICollection<ProjectLocationAreaWatershed> ProjectLocationAreaWatersheds { get; set; }
        public virtual ICollection<ProjectWatershed> ProjectWatersheds { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {
            public const int WatershedName = 100;
        }
    }
}