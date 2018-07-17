alter table dbo.TenantAttribute add ReportingYearStartDate datetime null, UseFiscalYears bit null
GO

update dbo.TenantAttribute
set ReportingYearStartDate = '1/1/1990', UseFiscalYears = 0


update dbo.TenantAttribute
set ReportingYearStartDate = '7/1/1990', UseFiscalYears = 1
where TenantID = 9

alter table dbo.TenantAttribute alter column ReportingYearStartDate datetime not null
alter table dbo.TenantAttribute alter column UseFiscalYears bit not null

update dbo.FieldDefinitionData
set FieldDefinitionLabel = 'Fiscal Year'
where TenantID = 9 and FieldDefinitionID = 76