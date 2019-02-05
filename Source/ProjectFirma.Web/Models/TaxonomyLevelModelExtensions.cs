using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class TaxonomyLevelModelExtensions
    {
        public static FieldDefinition GetFieldDefinition(this TaxonomyLevel taxonomyLevel)
        {
            switch (taxonomyLevel.ToEnum)
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

        public static List<TaxonomyTier> GetTaxonomyTiers(this TaxonomyLevel taxonomyLevel, DatabaseEntities databaseEntities)
        {
            switch (taxonomyLevel.ToEnum)
            {
                case TaxonomyLevelEnum.Leaf:
                    return databaseEntities.TaxonomyLeafs.ToList().Select(x => new TaxonomyTier(x)).ToList();
                case TaxonomyLevelEnum.Branch:
                    return databaseEntities.TaxonomyBranches.ToList().Select(x => new TaxonomyTier(x)).ToList();
                case TaxonomyLevelEnum.Trunk:
                    return databaseEntities.TaxonomyTrunks.ToList().Select(x => new TaxonomyTier(x)).ToList();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}