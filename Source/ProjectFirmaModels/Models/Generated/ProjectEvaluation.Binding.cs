//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectEvaluation]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[ProjectEvaluation] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectEvaluation]")]
    public partial class ProjectEvaluation : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectEvaluation()
        {
            this.ProjectEvaluationSelectedValues = new HashSet<ProjectEvaluationSelectedValue>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectEvaluation(int projectEvaluationID, int projectID, int evaluationID, string comments) : this()
        {
            this.ProjectEvaluationID = projectEvaluationID;
            this.ProjectID = projectID;
            this.EvaluationID = evaluationID;
            this.Comments = comments;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectEvaluation(int projectID, int evaluationID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectEvaluationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.EvaluationID = evaluationID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectEvaluation(Project project, Evaluation evaluation) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectEvaluationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectEvaluations.Add(this);
            this.EvaluationID = evaluation.EvaluationID;
            this.Evaluation = evaluation;
            evaluation.ProjectEvaluations.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectEvaluation CreateNewBlank(Project project, Evaluation evaluation)
        {
            return new ProjectEvaluation(project, evaluation);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectEvaluationSelectedValues.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectEvaluation).Name, typeof(ProjectEvaluationSelectedValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectEvaluations.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in ProjectEvaluationSelectedValues.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ProjectEvaluationID { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int EvaluationID { get; set; }
        public string Comments { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectEvaluationID; } set { ProjectEvaluationID = value; } }

        public virtual ICollection<ProjectEvaluationSelectedValue> ProjectEvaluationSelectedValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Project Project { get; set; }
        public virtual Evaluation Evaluation { get; set; }

        public static class FieldLengths
        {
            public const int Comments = 1000;
        }
    }
}