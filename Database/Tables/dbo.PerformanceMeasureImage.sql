SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureImage](
	[PerformanceMeasureImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureImage_PerformanceMeasureImageID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureImage]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[PerformanceMeasureImage] CHECK CONSTRAINT [FK_PerformanceMeasureImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[PerformanceMeasureImage]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureImage_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureImage] CHECK CONSTRAINT [FK_PerformanceMeasureImage_FileResource_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureImage]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureImage_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureImage] CHECK CONSTRAINT [FK_PerformanceMeasureImage_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureImage]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureImage_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureImage] CHECK CONSTRAINT [FK_PerformanceMeasureImage_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureImage]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureImage] CHECK CONSTRAINT [FK_PerformanceMeasureImage_Tenant_TenantID]