//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationCriteriaValue]
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
    // Table [dbo].[EvaluationCriteriaValue] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[EvaluationCriteriaValue]")]
    public partial class EvaluationCriteriaValue : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EvaluationCriteriaValue()
        {
            this.ProjectEvaluationSelectedValues = new HashSet<ProjectEvaluationSelectedValue>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationCriteriaValue(int evaluationCriteriaValueID, int evaluationCriteriaID, string evaluationCriteriaValueRating, string evaluationCriteriaValueDescription, int? sortOrder) : this()
        {
            this.EvaluationCriteriaValueID = evaluationCriteriaValueID;
            this.EvaluationCriteriaID = evaluationCriteriaID;
            this.EvaluationCriteriaValueRating = evaluationCriteriaValueRating;
            this.EvaluationCriteriaValueDescription = evaluationCriteriaValueDescription;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationCriteriaValue(int evaluationCriteriaID, string evaluationCriteriaValueRating, string evaluationCriteriaValueDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationCriteriaValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EvaluationCriteriaID = evaluationCriteriaID;
            this.EvaluationCriteriaValueRating = evaluationCriteriaValueRating;
            this.EvaluationCriteriaValueDescription = evaluationCriteriaValueDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public EvaluationCriteriaValue(EvaluationCriteria evaluationCriteria, string evaluationCriteriaValueRating, string evaluationCriteriaValueDescription) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationCriteriaValueID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EvaluationCriteriaID = evaluationCriteria.EvaluationCriteriaID;
            this.EvaluationCriteria = evaluationCriteria;
            evaluationCriteria.EvaluationCriteriaValues.Add(this);
            this.EvaluationCriteriaValueRating = evaluationCriteriaValueRating;
            this.EvaluationCriteriaValueDescription = evaluationCriteriaValueDescription;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EvaluationCriteriaValue CreateNewBlank(EvaluationCriteria evaluationCriteria)
        {
            return new EvaluationCriteriaValue(evaluationCriteria, default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EvaluationCriteriaValue).Name, typeof(ProjectEvaluationSelectedValue).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllEvaluationCriteriaValues.Remove(this);
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
        public int EvaluationCriteriaValueID { get; set; }
        public int TenantID { get; set; }
        public int EvaluationCriteriaID { get; set; }
        public string EvaluationCriteriaValueRating { get; set; }
        public string EvaluationCriteriaValueDescription { get; set; }
        public int? SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationCriteriaValueID; } set { EvaluationCriteriaValueID = value; } }

        public virtual ICollection<ProjectEvaluationSelectedValue> ProjectEvaluationSelectedValues { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual EvaluationCriteria EvaluationCriteria { get; set; }

        public static class FieldLengths
        {
            public const int EvaluationCriteriaValueRating = 60;
            public const int EvaluationCriteriaValueDescription = 500;
        }
    }
}