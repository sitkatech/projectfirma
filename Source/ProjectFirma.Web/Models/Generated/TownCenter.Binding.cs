//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TownCenter]
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
    [Table("[dbo].[TownCenter]")]
    public partial class TownCenter : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TownCenter()
        {
            this.ParcelDistanceFromTownCenters = new HashSet<ParcelDistanceFromTownCenter>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TownCenter(int townCenterID, string townCenterName, int townCenterTypeID, string geometryXml) : this()
        {
            this.TownCenterID = townCenterID;
            this.TownCenterName = townCenterName;
            this.TownCenterTypeID = townCenterTypeID;
            this.GeometryXml = geometryXml;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TownCenter(string townCenterName, int townCenterTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            TownCenterID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TownCenterName = townCenterName;
            this.TownCenterTypeID = townCenterTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TownCenter(string townCenterName, TownCenterType townCenterType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TownCenterID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TownCenterName = townCenterName;
            this.TownCenterTypeID = townCenterType.TownCenterTypeID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TownCenter CreateNewBlank(TownCenterType townCenterType)
        {
            return new TownCenter(default(string), townCenterType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ParcelDistanceFromTownCenters.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TownCenter).Name, typeof(ParcelDistanceFromTownCenter).Name};

        [Key]
        public int TownCenterID { get; set; }
        public string TownCenterName { get; set; }
        public int TownCenterTypeID { get; set; }
        public string GeometryXml { get; set; }
        public int PrimaryKey { get { return TownCenterID; } set { TownCenterID = value; } }

        public virtual ICollection<ParcelDistanceFromTownCenter> ParcelDistanceFromTownCenters { get; set; }
        public TownCenterType TownCenterType { get { return TownCenterType.AllLookupDictionary[TownCenterTypeID]; } }

        public static class FieldLengths
        {
            public const int TownCenterName = 200;
        }
    }
}