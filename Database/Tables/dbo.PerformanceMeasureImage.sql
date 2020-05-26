SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureImage](
	[PerformanceMeasureImageID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[FileResourceInfoID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureImage_PerformanceMeasureImageID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureImage]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureImage_FileResourceInfo_FileResourceInfoID] FOREIGN KEY([FileResourceInfoID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID])
GO
ALTER TABLE [dbo].[PerformanceMeasureImage] CHECK CONSTRAINT [FK_PerformanceMeasureImage_FileResourceInfo_FileResourceInfoID]
GO
ALTER TABLE [dbo].[PerformanceMeasureImage]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureImage_FileResourceInfo_FileResourceInfoID_TenantID] FOREIGN KEY([FileResourceInfoID], [TenantID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureImage] CHECK CONSTRAINT [FK_PerformanceMeasureImage_FileResourceInfo_FileResourceInfoID_TenantID]
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