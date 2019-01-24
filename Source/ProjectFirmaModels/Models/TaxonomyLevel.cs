using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class TaxonomyLevel
    {
        public abstract FieldDefinition GetFieldDefinition();
        public abstract List<ITaxonomyTier> GetTaxonomyTiers(DatabaseEntities databaseEntities);
    }

    public partial class TaxonomyLevelTrunk
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinitionEnum.TaxonomyTrunk;
        }

        public override List<ITaxonomyTier> GetTaxonomyTiers(DatabaseEntities databaseEntities)
        {
            return new List<ITaxonomyTier>(databaseEntities.TaxonomyTrunks.ToList());
        }
    }

    public partial class TaxonomyLevelBranch
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinitionEnum.TaxonomyBranch;
        }

        public override List<ITaxonomyTier> GetTaxonomyTiers(DatabaseEntities databaseEntities)
        {
            return new List<ITaxonomyTier>(databaseEntities.TaxonomyBranches.ToList());
        }
    }

    public partial class TaxonomyLevelLeaf
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinitionEnum.TaxonomyLeaf;
        }

        public override List<ITaxonomyTier> GetTaxonomyTiers(DatabaseEntities databaseEntities)
        {
            return new List<ITaxonomyTier>(databaseEntities.TaxonomyLeafs.ToList());
        }
    }
}