SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonSettingGridColumnSetting](
	[PersonSettingGridColumnSettingID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[PersonSettingGridColumnID] [int] NOT NULL,
	[FilterText] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridColumnSettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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