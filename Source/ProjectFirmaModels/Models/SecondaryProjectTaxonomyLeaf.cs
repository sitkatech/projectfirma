namespace ProjectFirmaModels.Models
{
    public partial class SecondaryProjectTaxonomyLeaf : IAuditableEntity
    {
        public string GetAuditDescriptionString() =>
            $"Secondary Project Taxonomy Leaf (Project: {ProjectID}, Taxonomy Leaf: {TaxonomyLeafID}, Tenant: {TenantID})";
    }
}
