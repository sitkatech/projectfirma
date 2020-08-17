
CREATE TABLE [dbo].[PersonSettingGridTable](
	[PersonSettingGridTableID] [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] not null,
	[GridName] [varchar](256) NOT NULL,
    
 CONSTRAINT [PK_PersonSettingGridTable_PersonSettingGridTableID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridTableID] ASC
)
)

go


ALTER TABLE [dbo].[PersonSettingGridTable]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridTable_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[PersonSettingGridTable] CHECK CONSTRAINT [FK_PersonSettingGridTable_Tenant_TenantID]
GO




CREATE TABLE [dbo].[PersonSettingGridColumn](
	[PersonSettingGridColumnID] [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] not null,
	[PersonSettingGridTableID] [int] NOT NULL,
	[ColumnName] [varchar](256) NOT NULL,
    [SortOrder] [int] not null,
 CONSTRAINT [PK_PersonSettingGridColumn_PersonSettingGridColumnID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridColumnID] ASC
)
)
GO

ALTER TABLE [dbo].[PersonSettingGridColumn]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumn_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[PersonSettingGridColumn] CHECK CONSTRAINT [FK_PersonSettingGridColumn_Tenant_TenantID]
GO




ALTER TABLE [dbo].[PersonSettingGridColumn]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumn_PersonSettingGridTable_PersonSettingGridTableID] FOREIGN KEY([PersonSettingGridTableID])
REFERENCES [dbo].[PersonSettingGridTable] ([PersonSettingGridTableID])
GO

ALTER TABLE [dbo].[PersonSettingGridColumn] CHECK CONSTRAINT [FK_PersonSettingGridColumn_PersonSettingGridTable_PersonSettingGridTableID]
GO

-- GRID COLUMN SETTING 

CREATE TABLE [dbo].[PersonSettingGridColumnSetting](
	[PersonSettingGridColumnSettingID] [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] not null,
	[PersonID] [int] NOT NULL,
    [PersonSettingGridColumnID] [int] not null
 CONSTRAINT [PK_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridColumnSettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PersonSettingGridColumnSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSetting_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[PersonSettingGridColumnSetting] CHECK CONSTRAINT [FK_PersonSettingGridColumnSetting_Tenant_TenantID]
GO


ALTER TABLE [dbo].[PersonSettingGridColumnSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSetting_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[PersonSettingGridColumnSetting] CHECK CONSTRAINT [FK_PersonSettingGridColumnSetting_Person_PersonID]
GO

ALTER TABLE [dbo].[PersonSettingGridColumnSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSetting_PersonSettingGridColumn_PersonSettingGridColumnID] FOREIGN KEY([PersonSettingGridColumnID])
REFERENCES [dbo].[PersonSettingGridColumn] ([PersonSettingGridColumnID])
GO

ALTER TABLE [dbo].[PersonSettingGridColumnSetting] CHECK CONSTRAINT [FK_PersonSettingGridColumnSetting_PersonSettingGridColumn_PersonSettingGridColumnID]
GO



CREATE TABLE [dbo].[PersonSettingGridColumnSettingFilter](
	[PersonSettingGridColumnSettingFilterID] [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] not null,
	[PersonSettingGridColumnSettingID] [int] NOT NULL,
	[FilterText] [varchar](256) NOT NULL,
 CONSTRAINT [PK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSettingFilterID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridColumnSettingFilterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter] CHECK CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_Tenant_TenantID]
GO



ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID] FOREIGN KEY([PersonSettingGridColumnSettingID])
REFERENCES [dbo].[PersonSettingGridColumnSetting] ([PersonSettingGridColumnSettingID])
GO

ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter] CHECK CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID]
GO


