//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Evaluation]
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
    // Table [dbo].[Evaluation] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Evaluation]")]
    public partial class Evaluation : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Evaluation()
        {
            this.EvaluationCriterions = new HashSet<EvaluationCriterion>();
            this.ProjectEvaluations = new HashSet<ProjectEvaluation>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Evaluation(int evaluationID, int evaluationVisibilityID, int evaluationStatusID, int createPersonID, string evaluationName, string evaluationDefinition, DateTime? evaluationStartDate, DateTime? evaluationEndDate, DateTime createDate) : this()
        {
            this.EvaluationID = evaluationID;
            this.EvaluationVisibilityID = evaluationVisibilityID;
            this.EvaluationStatusID = evaluationStatusID;
            this.CreatePersonID = createPersonID;
            this.EvaluationName = evaluationName;
            this.EvaluationDefinition = evaluationDefinition;
            this.EvaluationStartDate = evaluationStartDate;
            this.EvaluationEndDate = evaluationEndDate;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Evaluation(int evaluationVisibilityID, int evaluationStatusID, int createPersonID, string evaluationName, string evaluationDefinition, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EvaluationVisibilityID = evaluationVisibilityID;
            this.EvaluationStatusID = evaluationStatusID;
            this.CreatePersonID = createPersonID;
            this.EvaluationName = evaluationName;
            this.EvaluationDefinition = evaluationDefinition;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Evaluation(EvaluationVisibility evaluationVisibility, EvaluationStatus evaluationStatus, Person createPerson, string evaluationName, string evaluationDefinition, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.EvaluationVisibilityID = evaluationVisibility.EvaluationVisibilityID;
            this.EvaluationStatusID = evaluationStatus.EvaluationStatusID;
            this.CreatePersonID = createPerson.PersonID;
            this.CreatePerson = createPerson;
            createPerson.EvaluationsWhereYouAreTheCreatePerson.Add(this);
            this.EvaluationName = evaluationName;
            this.EvaluationDefinition = evaluationDefinition;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Evaluation CreateNewBlank(EvaluationVisibility evaluationVisibility, EvaluationStatus evaluationStatus, Person createPerson)
        {
            return new Evaluation(evaluationVisibility, evaluationStatus, createPerson, default(string), default(string), default(DateTime));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return EvaluationCriterions.Any() || ProjectEvaluations.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Evaluation).Name, typeof(EvaluationCriterion).Name, typeof(ProjectEvaluation).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllEvaluations.Remove(this);
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

            foreach(var x in EvaluationCriterions.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectEvaluations.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int EvaluationID { get; set; }
        public int TenantID { get; set; }
        public int EvaluationVisibilityID { get; set; }
        public int EvaluationStatusID { get; set; }
        public int CreatePersonID { get; set; }
        public string EvaluationName { get; set; }
        public string EvaluationDefinition { get; set; }
        public DateTime? EvaluationStartDate { get; set; }
        public DateTime? EvaluationEndDate { get; set; }
        public DateTime CreateDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationID; } set { EvaluationID = value; } }

        public virtual ICollection<EvaluationCriterion> EvaluationCriterions { get; set; }
        public virtual ICollection<ProjectEvaluation> ProjectEvaluations { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public EvaluationVisibility EvaluationVisibility { get { return EvaluationVisibility.AllLookupDictionary[EvaluationVisibilityID]; } }
        public EvaluationStatus EvaluationStatus { get { return EvaluationStatus.AllLookupDictionary[EvaluationStatusID]; } }
        public virtual Person CreatePerson { get; set; }

        public static class FieldLengths
        {
            public const int EvaluationName = 120;
            public const int EvaluationDefinition = 1000;
        }
    }
}