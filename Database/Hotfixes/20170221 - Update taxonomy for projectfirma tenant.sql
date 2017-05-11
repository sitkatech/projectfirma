update dbo.TenantAttribute  set
TaxonomyTierOneDisplayName = 'Focus Area',
TaxonomyTierTwoDisplayName = 'Program Area',
TaxonomyTierOneDisplayNameForProject = 'Primary Focus Area',
TaxonomySystemName = 'Project Hierarchy'
where TenantID = 1
