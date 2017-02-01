//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectLocation]
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
    [Table("[dbo].[ProposedProjectLocation]")]
    public partial class ProposedProjectLocation : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectLocation()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectLocation(int proposedProjectLocationID, int proposedProjectID, DbGeometry projectLocationGeometry, string annotation) : this()
        {
            this.ProposedProjectLocationID = proposedProjectLocationID;
            this.ProposedProjectID = proposedProjectID;
            this.ProjectLocationGeometry = projectLocationGeometry;
            this.Annotation = annotation;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectLocation(int proposedProjectID, DbGeometry projectLocationGeometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProposedProjectLocationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProposedProjectID = proposedProjectID;
            this.ProjectLocationGeometry = projectLocationGeometry;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectLocation(ProposedProject proposedProject, DbGeometry projectLocationGeometry) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectLocationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectLocations.Add(this);
            this.ProjectLocationGeometry = projectLocationGeometry;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectLocation CreateNewBlank(ProposedProject proposedProject)
        {
            return new ProposedProjectLocation(proposedProject, default(DbGeometry));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectLocation).Name};

        [Key]
        public int ProposedProjectLocationID { get; set; }
        public int ProposedProjectID { get; set; }
        public DbGeometry ProjectLocationGeometry { get; set; }
        public string Annotation { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ProposedProjectLocationID; } set { ProposedProjectLocationID = value; } }

        public virtual ProposedProject ProposedProject { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {
            public const int Annotation = 255;
        }
    }
}