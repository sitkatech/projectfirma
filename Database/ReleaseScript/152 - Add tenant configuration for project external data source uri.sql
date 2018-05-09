alter table dbo.TenantAttribute add ProjectExternalDataSourceEnabled bit null
go
update dbo.TenantAttribute set ProjectExternalDataSourceEnabled = 0
go
alter table dbo.TenantAttribute alter column ProjectExternalDataSourceEnabled bit not null
