using System;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyTierHelpers
    {
        public static FieldDefinition GetFieldDefinitionForTaxonomyLevel(TaxonomyLevel taxonomyLevel)
        {
            return GetFieldDefinitionForTaxonomyLevel(taxonomyLevel.ToEnum);
        }

        public static FieldDefinition GetFieldDefinitionForTaxonomyLevel(TaxonomyLevelEnum taxonomyLevelEnum)
        {
            switch (taxonomyLevelEnum)
            {
                case TaxonomyLevelEnum.Leaf:
                    return FieldDefinition.TaxonomyLeaf;
                case TaxonomyLevelEnum.Branch:
                    return FieldDefinition.TaxonomyBranch;
                case TaxonomyLevelEnum.Trunk:
                    return FieldDefinition.TaxonomyTrunk;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
