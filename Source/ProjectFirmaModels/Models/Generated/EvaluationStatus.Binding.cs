//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationStatus]
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
    // Table [dbo].[EvaluationStatus] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[EvaluationStatus]")]
    public partial class EvaluationStatus : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EvaluationStatus()
        {
            this.Evaluations = new HashSet<Evaluation>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationStatus(int evaluationStatusID, string evaluationStatusName, string evaluationStatusDisplayName) : this()
        {
            this.EvaluationStatusID = evaluationStatusID;
            this.EvaluationStatusName = evaluationStatusName;
            this.EvaluationStatusDisplayName = evaluationStatusDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationStatus(string evaluationStatusName, string evaluationStatusDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationStatusID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EvaluationStatusName = evaluationStatusName;
            this.EvaluationStatusDisplayName = evaluationStatusDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EvaluationStatus CreateNewBlank()
        {
            return new EvaluationStatus(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Evaluations.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EvaluationStatus).Name, typeof(Evaluation).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.EvaluationStatuses.Remove(this);
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

            foreach(var x in Evaluations.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int EvaluationStatusID { get; set; }
        public string EvaluationStatusName { get; set; }
        public string EvaluationStatusDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationStatusID; } set { EvaluationStatusID = value; } }

        public virtual ICollection<Evaluation> Evaluations { get; set; }

        public static class FieldLengths
        {
            public const int EvaluationStatusName = 100;
            public const int EvaluationStatusDisplayName = 100;
        }
    }
}