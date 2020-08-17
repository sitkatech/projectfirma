SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonSettingGridTable](
	[PersonSettingGridTableID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GridName] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_PersonSettingGridTable_PersonSettingGridTableID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonSettingGridTable]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridTable_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PersonSettingGridTable] CHECK CONSTRAINT [FK_PersonSettingGridTable_Tenant_TenantID]