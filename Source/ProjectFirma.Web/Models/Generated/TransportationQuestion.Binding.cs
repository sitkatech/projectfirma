//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TransportationQuestion]
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
    [Table("[dbo].[TransportationQuestion]")]
    public partial class TransportationQuestion : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TransportationQuestion()
        {
            this.ProjectTransportationQuestions = new HashSet<ProjectTransportationQuestion>();
            this.ProposedProjectTransportationQuestions = new HashSet<ProposedProjectTransportationQuestion>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationQuestion(int transportationQuestionID, int transportationSubGoalID, string transportationQuestionText, DateTime? archiveDate) : this()
        {
            this.TransportationQuestionID = transportationQuestionID;
            this.TransportationSubGoalID = transportationSubGoalID;
            this.TransportationQuestionText = transportationQuestionText;
            this.ArchiveDate = archiveDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TransportationQuestion(int transportationSubGoalID, string transportationQuestionText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TransportationQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TransportationSubGoalID = transportationSubGoalID;
            this.TransportationQuestionText = transportationQuestionText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TransportationQuestion(TransportationSubGoal transportationSubGoal, string transportationQuestionText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TransportationQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TransportationSubGoalID = transportationSubGoal.TransportationSubGoalID;
            this.TransportationSubGoal = transportationSubGoal;
            transportationSubGoal.TransportationQuestions.Add(this);
            this.TransportationQuestionText = transportationQuestionText;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TransportationQuestion CreateNewBlank(TransportationSubGoal transportationSubGoal)
        {
            return new TransportationQuestion(transportationSubGoal, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectTransportationQuestions.Any() || ProposedProjectTransportationQuestions.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TransportationQuestion).Name, typeof(ProjectTransportationQuestion).Name, typeof(ProposedProjectTransportationQuestion).Name};

        [Key]
        public int TransportationQuestionID { get; set; }
        public int TransportationSubGoalID { get; set; }
        public string TransportationQuestionText { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public int PrimaryKey { get { return TransportationQuestionID; } set { TransportationQuestionID = value; } }

        public virtual ICollection<ProjectTransportationQuestion> ProjectTransportationQuestions { get; set; }
        public virtual ICollection<ProposedProjectTransportationQuestion> ProposedProjectTransportationQuestions { get; set; }
        public virtual TransportationSubGoal TransportationSubGoal { get; set; }

        public static class FieldLengths
        {
            public const int TransportationQuestionText = 300;
        }
    }
}