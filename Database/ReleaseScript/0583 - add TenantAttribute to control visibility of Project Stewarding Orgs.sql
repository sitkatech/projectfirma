alter table dbo.tenantattribute add ProjectStewardshipVisibilityAdminOnly bit null

go
update dbo.TenantAttribute set ProjectStewardshipVisibilityAdminOnly = 1 where TenantID = 4