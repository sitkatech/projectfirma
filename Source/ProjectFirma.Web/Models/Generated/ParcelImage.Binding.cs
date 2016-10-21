//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelImage]
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
    [Table("[dbo].[ParcelImage]")]
    public partial class ParcelImage : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ParcelImage()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelImage(int parcelImageID, int fileResourceID, int parcelID, string caption, string credit, bool isKeyPhoto) : this()
        {
            this.ParcelImageID = parcelImageID;
            this.FileResourceID = fileResourceID;
            this.ParcelID = parcelID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelImage(int fileResourceID, int parcelID, string caption, string credit, bool isKeyPhoto) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.FileResourceID = fileResourceID;
            this.ParcelID = parcelID;
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ParcelImage(FileResource fileResource, Parcel parcel, string caption, string credit, bool isKeyPhoto) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ParcelImageID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.FileResourceID = fileResource.FileResourceID;
            this.FileResource = fileResource;
            fileResource.ParcelImages.Add(this);
            this.ParcelID = parcel.ParcelID;
            this.Parcel = parcel;
            parcel.ParcelImages.Add(this);
            this.Caption = caption;
            this.Credit = credit;
            this.IsKeyPhoto = isKeyPhoto;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ParcelImage CreateNewBlank(FileResource fileResource, Parcel parcel)
        {
            return new ParcelImage(fileResource, parcel, default(string), default(string), default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ParcelImage).Name};

        [Key]
        public int ParcelImageID { get; set; }
        public int FileResourceID { get; set; }
        public int ParcelID { get; set; }
        public string Caption { get; set; }
        public string Credit { get; set; }
        public bool IsKeyPhoto { get; set; }
        public int PrimaryKey { get { return ParcelImageID; } set { ParcelImageID = value; } }

        public virtual FileResource FileResource { get; set; }
        public virtual Parcel Parcel { get; set; }

        public static class FieldLengths
        {
            public const int Caption = 200;
            public const int Credit = 200;
        }
    }
}