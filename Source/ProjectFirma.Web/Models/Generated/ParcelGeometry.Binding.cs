//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ParcelGeometry]
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
    [Table("[dbo].[ParcelGeometry]")]
    public partial class ParcelGeometry : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ParcelGeometry()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelGeometry(DbGeometry ogr_Geometry, string parcelNumber, int? parcelID, int parcelGeometryID) : this()
        {
            this.Ogr_Geometry = ogr_Geometry;
            this.ParcelNumber = parcelNumber;
            this.ParcelID = parcelID;
            this.ParcelGeometryID = parcelGeometryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ParcelGeometry(DbGeometry ogr_Geometry, string parcelNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ParcelGeometryID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.Ogr_Geometry = ogr_Geometry;
            this.ParcelNumber = parcelNumber;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ParcelGeometry CreateNewBlank()
        {
            return new ParcelGeometry(default(DbGeometry), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ParcelGeometry).Name};

        public DbGeometry Ogr_Geometry { get; set; }
        public string ParcelNumber { get; set; }
        public int? ParcelID { get; set; }
        [Key]
        public int ParcelGeometryID { get; set; }
        public int PrimaryKey { get { return ParcelGeometryID; } set { ParcelGeometryID = value; } }

        public virtual Parcel Parcel { get; set; }

        public static class FieldLengths
        {
            public const int ParcelNumber = 30;
        }
    }
}