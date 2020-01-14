--select * from dbo.TenantAttribute

alter table dbo.TenantAttribute
add EnableEvaluations bit null;
go

update dbo.TenantAttribute set EnableEvaluations = 0 where EnableEvaluations is null;

--update dbo.TenantAttribute set EnableEvaluations = 1 where TenantID = 9;

go

alter table dbo.TenantAttribute
alter column EnableEvaluations bit not null;