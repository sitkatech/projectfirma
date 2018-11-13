//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vGeoServerWatershed]
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
    public partial class vGeoServerWatershed
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vGeoServerWatershed()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vGeoServerWatershed(int watershedID, int primaryKey, string watershedName, int tenantID, string tenantName, string watershedLabelName) : this()
        {
            this.WatershedID = watershedID;
            this.PrimaryKey = primaryKey;
            this.WatershedName = watershedName;
            this.TenantID = tenantID;
            this.TenantName = tenantName;
            this.WatershedLabelName = watershedLabelName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vGeoServerWatershed(vGeoServerWatershed vGeoServerWatershed) : this()
        {
            this.WatershedID = vGeoServerWatershed.WatershedID;
            this.PrimaryKey = vGeoServerWatershed.PrimaryKey;
            this.WatershedName = vGeoServerWatershed.WatershedName;
            this.TenantID = vGeoServerWatershed.TenantID;
            this.TenantName = vGeoServerWatershed.TenantName;
            this.WatershedLabelName = vGeoServerWatershed.WatershedLabelName;
            CallAfterConstructor(vGeoServerWatershed);
        }

        partial void CallAfterConstructor(vGeoServerWatershed vGeoServerWatershed);

        public int WatershedID { get; set; }
        public int PrimaryKey { get; set; }
        public string WatershedName { get; set; }
        public int TenantID { get; set; }
        public string TenantName { get; set; }
        public string WatershedLabelName { get; set; }
    }
}