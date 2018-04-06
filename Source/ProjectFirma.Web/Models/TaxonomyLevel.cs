namespace ProjectFirma.Web.Models
{
    public partial class TaxonomyLevel
    {
        public abstract FieldDefinition GetFieldDefinition();
    }

    public partial class TaxonomyLevelTrunk
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinition.TaxonomyTrunk;
        }
    }

    public partial class TaxonomyLevelBranch
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinition.TaxonomyBranch;
        }
    }

    public partial class TaxonomyLevelLeaf
    {
        public override FieldDefinition GetFieldDefinition()
        {
            return FieldDefinition.TaxonomyLeaf;
        }
    }
}