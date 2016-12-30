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
            return "Taxonomy Tier Three";
        }

        public static string GetTaxonomyTierTwoDisplayName()
        {
            return "Taxonomy Tier Two";
        }

        public static string GetTaxonomyTierOneDisplayName()
        {
            return "Taxonomy Tier One";
        }

        public static string GetTaxonomyTierThreeDisplayNamePluralized()
        {
            return "Taxonomy Tier Threes";
        }

        public static string GetTaxonomyTierTwoDisplayNamePluralized()
        {
            return "Taxonomy Tier Twos";
        }

        public static string GetTaxonomyTierOneDisplayNamePluralized()
        {
            return "Taxonomy Tier Ones";
        }

        public static string GetClassificationDisplayName()
        {
            return "Classification";
        }

        public static string GetClassificationDisplayNamePluralized()
        {
            return "Classifications";
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