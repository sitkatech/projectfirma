SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomPageImage](
	[CustomPageImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[CustomPageID] [int] NOT NULL,
	[FileResourceInfoID] [int] NOT NULL,
 CONSTRAINT [PK_CustomPageImage_CustomPageImageID] PRIMARY KEY CLUSTERED 
(
	[CustomPageImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CustomPageImage_CustomPageImageID_FileResourceInfoID] UNIQUE NONCLUSTERED 
(
	[CustomPageImageID] ASC,
	[FileResourceInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CustomPageImage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageImage_CustomPage_CustomPageID] FOREIGN KEY([CustomPageID])
REFERENCES [dbo].[CustomPage] ([CustomPageID])
GO
ALTER TABLE [dbo].[CustomPageImage] CHECK CONSTRAINT [FK_CustomPageImage_CustomPage_CustomPageID]
GO
ALTER TABLE [dbo].[CustomPageImage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageImage_CustomPage_CustomPageID_TenantID] FOREIGN KEY([CustomPageID], [TenantID])
REFERENCES [dbo].[CustomPage] ([CustomPageID], [TenantID])
GO
ALTER TABLE [dbo].[CustomPageImage] CHECK CONSTRAINT [FK_CustomPageImage_CustomPage_CustomPageID_TenantID]
GO
ALTER TABLE [dbo].[CustomPageImage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageImage_FileResourceInfo_FileResourceInfoID] FOREIGN KEY([FileResourceInfoID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID])
GO
ALTER TABLE [dbo].[CustomPageImage] CHECK CONSTRAINT [FK_CustomPageImage_FileResourceInfo_FileResourceInfoID]
GO
ALTER TABLE [dbo].[CustomPageImage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageImage_FileResourceInfo_FileResourceInfoID_TenantID] FOREIGN KEY([FileResourceInfoID], [TenantID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID], [TenantID])
GO
ALTER TABLE [dbo].[CustomPageImage] CHECK CONSTRAINT [FK_CustomPageImage_FileResourceInfo_FileResourceInfoID_TenantID]
GO
ALTER TABLE [dbo].[CustomPageImage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[CustomPageImage] CHECK CONSTRAINT [FK_CustomPageImage_Tenant_TenantID]