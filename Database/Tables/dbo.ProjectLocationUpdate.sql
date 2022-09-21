SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationUpdate](
	[ProjectLocationUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ProjectLocationUpdateGeometry] [geometry] NOT NULL,
	[Annotation] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProjectLocationUpdate_ProjectLocationUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectLocationUpdate] CHECK CONSTRAINT [FK_ProjectLocationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectLocationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationUpdate] CHECK CONSTRAINT [FK_ProjectLocationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationUpdate] CHECK CONSTRAINT [FK_ProjectLocationUpdate_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocationUpdate]  WITH CHECK ADD  CONSTRAINT [CK_ProjectLocation_ProjectLocationUpdateGeometry_SpatialReferenceID_Must_Be_4326] CHECK  (([ProjectLocationUpdateGeometry] IS NULL OR [ProjectLocationUpdateGeometry].[STSrid]=(4326)))
GO
ALTER TABLE [dbo].[ProjectLocationUpdate] CHECK CONSTRAINT [CK_ProjectLocation_ProjectLocationUpdateGeometry_SpatialReferenceID_Must_Be_4326]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
CREATE SPATIAL INDEX [SPATIAL_ProjectLocationUpdate_ProjectLocationUpdateGeometry] ON [dbo].[ProjectLocationUpdate]
(
	[ProjectLocationUpdateGeometry]
)USING  GEOMETRY_AUTO_GRID 
WITH (BOUNDING_BOX =(-126, 33, -105, 50), 
CELLS_PER_OBJECT = 8, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]