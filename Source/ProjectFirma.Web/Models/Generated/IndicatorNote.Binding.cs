//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[IndicatorNote]
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
    [Table("[dbo].[IndicatorNote]")]
    public partial class IndicatorNote : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected IndicatorNote()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorNote(int indicatorNoteID, int indicatorID, string note, int? createPersonID, DateTime createDate, int? updatePersonID, DateTime? updateDate) : this()
        {
            this.IndicatorNoteID = indicatorNoteID;
            this.IndicatorID = indicatorID;
            this.Note = note;
            this.CreatePersonID = createPersonID;
            this.CreateDate = createDate;
            this.UpdatePersonID = updatePersonID;
            this.UpdateDate = updateDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorNote(int indicatorID, string note, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            IndicatorNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IndicatorID = indicatorID;
            this.Note = note;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public IndicatorNote(Indicator indicator, string note, DateTime createDate) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.IndicatorNoteID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IndicatorID = indicator.IndicatorID;
            this.Indicator = indicator;
            indicator.IndicatorNotes.Add(this);
            this.Note = note;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static IndicatorNote CreateNewBlank(Indicator indicator)
        {
            return new IndicatorNote(indicator, default(string), default(DateTime));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(IndicatorNote).Name};

        [Key]
        public int IndicatorNoteID { get; set; }
        public int IndicatorID { get; set; }
        public string Note { get; set; }
        public int? CreatePersonID { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdatePersonID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int PrimaryKey { get { return IndicatorNoteID; } set { IndicatorNoteID = value; } }

        public virtual Indicator Indicator { get; set; }
        public virtual Person CreatePerson { get; set; }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int Note = 8000;
        }
    }
}