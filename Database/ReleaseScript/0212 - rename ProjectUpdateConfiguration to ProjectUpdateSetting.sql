exec sp_rename 'dbo.PK_ProjectUpdateConfiguration_ProjectUpdateConfigurationID', 'PK_ProjectUpdateSetting_ProjectUpdateSettingID', 'OBJECT';
exec sp_rename 'dbo.AK_ProjectUpdateConfiguration_Tenant', 'AK_ProjectUpdateSetting_Tenant', 'OBJECT';
exec sp_rename 'dbo.FK_ProjectUpdateConfiguration_Tenant_TenantID', 'FK_ProjectUpdateSetting_Tenant_TenantID', 'OBJECT';
exec sp_rename 'dbo.ProjectUpdateConfiguration.ProjectUpdateConfigurationID', 'ProjectUpdateSettingID', 'COLUMN';
exec sp_rename 'dbo.ProjectUpdateConfiguration', 'ProjectUpdateSetting';