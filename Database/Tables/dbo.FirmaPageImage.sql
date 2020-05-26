SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmaPageImage](
	[FirmaPageImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FirmaPageID] [int] NOT NULL,
	[FileResourceInfoID] [int] NOT NULL,
 CONSTRAINT [PK_FirmaPageImage_FirmaPageImageID] PRIMARY KEY CLUSTERED 
(
	[FirmaPageImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FirmaPageImage_FirmaPageImageID_FileResourceInfoID] UNIQUE NONCLUSTERED 
(
	[FirmaPageImageID] ASC,
	[FileResourceInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPageImage_FileResourceInfo_FileResourceInfoID] FOREIGN KEY([FileResourceInfoID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID])
GO
ALTER TABLE [dbo].[FirmaPageImage] CHECK CONSTRAINT [FK_FirmaPageImage_FileResourceInfo_FileResourceInfoID]
GO
ALTER TABLE [dbo].[FirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPageImage_FileResourceInfo_FileResourceInfoID_TenantID] FOREIGN KEY([FileResourceInfoID], [TenantID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID], [TenantID])
GO
ALTER TABLE [dbo].[FirmaPageImage] CHECK CONSTRAINT [FK_FirmaPageImage_FileResourceInfo_FileResourceInfoID_TenantID]
GO
ALTER TABLE [dbo].[FirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPageImage_FirmaPage_FirmaPageID] FOREIGN KEY([FirmaPageID])
REFERENCES [dbo].[FirmaPage] ([FirmaPageID])
GO
ALTER TABLE [dbo].[FirmaPageImage] CHECK CONSTRAINT [FK_FirmaPageImage_FirmaPage_FirmaPageID]
GO
ALTER TABLE [dbo].[FirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPageImage_FirmaPage_FirmaPageID_TenantID] FOREIGN KEY([FirmaPageID], [TenantID])
REFERENCES [dbo].[FirmaPage] ([FirmaPageID], [TenantID])
GO
ALTER TABLE [dbo].[FirmaPageImage] CHECK CONSTRAINT [FK_FirmaPageImage_FirmaPage_FirmaPageID_TenantID]
GO
ALTER TABLE [dbo].[FirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPageImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[FirmaPageImage] CHECK CONSTRAINT [FK_FirmaPageImage_Tenant_TenantID]