//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vProjectDetail]
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
    public partial class vProjectDetail
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vProjectDetail()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vProjectDetail(int projectID, int primaryKey, int tenantID, string projectName, int? primaryContactOrganizationID, string primaryContactOrganizationDisplayName, int? primaryContactPersonID, string primaryContactPersonFullNameFirstLast, string primaryContactPersonEmail, int? performanceMeasureActualCount, int? projectImageCount, int? canStewardProjectsOrganizationID, string canStewardProjectsOrganizationDisplayName, int taxonomyLeafID, string taxonomyLeafDisplayName, string finalStatusReportStatusDescription, int? projectFundingSourceExpenditureCount) : this()
        {
            this.ProjectID = projectID;
            this.PrimaryKey = primaryKey;
            this.TenantID = tenantID;
            this.ProjectName = projectName;
            this.PrimaryContactOrganizationID = primaryContactOrganizationID;
            this.PrimaryContactOrganizationDisplayName = primaryContactOrganizationDisplayName;
            this.PrimaryContactPersonID = primaryContactPersonID;
            this.PrimaryContactPersonFullNameFirstLast = primaryContactPersonFullNameFirstLast;
            this.PrimaryContactPersonEmail = primaryContactPersonEmail;
            this.PerformanceMeasureActualCount = performanceMeasureActualCount;
            this.ProjectImageCount = projectImageCount;
            this.CanStewardProjectsOrganizationID = canStewardProjectsOrganizationID;
            this.CanStewardProjectsOrganizationDisplayName = canStewardProjectsOrganizationDisplayName;
            this.TaxonomyLeafID = taxonomyLeafID;
            this.TaxonomyLeafDisplayName = taxonomyLeafDisplayName;
            this.FinalStatusReportStatusDescription = finalStatusReportStatusDescription;
            this.ProjectFundingSourceExpenditureCount = projectFundingSourceExpenditureCount;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vProjectDetail(vProjectDetail vProjectDetail) : this()
        {
            this.ProjectID = vProjectDetail.ProjectID;
            this.PrimaryKey = vProjectDetail.PrimaryKey;
            this.TenantID = vProjectDetail.TenantID;
            this.ProjectName = vProjectDetail.ProjectName;
            this.PrimaryContactOrganizationID = vProjectDetail.PrimaryContactOrganizationID;
            this.PrimaryContactOrganizationDisplayName = vProjectDetail.PrimaryContactOrganizationDisplayName;
            this.PrimaryContactPersonID = vProjectDetail.PrimaryContactPersonID;
            this.PrimaryContactPersonFullNameFirstLast = vProjectDetail.PrimaryContactPersonFullNameFirstLast;
            this.PrimaryContactPersonEmail = vProjectDetail.PrimaryContactPersonEmail;
            this.PerformanceMeasureActualCount = vProjectDetail.PerformanceMeasureActualCount;
            this.ProjectImageCount = vProjectDetail.ProjectImageCount;
            this.CanStewardProjectsOrganizationID = vProjectDetail.CanStewardProjectsOrganizationID;
            this.CanStewardProjectsOrganizationDisplayName = vProjectDetail.CanStewardProjectsOrganizationDisplayName;
            this.TaxonomyLeafID = vProjectDetail.TaxonomyLeafID;
            this.TaxonomyLeafDisplayName = vProjectDetail.TaxonomyLeafDisplayName;
            this.FinalStatusReportStatusDescription = vProjectDetail.FinalStatusReportStatusDescription;
            this.ProjectFundingSourceExpenditureCount = vProjectDetail.ProjectFundingSourceExpenditureCount;
            CallAfterConstructor(vProjectDetail);
        }

        partial void CallAfterConstructor(vProjectDetail vProjectDetail);

        public int ProjectID { get; set; }
        public int PrimaryKey { get; set; }
        public int TenantID { get; set; }
        public string ProjectName { get; set; }
        public int? PrimaryContactOrganizationID { get; set; }
        public string PrimaryContactOrganizationDisplayName { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public string PrimaryContactPersonFullNameFirstLast { get; set; }
        public string PrimaryContactPersonEmail { get; set; }
        public int? PerformanceMeasureActualCount { get; set; }
        public int? ProjectImageCount { get; set; }
        public int? CanStewardProjectsOrganizationID { get; set; }
        public string CanStewardProjectsOrganizationDisplayName { get; set; }
        public int TaxonomyLeafID { get; set; }
        public string TaxonomyLeafDisplayName { get; set; }
        public string FinalStatusReportStatusDescription { get; set; }
        public int? ProjectFundingSourceExpenditureCount { get; set; }
    }
}