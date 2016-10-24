//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionPriority]
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
    [Table("[dbo].[ActionPriority]")]
    public partial class ActionPriority : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ActionPriority()
        {
            this.ActionPriorityImages = new HashSet<ActionPriorityImage>();
            this.Projects = new HashSet<Project>();
            this.ProposedProjects = new HashSet<ProposedProject>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ActionPriority(int actionPriorityID, int programID, byte actionPriorityNumber, string actionPriorityName, string actionPriorityDescription) : this()
        {
            this.ActionPriorityID = actionPriorityID;
            this.ProgramID = programID;
            this.ActionPriorityNumber = actionPriorityNumber;
            this.ActionPriorityName = actionPriorityName;
            this.ActionPriorityDescription = actionPriorityDescription;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ActionPriority(int programID, byte actionPriorityNumber, string actionPriorityName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ActionPriorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProgramID = programID;
            this.ActionPriorityNumber = actionPriorityNumber;
            this.ActionPriorityName = actionPriorityName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ActionPriority(Program program, byte actionPriorityNumber, string actionPriorityName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ActionPriorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProgramID = program.ProgramID;
            this.Program = program;
            program.ActionPriorities.Add(this);
            this.ActionPriorityNumber = actionPriorityNumber;
            this.ActionPriorityName = actionPriorityName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ActionPriority CreateNewBlank(Program program)
        {
            return new ActionPriority(program, default(byte), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ActionPriorityImages.Any() || Projects.Any() || ProposedProjects.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ActionPriority).Name, typeof(ActionPriorityImage).Name, typeof(Project).Name, typeof(ProposedProject).Name};

        [Key]
        public int ActionPriorityID { get; set; }
        public int ProgramID { get; set; }
        public byte ActionPriorityNumber { get; set; }
        public string ActionPriorityName { get; set; }
        [NotMapped]
        private string ActionPriorityDescription { get; set; }
        public HtmlString ActionPriorityDescriptionHtmlString
        { 
            get { return ActionPriorityDescription == null ? null : new HtmlString(ActionPriorityDescription); }
            set { ActionPriorityDescription = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return ActionPriorityID; } set { ActionPriorityID = value; } }

        public virtual ICollection<ActionPriorityImage> ActionPriorityImages { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProposedProject> ProposedProjects { get; set; }
        public virtual Program Program { get; set; }

        public static class FieldLengths
        {
            public const int ActionPriorityName = 100;
        }
    }
}