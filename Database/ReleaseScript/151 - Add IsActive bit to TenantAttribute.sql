alter table dbo.TenantAttribute add IsActive bit null
GO

update dbo.TenantAttribute
set IsActive = 1

update dbo.TenantAttribute
set IsActive = 0
where TenantID = 9

alter table dbo.TenantAttribute alter column IsActive bit not null
