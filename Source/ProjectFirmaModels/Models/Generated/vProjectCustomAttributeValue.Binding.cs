//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vProjectCustomAttributeValue]
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
    public partial class vProjectCustomAttributeValue
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vProjectCustomAttributeValue()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vProjectCustomAttributeValue(int projectCustomAttributeID, int primaryKey, int tenantID, int projectID, int projectCustomAttributeTypeID, string projectCustomAttributeValuesConcatenated) : this()
        {
            this.ProjectCustomAttributeID = projectCustomAttributeID;
            this.PrimaryKey = primaryKey;
            this.TenantID = tenantID;
            this.ProjectID = projectID;
            this.ProjectCustomAttributeTypeID = projectCustomAttributeTypeID;
            this.ProjectCustomAttributeValuesConcatenated = projectCustomAttributeValuesConcatenated;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vProjectCustomAttributeValue(vProjectCustomAttributeValue vProjectCustomAttributeValue) : this()
        {
            this.ProjectCustomAttributeID = vProjectCustomAttributeValue.ProjectCustomAttributeID;
            this.PrimaryKey = vProjectCustomAttributeValue.PrimaryKey;
            this.TenantID = vProjectCustomAttributeValue.TenantID;
            this.ProjectID = vProjectCustomAttributeValue.ProjectID;
            this.ProjectCustomAttributeTypeID = vProjectCustomAttributeValue.ProjectCustomAttributeTypeID;
            this.ProjectCustomAttributeValuesConcatenated = vProjectCustomAttributeValue.ProjectCustomAttributeValuesConcatenated;
            CallAfterConstructor(vProjectCustomAttributeValue);
        }

        partial void CallAfterConstructor(vProjectCustomAttributeValue vProjectCustomAttributeValue);

        public int ProjectCustomAttributeID { get; set; }
        public int PrimaryKey { get; set; }
        public int TenantID { get; set; }
        public int ProjectID { get; set; }
        public int ProjectCustomAttributeTypeID { get; set; }
        public string ProjectCustomAttributeValuesConcatenated { get; set; }
    }
}