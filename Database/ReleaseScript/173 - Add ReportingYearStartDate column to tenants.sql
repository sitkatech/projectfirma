alter table dbo.TenantAttribute add ReportingYearStartDate datetime null, UseFiscalYears bit null
GO

update dbo.TenantAttribute
set ReportingYearStartDate = '1/1/1990', UseFiscalYears = 0


update dbo.TenantAttribute
set ReportingYearStartDate = '7/1/1990', UseFiscalYears = 1
where TenantID = 9

alter table dbo.TenantAttribute alter column ReportingYearStartDate datetime not null
alter table dbo.TenantAttribute alter column UseFiscalYears bit not null




UPDATE dbo.PerformanceMeasureSubcategory SET ChartConfigurationJson = REPLACE(ChartConfigurationJson, '"title": "Date"', '"title": "Fiscal Year"')
WHERE TenantID = 9; 


UPDATE dbo.PerformanceMeasureSubcategory SET ChartConfigurationJson = REPLACE(ChartConfigurationJson, '"title":"Date"', '"title": "Fiscal Year"')
WHERE TenantID = 9; 


UPDATE dbo.PerformanceMeasureSubcategory SET ChartConfigurationJson = REPLACE(ChartConfigurationJson, '"title":"Year"', '"title": "Fiscal Year"')
WHERE TenantID = 9; 