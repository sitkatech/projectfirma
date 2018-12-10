//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[AssessmentQuestion]
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
    [Table("[dbo].[AssessmentQuestion]")]
    public partial class AssessmentQuestion : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AssessmentQuestion()
        {
            this.ProjectAssessmentQuestions = new HashSet<ProjectAssessmentQuestion>();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AssessmentQuestion(int assessmentQuestionID, int assessmentSubGoalID, string assessmentQuestionText, DateTime? archiveDate) : this()
        {
            this.AssessmentQuestionID = assessmentQuestionID;
            this.AssessmentSubGoalID = assessmentSubGoalID;
            this.AssessmentQuestionText = assessmentQuestionText;
            this.ArchiveDate = archiveDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AssessmentQuestion(int assessmentSubGoalID, string assessmentQuestionText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AssessmentQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AssessmentSubGoalID = assessmentSubGoalID;
            this.AssessmentQuestionText = assessmentQuestionText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AssessmentQuestion(AssessmentSubGoal assessmentSubGoal, string assessmentQuestionText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AssessmentQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.AssessmentSubGoalID = assessmentSubGoal.AssessmentSubGoalID;
            this.AssessmentSubGoal = assessmentSubGoal;
            assessmentSubGoal.AssessmentQuestions.Add(this);
            this.AssessmentQuestionText = assessmentQuestionText;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AssessmentQuestion CreateNewBlank(AssessmentSubGoal assessmentSubGoal)
        {
            return new AssessmentQuestion(assessmentSubGoal, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectAssessmentQuestions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AssessmentQuestion).Name, typeof(ProjectAssessmentQuestion).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(HttpRequestStorage.DatabaseEntities);
            dbContext.AllAssessmentQuestions.Remove(this);
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in ProjectAssessmentQuestions.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int AssessmentQuestionID { get; set; }
        public int TenantID { get; private set; }
        public int AssessmentSubGoalID { get; set; }
        public string AssessmentQuestionText { get; set; }
        public DateTime? ArchiveDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AssessmentQuestionID; } set { AssessmentQuestionID = value; } }

        public virtual ICollection<ProjectAssessmentQuestion> ProjectAssessmentQuestions { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual AssessmentSubGoal AssessmentSubGoal { get; set; }

        public static class FieldLengths
        {
            public const int AssessmentQuestionText = 300;
        }
    }
}