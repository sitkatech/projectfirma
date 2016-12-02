//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdCategory]
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
    [Table("[dbo].[ThresholdCategory]")]
    public partial class ThresholdCategory : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdCategory()
        {
            this.ProjectThresholdCategories = new HashSet<ProjectThresholdCategory>();
            this.ProposedProjectThresholdCategories = new HashSet<ProposedProjectThresholdCategory>();
            this.ThresholdCategoryImages = new HashSet<ThresholdCategoryImage>();
            this.ThresholdCategoryPerformanceMeasures = new HashSet<ThresholdCategoryPerformanceMeasure>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdCategory(int thresholdCategoryID, string thresholdCategoryName, string thresholdCategoryDescription, string themeColor, string displayName, string goalStatement, string narrative) : this()
        {
            this.ThresholdCategoryID = thresholdCategoryID;
            this.ThresholdCategoryName = thresholdCategoryName;
            this.ThresholdCategoryDescription = thresholdCategoryDescription;
            this.ThemeColor = themeColor;
            this.DisplayName = displayName;
            this.GoalStatement = goalStatement;
            this.Narrative = narrative;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdCategory(string thresholdCategoryName, string thresholdCategoryDescription, string themeColor, string displayName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdCategoryName = thresholdCategoryName;
            this.ThresholdCategoryDescription = thresholdCategoryDescription;
            this.ThemeColor = themeColor;
            this.DisplayName = displayName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdCategory CreateNewBlank()
        {
            return new ThresholdCategory(default(string), default(string), default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectThresholdCategories.Any() || ProposedProjectThresholdCategories.Any() || ThresholdCategoryImages.Any() || ThresholdCategoryPerformanceMeasures.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdCategory).Name, typeof(ProjectThresholdCategory).Name, typeof(ProposedProjectThresholdCategory).Name, typeof(ThresholdCategoryImage).Name, typeof(ThresholdCategoryPerformanceMeasure).Name};

        [Key]
        public int ThresholdCategoryID { get; set; }
        public string ThresholdCategoryName { get; set; }
        public string ThresholdCategoryDescription { get; set; }
        public string ThemeColor { get; set; }
        public string DisplayName { get; set; }
        public string GoalStatement { get; set; }
        [NotMapped]
        private string Narrative { get; set; }
        public HtmlString NarrativeHtmlString
        { 
            get { return Narrative == null ? null : new HtmlString(Narrative); }
            set { Narrative = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return ThresholdCategoryID; } set { ThresholdCategoryID = value; } }

        public virtual ICollection<ProjectThresholdCategory> ProjectThresholdCategories { get; set; }
        public virtual ICollection<ProposedProjectThresholdCategory> ProposedProjectThresholdCategories { get; set; }
        public virtual ICollection<ThresholdCategoryImage> ThresholdCategoryImages { get; set; }
        public virtual ICollection<ThresholdCategoryPerformanceMeasure> ThresholdCategoryPerformanceMeasures { get; set; }

        public static class FieldLengths
        {
            public const int ThresholdCategoryName = 100;
            public const int ThresholdCategoryDescription = 300;
            public const int ThemeColor = 7;
            public const int DisplayName = 50;
            public const int GoalStatement = 200;
        }
    }
}