//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vGeoServerProjectSimpleLocations]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class vGeoServerProjectSimpleLocations
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vGeoServerProjectSimpleLocations()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vGeoServerProjectSimpleLocations(int projectID, int primaryKey, string projectName, int tenantID, string tenantName) : this()
        {
            this.ProjectID = projectID;
            this.PrimaryKey = primaryKey;
            this.ProjectName = projectName;
            this.TenantID = tenantID;
            this.TenantName = tenantName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vGeoServerProjectSimpleLocations(vGeoServerProjectSimpleLocations vGeoServerProjectSimpleLocations) : this()
        {
            this.ProjectID = vGeoServerProjectSimpleLocations.ProjectID;
            this.PrimaryKey = vGeoServerProjectSimpleLocations.PrimaryKey;
            this.ProjectName = vGeoServerProjectSimpleLocations.ProjectName;
            this.TenantID = vGeoServerProjectSimpleLocations.TenantID;
            this.TenantName = vGeoServerProjectSimpleLocations.TenantName;
            CallAfterConstructor(vGeoServerProjectSimpleLocations);
        }

        partial void CallAfterConstructor(vGeoServerProjectSimpleLocations vGeoServerProjectSimpleLocations);

        public int ProjectID { get; set; }
        public int PrimaryKey { get; set; }
        public string ProjectName { get; set; }
        public int TenantID { get; set; }
        public string TenantName { get; set; }
    }
}