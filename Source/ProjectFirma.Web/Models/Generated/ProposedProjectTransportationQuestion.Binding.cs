//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectTransportationQuestion]
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
    [Table("[dbo].[ProposedProjectTransportationQuestion]")]
    public partial class ProposedProjectTransportationQuestion : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProposedProjectTransportationQuestion()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectTransportationQuestion(int proposedProjectTransportationQuestionID, int proposedProjectID, int transportationQuestionID, bool? answer) : this()
        {
            this.ProposedProjectTransportationQuestionID = proposedProjectTransportationQuestionID;
            this.ProposedProjectID = proposedProjectID;
            this.TransportationQuestionID = transportationQuestionID;
            this.Answer = answer;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectTransportationQuestion(int proposedProjectID, int transportationQuestionID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProposedProjectTransportationQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProposedProjectID = proposedProjectID;
            this.TransportationQuestionID = transportationQuestionID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProposedProjectTransportationQuestion(ProposedProject proposedProject, TransportationQuestion transportationQuestion) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProposedProjectTransportationQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProposedProjectID = proposedProject.ProposedProjectID;
            this.ProposedProject = proposedProject;
            proposedProject.ProposedProjectTransportationQuestions.Add(this);
            this.TransportationQuestionID = transportationQuestion.TransportationQuestionID;
            this.TransportationQuestion = transportationQuestion;
            transportationQuestion.ProposedProjectTransportationQuestions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProposedProjectTransportationQuestion CreateNewBlank(ProposedProject proposedProject, TransportationQuestion transportationQuestion)
        {
            return new ProposedProjectTransportationQuestion(proposedProject, transportationQuestion);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProposedProjectTransportationQuestion).Name};

        [Key]
        public int ProposedProjectTransportationQuestionID { get; set; }
        public int ProposedProjectID { get; set; }
        public int TransportationQuestionID { get; set; }
        public bool? Answer { get; set; }
        public int PrimaryKey { get { return ProposedProjectTransportationQuestionID; } set { ProposedProjectTransportationQuestionID = value; } }

        public virtual ProposedProject ProposedProject { get; set; }
        public virtual TransportationQuestion TransportationQuestion { get; set; }

        public static class FieldLengths
        {

        }
    }
}