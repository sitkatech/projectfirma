SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonSettingGridColumnSettingFilter](
	[PersonSettingGridColumnSettingFilterID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonSettingGridColumnSettingID] [int] NOT NULL,
	[FilterText] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSettingFilterID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridColumnSettingFilterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSettingFilterID_PersonSettingGridColumnSettingID_TenantID] UNIQUE NONCLUSTERED 
(
	[PersonSettingGridColumnSettingFilterID] ASC,
	[PersonSettingGridColumnSettingID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID] FOREIGN KEY([PersonSettingGridColumnSettingID])
REFERENCES [dbo].[PersonSettingGridColumnSetting] ([PersonSettingGridColumnSettingID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter] CHECK CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID]
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID_TenantID] FOREIGN KEY([PersonSettingGridColumnSettingID], [TenantID])
REFERENCES [dbo].[PersonSettingGridColumnSetting] ([PersonSettingGridColumnSettingID], [TenantID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter] CHECK CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID_TenantID]
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSettingFilter] CHECK CONSTRAINT [FK_PersonSettingGridColumnSettingFilter_Tenant_TenantID]