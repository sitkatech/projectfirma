//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdEvaluationPeriod]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[ThresholdEvaluationPeriod]")]
    public partial class ThresholdEvaluationPeriod : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdEvaluationPeriod()
        {
            this.ThresholdEvaluations = new HashSet<ThresholdEvaluation>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdEvaluationPeriod(int thresholdEvaluationPeriodID, int thresholdEvaluationYear) : this()
        {
            this.ThresholdEvaluationPeriodID = thresholdEvaluationPeriodID;
            this.ThresholdEvaluationYear = thresholdEvaluationYear;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdEvaluationPeriod(int thresholdEvaluationYear) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdEvaluationPeriodID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdEvaluationYear = thresholdEvaluationYear;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdEvaluationPeriod CreateNewBlank()
        {
            return new ThresholdEvaluationPeriod(default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ThresholdEvaluations.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdEvaluationPeriod).Name, typeof(ThresholdEvaluation).Name};

        [Key]
        public int ThresholdEvaluationPeriodID { get; set; }
        public int ThresholdEvaluationYear { get; set; }
        public int PrimaryKey { get { return ThresholdEvaluationPeriodID; } set { ThresholdEvaluationPeriodID = value; } }

        public virtual ICollection<ThresholdEvaluation> ThresholdEvaluations { get; set; }

        public static class FieldLengths
        {

        }
    }
}