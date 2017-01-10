using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    public static class MultiTenantHelpers
    {
        public static string GetTaxonomySystemName()
        {
            return "Project Taxonomy";
        }
        public static string GetTaxonomyTierThreeDisplayName()
        {
            return "Focused Investment Partnership";
        }

        public static string GetTaxonomyTierThreeDisplayNamePluralized()
        {
            return "Focused Investment Partnerships";
        }
        
        public static string GetTaxonomyTierTwoDisplayName()
        {
            return "HUC 5 Watershed";
        }

        public static string GetTaxonomyTierTwoDisplayNamePluralized()
        {
            return "HUC 5 Watersheds";
        }

        public static string GetTaxonomyTierOneDisplayName()
        {
            return "HUC 6 Watershed";
        }

        public static string GetTaxonomyTierOneDisplayNamePluralized()
        {
            return "HUC 6 Watersheds";
        }

        public static string GetPerformanceMeasureName()
        {
            return "Limiting Factor";
        }

        public static string GetPerformanceMeasureNamePluralized()
        {
            return "Limiting Factors";
        }

        public static string GetClassificationDisplayName()
        {
            return "Focal Species";
        }

        public static string GetClassificationDisplayNamePluralized()
        {
            return "Listed Species";
        }

        public static string GetTenantDisplayName()
        {
            return "Clackamas Partnership";
        }

        public static string GetTenantSquareLogoUrl()
        {
            return "/Content/img/ProjectFirma_Logo_Square.png";
        }

        public static string GetTenantBannerLogoUrl()
        {
            return "/Content/img/ProjectFirma_Logo_2016_FNL.width-600.png";
        }

        public static Point GetDefaultSouthWestPoint()
        {
            return new Point(44.821389, -122.608611);
        }

        public static Point GetDefaultNorthEastPoint()
        {
            return new Point(45.3725, -121.796389);
        }
    }
}