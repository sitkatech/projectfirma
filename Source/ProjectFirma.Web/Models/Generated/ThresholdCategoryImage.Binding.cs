//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdCategoryImage]
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
    [Table("[dbo].[ThresholdCategoryImage]")]
    public partial class ThresholdCategoryImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdCategoryImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdCategoryImage(int thresholdCategoryImageID, int thresholdCategoryID, int fileResourceID) : this()
        {
            this.ThresholdCategoryImageID = thresholdCategoryImageID;
            this.ThresholdCategoryID = thresholdCategoryID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdCategoryImage(int thresholdCategoryID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdCategoryImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ThresholdCategoryID = thresholdCategoryID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdCategoryImage(ThresholdCategory thresholdCategory, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdCategoryImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ThresholdCategoryID = thresholdCategory.ThresholdCategoryID;
            this.ThresholdCategory = thresholdCategory;
            thresholdCategory.ThresholdCategoryImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ThresholdCategoryImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdCategoryImage CreateNewBlank(ThresholdCategory thresholdCategory, FileResource fileResource)
        {
            return new ThresholdCategoryImage(thresholdCategory, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdCategoryImage).Name};

        [Key]
        public int ThresholdCategoryImageID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return ThresholdCategoryImageID; } set { ThresholdCategoryImageID = value; } }

        public virtual ThresholdCategory ThresholdCategory { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}