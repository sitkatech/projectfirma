//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EIPPerformanceMeasureExpectedProposed]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[EIPPerformanceMeasureExpectedProposed]")]
    public partial class EIPPerformanceMeasureExpectedProposed : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EIPPerformanceMeasureExpectedProposed()
        {
            this.EIPPerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<EIPPerformanceMeasureExpectedSubcategoryOptionProposed>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpectedProposed(int eIPPerformanceMeasureExpectedProposedID, int proposedProjectID, int eIPPerformanceMeasureID, double? expectedValue) : this()
        {
            this.EIPPerformanceMeasureExpectedProposedID = eIPPerformanceMeasureExpectedProposedID;
            this.ProposedProjectID = proposedProjectID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EIPPerformanceMeasureExpectedProposed(int proposedProjectID, int eIPPerformanceMeasureID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            EIPPerformanceMeasureExpectedProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProposedProjectID = proposedProjectID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EIPPerformanceMeasureExpectedProposed(ProposedProject proposedProject, EIPPerformanceMeasure eIPPerformanceMeasure) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EIPPerformanceMeasureExpectedProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.EIPPerformanceMeasureExpectedProposeds.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.EIPPerformanceMeasureExpectedProposeds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EIPPerformanceMeasureExpectedProposed CreateNewBlank(ProposedProject proposedProject, EIPPerformanceMeasure eIPPerformanceMeasure)
        {
            return new EIPPerformanceMeasureExpectedProposed(proposedProject, eIPPerformanceMeasure);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EIPPerformanceMeasureExpectedSubcategoryOptionProposeds.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EIPPerformanceMeasureExpectedProposed).Name, typeof(EIPPerformanceMeasureExpectedSubcategoryOptionProposed).Name};

        [Key]
        public int EIPPerformanceMeasureExpectedProposedID { get; set; }
        public int ProposedProjectID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public double? ExpectedValue { get; set; }
        public int PrimaryKey { get { return EIPPerformanceMeasureExpectedProposedID; } set { EIPPerformanceMeasureExpectedProposedID = value; } }

        public virtual ICollection<EIPPerformanceMeasureExpectedSubcategoryOptionProposed> EIPPerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ProposedProject ProposedProject { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}