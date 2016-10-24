//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProgramImage]
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
    [Table("[dbo].[ProgramImage]")]
    public partial class ProgramImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProgramImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramImage(int programImageID, int programID, int fileResourceID) : this()
        {
            this.ProgramImageID = programImageID;
            this.ProgramID = programID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProgramImage(int programID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProgramImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProgramID = programID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProgramImage(Program program, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProgramImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProgramID = program.ProgramID;
            this.Program = program;
            program.ProgramImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ProgramImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProgramImage CreateNewBlank(Program program, FileResource fileResource)
        {
            return new ProgramImage(program, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProgramImage).Name};

        [Key]
        public int ProgramImageID { get; set; }
        public int ProgramID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return ProgramImageID; } set { ProgramImageID = value; } }

        public virtual Program Program { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}