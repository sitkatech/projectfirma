using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
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
            return FieldDefinition.TaxonomyTrunk;
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
            return FieldDefinition.TaxonomyBranch;
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
            return FieldDefinition.TaxonomyLeaf;
        }

        public override List<ITaxonomyTier> GetTaxonomyTiers(DatabaseEntities databaseEntities)
        {
            return new List<ITaxonomyTier>(databaseEntities.TaxonomyLeafs.ToList());
        }
    }
}