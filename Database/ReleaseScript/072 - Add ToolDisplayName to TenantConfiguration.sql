alter table dbo.TenantAttribute add ToolDisplayName varchar(100) null
go

update dbo.TenantAttribute
set ToolDisplayName = 'John Day Basin Partnership (DEMO) Project Tracker'
where TenantID = 1

update dbo.TenantAttribute
set ToolDisplayName = 'Clackamas Partnership Project Tracker'
where TenantID = 2

update dbo.TenantAttribute
set ToolDisplayName = 'RCD Project Tracker'
where TenantID = 3


alter table dbo.TenantAttribute alter column ToolDisplayName varchar(100) not null