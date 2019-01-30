alter table dbo.Tenant add ArePerformanceMeasuresExternallySourced bit null
GO

update dbo.Tenant
set ArePerformanceMeasuresExternallySourced = 0


update dbo.Tenant
set ArePerformanceMeasuresExternallySourced = 1
where TenantID = 11

alter table dbo.Tenant alter column ArePerformanceMeasuresExternallySourced bit not null