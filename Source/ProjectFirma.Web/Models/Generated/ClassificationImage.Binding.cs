//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationImage]
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
    [Table("[dbo].[ClassificationImage]")]
    public partial class ClassificationImage : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ClassificationImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationImage(int classificationImageID, int classificationID, int fileResourceID) : this()
        {
            this.ClassificationImageID = classificationImageID;
            this.ClassificationID = classificationID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationImage(int classificationID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ClassificationImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ClassificationID = classificationID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ClassificationImage(Classification classification, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ClassificationID = classification.ClassificationID;
            this.Classification = classification;
            classification.ClassificationImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ClassificationImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ClassificationImage CreateNewBlank(Classification classification, FileResource fileResource)
        {
            return new ClassificationImage(classification, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ClassificationImage).Name};

        [Key]
        public int ClassificationImageID { get; set; }
        public int ClassificationID { get; set; }
        public int FileResourceID { get; set; }
        public int TenantID { get; set; }
        public int PrimaryKey { get { return ClassificationImageID; } set { ClassificationImageID = value; } }

        public virtual Classification Classification { get; set; }
        public virtual FileResource FileResource { get; set; }
        public virtual Tenant Tenant { get; set; }

        public static class FieldLengths
        {

        }
    }
}