//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectWatershed]
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
    [Table("[dbo].[ProposedProjectWatershed]")]
    public partial class ProposedProjectWatershed : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectWatershed()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectWatershed(int proposedProjectWatershedID, int proposedProjectID, int watershedID) : this()
        {
            this.ProposedProjectWatershedID = proposedProjectWatershedID;
            this.ProposedProjectID = proposedProjectID;
            this.WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectWatershed(int proposedProjectID, int watershedID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectWatershedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProposedProjectID = proposedProjectID;
            this.WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectWatershed(ProposedProject proposedProject, Watershed watershed) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectWatershedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectWatersheds.Add(this);
            this.WatershedID = watershed.WatershedID;
            this.Watershed = watershed;
            watershed.ProposedProjectWatersheds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectWatershed CreateNewBlank(ProposedProject proposedProject, Watershed watershed)
        {
            return new ProposedProjectWatershed(proposedProject, watershed);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectWatershed).Name};

        [Key]
        public int ProposedProjectWatershedID { get; set; }
        public int TenantID { get; private set; }
        public int ProposedProjectID { get; set; }
        public int WatershedID { get; set; }
        public int PrimaryKey { get { return ProposedProjectWatershedID; } set { ProposedProjectWatershedID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProposedProject ProposedProject { get; set; }
        public virtual Watershed Watershed { get; set; }

        public static class FieldLengths
        {

        }
    }
}