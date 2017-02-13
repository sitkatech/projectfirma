//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectClassification]
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
    [Table("[dbo].[ProposedProjectClassification]")]
    public partial class ProposedProjectClassification : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectClassification()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectClassification(int proposedProjectClassificationID, int proposedProjectID, int classificationID, string proposedProjectClassificationNotes) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProposedProjectClassificationID = proposedProjectClassificationID;
            this.ProposedProjectID = proposedProjectID;
            this.ClassificationID = classificationID;
            this.ProposedProjectClassificationNotes = proposedProjectClassificationNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectClassification(int proposedProjectID, int classificationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectClassificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProposedProjectID = proposedProjectID;
            this.ClassificationID = classificationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectClassification(ProposedProject proposedProject, Classification classification) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectClassificationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectClassifications.Add(this);
            this.ClassificationID = classification.ClassificationID;
            this.Classification = classification;
            classification.ProposedProjectClassifications.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectClassification CreateNewBlank(ProposedProject proposedProject, Classification classification)
        {
            return new ProposedProjectClassification(proposedProject, classification);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectClassification).Name};

        [Key]
        public int ProposedProjectClassificationID { get; set; }
        public int ProposedProjectID { get; set; }
        public int ClassificationID { get; set; }
        public string ProposedProjectClassificationNotes { get; set; }
        public int TenantID { get; private set; }
        public int PrimaryKey { get { return ProposedProjectClassificationID; } set { ProposedProjectClassificationID = value; } }

        public virtual ProposedProject ProposedProject { get; set; }
        public virtual Classification Classification { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int ProposedProjectClassificationNotes = 600;
        }
    }
}