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

        public static Tuple<TaxonomyLevelEnum, int> GetTaxonomyLevelAndIDFromComboTreeNodeKey(string compoundKey)
        {
            var keyParts = compoundKey.Split('-');
            var taxonomyLevelID = int.Parse(keyParts[0]);
            var taxonomyID = int.Parse(keyParts[1]);
            if (taxonomyLevelID == TaxonomyLevel.Trunk.TaxonomyLevelID)
            {
                return new Tuple<TaxonomyLevelEnum, int>(TaxonomyLevelEnum.Trunk, taxonomyID);
            }
            if (taxonomyLevelID == TaxonomyLevel.Branch.TaxonomyLevelID)
            {
                return new Tuple<TaxonomyLevelEnum, int>(TaxonomyLevelEnum.Branch, taxonomyID);
            }
            return new Tuple<TaxonomyLevelEnum, int>(TaxonomyLevelEnum.Leaf, taxonomyID);
        }

        public static string GetComboTreeNodeKeyFromTaxonomyLevelAndID(TaxonomyLevel taxonomyLevel, int taxonomyTierID)
        {
            return $"{taxonomyLevel.TaxonomyLevelID}-{taxonomyTierID}";
        }
    }
}
