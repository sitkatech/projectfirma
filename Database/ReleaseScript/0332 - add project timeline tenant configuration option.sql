alter table dbo.TenantAttribute
ADD UseProjectTimeline bit null;

go

update dbo.TenantAttribute 
set UseProjectTimeline = 1 
where UseProjectTimeline is null;

go

alter table dbo.TenantAttribute
alter COLUMN UseProjectTimeline bit not null;