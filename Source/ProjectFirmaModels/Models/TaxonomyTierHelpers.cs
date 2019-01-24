using System;

namespace ProjectFirmaModels.Models
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
                    return FieldDefinitionEnum.TaxonomyLeaf;
                case TaxonomyLevelEnum.Branch:
                    return FieldDefinitionEnum.TaxonomyBranch;
                case TaxonomyLevelEnum.Trunk:
                    return FieldDefinitionEnum.TaxonomyTrunk;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
