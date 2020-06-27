//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vGeospatialArea]
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
    public partial class vGeospatialArea
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vGeospatialArea()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vGeospatialArea(int geospatialAreaID, int primaryKey, string geospatialAreaShortName, int tenantID, string tenantName, string geospatialAreaTypeName, int geospatialAreaTypeID) : this()
        {
            this.GeospatialAreaID = geospatialAreaID;
            this.PrimaryKey = primaryKey;
            this.GeospatialAreaShortName = geospatialAreaShortName;
            this.TenantID = tenantID;
            this.TenantName = tenantName;
            this.GeospatialAreaTypeName = geospatialAreaTypeName;
            this.GeospatialAreaTypeID = geospatialAreaTypeID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vGeospatialArea(vGeospatialArea vGeospatialArea) : this()
        {
            this.GeospatialAreaID = vGeospatialArea.GeospatialAreaID;
            this.PrimaryKey = vGeospatialArea.PrimaryKey;
            this.GeospatialAreaShortName = vGeospatialArea.GeospatialAreaShortName;
            this.TenantID = vGeospatialArea.TenantID;
            this.TenantName = vGeospatialArea.TenantName;
            this.GeospatialAreaTypeName = vGeospatialArea.GeospatialAreaTypeName;
            this.GeospatialAreaTypeID = vGeospatialArea.GeospatialAreaTypeID;
            CallAfterConstructor(vGeospatialArea);
        }

        partial void CallAfterConstructor(vGeospatialArea vGeospatialArea);

        public int GeospatialAreaID { get; set; }
        public int PrimaryKey { get; set; }
        public string GeospatialAreaShortName { get; set; }
        public int TenantID { get; set; }
        public string TenantName { get; set; }
        public string GeospatialAreaTypeName { get; set; }
        public int GeospatialAreaTypeID { get; set; }
    }
}