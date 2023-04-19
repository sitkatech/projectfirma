alter table dbo.TenantAttribute add ReportFinancialsAtProjectLevel bit null
go
update dbo.TenantAttribute set ReportFinancialsAtProjectLevel = 1

alter table dbo.TenantAttribute alter column ReportFinancialsAtProjectLevel bit not null

