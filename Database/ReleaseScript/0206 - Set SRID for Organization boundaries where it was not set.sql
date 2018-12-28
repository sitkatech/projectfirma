update dbo.Organization
set OrganizationBoundary.STSrid = 4326
where OrganizationBoundary.STSrid = 0