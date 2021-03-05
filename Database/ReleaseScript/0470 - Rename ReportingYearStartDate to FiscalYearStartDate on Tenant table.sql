exec sp_rename 'dbo.Tenant.ReportingYearStartDate', 'FiscalYearStartDate', 'COLUMN';
GO

alter table dbo.ProjectUpdateSetting add DaysBeforeCloseOutDateForReminder int null

update dbo.ProjectUpdateSetting set ProjectUpdateKickOffDate = (select FiscalYearStartDate from dbo.Tenant t where t.TenantID = dbo.ProjectUpdateSetting.TenantID) where ProjectUpdateKickOffDate is null

update dbo.ProjectUpdateSetting set ProjectUpdateCloseOutDate = '1990-12-31' where TenantID != 3 and ProjectUpdateCloseOutDate is null
update dbo.ProjectUpdateSetting set ProjectUpdateCloseOutDate = '2020-06-30' where TenantID = 3

