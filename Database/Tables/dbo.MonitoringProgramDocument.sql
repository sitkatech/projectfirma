SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitoringProgramDocument](
	[MonitoringProgramDocumentID] [int] IDENTITY(1,1) NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[MonitoringProgramID] [int] NOT NULL,
	[DisplayName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UploadDate] [date] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_MonitoringProgramDocument_MonitoringProgramDocumentID] PRIMARY KEY CLUSTERED 
(
	[MonitoringProgramDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MonitoringProgramDocument_FileResourceID_MonitoringProgramID] UNIQUE NONCLUSTERED 
(
	[FileResourceID] ASC,
	[MonitoringProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MonitoringProgramDocument]  WITH CHECK ADD  CONSTRAINT [FK_MonitoringProgramDocument_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[MonitoringProgramDocument] CHECK CONSTRAINT [FK_MonitoringProgramDocument_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[MonitoringProgramDocument]  WITH CHECK ADD  CONSTRAINT [FK_MonitoringProgramDocument_MonitoringProgram_MonitoringProgramID] FOREIGN KEY([MonitoringProgramID])
REFERENCES [dbo].[MonitoringProgram] ([MonitoringProgramID])
GO
ALTER TABLE [dbo].[MonitoringProgramDocument] CHECK CONSTRAINT [FK_MonitoringProgramDocument_MonitoringProgram_MonitoringProgramID]
GO
ALTER TABLE [dbo].[MonitoringProgramDocument]  WITH CHECK ADD  CONSTRAINT [FK_MonitoringProgramDocument_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MonitoringProgramDocument] CHECK CONSTRAINT [FK_MonitoringProgramDocument_Tenant_TenantID]