//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProgramEIPPerformanceMeasure]
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
    [Table("[dbo].[ProgramEIPPerformanceMeasure]")]
    public partial class ProgramEIPPerformanceMeasure : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProgramEIPPerformanceMeasure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramEIPPerformanceMeasure(int programEIPPerformanceMeasureID, int programID, int eIPPerformanceMeasureID, bool isPrimaryProgram) : this()
        {
            this.ProgramEIPPerformanceMeasureID = programEIPPerformanceMeasureID;
            this.ProgramID = programID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IsPrimaryProgram = isPrimaryProgram;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramEIPPerformanceMeasure(int programID, int eIPPerformanceMeasureID, bool isPrimaryProgram) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProgramEIPPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProgramID = programID;
            this.EIPPerformanceMeasureID = eIPPerformanceMeasureID;
            this.IsPrimaryProgram = isPrimaryProgram;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProgramEIPPerformanceMeasure(Program program, EIPPerformanceMeasure eIPPerformanceMeasure, bool isPrimaryProgram) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProgramEIPPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProgramID = program.ProgramID;
            this.Program = program;
            program.ProgramEIPPerformanceMeasures.Add(this);
            this.EIPPerformanceMeasureID = eIPPerformanceMeasure.EIPPerformanceMeasureID;
            this.EIPPerformanceMeasure = eIPPerformanceMeasure;
            eIPPerformanceMeasure.ProgramEIPPerformanceMeasures.Add(this);
            this.IsPrimaryProgram = isPrimaryProgram;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProgramEIPPerformanceMeasure CreateNewBlank(Program program, EIPPerformanceMeasure eIPPerformanceMeasure)
        {
            return new ProgramEIPPerformanceMeasure(program, eIPPerformanceMeasure, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProgramEIPPerformanceMeasure).Name};

        [Key]
        public int ProgramEIPPerformanceMeasureID { get; set; }
        public int ProgramID { get; set; }
        public int EIPPerformanceMeasureID { get; set; }
        public bool IsPrimaryProgram { get; set; }
        public int PrimaryKey { get { return ProgramEIPPerformanceMeasureID; } set { ProgramEIPPerformanceMeasureID = value; } }

        public virtual Program Program { get; set; }
        public virtual EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}