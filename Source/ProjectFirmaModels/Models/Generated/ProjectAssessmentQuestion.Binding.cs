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
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ProjectAssessmentQuestion] is multi-tenant, so is attributed as IHaveATenantID
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
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectAssessmentQuestion).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectAssessmentQuestions.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectAssessmentQuestionID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int AssessmentQuestionID { get; set; }
        public bool? Answer { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectAssessmentQuestionID; } set { ProjectAssessmentQuestionID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual AssessmentQuestion AssessmentQuestion { get; set; }

        public static class FieldLengths
        {

        }
    }
}