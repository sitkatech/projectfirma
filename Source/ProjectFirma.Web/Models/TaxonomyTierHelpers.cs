using System;
using ProjectFirmaModels.Models;

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
                    return FieldDefinitionEnum.TaxonomyLeaf.ToType();
                case TaxonomyLevelEnum.Branch:
                    return FieldDefinitionEnum.TaxonomyBranch.ToType();
                case TaxonomyLevelEnum.Trunk:
                    return FieldDefinitionEnum.TaxonomyTrunk.ToType();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
