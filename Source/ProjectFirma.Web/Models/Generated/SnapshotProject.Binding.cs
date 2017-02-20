//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SnapshotProject]
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
    [Table("[dbo].[SnapshotProject]")]
    public partial class SnapshotProject : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SnapshotProject()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotProject(int snapshotProjectID, int snapshotID, int projectID, int snapshotProjectTypeID) : this()
        {
            this.SnapshotProjectID = snapshotProjectID;
            this.SnapshotID = snapshotID;
            this.ProjectID = projectID;
            this.SnapshotProjectTypeID = snapshotProjectTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SnapshotProject(int snapshotID, int projectID, int snapshotProjectTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SnapshotID = snapshotID;
            this.ProjectID = projectID;
            this.SnapshotProjectTypeID = snapshotProjectTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SnapshotProject(Snapshot snapshot, Project project, SnapshotProjectType snapshotProjectType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SnapshotProjectID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SnapshotID = snapshot.SnapshotID;
            this.Snapshot = snapshot;
            snapshot.SnapshotProjects.Add(this);
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.SnapshotProjects.Add(this);
            this.SnapshotProjectTypeID = snapshotProjectType.SnapshotProjectTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SnapshotProject CreateNewBlank(Snapshot snapshot, Project project, SnapshotProjectType snapshotProjectType)
        {
            return new SnapshotProject(snapshot, project, snapshotProjectType);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SnapshotProject).Name};

        [Key]
        public int SnapshotProjectID { get; set; }
        public int TenantID { get; private set; }
        public int SnapshotID { get; set; }
        public int ProjectID { get; set; }
        public int SnapshotProjectTypeID { get; set; }
        public int PrimaryKey { get { return SnapshotProjectID; } set { SnapshotProjectID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Snapshot Snapshot { get; set; }
        public virtual Project Project { get; set; }
        public SnapshotProjectType SnapshotProjectType { get { return SnapshotProjectType.AllLookupDictionary[SnapshotProjectTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}