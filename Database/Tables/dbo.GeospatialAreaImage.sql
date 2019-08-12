SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaImage](
	[GeospatialAreaImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_GeospatialAreaImage_GeospatialAreaImageID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaImage_GeospatialAreaImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaImage]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[GeospatialAreaImage] CHECK CONSTRAINT [FK_GeospatialAreaImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[GeospatialAreaImage]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaImage_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaImage] CHECK CONSTRAINT [FK_GeospatialAreaImage_FileResource_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaImage]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaImage_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO
ALTER TABLE [dbo].[GeospatialAreaImage] CHECK CONSTRAINT [FK_GeospatialAreaImage_GeospatialArea_GeospatialAreaID]
GO
ALTER TABLE [dbo].[GeospatialAreaImage]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaImage_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaImage] CHECK CONSTRAINT [FK_GeospatialAreaImage_GeospatialArea_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaImage]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaImage] CHECK CONSTRAINT [FK_GeospatialAreaImage_Tenant_TenantID]