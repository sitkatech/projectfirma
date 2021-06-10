alter table dbo.TenantAttribute add TrackAccomplishments bit null
go

update dbo.TenantAttribute set TrackAccomplishments = 1
go

alter table dbo.TenantAttribute alter column TrackAccomplishments bit not null
