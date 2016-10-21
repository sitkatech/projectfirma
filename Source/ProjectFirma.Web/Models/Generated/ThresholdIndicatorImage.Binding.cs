//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ThresholdIndicatorImage]
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
    [Table("[dbo].[ThresholdIndicatorImage]")]
    public partial class ThresholdIndicatorImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ThresholdIndicatorImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicatorImage(int thresholdIndicatorImageID, int fileResourceID, int thresholdIndicatorID, string caption, string credit, bool isKeyPhoto) : this()
        {
            this.ThresholdIndicatorImageID = thresholdIndicatorImageID;
            this.FileResourceID = fileResourceID;
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ThresholdIndicatorImage(int fileResourceID, int thresholdIndicatorID, string caption, string credit, bool isKeyPhoto) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ThresholdIndicatorImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceID = fileResourceID;
            this.ThresholdIndicatorID = thresholdIndicatorID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ThresholdIndicatorImage(FileResource fileResource, ThresholdIndicator thresholdIndicator, string caption, string credit, bool isKeyPhoto) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ThresholdIndicatorImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ThresholdIndicatorImages.Add(this);
            this.ThresholdIndicatorID = thresholdIndicator.ThresholdIndicatorID;
            this.ThresholdIndicator = thresholdIndicator;
            thresholdIndicator.ThresholdIndicatorImages.Add(this);
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ThresholdIndicatorImage CreateNewBlank(FileResource fileResource, ThresholdIndicator thresholdIndicator)
        {
            return new ThresholdIndicatorImage(fileResource, thresholdIndicator, default(string), default(string), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ThresholdIndicatorImage).Name};

        [Key]
        public int ThresholdIndicatorImageID { get; set; }
        public int FileResourceID { get; set; }
        public int ThresholdIndicatorID { get; set; }
        public string Caption { get; set; }
        public string Credit { get; set; }
        public bool IsKeyPhoto { get; set; }
        public int PrimaryKey { get { return ThresholdIndicatorImageID; } set { ThresholdIndicatorImageID = value; } }

        public virtual FileResource FileResource { get; set; }
        public virtual ThresholdIndicator ThresholdIndicator { get; set; }

        public static class FieldLengths
        {
            public const int Caption = 200;
            public const int Credit = 200;
        }
    }
}