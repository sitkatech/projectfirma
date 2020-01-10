using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public static class AttachmentRelationshipTypeTaxonomyTrunkModelExtensions
    {
        public static string GetTaxonomyTrunkNamesAsCommaDelimitedList(this ICollection<AttachmentTypeTaxonomyTrunk> attachmentRelationshipTypeTaxonomyTrunks)
        {
            List<string> displayNames = attachmentRelationshipTypeTaxonomyTrunks.Select(x => x.TaxonomyTrunk.TaxonomyTrunkName).ToList();
            return string.Join(", ", displayNames);
        }
    }
}