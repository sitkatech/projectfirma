//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectTransportationQuestion]
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
    [Table("[dbo].[ProjectTransportationQuestion]")]
    public partial class ProjectTransportationQuestion : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectTransportationQuestion()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectTransportationQuestion(int projectTransportationQuestionID, int projectID, int transportationQuestionID, bool? answer) : this()
        {
            this.ProjectTransportationQuestionID = projectTransportationQuestionID;
            this.ProjectID = projectID;
            this.TransportationQuestionID = transportationQuestionID;
            this.Answer = answer;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectTransportationQuestion(int projectID, int transportationQuestionID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectTransportationQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.TransportationQuestionID = transportationQuestionID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectTransportationQuestion(Project project, TransportationQuestion transportationQuestion) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectTransportationQuestionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectTransportationQuestions.Add(this);
            this.TransportationQuestionID = transportationQuestion.TransportationQuestionID;
            this.TransportationQuestion = transportationQuestion;
            transportationQuestion.ProjectTransportationQuestions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectTransportationQuestion CreateNewBlank(Project project, TransportationQuestion transportationQuestion)
        {
            return new ProjectTransportationQuestion(project, transportationQuestion);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectTransportationQuestion).Name};

        [Key]
        public int ProjectTransportationQuestionID { get; set; }
        public int ProjectID { get; set; }
        public int TransportationQuestionID { get; set; }
        public bool? Answer { get; set; }
        public int PrimaryKey { get { return ProjectTransportationQuestionID; } set { ProjectTransportationQuestionID = value; } }

        public virtual Project Project { get; set; }
        public virtual TransportationQuestion TransportationQuestion { get; set; }

        public static class FieldLengths
        {

        }
    }
}