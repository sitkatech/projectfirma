//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectThresholdCategory]
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
    [Table("[dbo].[ProjectThresholdCategory]")]
    public partial class ProjectThresholdCategory : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectThresholdCategory()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectThresholdCategory(int projectThresholdCategoryID, int projectID, int thresholdCategoryID, string projectThresholdCategoryNotes) : this()
        {
            this.ProjectThresholdCategoryID = projectThresholdCategoryID;
            this.ProjectID = projectID;
            this.ThresholdCategoryID = thresholdCategoryID;
            this.ProjectThresholdCategoryNotes = projectThresholdCategoryNotes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectThresholdCategory(int projectID, int thresholdCategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectThresholdCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectID = projectID;
            this.ThresholdCategoryID = thresholdCategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectThresholdCategory(Project project, ThresholdCategory thresholdCategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectThresholdCategoryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = project.ProjectID;
            this.Project = project;
            project.ProjectThresholdCategories.Add(this);
            this.ThresholdCategoryID = thresholdCategory.ThresholdCategoryID;
            this.ThresholdCategory = thresholdCategory;
            thresholdCategory.ProjectThresholdCategories.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectThresholdCategory CreateNewBlank(Project project, ThresholdCategory thresholdCategory)
        {
            return new ProjectThresholdCategory(project, thresholdCategory);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectThresholdCategory).Name};

        [Key]
        public int ProjectThresholdCategoryID { get; set; }
        public int ProjectID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public string ProjectThresholdCategoryNotes { get; set; }
        public int PrimaryKey { get { return ProjectThresholdCategoryID; } set { ProjectThresholdCategoryID = value; } }

        public virtual Project Project { get; set; }
        public virtual ThresholdCategory ThresholdCategory { get; set; }

        public static class FieldLengths
        {
            public const int ProjectThresholdCategoryNotes = 600;
        }
    }
}