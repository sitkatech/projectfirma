using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    public static class MultiTenantHelpers
    {
        private static readonly EnglishPluralizationService PluralizationService = new EnglishPluralizationService();

        private static TenantAttribute GetCurrentTenantAttributes()
        {
            return HttpRequestStorage.DatabaseEntities.TenantAttributes.Single(x => x.TenantID == HttpRequestStorage.Tenant.TenantID);
        }

        public static string GetTaxonomySystemName()
        {
            return GetCurrentTenantAttributes().TaxonomySystemName;
        }

        public static string GetTaxonomyTierThreeDisplayName()
        {
            return GetCurrentTenantAttributes().TaxonomyTierThreeDisplayName;
        }

        public static string GetTaxonomyTierThreeDisplayNamePluralized()
        {
            return PluralizationService.Pluralize(GetTaxonomyTierThreeDisplayName());
        }

        public static string GetTaxonomyTierTwoDisplayName()
        {
            return GetCurrentTenantAttributes().TaxonomyTierTwoDisplayName;
        }

        public static string GetTaxonomyTierTwoDisplayNamePluralized()
        {
            return PluralizationService.Pluralize(GetTaxonomyTierTwoDisplayName());
        }

        public static string GetTaxonomyTierOneDisplayName()
        {
            return GetCurrentTenantAttributes().TaxonomyTierOneDisplayName;
        }

        public static string GetTaxonomyTierOneDisplayNamePluralized()
        {
            return PluralizationService.Pluralize(GetTaxonomyTierOneDisplayName());
        }

        public static string GetTaxonomyTierOneDisplayNameForProject()
        {
            return GetCurrentTenantAttributes().TaxonomyTierOneDisplayNameForProject;
        }

        public static string GetPerformanceMeasureName()
        {
            return GetCurrentTenantAttributes().PerformanceMeasureDisplayName;
        }

        public static string GetPerformanceMeasureNamePluralized()
        {
            return PluralizationService.Pluralize(GetPerformanceMeasureName());
        }

        public static string GetClassificationDisplayName()
        {
            return GetCurrentTenantAttributes().ClassificationDisplayName;
        }

        public static string GetClassificationDisplayNamePluralized()
        {
            return PluralizationService.Pluralize(GetClassificationDisplayName());
        }

        public static string GetTenantDisplayName()
        {
            return HttpRequestStorage.Tenant.TenantName;
        }

        public static string GetTenantSquareLogoUrl()
        {
            return GetCurrentTenantAttributes().TenantSquareLogoUrl;
        }

        public static string GetTenantBannerLogoUrl()
        {
            return GetCurrentTenantAttributes().TenantBannerLogoUrl;
        }

        public static Point GetDefaultSouthWestPoint()
        {
            return new Point(44.821389, -122.608611);
        }

        public static Point GetDefaultNorthEastPoint()
        {
            return new Point(45.5725, -121.796389);
        }

        public static DbGeometry GetDefaultBoundingBox()
        {
            return GetCurrentTenantAttributes().DefaultBoundingBox;
        }
    }
}