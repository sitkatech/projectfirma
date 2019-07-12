ALTER TABLE dbo.TenantAttribute	ADD CanManageCustomAttributes bit NULL;
GO

update dbo.TenantAttribute set CanManageCustomAttributes = 0;
-- set to True for Action Agenda Tracker
update dbo.TenantAttribute set CanManageCustomAttributes = 1 where TenantID = 11;

alter table dbo.TenantAttribute alter column  CanManageCustomAttributes bit not null
