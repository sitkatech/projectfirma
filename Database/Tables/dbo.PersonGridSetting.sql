SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonGridSetting](
	[PersonGridSettingID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[GridName] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FilterState] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ColumnState] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_PersonGridSetting_PersonGridSettingID] PRIMARY KEY CLUSTERED 
(
	[PersonGridSettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_PersonGrisSetting_TenantID_PersonID_GridName] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
	[PersonID] ASC,
	[GridName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonGridSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonGridSetting_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonGridSetting] CHECK CONSTRAINT [FK_PersonGridSetting_Person_PersonID]
GO
ALTER TABLE [dbo].[PersonGridSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonGridSetting_Person_PersonID_TenantID] FOREIGN KEY([PersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[PersonGridSetting] CHECK CONSTRAINT [FK_PersonGridSetting_Person_PersonID_TenantID]
GO
ALTER TABLE [dbo].[PersonGridSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonGridSetting_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PersonGridSetting] CHECK CONSTRAINT [FK_PersonGridSetting_Tenant_TenantID]