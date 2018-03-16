//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Snapshot]
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
    [Table("[dbo].[Snapshot]")]
    public partial class Snapshot : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Snapshot()
        {
            this.SnapshotOrganizationTypeExpenditures = new HashSet<SnapshotOrganizationTypeExpenditure>();
            this.SnapshotPerformanceMeasures = new HashSet<SnapshotPerformanceMeasure>();
            this.SnapshotProjects = new HashSet<SnapshotProject>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Snapshot(int snapshotID, DateTime snapshotDate, string snapshotNote, int projectCount) : this()
        {
            this.SnapshotID = snapshotID;
            this.SnapshotDate = snapshotDate;
            this.SnapshotNote = snapshotNote;
            this.ProjectCount = projectCount;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Snapshot(DateTime snapshotDate, int projectCount) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SnapshotDate = snapshotDate;
            this.ProjectCount = projectCount;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Snapshot CreateNewBlank()
        {
            return new Snapshot(default(DateTime), default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SnapshotOrganizationTypeExpenditures.Any() || SnapshotPerformanceMeasures.Any() || SnapshotProjects.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Snapshot).Name, typeof(SnapshotOrganizationTypeExpenditure).Name, typeof(SnapshotPerformanceMeasure).Name, typeof(SnapshotProject).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {

            foreach(var x in SnapshotOrganizationTypeExpenditures.ToList())
            {
                x.DeleteFull();
            }

            foreach(var x in SnapshotPerformanceMeasures.ToList())
            {
                x.DeleteFull();
            }

            foreach(var x in SnapshotProjects.ToList())
            {
                x.DeleteFull();
            }
            HttpRequestStorage.DatabaseEntities.AllSnapshots.Remove(this);                
        }

        [Key]
        public int SnapshotID { get; set; }
        public int TenantID { get; private set; }
        public DateTime SnapshotDate { get; set; }
        public string SnapshotNote { get; set; }
        public int ProjectCount { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SnapshotID; } set { SnapshotID = value; } }

        public virtual ICollection<SnapshotOrganizationTypeExpenditure> SnapshotOrganizationTypeExpenditures { get; set; }
        public virtual ICollection<SnapshotPerformanceMeasure> SnapshotPerformanceMeasures { get; set; }
        public virtual ICollection<SnapshotProject> SnapshotProjects { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int SnapshotNote = 200;
        }
    }
}