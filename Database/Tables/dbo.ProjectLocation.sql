SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocation](
	[ProjectLocationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ProjectLocationGeometry] [geometry] NOT NULL,
	[Annotation] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProjectLocation_ProjectLocationID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocation]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocation_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectLocation] CHECK CONSTRAINT [FK_ProjectLocation_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectLocation]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocation_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectLocation] CHECK CONSTRAINT [FK_ProjectLocation_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocation]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocation_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectLocation] CHECK CONSTRAINT [FK_ProjectLocation_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocation]  WITH CHECK ADD  CONSTRAINT [CK_ProjectLocation_ProjectLocationGeometry_SpatialReferenceID_Must_Be_4326] CHECK  (([ProjectLocationGeometry] IS NULL OR [ProjectLocationGeometry].[STSrid]=(4326)))
GO
ALTER TABLE [dbo].[ProjectLocation] CHECK CONSTRAINT [CK_ProjectLocation_ProjectLocationGeometry_SpatialReferenceID_Must_Be_4326]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
CREATE SPATIAL INDEX [SPATIAL_ProjectLocation_ProjectLocationGeometry] ON [dbo].[ProjectLocation]
(
	[ProjectLocationGeometry]
)USING  GEOMETRY_AUTO_GRID 
WITH (BOUNDING_BOX =(-125, 33, -105, 50), 
CELLS_PER_OBJECT = 8, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]