//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFirmaPage]
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
    [Table("[dbo].[ProjectFirmaPage]")]
    public partial class ProjectFirmaPage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFirmaPage()
        {
            this.ProjectFirmaPageImages = new HashSet<ProjectFirmaPageImage>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFirmaPage(int projectFirmaPageID, int projectFirmaPageTypeID, string projectFirmaPageContent) : this()
        {
            this.ProjectFirmaPageID = projectFirmaPageID;
            this.ProjectFirmaPageTypeID = projectFirmaPageTypeID;
            this.ProjectFirmaPageContent = projectFirmaPageContent;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFirmaPage(int projectFirmaPageTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectFirmaPageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectFirmaPageTypeID = projectFirmaPageTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFirmaPage(ProjectFirmaPageType projectFirmaPageType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFirmaPageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectFirmaPageTypeID = projectFirmaPageType.ProjectFirmaPageTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFirmaPage CreateNewBlank(ProjectFirmaPageType projectFirmaPageType)
        {
            return new ProjectFirmaPage(projectFirmaPageType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectFirmaPageImages.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFirmaPage).Name, typeof(ProjectFirmaPageImage).Name};

        [Key]
        public int ProjectFirmaPageID { get; set; }
        public int ProjectFirmaPageTypeID { get; set; }
        [NotMapped]
        private string ProjectFirmaPageContent { get; set; }
        public HtmlString ProjectFirmaPageContentHtmlString
        { 
            get { return ProjectFirmaPageContent == null ? null : new HtmlString(ProjectFirmaPageContent); }
            set { ProjectFirmaPageContent = value == null ? null : value.ToString(); }
        }
        public int PrimaryKey { get { return ProjectFirmaPageID; } set { ProjectFirmaPageID = value; } }

        public virtual ICollection<ProjectFirmaPageImage> ProjectFirmaPageImages { get; set; }
        public ProjectFirmaPageType ProjectFirmaPageType { get { return ProjectFirmaPageType.AllLookupDictionary[ProjectFirmaPageTypeID]; } }

        public static class FieldLengths
        {

        }
    }
}