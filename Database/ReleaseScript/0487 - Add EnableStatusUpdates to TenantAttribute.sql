alter table dbo.TenantAttribute add EnableStatusUpdates bit null
go
update dbo.TenantAttribute set EnableStatusUpdates = UseProjectTimeline
go
alter table dbo.TenantAttribute alter column EnableStatusUpdates bit not null