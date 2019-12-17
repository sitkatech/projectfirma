//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[EvaluationVisibility]
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
    // Table [dbo].[EvaluationVisibility] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[EvaluationVisibility]")]
    public partial class EvaluationVisibility : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected EvaluationVisibility()
        {
            this.Evaluations = new HashSet<Evaluation>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationVisibility(int evaluationVisibilityID, string evaluationVisibilityName, string evaluationVisibilityDisplayName) : this()
        {
            this.EvaluationVisibilityID = evaluationVisibilityID;
            this.EvaluationVisibilityName = evaluationVisibilityName;
            this.EvaluationVisibilityDisplayName = evaluationVisibilityDisplayName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public EvaluationVisibility(string evaluationVisibilityName, string evaluationVisibilityDisplayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.EvaluationVisibilityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.EvaluationVisibilityName = evaluationVisibilityName;
            this.EvaluationVisibilityDisplayName = evaluationVisibilityDisplayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static EvaluationVisibility CreateNewBlank()
        {
            return new EvaluationVisibility(default(string), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(EvaluationVisibility).Name, typeof(Evaluation).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.EvaluationVisibilities.Remove(this);
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
        public int EvaluationVisibilityID { get; set; }
        public string EvaluationVisibilityName { get; set; }
        public string EvaluationVisibilityDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return EvaluationVisibilityID; } set { EvaluationVisibilityID = value; } }

        public virtual ICollection<Evaluation> Evaluations { get; set; }

        public static class FieldLengths
        {
            public const int EvaluationVisibilityName = 100;
            public const int EvaluationVisibilityDisplayName = 100;
        }
    }
}