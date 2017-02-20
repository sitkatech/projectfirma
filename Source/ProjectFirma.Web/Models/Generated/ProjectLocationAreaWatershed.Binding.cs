//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaWatershed]
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
    [Table("[dbo].[ProjectLocationAreaWatershed]")]
    public partial class ProjectLocationAreaWatershed : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectLocationAreaWatershed()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationAreaWatershed(int projectLocationAreaWatershedID, int projectLocationAreaID, int watershedID) : this()
        {
            this.ProjectLocationAreaWatershedID = projectLocationAreaWatershedID;
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocationAreaWatershed(int projectLocationAreaID, int watershedID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationAreaWatershedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectLocationAreaID = projectLocationAreaID;
            this.WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectLocationAreaWatershed(ProjectLocationArea projectLocationArea, Watershed watershed) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectLocationAreaWatershedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectLocationAreaID = projectLocationArea.ProjectLocationAreaID;
            this.ProjectLocationArea = projectLocationArea;
            projectLocationArea.ProjectLocationAreaWatersheds.Add(this);
            this.WatershedID = watershed.WatershedID;
            this.Watershed = watershed;
            watershed.ProjectLocationAreaWatersheds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectLocationAreaWatershed CreateNewBlank(ProjectLocationArea projectLocationArea, Watershed watershed)
        {
            return new ProjectLocationAreaWatershed(projectLocationArea, watershed);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectLocationAreaWatershed).Name};

        [Key]
        public int ProjectLocationAreaWatershedID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectLocationAreaID { get; set; }
        public int WatershedID { get; set; }
        public int PrimaryKey { get { return ProjectLocationAreaWatershedID; } set { ProjectLocationAreaWatershedID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectLocationArea ProjectLocationArea { get; set; }
        public virtual Watershed Watershed { get; set; }

        public static class FieldLengths
        {

        }
    }
}