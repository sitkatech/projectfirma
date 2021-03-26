exec sp_rename 'dbo.Tenant.ReportingYearStartDate', 'FiscalYearStartDate', 'COLUMN';
GO

alter table dbo.ProjectUpdateSetting add DaysBeforeCloseOutDateForReminder int null

update dbo.ProjectUpdateSetting set ProjectUpdateKickOffDate = (select FiscalYearStartDate from dbo.Tenant t where t.TenantID = dbo.ProjectUpdateSetting.TenantID) where ProjectUpdateKickOffDate is null

update dbo.ProjectUpdateSetting set ProjectUpdateCloseOutDate = '1990-12-31' where TenantID != 3 and ProjectUpdateCloseOutDate is null
update dbo.ProjectUpdateSetting set ProjectUpdateCloseOutDate = '2020-06-30' where TenantID = 3


-- kick-off date
update dbo.FieldDefinitionDefault set DefaultDefinition = 'The date (month and day) that the currently configured reporting period starts. If enabled, Kick-off email reminders will be sent on this date.' where FieldDefinitionID = 261
-- close-out date
update dbo.FieldDefinitionDefault set DefaultDefinition = 'The date (month and day) that the currently configured reporting period ends. If enabled, Close-out emails will be sent relative to this date.' where FieldDefinitionID = 263