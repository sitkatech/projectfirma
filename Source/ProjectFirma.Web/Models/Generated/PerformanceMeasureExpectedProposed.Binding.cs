//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasureExpectedProposed]
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
    [Table("[dbo].[PerformanceMeasureExpectedProposed]")]
    public partial class PerformanceMeasureExpectedProposed : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasureExpectedProposed()
        {
            this.PerformanceMeasureExpectedSubcategoryOptionProposeds = new HashSet<PerformanceMeasureExpectedSubcategoryOptionProposed>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedProposed(int performanceMeasureExpectedProposedID, int proposedProjectID, int performanceMeasureID, double? expectedValue) : this()
        {
            this.PerformanceMeasureExpectedProposedID = performanceMeasureExpectedProposedID;
            this.ProposedProjectID = proposedProjectID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedProposed(int proposedProjectID, int performanceMeasureID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            PerformanceMeasureExpectedProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProposedProjectID = proposedProjectID;
            this.PerformanceMeasureID = performanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasureExpectedProposed(ProposedProject proposedProject, PerformanceMeasure performanceMeasure) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureExpectedProposedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.PerformanceMeasureExpectedProposeds.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.PerformanceMeasureExpectedProposeds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasureExpectedProposed CreateNewBlank(ProposedProject proposedProject, PerformanceMeasure performanceMeasure)
        {
            return new PerformanceMeasureExpectedProposed(proposedProject, performanceMeasure);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PerformanceMeasureExpectedSubcategoryOptionProposeds.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasureExpectedProposed).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionProposed).Name};

        [Key]
        public int PerformanceMeasureExpectedProposedID { get; set; }
        public int ProposedProjectID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double? ExpectedValue { get; set; }
        public int PrimaryKey { get { return PerformanceMeasureExpectedProposedID; } set { PerformanceMeasureExpectedProposedID = value; } }

        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionProposed> PerformanceMeasureExpectedSubcategoryOptionProposeds { get; set; }
        public virtual ProposedProject ProposedProject { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}