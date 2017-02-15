SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirmaPageImage](
	[FirmaPageImageID] [int] IDENTITY(1,1) NOT NULL,
	[FirmaPageID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_FirmaPageImage_FirmaPageImageID] PRIMARY KEY CLUSTERED 
(
	[FirmaPageImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FirmaPageImage_FirmaPageImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[FirmaPageImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPageImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[FirmaPageImage] CHECK CONSTRAINT [FK_FirmaPageImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[FirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_FirmaPageImage_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[FirmaPageImage] CHECK CONSTRAINT [FK_FirmaPageImage_FileResource_FileResourceID_TenantID]
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