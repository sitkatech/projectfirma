//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[fGeoServerGeospatialAreaAreasContainingProjectLocation_Result]
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
    public partial class fGeoServerGeospatialAreaAreasContainingProjectLocation_Result
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public fGeoServerGeospatialAreaAreasContainingProjectLocation_Result()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public fGeoServerGeospatialAreaAreasContainingProjectLocation_Result(int geospatialAreaID, int primaryKey, string geospatialAreaName, int geospatialAreaTypeID) : this()
        {
            this.GeospatialAreaID = geospatialAreaID;
            this.PrimaryKey = primaryKey;
            this.GeospatialAreaName = geospatialAreaName;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public fGeoServerGeospatialAreaAreasContainingProjectLocation_Result(fGeoServerGeospatialAreaAreasContainingProjectLocation_Result fGeoServerGeospatialAreaAreasContainingProjectLocation_Result) : this()
        {
            this.GeospatialAreaID = fGeoServerGeospatialAreaAreasContainingProjectLocation_Result.GeospatialAreaID;
            this.PrimaryKey = fGeoServerGeospatialAreaAreasContainingProjectLocation_Result.PrimaryKey;
            this.GeospatialAreaName = fGeoServerGeospatialAreaAreasContainingProjectLocation_Result.GeospatialAreaName;
            this.GeospatialAreaTypeID = fGeoServerGeospatialAreaAreasContainingProjectLocation_Result.GeospatialAreaTypeID;
            CallAfterConstructor(fGeoServerGeospatialAreaAreasContainingProjectLocation_Result);
        }

        partial void CallAfterConstructor(fGeoServerGeospatialAreaAreasContainingProjectLocation_Result fGeoServerGeospatialAreaAreasContainingProjectLocation_Result);

        public int GeospatialAreaID { get; set; }
        [Key]
        public int PrimaryKey { get; set; }
        public string GeospatialAreaName { get; set; }
        public int GeospatialAreaTypeID { get; set; }
    }
}