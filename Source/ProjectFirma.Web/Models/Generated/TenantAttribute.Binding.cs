//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TenantAttribute]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [Table("[dbo].[TenantAttribute]")]
    public partial class TenantAttribute : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TenantAttribute()
        {

            this.TenantID = HttpRequestStorage.Tenant.TenantID;
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TenantAttribute(int tenantAttributeID, DbGeometry defaultBoundingBox, int minimumYear, int? primaryContactPersonID, int? tenantSquareLogoFileResourceID, int? tenantBannerLogoFileResourceID, int? tenantStyleSheetFileResourceID, string tenantDisplayName, string toolDisplayName, string recaptchaPublicKey, string recaptchaPrivateKey, string mapServiceUrl, string watershedLayerName, bool showProposalsToThePublic, int taxonomyLevelID, int associatePerfomanceMeasureTaxonomyLevelID, bool isActive, bool projectExternalDataSourceEnabled, int accomplishmentsDashboardFundingDisplayTypeID, string accomplishmentsDashboardAccomplishmentsButtonText, string accomplishmentsDashboardExpendituresButtonText, string accomplishmentsDashboardOrganizationsButtonText, bool accomplishmentsDashboardIncludeReportingOrganizationType) : this()
        {
            this.TenantAttributeID = tenantAttributeID;
            this.DefaultBoundingBox = defaultBoundingBox;
            this.MinimumYear = minimumYear;
            this.PrimaryContactPersonID = primaryContactPersonID;
            this.TenantSquareLogoFileResourceID = tenantSquareLogoFileResourceID;
            this.TenantBannerLogoFileResourceID = tenantBannerLogoFileResourceID;
            this.TenantStyleSheetFileResourceID = tenantStyleSheetFileResourceID;
            this.TenantDisplayName = tenantDisplayName;
            this.ToolDisplayName = toolDisplayName;
            this.RecaptchaPublicKey = recaptchaPublicKey;
            this.RecaptchaPrivateKey = recaptchaPrivateKey;
            this.MapServiceUrl = mapServiceUrl;
            this.WatershedLayerName = watershedLayerName;
            this.ShowProposalsToThePublic = showProposalsToThePublic;
            this.TaxonomyLevelID = taxonomyLevelID;
            this.AssociatePerfomanceMeasureTaxonomyLevelID = associatePerfomanceMeasureTaxonomyLevelID;
            this.IsActive = isActive;
            this.ProjectExternalDataSourceEnabled = projectExternalDataSourceEnabled;
            this.AccomplishmentsDashboardFundingDisplayTypeID = accomplishmentsDashboardFundingDisplayTypeID;
            this.AccomplishmentsDashboardAccomplishmentsButtonText = accomplishmentsDashboardAccomplishmentsButtonText;
            this.AccomplishmentsDashboardExpendituresButtonText = accomplishmentsDashboardExpendituresButtonText;
            this.AccomplishmentsDashboardOrganizationsButtonText = accomplishmentsDashboardOrganizationsButtonText;
            this.AccomplishmentsDashboardIncludeReportingOrganizationType = accomplishmentsDashboardIncludeReportingOrganizationType;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TenantAttribute(DbGeometry defaultBoundingBox, int minimumYear, string tenantDisplayName, string toolDisplayName, bool showProposalsToThePublic, int taxonomyLevelID, int associatePerfomanceMeasureTaxonomyLevelID, bool isActive, bool projectExternalDataSourceEnabled, int accomplishmentsDashboardFundingDisplayTypeID, bool accomplishmentsDashboardIncludeReportingOrganizationType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TenantAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.DefaultBoundingBox = defaultBoundingBox;
            this.MinimumYear = minimumYear;
            this.TenantDisplayName = tenantDisplayName;
            this.ToolDisplayName = toolDisplayName;
            this.ShowProposalsToThePublic = showProposalsToThePublic;
            this.TaxonomyLevelID = taxonomyLevelID;
            this.AssociatePerfomanceMeasureTaxonomyLevelID = associatePerfomanceMeasureTaxonomyLevelID;
            this.IsActive = isActive;
            this.ProjectExternalDataSourceEnabled = projectExternalDataSourceEnabled;
            this.AccomplishmentsDashboardFundingDisplayTypeID = accomplishmentsDashboardFundingDisplayTypeID;
            this.AccomplishmentsDashboardIncludeReportingOrganizationType = accomplishmentsDashboardIncludeReportingOrganizationType;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TenantAttribute(DbGeometry defaultBoundingBox, int minimumYear, string tenantDisplayName, string toolDisplayName, bool showProposalsToThePublic, TaxonomyLevel taxonomyLevel, TaxonomyLevel associatePerfomanceMeasureTaxonomyLevel, bool isActive, bool projectExternalDataSourceEnabled, AccomplishmentsDashboardFundingDisplayType accomplishmentsDashboardFundingDisplayType, bool accomplishmentsDashboardIncludeReportingOrganizationType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TenantAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.DefaultBoundingBox = defaultBoundingBox;
            this.MinimumYear = minimumYear;
            this.TenantDisplayName = tenantDisplayName;
            this.ToolDisplayName = toolDisplayName;
            this.ShowProposalsToThePublic = showProposalsToThePublic;
            this.TaxonomyLevelID = taxonomyLevel.TaxonomyLevelID;
            this.AssociatePerfomanceMeasureTaxonomyLevelID = associatePerfomanceMeasureTaxonomyLevel.TaxonomyLevelID;
            this.IsActive = isActive;
            this.ProjectExternalDataSourceEnabled = projectExternalDataSourceEnabled;
            this.AccomplishmentsDashboardFundingDisplayTypeID = accomplishmentsDashboardFundingDisplayType.AccomplishmentsDashboardFundingDisplayTypeID;
            this.AccomplishmentsDashboardIncludeReportingOrganizationType = accomplishmentsDashboardIncludeReportingOrganizationType;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TenantAttribute CreateNewBlank(TaxonomyLevel taxonomyLevel, TaxonomyLevel associatePerfomanceMeasureTaxonomyLevel, AccomplishmentsDashboardFundingDisplayType accomplishmentsDashboardFundingDisplayType)
        {
            return new TenantAttribute(default(DbGeometry), default(int), default(string), default(string), default(bool), taxonomyLevel, associatePerfomanceMeasureTaxonomyLevel, default(bool), default(bool), accomplishmentsDashboardFundingDisplayType, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TenantAttribute).Name};


        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteFull()
        {
            HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Remove(this);                
        }

        [Key]
        public int TenantAttributeID { get; set; }
        public int TenantID { get; private set; }
        public DbGeometry DefaultBoundingBox { get; set; }
        public int MinimumYear { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public int? TenantSquareLogoFileResourceID { get; set; }
        public int? TenantBannerLogoFileResourceID { get; set; }
        public int? TenantStyleSheetFileResourceID { get; set; }
        public string TenantDisplayName { get; set; }
        public string ToolDisplayName { get; set; }
        public string RecaptchaPublicKey { get; set; }
        public string RecaptchaPrivateKey { get; set; }
        public string MapServiceUrl { get; set; }
        public string WatershedLayerName { get; set; }
        public bool ShowProposalsToThePublic { get; set; }
        public int TaxonomyLevelID { get; set; }
        public int AssociatePerfomanceMeasureTaxonomyLevelID { get; set; }
        public bool IsActive { get; set; }
        public bool ProjectExternalDataSourceEnabled { get; set; }
        public int AccomplishmentsDashboardFundingDisplayTypeID { get; set; }
        public string AccomplishmentsDashboardAccomplishmentsButtonText { get; set; }
        [NotMapped]
        public HtmlString AccomplishmentsDashboardAccomplishmentsButtonTextHtmlString
        { 
            get { return AccomplishmentsDashboardAccomplishmentsButtonText == null ? null : new HtmlString(AccomplishmentsDashboardAccomplishmentsButtonText); }
            set { AccomplishmentsDashboardAccomplishmentsButtonText = value?.ToString(); }
        }
        public string AccomplishmentsDashboardExpendituresButtonText { get; set; }
        [NotMapped]
        public HtmlString AccomplishmentsDashboardExpendituresButtonTextHtmlString
        { 
            get { return AccomplishmentsDashboardExpendituresButtonText == null ? null : new HtmlString(AccomplishmentsDashboardExpendituresButtonText); }
            set { AccomplishmentsDashboardExpendituresButtonText = value?.ToString(); }
        }
        public string AccomplishmentsDashboardOrganizationsButtonText { get; set; }
        [NotMapped]
        public HtmlString AccomplishmentsDashboardOrganizationsButtonTextHtmlString
        { 
            get { return AccomplishmentsDashboardOrganizationsButtonText == null ? null : new HtmlString(AccomplishmentsDashboardOrganizationsButtonText); }
            set { AccomplishmentsDashboardOrganizationsButtonText = value?.ToString(); }
        }
        public bool AccomplishmentsDashboardIncludeReportingOrganizationType { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TenantAttributeID; } set { TenantAttributeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual FileResource TenantBannerLogoFileResource { get; set; }
        public virtual FileResource TenantSquareLogoFileResource { get; set; }
        public virtual FileResource TenantStyleSheetFileResource { get; set; }
        public TaxonomyLevel AssociatePerfomanceMeasureTaxonomyLevel { get { return TaxonomyLevel.AllLookupDictionary[AssociatePerfomanceMeasureTaxonomyLevelID]; } }
        public TaxonomyLevel TaxonomyLevel { get { return TaxonomyLevel.AllLookupDictionary[TaxonomyLevelID]; } }
        public AccomplishmentsDashboardFundingDisplayType AccomplishmentsDashboardFundingDisplayType { get { return AccomplishmentsDashboardFundingDisplayType.AllLookupDictionary[AccomplishmentsDashboardFundingDisplayTypeID]; } }

        public static class FieldLengths
        {
            public const int TenantDisplayName = 100;
            public const int ToolDisplayName = 100;
            public const int RecaptchaPublicKey = 100;
            public const int RecaptchaPrivateKey = 100;
            public const int MapServiceUrl = 255;
            public const int WatershedLayerName = 255;
        }
    }
}