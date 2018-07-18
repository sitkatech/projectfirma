alter table dbo.Tenant add ReportingYearStartDate datetime null, UseFiscalYears bit null
GO

update dbo.Tenant
set ReportingYearStartDate = '1/1/1990', UseFiscalYears = 0


update dbo.Tenant
set ReportingYearStartDate = '7/1/1990', UseFiscalYears = 1
where TenantID = 9

alter table dbo.Tenant alter column ReportingYearStartDate datetime not null
alter table dbo.Tenant alter column UseFiscalYears bit not null




UPDATE dbo.PerformanceMeasureSubcategory SET ChartConfigurationJson = REPLACE(ChartConfigurationJson, '"title": "Date"', '"title": "Reporting Year"')
WHERE TenantID = 9; 


UPDATE dbo.PerformanceMeasureSubcategory SET ChartConfigurationJson = REPLACE(ChartConfigurationJson, '"title":"Date"', '"title": "Reporting Year"')
WHERE TenantID = 9; 

update dbo.FieldDefinitionData
set FieldDefinitionLabel = null
where TenantID = 9 and FieldDefinitionID = 76
