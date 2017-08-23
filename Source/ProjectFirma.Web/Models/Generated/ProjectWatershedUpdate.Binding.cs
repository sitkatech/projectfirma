//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectWatershedUpdate]
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
    [Table("[dbo].[ProjectWatershedUpdate]")]
    public partial class ProjectWatershedUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectWatershedUpdate()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectWatershedUpdate(int projectWatershedUpdateID, int projectUpdateID, int watershedID) : this()
        {
            this.ProjectWatershedUpdateID = projectWatershedUpdateID;
            this.ProjectUpdateID = projectUpdateID;
            this.WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectWatershedUpdate(int projectUpdateID, int watershedID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectWatershedUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateID = projectUpdateID;
            this.WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectWatershedUpdate(ProjectUpdate projectUpdate, Watershed watershed) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectWatershedUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateID = projectUpdate.ProjectUpdateID;
            this.ProjectUpdate = projectUpdate;
            projectUpdate.ProjectWatershedUpdates.Add(this);
            this.WatershedID = watershed.WatershedID;
            this.Watershed = watershed;
            watershed.ProjectWatershedUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectWatershedUpdate CreateNewBlank(ProjectUpdate projectUpdate, Watershed watershed)
        {
            return new ProjectWatershedUpdate(projectUpdate, watershed);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectWatershedUpdate).Name};

        [Key]
        public int ProjectWatershedUpdateID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectUpdateID { get; set; }
        public int WatershedID { get; set; }
        public int PrimaryKey { get { return ProjectWatershedUpdateID; } set { ProjectWatershedUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdate ProjectUpdate { get; set; }
        public virtual Watershed Watershed { get; set; }

        public static class FieldLengths
        {

        }
    }
}