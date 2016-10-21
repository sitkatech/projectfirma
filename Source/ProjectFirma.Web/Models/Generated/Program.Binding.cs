//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Program]
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
    [Table("[dbo].[Program]")]
    public partial class Program : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Program()
        {
            this.ActionPriorities = new HashSet<ActionPriority>();
            this.ProgramEIPPerformanceMeasures = new HashSet<ProgramEIPPerformanceMeasure>();
            this.ProgramImages = new HashSet<ProgramImage>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Program(int programID, int focusAreaID, byte programNumber, string programName, string programDescription, string associatedPrograms) : this()
        {
            this.ProgramID = programID;
            this.FocusAreaID = focusAreaID;
            this.ProgramNumber = programNumber;
            this.ProgramName = programName;
            this.ProgramDescription = programDescription;
            this.AssociatedPrograms = associatedPrograms;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Program(int focusAreaID, byte programNumber, string programName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProgramID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FocusAreaID = focusAreaID;
            this.ProgramNumber = programNumber;
            this.ProgramName = programName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Program(FocusArea focusArea, byte programNumber, string programName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProgramID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FocusAreaID = focusArea.FocusAreaID;
            this.FocusArea = focusArea;
            focusArea.Programs.Add(this);
            this.ProgramNumber = programNumber;
            this.ProgramName = programName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Program CreateNewBlank(FocusArea focusArea)
        {
            return new Program(focusArea, default(byte), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ActionPriorities.Any() || ProgramEIPPerformanceMeasures.Any() || ProgramImages.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Program).Name, typeof(ActionPriority).Name, typeof(ProgramEIPPerformanceMeasure).Name, typeof(ProgramImage).Name};

        [Key]
        public int ProgramID { get; set; }
        public int FocusAreaID { get; set; }
        public byte ProgramNumber { get; set; }
        public string ProgramName { get; set; }
        [NotMapped]
        private string ProgramDescription { get; set; }
        public HtmlString ProgramDescriptionHtmlString
        { 
            get { return ProgramDescription == null ? null : new HtmlString(ProgramDescription); }
            set { ProgramDescription = value == null ? null : value.ToString(); }
        }
        [NotMapped]
        private string AssociatedPrograms { get; set; }
        public HtmlString AssociatedProgramsHtmlString
        { 
            get { return AssociatedPrograms == null ? null : new HtmlString(AssociatedPrograms); }
            set { AssociatedPrograms = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return ProgramID; } set { ProgramID = value; } }

        public virtual ICollection<ActionPriority> ActionPriorities { get; set; }
        public virtual ICollection<ProgramEIPPerformanceMeasure> ProgramEIPPerformanceMeasures { get; set; }
        public virtual ICollection<ProgramImage> ProgramImages { get; set; }
        public virtual FocusArea FocusArea { get; set; }

        public static class FieldLengths
        {
            public const int ProgramName = 100;
        }
    }
}