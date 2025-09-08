
alter table dbo.TenantAttribute add DisableProjectStewardOrganizationIndexPage bit null
go

update dbo.TenantAttribute set DisableProjectStewardOrganizationIndexPage = 0 where TenantID = 3
update dbo.TenantAttribute set DisableProjectStewardOrganizationIndexPage = 1 where TenantID = 4