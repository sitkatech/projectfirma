//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[fGeoServerGeospatialAreaAreasContainingProjectLocationResult]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class fGeoServerGeospatialAreaAreasContainingProjectLocationResult
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public fGeoServerGeospatialAreaAreasContainingProjectLocationResult()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public fGeoServerGeospatialAreaAreasContainingProjectLocationResult(int geospatialAreaID, int primaryKey, string geospatialAreaName, int geospatialAreaTypeID) : this()
        {
            this.GeospatialAreaID = geospatialAreaID;
            this.PrimaryKey = primaryKey;
            this.GeospatialAreaName = geospatialAreaName;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public fGeoServerGeospatialAreaAreasContainingProjectLocationResult(fGeoServerGeospatialAreaAreasContainingProjectLocationResult fGeoServerGeospatialAreaAreasContainingProjectLocationResult) : this()
        {
            this.GeospatialAreaID = fGeoServerGeospatialAreaAreasContainingProjectLocationResult.GeospatialAreaID;
            this.PrimaryKey = fGeoServerGeospatialAreaAreasContainingProjectLocationResult.PrimaryKey;
            this.GeospatialAreaName = fGeoServerGeospatialAreaAreasContainingProjectLocationResult.GeospatialAreaName;
            this.GeospatialAreaTypeID = fGeoServerGeospatialAreaAreasContainingProjectLocationResult.GeospatialAreaTypeID;
            CallAfterConstructor(fGeoServerGeospatialAreaAreasContainingProjectLocationResult);
        }

        partial void CallAfterConstructor(fGeoServerGeospatialAreaAreasContainingProjectLocationResult fGeoServerGeospatialAreaAreasContainingProjectLocationResult);

        public int GeospatialAreaID { get; set; }
        [Key]
        public int PrimaryKey { get; set; }
        public string GeospatialAreaName { get; set; }
        public int GeospatialAreaTypeID { get; set; }
    }
}