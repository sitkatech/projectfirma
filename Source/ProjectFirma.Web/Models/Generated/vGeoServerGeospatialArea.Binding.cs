//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vGeoServerGeospatialArea]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class vGeoServerGeospatialArea
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vGeoServerGeospatialArea()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vGeoServerGeospatialArea(int geospatialAreaID, int primaryKey, string geospatialAreaName, int tenantID, string tenantName, string geospatialAreaTypeName) : this()
        {
            this.GeospatialAreaID = geospatialAreaID;
            this.PrimaryKey = primaryKey;
            this.GeospatialAreaName = geospatialAreaName;
            this.TenantID = tenantID;
            this.TenantName = tenantName;
            this.GeospatialAreaTypeName = geospatialAreaTypeName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vGeoServerGeospatialArea(vGeoServerGeospatialArea vGeoServerGeospatialArea) : this()
        {
            this.GeospatialAreaID = vGeoServerGeospatialArea.GeospatialAreaID;
            this.PrimaryKey = vGeoServerGeospatialArea.PrimaryKey;
            this.GeospatialAreaName = vGeoServerGeospatialArea.GeospatialAreaName;
            this.TenantID = vGeoServerGeospatialArea.TenantID;
            this.TenantName = vGeoServerGeospatialArea.TenantName;
            this.GeospatialAreaTypeName = vGeoServerGeospatialArea.GeospatialAreaTypeName;
            CallAfterConstructor(vGeoServerGeospatialArea);
        }

        partial void CallAfterConstructor(vGeoServerGeospatialArea vGeoServerGeospatialArea);

        public int GeospatialAreaID { get; set; }
        public int PrimaryKey { get; set; }
        public string GeospatialAreaName { get; set; }
        public int TenantID { get; set; }
        public string TenantName { get; set; }
        public string GeospatialAreaTypeName { get; set; }
    }
}