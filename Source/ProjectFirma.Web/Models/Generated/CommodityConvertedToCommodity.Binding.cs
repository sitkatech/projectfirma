//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CommodityConvertedToCommodity]
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
    [Table("[dbo].[CommodityConvertedToCommodity]")]
    public partial class CommodityConvertedToCommodity : IHavePrimaryKey
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CommodityConvertedToCommodity()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommodityConvertedToCommodity(int commodityConvertedToCommodityID, int commodityID, int convertedToCommodityID) : this()
        {
            this.CommodityConvertedToCommodityID = commodityConvertedToCommodityID;
            this.CommodityID = commodityID;
            this.ConvertedToCommodityID = convertedToCommodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CommodityConvertedToCommodity(int commodityID, int convertedToCommodityID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            CommodityConvertedToCommodityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CommodityID = commodityID;
            this.ConvertedToCommodityID = convertedToCommodityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CommodityConvertedToCommodity(Commodity commodity, Commodity convertedToCommodity) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CommodityConvertedToCommodityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.CommodityID = commodity.CommodityID;
            this.ConvertedToCommodityID = convertedToCommodity.CommodityID;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CommodityConvertedToCommodity CreateNewBlank(Commodity commodity, Commodity convertedToCommodity)
        {
            return new CommodityConvertedToCommodity(commodity, convertedToCommodity);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CommodityConvertedToCommodity).Name};

        [Key]
        public int CommodityConvertedToCommodityID { get; set; }
        public int CommodityID { get; set; }
        public int ConvertedToCommodityID { get; set; }
        public int PrimaryKey { get { return CommodityConvertedToCommodityID; } set { CommodityConvertedToCommodityID = value; } }

        public Commodity Commodity { get { return Commodity.AllLookupDictionary[CommodityID]; } }
        public Commodity ConvertedToCommodity { get { return Commodity.AllLookupDictionary[ConvertedToCommodityID]; } }

        public static class FieldLengths
        {

        }
    }
}