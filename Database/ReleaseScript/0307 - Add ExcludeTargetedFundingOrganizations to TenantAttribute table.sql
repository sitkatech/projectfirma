ALTER TABLE dbo.TenantAttribute	ADD ExcludeTargetedFundingOrganizations bit NULL;
GO

-- set to True for all existing tenants
update dbo.TenantAttribute set ExcludeTargetedFundingOrganizations = 1;

alter table dbo.TenantAttribute alter column  ExcludeTargetedFundingOrganizations bit not null