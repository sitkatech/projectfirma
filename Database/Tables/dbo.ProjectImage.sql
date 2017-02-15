SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectImage](
	[ProjectImageID] [int] IDENTITY(1,1) NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ProjectImageTimingID] [int] NOT NULL,
	[Caption] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Credit] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsKeyPhoto] [bit] NOT NULL,
	[ExcludeFromFactSheet] [bit] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectImage_ProjectImageID] PRIMARY KEY CLUSTERED 
(
	[ProjectImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectImage_FileResourceID_ProjectID] UNIQUE NONCLUSTERED 
(
	[FileResourceID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectImage_ProjectImageID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectImageID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ProjectImage] CHECK CONSTRAINT [FK_ProjectImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[ProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImage_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectImage] CHECK CONSTRAINT [FK_ProjectImage_FileResource_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[ProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImage_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectImage] CHECK CONSTRAINT [FK_ProjectImage_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImage_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectImage] CHECK CONSTRAINT [FK_ProjectImage_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImage_ProjectImageTiming_ProjectImageTimingID] FOREIGN KEY([ProjectImageTimingID])
REFERENCES [dbo].[ProjectImageTiming] ([ProjectImageTimingID])
GO
ALTER TABLE [dbo].[ProjectImage] CHECK CONSTRAINT [FK_ProjectImage_ProjectImageTiming_ProjectImageTimingID]
GO
ALTER TABLE [dbo].[ProjectImage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectImage] CHECK CONSTRAINT [FK_ProjectImage_Tenant_TenantID]