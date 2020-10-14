--begin tran

alter table dbo.Tenant
add TenantEnabled bit null
GO

update dbo.Tenant
set TenantEnabled = 1
GO

alter table dbo.Tenant
alter column TenantEnabled bit not null
GO

--rollback tran