SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomPageImage](
	[CustomPageImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[CustomPageID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_CustomPageImage_CustomPageImageID] PRIMARY KEY CLUSTERED 
(
	[CustomPageImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CustomPageImage_CustomPageImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[CustomPageImageID] ASC,
	[FileResourceID] ASC
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
ALTER TABLE [dbo].[CustomPageImage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[CustomPageImage] CHECK CONSTRAINT [FK_CustomPageImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[CustomPageImage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageImage_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[CustomPageImage] CHECK CONSTRAINT [FK_CustomPageImage_FileResource_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[CustomPageImage]  WITH CHECK ADD  CONSTRAINT [FK_CustomPageImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[CustomPageImage] CHECK CONSTRAINT [FK_CustomPageImage_Tenant_TenantID]