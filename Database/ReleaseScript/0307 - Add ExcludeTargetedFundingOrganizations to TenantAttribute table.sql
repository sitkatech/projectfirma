ALTER TABLE dbo.TenantAttribute	ADD ExcludeTargetedFundingOrganizations bit NULL;
GO

-- set to False for all existing tenants
update dbo.TenantAttribute set ExcludeTargetedFundingOrganizations = 0;
-- set to True for Action Agenda
update dbo.TenantAttribute set ExcludeTargetedFundingOrganizations = 1 where TenantID = 11;

alter table dbo.TenantAttribute alter column  ExcludeTargetedFundingOrganizations bit not null