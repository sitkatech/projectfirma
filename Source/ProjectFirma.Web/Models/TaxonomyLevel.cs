using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyLevel
    {
        public abstract FieldDefinition GetFieldDefinition();
        public abstract List<ITaxonomyTier> GetTaxonomyTiers();
    }

    public partial class TaxonomyLevelTrunk
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinition.TaxonomyTrunk;
        }

        public override List<ITaxonomyTier> GetTaxonomyTiers()
        {
            return new List<ITaxonomyTier>(HttpRequestStorage.DatabaseEntities.TaxonomyTrunks.ToList());
        }
    }

    public partial class TaxonomyLevelBranch
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinition.TaxonomyBranch;
        }

        public override List<ITaxonomyTier> GetTaxonomyTiers()
        {
            return new List<ITaxonomyTier>(HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList());
        }
    }

    public partial class TaxonomyLevelLeaf
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinition.TaxonomyLeaf;
        }

        public override List<ITaxonomyTier> GetTaxonomyTiers()
        {
            return new List<ITaxonomyTier>(HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToList());
        }
    }
}