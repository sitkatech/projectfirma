ALTER TABLE dbo.TenantAttribute	ADD CanManageCustomAttributes bit NULL;
GO

update dbo.TenantAttribute set CanManageCustomAttributes = 0;
-- set to True for Action Agenda Tracker and Peaks to People
update dbo.TenantAttribute set CanManageCustomAttributes = 1 where TenantID = 11 or TenantID = 6;

alter table dbo.TenantAttribute alter column  CanManageCustomAttributes bit not null