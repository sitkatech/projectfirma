using System.Web;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierTwoSectorExpenditure
    {
        public readonly Sector Sector;
        public readonly HtmlString TaxonomyTierTwoName;
        public readonly HtmlString TaxonomyTierThreeName;
        public readonly decimal ExpenditureAmount;

        public TaxonomyTierTwoSectorExpenditure(Sector sector, TaxonomyTierTwo taxonomyTierTwo, decimal expenditureAmount) : this(sector, taxonomyTierTwo.GetDisplayNameAsUrl(), taxonomyTierTwo.TaxonomyTierThree.GetDisplayNameAsUrl(), expenditureAmount)
        {
        }

        public TaxonomyTierTwoSectorExpenditure(Sector sector, string taxonomyTierTwoName, string taxonomyTierThreeName, decimal expenditureAmount)
            : this(sector, new HtmlString(taxonomyTierTwoName), new HtmlString(taxonomyTierThreeName), expenditureAmount)
        {
        }

        private TaxonomyTierTwoSectorExpenditure(Sector sector, HtmlString taxonomyTierTwoName, HtmlString taxonomyTierThreeName, decimal expenditureAmount)
        {
            Sector = sector;
            TaxonomyTierTwoName = taxonomyTierTwoName;
            TaxonomyTierThreeName = taxonomyTierThreeName;
            ExpenditureAmount = expenditureAmount;
        }
    }
}