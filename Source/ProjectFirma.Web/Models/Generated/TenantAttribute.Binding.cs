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
        public TenantAttribute(int tenantAttributeID, string taxonomySystemName, string taxonomyTierOneDisplayNameForProject, string performanceMeasureDisplayName, string classificationDisplayName, string tenantSquareLogoUrl, string tenantBannerLogoUrl, DbGeometry defaultBoundingBox, int numberOfTaxonomyTiersToUse, int minimumYear, string tenantStyleSheetUrl) : this()
        {
            this.TenantAttributeID = tenantAttributeID;
            this.TaxonomySystemName = taxonomySystemName;
            this.TaxonomyTierOneDisplayNameForProject = taxonomyTierOneDisplayNameForProject;
            this.PerformanceMeasureDisplayName = performanceMeasureDisplayName;
            this.ClassificationDisplayName = classificationDisplayName;
            this.TenantSquareLogoUrl = tenantSquareLogoUrl;
            this.TenantBannerLogoUrl = tenantBannerLogoUrl;
            this.DefaultBoundingBox = defaultBoundingBox;
            this.NumberOfTaxonomyTiersToUse = numberOfTaxonomyTiersToUse;
            this.MinimumYear = minimumYear;
            this.TenantStyleSheetUrl = tenantStyleSheetUrl;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TenantAttribute(string taxonomySystemName, string taxonomyTierOneDisplayNameForProject, string performanceMeasureDisplayName, string classificationDisplayName, string tenantSquareLogoUrl, string tenantBannerLogoUrl, DbGeometry defaultBoundingBox, int numberOfTaxonomyTiersToUse, int minimumYear, string tenantStyleSheetUrl) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TenantAttributeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomySystemName = taxonomySystemName;
            this.TaxonomyTierOneDisplayNameForProject = taxonomyTierOneDisplayNameForProject;
            this.PerformanceMeasureDisplayName = performanceMeasureDisplayName;
            this.ClassificationDisplayName = classificationDisplayName;
            this.TenantSquareLogoUrl = tenantSquareLogoUrl;
            this.TenantBannerLogoUrl = tenantBannerLogoUrl;
            this.DefaultBoundingBox = defaultBoundingBox;
            this.NumberOfTaxonomyTiersToUse = numberOfTaxonomyTiersToUse;
            this.MinimumYear = minimumYear;
            this.TenantStyleSheetUrl = tenantStyleSheetUrl;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TenantAttribute CreateNewBlank()
        {
            return new TenantAttribute(default(string), default(string), default(string), default(string), default(string), default(string), default(DbGeometry), default(int), default(int), default(string));
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
        public string TaxonomySystemName { get; set; }
        public string TaxonomyTierOneDisplayNameForProject { get; set; }
        public string PerformanceMeasureDisplayName { get; set; }
        public string ClassificationDisplayName { get; set; }
        public string TenantSquareLogoUrl { get; set; }
        public string TenantBannerLogoUrl { get; set; }
        public DbGeometry DefaultBoundingBox { get; set; }
        public int NumberOfTaxonomyTiersToUse { get; set; }
        public int MinimumYear { get; set; }
        public string TenantStyleSheetUrl { get; set; }
        public int PrimaryKey { get { return TenantAttributeID; } set { TenantAttributeID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int TaxonomySystemName = 100;
            public const int TaxonomyTierOneDisplayNameForProject = 100;
            public const int PerformanceMeasureDisplayName = 100;
            public const int ClassificationDisplayName = 100;
            public const int TenantSquareLogoUrl = 100;
            public const int TenantBannerLogoUrl = 100;
            public const int TenantStyleSheetUrl = 200;
        }
    }
}