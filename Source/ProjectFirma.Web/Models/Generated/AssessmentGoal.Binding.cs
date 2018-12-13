//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentGoal]
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
    [Table("[dbo].[AssessmentGoal]")]
    public partial class AssessmentGoal : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AssessmentGoal()
        {
            this.AssessmentSubGoals = new HashSet<AssessmentSubGoal>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AssessmentGoal(int assessmentGoalID, int assessmentGoalNumber, string assessmentGoalTitle, string assessmentGoalDescription) : this()
        {
            this.AssessmentGoalID = assessmentGoalID;
            this.AssessmentGoalNumber = assessmentGoalNumber;
            this.AssessmentGoalTitle = assessmentGoalTitle;
            this.AssessmentGoalDescription = assessmentGoalDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AssessmentGoal(int assessmentGoalNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AssessmentGoalID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AssessmentGoalNumber = assessmentGoalNumber;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AssessmentGoal CreateNewBlank()
        {
            return new AssessmentGoal(default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AssessmentSubGoals.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AssessmentGoal).Name, typeof(AssessmentSubGoal).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            dbContext.AllAssessmentGoals.Remove(this);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in AssessmentSubGoals.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int AssessmentGoalID { get; set; }
        public int TenantID { get; private set; }
        public int AssessmentGoalNumber { get; set; }
        public string AssessmentGoalTitle { get; set; }
        public string AssessmentGoalDescription { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AssessmentGoalID; } set { AssessmentGoalID = value; } }

        public virtual ICollection<AssessmentSubGoal> AssessmentSubGoals { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int AssessmentGoalTitle = 100;
            public const int AssessmentGoalDescription = 300;
        }
    }
}