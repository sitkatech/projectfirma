using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    public static class MultiTenantHelpers
    {
        public static string GetTaxonomySystemName()
        {
            return "Limiting Factors";
        }
        public static string GetTaxonomyTierThreeDisplayName()
        {
            return "Ecological Concern";
        }

        public static string GetTaxonomyTierThreeDisplayNamePluralized()
        {
            return "Ecological Concerns";
        }
        
        public static string GetTaxonomyTierTwoDisplayName()
        {
            return "Ecological Sub-Concern";
        }

        public static string GetTaxonomyTierTwoDisplayNamePluralized()
        {
            return "Ecological Sub-Concerns";
        }

        public static string GetTaxonomyTierOneDisplayName()
        {
            return "Limiting Factor";
        }

        public static string GetTaxonomyTierOneDisplayNamePluralized()
        {
            return "Limiting Factors";
        }

        public static string GetPerformanceMeasureName()
        {
            return "Performance Measure";
        }

        public static string GetPerformanceMeasureNamePluralized()
        {
            return "Performance Measures";
        }

        public static string GetClassificationDisplayName()
        {
            return "Focal Species";
        }

        public static string GetClassificationDisplayNamePluralized()
        {
            return "Focal Species";
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