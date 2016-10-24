//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationGoal]
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
    [Table("[dbo].[TransportationGoal]")]
    public partial class TransportationGoal : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationGoal()
        {
            this.TransportationSubGoals = new HashSet<TransportationSubGoal>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationGoal(int transportationGoalID, int transportationGoalNumber, string transportationGoalTitle, string transportationGoalDescription) : this()
        {
            this.TransportationGoalID = transportationGoalID;
            this.TransportationGoalNumber = transportationGoalNumber;
            this.TransportationGoalTitle = transportationGoalTitle;
            this.TransportationGoalDescription = transportationGoalDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationGoal(int transportationGoalNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationGoalID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TransportationGoalNumber = transportationGoalNumber;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationGoal CreateNewBlank()
        {
            return new TransportationGoal(default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return TransportationSubGoals.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationGoal).Name, typeof(TransportationSubGoal).Name};

        [Key]
        public int TransportationGoalID { get; set; }
        public int TransportationGoalNumber { get; set; }
        public string TransportationGoalTitle { get; set; }
        public string TransportationGoalDescription { get; set; }
        public int PrimaryKey { get { return TransportationGoalID; } set { TransportationGoalID = value; } }

        public virtual ICollection<TransportationSubGoal> TransportationSubGoals { get; set; }

        public static class FieldLengths
        {
            public const int TransportationGoalTitle = 100;
            public const int TransportationGoalDescription = 300;
        }
    }
}