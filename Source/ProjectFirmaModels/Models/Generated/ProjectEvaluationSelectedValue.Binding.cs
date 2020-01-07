//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectEvaluationSelectedValue]
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
    // Table [dbo].[ProjectEvaluationSelectedValue] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ProjectEvaluationSelectedValue]")]
    public partial class ProjectEvaluationSelectedValue : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectEvaluationSelectedValue()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectEvaluationSelectedValue(int projectEvaluationSelectedValueID, int projectEvaluationID, int evaluationCriterionValueID) : this()
        {
            this.ProjectEvaluationSelectedValueID = projectEvaluationSelectedValueID;
            this.ProjectEvaluationID = projectEvaluationID;
            this.EvaluationCriterionValueID = evaluationCriterionValueID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectEvaluationSelectedValue(int projectEvaluationID, int evaluationCriterionValueID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectEvaluationSelectedValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectEvaluationID = projectEvaluationID;
            this.EvaluationCriterionValueID = evaluationCriterionValueID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectEvaluationSelectedValue(ProjectEvaluation projectEvaluation, EvaluationCriterionValue evaluationCriterionValue) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectEvaluationSelectedValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectEvaluationID = projectEvaluation.ProjectEvaluationID;
            this.ProjectEvaluation = projectEvaluation;
            projectEvaluation.ProjectEvaluationSelectedValues.Add(this);
            this.EvaluationCriterionValueID = evaluationCriterionValue.EvaluationCriterionValueID;
            this.EvaluationCriterionValue = evaluationCriterionValue;
            evaluationCriterionValue.ProjectEvaluationSelectedValues.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectEvaluationSelectedValue CreateNewBlank(ProjectEvaluation projectEvaluation, EvaluationCriterionValue evaluationCriterionValue)
        {
            return new ProjectEvaluationSelectedValue(projectEvaluation, evaluationCriterionValue);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectEvaluationSelectedValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectEvaluationSelectedValues.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectEvaluationSelectedValueID { get; set; }
        public int TenantID { get; set; }
        public int ProjectEvaluationID { get; set; }
        public int EvaluationCriterionValueID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectEvaluationSelectedValueID; } set { ProjectEvaluationSelectedValueID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectEvaluation ProjectEvaluation { get; set; }
        public virtual EvaluationCriterionValue EvaluationCriterionValue { get; set; }

        public static class FieldLengths
        {

        }
    }
}