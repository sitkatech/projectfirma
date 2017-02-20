SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectImageUpdate](
	[ProjectImageUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FileResourceID] [int] NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ProjectImageTimingID] [int] NOT NULL,
	[Caption] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Credit] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsKeyPhoto] [bit] NOT NULL,
	[ExcludeFromFactSheet] [bit] NOT NULL,
	[ProjectImageID] [int] NULL,
 CONSTRAINT [PK_ProjectImageUpdate_ProjectImageUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectImageUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectImageUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageUpdate_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ProjectImageUpdate] CHECK CONSTRAINT [FK_ProjectImageUpdate_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[ProjectImageUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageUpdate_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectImageUpdate] CHECK CONSTRAINT [FK_ProjectImageUpdate_FileResource_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[ProjectImageUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageUpdate_ProjectImage_ProjectImageID] FOREIGN KEY([ProjectImageID])
REFERENCES [dbo].[ProjectImage] ([ProjectImageID])
GO
ALTER TABLE [dbo].[ProjectImageUpdate] CHECK CONSTRAINT [FK_ProjectImageUpdate_ProjectImage_ProjectImageID]
GO
ALTER TABLE [dbo].[ProjectImageUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageUpdate_ProjectImage_ProjectImageID_TenantID] FOREIGN KEY([ProjectImageID], [TenantID])
REFERENCES [dbo].[ProjectImage] ([ProjectImageID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectImageUpdate] CHECK CONSTRAINT [FK_ProjectImageUpdate_ProjectImage_ProjectImageID_TenantID]
GO
ALTER TABLE [dbo].[ProjectImageUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageUpdate_ProjectImageTiming_ProjectImageTimingID] FOREIGN KEY([ProjectImageTimingID])
REFERENCES [dbo].[ProjectImageTiming] ([ProjectImageTimingID])
GO
ALTER TABLE [dbo].[ProjectImageUpdate] CHECK CONSTRAINT [FK_ProjectImageUpdate_ProjectImageTiming_ProjectImageTimingID]
GO
ALTER TABLE [dbo].[ProjectImageUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectImageUpdate] CHECK CONSTRAINT [FK_ProjectImageUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectImageUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectImageUpdate] CHECK CONSTRAINT [FK_ProjectImageUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectImageUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImageUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectImageUpdate] CHECK CONSTRAINT [FK_ProjectImageUpdate_Tenant_TenantID]