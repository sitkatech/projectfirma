//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationSubGoal]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[TransportationSubGoal]")]
    public partial class TransportationSubGoal : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationSubGoal()
        {
            this.TransportationQuestions = new HashSet<TransportationQuestion>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationSubGoal(int transportationSubGoalID, int transportationGoalID, int transportationSubGoalNumber, string transportationSubGoalTitle, string transportationSubGoalDescription) : this()
        {
            this.TransportationSubGoalID = transportationSubGoalID;
            this.TransportationGoalID = transportationGoalID;
            this.TransportationSubGoalNumber = transportationSubGoalNumber;
            this.TransportationSubGoalTitle = transportationSubGoalTitle;
            this.TransportationSubGoalDescription = transportationSubGoalDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationSubGoal(int transportationGoalID, int transportationSubGoalNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationSubGoalID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TransportationGoalID = transportationGoalID;
            this.TransportationSubGoalNumber = transportationSubGoalNumber;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TransportationSubGoal(TransportationGoal transportationGoal, int transportationSubGoalNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TransportationSubGoalID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TransportationGoalID = transportationGoal.TransportationGoalID;
            this.TransportationGoal = transportationGoal;
            transportationGoal.TransportationSubGoals.Add(this);
            this.TransportationSubGoalNumber = transportationSubGoalNumber;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationSubGoal CreateNewBlank(TransportationGoal transportationGoal)
        {
            return new TransportationSubGoal(transportationGoal, default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TransportationQuestions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationSubGoal).Name, typeof(TransportationQuestion).Name};

        [Key]
        public int TransportationSubGoalID { get; set; }
        public int TransportationGoalID { get; set; }
        public int TransportationSubGoalNumber { get; set; }
        public string TransportationSubGoalTitle { get; set; }
        public string TransportationSubGoalDescription { get; set; }
        public int PrimaryKey { get { return TransportationSubGoalID; } set { TransportationSubGoalID = value; } }

        public virtual ICollection<TransportationQuestion> TransportationQuestions { get; set; }
        public virtual TransportationGoal TransportationGoal { get; set; }

        public static class FieldLengths
        {
            public const int TransportationSubGoalTitle = 100;
            public const int TransportationSubGoalDescription = 300;
        }
    }
}