//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FocusAreaImage]
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
    [Table("[dbo].[FocusAreaImage]")]
    public partial class FocusAreaImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected FocusAreaImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public FocusAreaImage(int focusAreaImageID, int focusAreaID, int fileResourceID) : this()
        {
            this.FocusAreaImageID = focusAreaImageID;
            this.FocusAreaID = focusAreaID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public FocusAreaImage(int focusAreaID, int fileResourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            FocusAreaImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FocusAreaID = focusAreaID;
            this.FileResourceID = fileResourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public FocusAreaImage(FocusArea focusArea, FileResource fileResource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.FocusAreaImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FocusAreaID = focusArea.FocusAreaID;
            this.FocusArea = focusArea;
            focusArea.FocusAreaImages.Add(this);
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.FocusAreaImages.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static FocusAreaImage CreateNewBlank(FocusArea focusArea, FileResource fileResource)
        {
            return new FocusAreaImage(focusArea, fileResource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(FocusAreaImage).Name};

        [Key]
        public int FocusAreaImageID { get; set; }
        public int FocusAreaID { get; set; }
        public int FileResourceID { get; set; }
        public int PrimaryKey { get { return FocusAreaImageID; } set { FocusAreaImageID = value; } }

        public virtual FocusArea FocusArea { get; set; }
        public virtual FileResource FileResource { get; set; }

        public static class FieldLengths
        {

        }
    }
}