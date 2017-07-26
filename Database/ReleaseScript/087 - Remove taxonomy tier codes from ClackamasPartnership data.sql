update dbo.TaxonomyTierThree
set TaxonomyTierThreeCode = null
where TenantID = 2

update dbo.TaxonomyTierTwo
set TaxonomyTierTwoCode = null
where TenantID = 2

update dbo.TaxonomyTierOne
set TaxonomyTierOneCode = null
where TenantID = 2