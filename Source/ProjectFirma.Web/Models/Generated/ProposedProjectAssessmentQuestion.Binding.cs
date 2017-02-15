//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectAssessmentQuestion]
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
    [Table("[dbo].[ProposedProjectAssessmentQuestion]")]
    public partial class ProposedProjectAssessmentQuestion : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectAssessmentQuestion()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectAssessmentQuestion(int proposedProjectAssessmentQuestionID, int proposedProjectID, int assessmentQuestionID, bool? answer) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProposedProjectAssessmentQuestionID = proposedProjectAssessmentQuestionID;
            this.ProposedProjectID = proposedProjectID;
            this.AssessmentQuestionID = assessmentQuestionID;
            this.Answer = answer;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectAssessmentQuestion(int proposedProjectID, int assessmentQuestionID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectAssessmentQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProposedProjectID = proposedProjectID;
            this.AssessmentQuestionID = assessmentQuestionID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectAssessmentQuestion(ProposedProject proposedProject, AssessmentQuestion assessmentQuestion) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectAssessmentQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectAssessmentQuestions.Add(this);
            this.AssessmentQuestionID = assessmentQuestion.AssessmentQuestionID;
            this.AssessmentQuestion = assessmentQuestion;
            assessmentQuestion.ProposedProjectAssessmentQuestions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectAssessmentQuestion CreateNewBlank(ProposedProject proposedProject, AssessmentQuestion assessmentQuestion)
        {
            return new ProposedProjectAssessmentQuestion(proposedProject, assessmentQuestion);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectAssessmentQuestion).Name};

        [Key]
        public int ProposedProjectAssessmentQuestionID { get; set; }
        public int TenantID { get; private set; }
        public int ProposedProjectID { get; set; }
        public int AssessmentQuestionID { get; set; }
        public bool? Answer { get; set; }
        public int PrimaryKey { get { return ProposedProjectAssessmentQuestionID; } set { ProposedProjectAssessmentQuestionID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProposedProject ProposedProject { get; set; }
        public virtual AssessmentQuestion AssessmentQuestion { get; set; }

        public static class FieldLengths
        {

        }
    }
}