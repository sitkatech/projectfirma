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
        public TenantAttribute(int tenantAttributeID, DbGeometry defaultBoundingBox, int numberOfTaxonomyTiersToUse, int minimumYear, int? primaryContactPersonID, int? tenantSquareLogoFileResourceID, int? tenantBannerLogoFileResourceID, int? tenantStyleSheetFileResourceID, string tenantDisplayName, string toolDisplayName, string recaptchaPublicKey, string recaptchaPrivateKey, string mapServiceUrl, string watershedLayerName, bool includeProposedProjectsOnMap) : this()
        {
            this.TenantAttributeID = tenantAttributeID;
            this.DefaultBoundingBox = defaultBoundingBox;
            this.NumberOfTaxonomyTiersToUse = numberOfTaxonomyTiersToUse;
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
            this.IncludeProposedProjectsOnMap = includeProposedProjectsOnMap;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TenantAttribute(DbGeometry defaultBoundingBox, int numberOfTaxonomyTiersToUse, int minimumYear, string tenantDisplayName, string toolDisplayName, bool includeProposedProjectsOnMap) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TenantAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.DefaultBoundingBox = defaultBoundingBox;
            this.NumberOfTaxonomyTiersToUse = numberOfTaxonomyTiersToUse;
            this.MinimumYear = minimumYear;
            this.TenantDisplayName = tenantDisplayName;
            this.ToolDisplayName = toolDisplayName;
            this.IncludeProposedProjectsOnMap = includeProposedProjectsOnMap;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TenantAttribute CreateNewBlank()
        {
            return new TenantAttribute(default(DbGeometry), default(int), default(int), default(string), default(string), default(bool));
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

        [Key]
        public int TenantAttributeID { get; set; }
        public int TenantID { get; private set; }
        public DbGeometry DefaultBoundingBox { get; set; }
        public int NumberOfTaxonomyTiersToUse { get; set; }
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
        public bool IncludeProposedProjectsOnMap { get; set; }
        public int PrimaryKey { get { return TenantAttributeID; } set { TenantAttributeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual FileResource TenantBannerLogoFileResource { get; set; }
        public virtual FileResource TenantSquareLogoFileResource { get; set; }
        public virtual FileResource TenantStyleSheetFileResource { get; set; }

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