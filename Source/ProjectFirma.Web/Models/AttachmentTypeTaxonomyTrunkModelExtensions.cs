using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public static class AttachmentTypeTaxonomyTrunkModelExtensions
    {
        public static string GetTaxonomyTrunkNamesAsCommaDelimitedList(this ICollection<AttachmentTypeTaxonomyTrunk> attachmentTypeTaxonomyTrunks)
        {
            List<string> displayNames = attachmentTypeTaxonomyTrunks.Select(x => x.TaxonomyTrunk.TaxonomyTrunkName).ToList();
            return string.Join(", ", displayNames);
        }
    }
}