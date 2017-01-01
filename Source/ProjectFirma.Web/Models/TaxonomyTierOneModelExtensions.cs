using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyTierOneModelExtensions
    {
        public static HtmlString GetDisplayNameAsUrl(this TaxonomyTierOne taxonomyTierOne)
        {
            return UrlTemplate.MakeHrefString(taxonomyTierOne.GetSummaryUrl(), taxonomyTierOne.DisplayName);
        }

        public static string GetSummaryUrl(this TaxonomyTierOne taxonomyTierOne)
        {
            return SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(x => x.Detail(taxonomyTierOne.TaxonomyTierOneID));
        }

        public static string GetDeleteUrl(this TaxonomyTierOne taxonomyTierOne)
        {
            return SitkaRoute<TaxonomyTierOneController>.BuildUrlFromExpression(c => c.DeleteTaxonomyTierOne(taxonomyTierOne.TaxonomyTierOneID));
        }

        public static IEnumerable<SelectListItem> ToGroupedSelectList(this List<TaxonomyTierOne> taxonomyTierOnes)
        {
            var selectListItems = new List<SelectListItem>();
            var groups = new Dictionary<string, SelectListGroup>();
            foreach (var taxonomyTierThreeGrouping in taxonomyTierOnes.GroupBy(x => x.TaxonomyTierTwo.TaxonomyTierThree).OrderBy(x => x.Key.DisplayName))
            {
                var taxonomyTierThree = taxonomyTierThreeGrouping.Key;
                var topLevelGroup = new SelectListGroup() {Name = taxonomyTierThree.DisplayName};
                groups.Add(taxonomyTierThree.DisplayName, topLevelGroup);
                
                foreach (var taxonomyTierTwoGrouping in taxonomyTierThreeGrouping.GroupBy(x => x.TaxonomyTierTwo).OrderBy(x => x.Key.DisplayName))
                {
                    var taxonomyTierTwo = taxonomyTierTwoGrouping.Key;
                    var selectListGroup = new SelectListGroup() {Name = taxonomyTierTwo.DisplayName};
                    groups.Add(taxonomyTierTwo.DisplayName, selectListGroup);

                    selectListItems.Add(new SelectListItem(){Text = taxonomyTierTwo.DisplayName, Group = topLevelGroup, Disabled = true});

                    foreach (var taxonomyTierOne in taxonomyTierTwoGrouping.OrderBy(x => x.DisplayName))
                    {
                        selectListItems.Add(new SelectListItem() { Value = taxonomyTierOne.TaxonomyTierOneID.ToString(), Text = taxonomyTierOne.DisplayName, Group = topLevelGroup });
                    }
                }

            }
            return selectListItems;
        }
    }
}