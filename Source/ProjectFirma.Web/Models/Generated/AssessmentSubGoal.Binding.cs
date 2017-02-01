//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentSubGoal]
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
    [Table("[dbo].[AssessmentSubGoal]")]
    public partial class AssessmentSubGoal : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AssessmentSubGoal()
        {
            this.AssessmentQuestions = new HashSet<AssessmentQuestion>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AssessmentSubGoal(int assessmentSubGoalID, int assessmentGoalID, int assessmentSubGoalNumber, string assessmentSubGoalTitle, string assessmentSubGoalDescription) : this()
        {
            this.AssessmentSubGoalID = assessmentSubGoalID;
            this.AssessmentGoalID = assessmentGoalID;
            this.AssessmentSubGoalNumber = assessmentSubGoalNumber;
            this.AssessmentSubGoalTitle = assessmentSubGoalTitle;
            this.AssessmentSubGoalDescription = assessmentSubGoalDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AssessmentSubGoal(int assessmentGoalID, int assessmentSubGoalNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            AssessmentSubGoalID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AssessmentGoalID = assessmentGoalID;
            this.AssessmentSubGoalNumber = assessmentSubGoalNumber;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AssessmentSubGoal(AssessmentGoal assessmentGoal, int assessmentSubGoalNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AssessmentSubGoalID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.AssessmentGoalID = assessmentGoal.AssessmentGoalID;
            this.AssessmentGoal = assessmentGoal;
            assessmentGoal.AssessmentSubGoals.Add(this);
            this.AssessmentSubGoalNumber = assessmentSubGoalNumber;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AssessmentSubGoal CreateNewBlank(AssessmentGoal assessmentGoal)
        {
            return new AssessmentSubGoal(assessmentGoal, default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AssessmentQuestions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AssessmentSubGoal).Name, typeof(AssessmentQuestion).Name};

        [Key]
        public int AssessmentSubGoalID { get; set; }
        public int AssessmentGoalID { get; set; }
        public int AssessmentSubGoalNumber { get; set; }
        public string AssessmentSubGoalTitle { get; set; }
        public string AssessmentSubGoalDescription { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return AssessmentSubGoalID; } set { AssessmentSubGoalID = value; } }

        public virtual ICollection<AssessmentQuestion> AssessmentQuestions { get; set; }
        public virtual AssessmentGoal AssessmentGoal { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {
            public const int AssessmentSubGoalTitle = 100;
            public const int AssessmentSubGoalDescription = 300;
        }
    }
}