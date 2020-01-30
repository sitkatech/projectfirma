//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriteria]
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
    // Table [dbo].[EvaluationCriteria] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[EvaluationCriteria]")]
    public partial class EvaluationCriteria : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EvaluationCriteria()
        {
            this.EvaluationCriteriaValues = new HashSet<EvaluationCriteriaValue>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationCriteria(int evaluationCriteriaID, int evaluationID, string evaluationCriteriaName, string evaluationCriteriaDefinition) : this()
        {
            this.EvaluationCriteriaID = evaluationCriteriaID;
            this.EvaluationID = evaluationID;
            this.EvaluationCriteriaName = evaluationCriteriaName;
            this.EvaluationCriteriaDefinition = evaluationCriteriaDefinition;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationCriteria(int evaluationID, string evaluationCriteriaName, string evaluationCriteriaDefinition) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationCriteriaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EvaluationID = evaluationID;
            this.EvaluationCriteriaName = evaluationCriteriaName;
            this.EvaluationCriteriaDefinition = evaluationCriteriaDefinition;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EvaluationCriteria(Evaluation evaluation, string evaluationCriteriaName, string evaluationCriteriaDefinition) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationCriteriaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EvaluationID = evaluation.EvaluationID;
            this.Evaluation = evaluation;
            evaluation.EvaluationCriterias.Add(this);
            this.EvaluationCriteriaName = evaluationCriteriaName;
            this.EvaluationCriteriaDefinition = evaluationCriteriaDefinition;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EvaluationCriteria CreateNewBlank(Evaluation evaluation)
        {
            return new EvaluationCriteria(evaluation, default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EvaluationCriteriaValues.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EvaluationCriteria).Name, typeof(EvaluationCriteriaValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllEvaluationCriterias.Remove(this);
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

            foreach(var x in EvaluationCriteriaValues.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int EvaluationCriteriaID { get; set; }
        public int TenantID { get; set; }
        public int EvaluationID { get; set; }
        public string EvaluationCriteriaName { get; set; }
        public string EvaluationCriteriaDefinition { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationCriteriaID; } set { EvaluationCriteriaID = value; } }

        public virtual ICollection<EvaluationCriteriaValue> EvaluationCriteriaValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Evaluation Evaluation { get; set; }

        public static class FieldLengths
        {
            public const int EvaluationCriteriaName = 120;
            public const int EvaluationCriteriaDefinition = 1000;
        }
    }
}