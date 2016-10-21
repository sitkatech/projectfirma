//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdReportingCategory]
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
    [Table("[dbo].[ThresholdReportingCategory]")]
    public partial class ThresholdReportingCategory : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdReportingCategory()
        {
            this.ThresholdIndicators = new HashSet<ThresholdIndicator>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdReportingCategory(int thresholdReportingCategoryID, int thresholdCategoryID, string thresholdReportingCategoryName, string displayName, int displayOrder, string narrative) : this()
        {
            this.ThresholdReportingCategoryID = thresholdReportingCategoryID;
            this.ThresholdCategoryID = thresholdCategoryID;
            this.ThresholdReportingCategoryName = thresholdReportingCategoryName;
            this.DisplayName = displayName;
            this.DisplayOrder = displayOrder;
            this.Narrative = narrative;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdReportingCategory(int thresholdCategoryID, string thresholdReportingCategoryName, string displayName, int displayOrder) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdReportingCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdCategoryID = thresholdCategoryID;
            this.ThresholdReportingCategoryName = thresholdReportingCategoryName;
            this.DisplayName = displayName;
            this.DisplayOrder = displayOrder;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdReportingCategory(ThresholdCategory thresholdCategory, string thresholdReportingCategoryName, string displayName, int displayOrder) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdReportingCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ThresholdCategoryID = thresholdCategory.ThresholdCategoryID;
            this.ThresholdCategory = thresholdCategory;
            thresholdCategory.ThresholdReportingCategories.Add(this);
            this.ThresholdReportingCategoryName = thresholdReportingCategoryName;
            this.DisplayName = displayName;
            this.DisplayOrder = displayOrder;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdReportingCategory CreateNewBlank(ThresholdCategory thresholdCategory)
        {
            return new ThresholdReportingCategory(thresholdCategory, default(string), default(string), default(int));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ThresholdIndicators.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdReportingCategory).Name, typeof(ThresholdIndicator).Name};

        [Key]
        public int ThresholdReportingCategoryID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public string ThresholdReportingCategoryName { get; set; }
        public string DisplayName { get; set; }
        public int DisplayOrder { get; set; }
        [NotMapped]
        private string Narrative { get; set; }
        public HtmlString NarrativeHtmlString
        { 
            get { return Narrative == null ? null : new HtmlString(Narrative); }
            set { Narrative = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return ThresholdReportingCategoryID; } set { ThresholdReportingCategoryID = value; } }

        public virtual ICollection<ThresholdIndicator> ThresholdIndicators { get; set; }
        public virtual ThresholdCategory ThresholdCategory { get; set; }

        public static class FieldLengths
        {
            public const int ThresholdReportingCategoryName = 100;
            public const int DisplayName = 100;
        }
    }
}