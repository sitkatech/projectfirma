//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriterion]
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
    // Table [dbo].[EvaluationCriterion] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[EvaluationCriterion]")]
    public partial class EvaluationCriterion : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EvaluationCriterion()
        {
            this.EvaluationCriterionValues = new HashSet<EvaluationCriterionValue>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationCriterion(int evaluationCriterionID, int evaluationID, string evaluationCriterionName, string evaluationCriterionDefinition) : this()
        {
            this.EvaluationCriterionID = evaluationCriterionID;
            this.EvaluationID = evaluationID;
            this.EvaluationCriterionName = evaluationCriterionName;
            this.EvaluationCriterionDefinition = evaluationCriterionDefinition;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationCriterion(int evaluationID, string evaluationCriterionName, string evaluationCriterionDefinition) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationCriterionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EvaluationID = evaluationID;
            this.EvaluationCriterionName = evaluationCriterionName;
            this.EvaluationCriterionDefinition = evaluationCriterionDefinition;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EvaluationCriterion(Evaluation evaluation, string evaluationCriterionName, string evaluationCriterionDefinition) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationCriterionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EvaluationID = evaluation.EvaluationID;
            this.Evaluation = evaluation;
            evaluation.EvaluationCriterions.Add(this);
            this.EvaluationCriterionName = evaluationCriterionName;
            this.EvaluationCriterionDefinition = evaluationCriterionDefinition;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EvaluationCriterion CreateNewBlank(Evaluation evaluation)
        {
            return new EvaluationCriterion(evaluation, default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EvaluationCriterionValues.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EvaluationCriterion).Name, typeof(EvaluationCriterionValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllEvaluationCriterions.Remove(this);
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

            foreach(var x in EvaluationCriterionValues.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int EvaluationCriterionID { get; set; }
        public int TenantID { get; set; }
        public int EvaluationID { get; set; }
        public string EvaluationCriterionName { get; set; }
        public string EvaluationCriterionDefinition { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationCriterionID; } set { EvaluationCriterionID = value; } }

        public virtual ICollection<EvaluationCriterionValue> EvaluationCriterionValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Evaluation Evaluation { get; set; }

        public static class FieldLengths
        {
            public const int EvaluationCriterionName = 120;
            public const int EvaluationCriterionDefinition = 1000;
        }
    }
}