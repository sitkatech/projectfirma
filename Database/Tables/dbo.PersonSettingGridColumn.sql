SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonSettingGridColumn](
	[PersonSettingGridColumnID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonSettingGridTableID] [int] NOT NULL,
	[ColumnName] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_PersonSettingGridColumn_PersonSettingGridColumnID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridColumnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonSettingGridColumn]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumn_PersonSettingGridTable_PersonSettingGridTableID] FOREIGN KEY([PersonSettingGridTableID])
REFERENCES [dbo].[PersonSettingGridTable] ([PersonSettingGridTableID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumn] CHECK CONSTRAINT [FK_PersonSettingGridColumn_PersonSettingGridTable_PersonSettingGridTableID]
GO
ALTER TABLE [dbo].[PersonSettingGridColumn]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumn_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumn] CHECK CONSTRAINT [FK_PersonSettingGridColumn_Tenant_TenantID]