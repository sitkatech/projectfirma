//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriterionValue]
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
    // Table [dbo].[EvaluationCriterionValue] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[EvaluationCriterionValue]")]
    public partial class EvaluationCriterionValue : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EvaluationCriterionValue()
        {
            this.ProjectEvaluationSelectedValues = new HashSet<ProjectEvaluationSelectedValue>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationCriterionValue(int evaluationCriterionValueID, int evaluationCriterionID, string evaluationCriterionValueRating, string evaluationCriterionValueDescription, int? sortOrder) : this()
        {
            this.EvaluationCriterionValueID = evaluationCriterionValueID;
            this.EvaluationCriterionID = evaluationCriterionID;
            this.EvaluationCriterionValueRating = evaluationCriterionValueRating;
            this.EvaluationCriterionValueDescription = evaluationCriterionValueDescription;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationCriterionValue(int evaluationCriterionID, string evaluationCriterionValueRating, string evaluationCriterionValueDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationCriterionValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EvaluationCriterionID = evaluationCriterionID;
            this.EvaluationCriterionValueRating = evaluationCriterionValueRating;
            this.EvaluationCriterionValueDescription = evaluationCriterionValueDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EvaluationCriterionValue(EvaluationCriterion evaluationCriterion, string evaluationCriterionValueRating, string evaluationCriterionValueDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationCriterionValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EvaluationCriterionID = evaluationCriterion.EvaluationCriterionID;
            this.EvaluationCriterion = evaluationCriterion;
            evaluationCriterion.EvaluationCriterionValues.Add(this);
            this.EvaluationCriterionValueRating = evaluationCriterionValueRating;
            this.EvaluationCriterionValueDescription = evaluationCriterionValueDescription;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EvaluationCriterionValue CreateNewBlank(EvaluationCriterion evaluationCriterion)
        {
            return new EvaluationCriterionValue(evaluationCriterion, default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EvaluationCriterionValue).Name, typeof(ProjectEvaluationSelectedValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllEvaluationCriterionValues.Remove(this);
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
        public int EvaluationCriterionValueID { get; set; }
        public int TenantID { get; set; }
        public int EvaluationCriterionID { get; set; }
        public string EvaluationCriterionValueRating { get; set; }
        public string EvaluationCriterionValueDescription { get; set; }
        public int? SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationCriterionValueID; } set { EvaluationCriterionValueID = value; } }

        public virtual ICollection<ProjectEvaluationSelectedValue> ProjectEvaluationSelectedValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual EvaluationCriterion EvaluationCriterion { get; set; }

        public static class FieldLengths
        {
            public const int EvaluationCriterionValueRating = 60;
            public const int EvaluationCriterionValueDescription = 500;
        }
    }
}