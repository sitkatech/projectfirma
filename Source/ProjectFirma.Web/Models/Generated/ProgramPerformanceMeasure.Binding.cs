//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProgramPerformanceMeasure]
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
    [Table("[dbo].[ProgramPerformanceMeasure]")]
    public partial class ProgramPerformanceMeasure : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProgramPerformanceMeasure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramPerformanceMeasure(int programPerformanceMeasureID, int programID, int performanceMeasureID, bool isPrimaryProgram) : this()
        {
            this.ProgramPerformanceMeasureID = programPerformanceMeasureID;
            this.ProgramID = programID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryProgram = isPrimaryProgram;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramPerformanceMeasure(int programID, int performanceMeasureID, bool isPrimaryProgram) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProgramPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProgramID = programID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryProgram = isPrimaryProgram;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProgramPerformanceMeasure(Program program, PerformanceMeasure performanceMeasure, bool isPrimaryProgram) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProgramPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProgramID = program.ProgramID;
            this.Program = program;
            program.ProgramPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.ProgramPerformanceMeasures.Add(this);
            this.IsPrimaryProgram = isPrimaryProgram;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProgramPerformanceMeasure CreateNewBlank(Program program, PerformanceMeasure performanceMeasure)
        {
            return new ProgramPerformanceMeasure(program, performanceMeasure, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProgramPerformanceMeasure).Name};

        [Key]
        public int ProgramPerformanceMeasureID { get; set; }
        public int ProgramID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryProgram { get; set; }
        public int PrimaryKey { get { return ProgramPerformanceMeasureID; } set { ProgramPerformanceMeasureID = value; } }

        public virtual Program Program { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}