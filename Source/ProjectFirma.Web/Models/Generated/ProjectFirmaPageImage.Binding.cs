//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFirmaPageImage]
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
    [Table("[dbo].[ProjectFirmaPageImage]")]
    public partial class ProjectFirmaPageImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFirmaPageImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFirmaPageImage(int projectFirmaPageImageID, int projectFirmaPageID, int fileResourceID) : this()
        {
            this.ProjectFirmaPageImageID = projectFirmaPageImageID;
            this.ProjectFirmaPageID = projectFirmaPageID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFirmaPageImage(int projectFirmaPageID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectFirmaPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectFirmaPageID = projectFirmaPageID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFirmaPageImage(ProjectFirmaPage projectFirmaPage, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFirmaPageImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectFirmaPageID = projectFirmaPage.ProjectFirmaPageID;
            this.ProjectFirmaPage = projectFirmaPage;
            projectFirmaPage.ProjectFirmaPageImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ProjectFirmaPageImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFirmaPageImage CreateNewBlank(ProjectFirmaPage projectFirmaPage, FileResource fileResource)
        {
            return new ProjectFirmaPageImage(projectFirmaPage, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFirmaPageImage).Name};

        [Key]
        public int ProjectFirmaPageImageID { get; set; }
        public int ProjectFirmaPageID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return ProjectFirmaPageImageID; } set { ProjectFirmaPageImageID = value; } }

        public virtual ProjectFirmaPage ProjectFirmaPage { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}