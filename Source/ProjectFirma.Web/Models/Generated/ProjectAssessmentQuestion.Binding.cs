//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectAssessmentQuestion]
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
    [Table("[dbo].[ProjectAssessmentQuestion]")]
    public partial class ProjectAssessmentQuestion : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectAssessmentQuestion()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectAssessmentQuestion(int projectAssessmentQuestionID, int projectID, int assessmentQuestionID, bool? answer) : this()
        {
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            
            this.ProjectAssessmentQuestionID = projectAssessmentQuestionID;
            this.ProjectID = projectID;
            this.AssessmentQuestionID = assessmentQuestionID;
            this.Answer = answer;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectAssessmentQuestion(int projectID, int assessmentQuestionID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectAssessmentQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProjectID = projectID;
            this.AssessmentQuestionID = assessmentQuestionID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectAssessmentQuestion(Project project, AssessmentQuestion assessmentQuestion) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectAssessmentQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TenantID = HttpRequestStorage.Tenant.TenantID;
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectAssessmentQuestions.Add(this);
            this.AssessmentQuestionID = assessmentQuestion.AssessmentQuestionID;
            this.AssessmentQuestion = assessmentQuestion;
            assessmentQuestion.ProjectAssessmentQuestions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectAssessmentQuestion CreateNewBlank(Project project, AssessmentQuestion assessmentQuestion)
        {
            return new ProjectAssessmentQuestion(project, assessmentQuestion);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectAssessmentQuestion).Name};

        [Key]
        public int ProjectAssessmentQuestionID { get; set; }
        public int TenantID { get; private set; }
        public int ProjectID { get; set; }
        public int AssessmentQuestionID { get; set; }
        public bool? Answer { get; set; }
        public int PrimaryKey { get { return ProjectAssessmentQuestionID; } set { ProjectAssessmentQuestionID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual AssessmentQuestion AssessmentQuestion { get; set; }

        public static class FieldLengths
        {

        }
    }
}