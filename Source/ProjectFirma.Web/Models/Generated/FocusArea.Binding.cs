//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FocusArea]
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
    [Table("[dbo].[FocusArea]")]
    public partial class FocusArea : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FocusArea()
        {
            this.FocusAreaImages = new HashSet<FocusAreaImage>();
            this.Programs = new HashSet<Program>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FocusArea(int focusAreaID, byte focusAreaNumber, string focusAreaName, string focusAreaDescription, string focusAreaColor) : this()
        {
            this.FocusAreaID = focusAreaID;
            this.FocusAreaNumber = focusAreaNumber;
            this.FocusAreaName = focusAreaName;
            this.FocusAreaDescription = focusAreaDescription;
            this.FocusAreaColor = focusAreaColor;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FocusArea(byte focusAreaNumber, string focusAreaName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            FocusAreaID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FocusAreaNumber = focusAreaNumber;
            this.FocusAreaName = focusAreaName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FocusArea CreateNewBlank()
        {
            return new FocusArea(default(byte), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FocusAreaImages.Any() || Programs.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FocusArea).Name, typeof(FocusAreaImage).Name, typeof(Program).Name};

        [Key]
        public int FocusAreaID { get; set; }
        public byte FocusAreaNumber { get; set; }
        public string FocusAreaName { get; set; }
        [NotMapped]
        private string FocusAreaDescription { get; set; }
        public HtmlString FocusAreaDescriptionHtmlString
        { 
            get { return FocusAreaDescription == null ? null : new HtmlString(FocusAreaDescription); }
            set { FocusAreaDescription = value == null ? null : value.ToString(); }
        }
        public string FocusAreaColor { get; set; }
        public int PrimaryKey { get { return FocusAreaID; } set { FocusAreaID = value; } }

        public virtual ICollection<FocusAreaImage> FocusAreaImages { get; set; }
        public virtual ICollection<Program> Programs { get; set; }

        public static class FieldLengths
        {
            public const int FocusAreaName = 100;
            public const int FocusAreaColor = 20;
        }
    }
}