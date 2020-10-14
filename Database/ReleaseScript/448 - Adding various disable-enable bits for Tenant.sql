--begin tran

alter table dbo.Tenant
add ShowInTenantDropdown bit null
GO

update dbo.Tenant
set ShowInTenantDropdown = 1
GO

alter table dbo.Tenant
alter column ShowInTenantDropdown bit not null
GO

-- This will also be done permanently in the lookup table, this is just to show intent
update dbo.Tenant
set ShowInTenantDropdown = 0 
where TenantID = 12

--rollback tran