SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialArea](
	[GeospatialAreaID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeospatialAreaFeature] [geometry] NULL,
	[GeospatialAreaTypeID] [int] NOT NULL,
	[GeospatialAreaDescriptionContent] [dbo].[html] NULL,
	[GeospatialAreaShortName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_GeospatialArea_GeospatialAreaID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialArea_GeospatialAreaID_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialArea_TenantID_GeospatialAreaName_GeospatialAreaTypeID] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
	[GeospatialAreaName] ASC,
	[GeospatialAreaTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialArea]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialArea_GeospatialAreaType_GeospatialAreaTypeID] FOREIGN KEY([GeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO
ALTER TABLE [dbo].[GeospatialArea] CHECK CONSTRAINT [FK_GeospatialArea_GeospatialAreaType_GeospatialAreaTypeID]
GO
ALTER TABLE [dbo].[GeospatialArea]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialArea_GeospatialAreaType_GeospatialAreaTypeID_TenantID] FOREIGN KEY([GeospatialAreaTypeID], [TenantID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialArea] CHECK CONSTRAINT [FK_GeospatialArea_GeospatialAreaType_GeospatialAreaTypeID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialArea]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialArea_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialArea] CHECK CONSTRAINT [FK_GeospatialArea_Tenant_TenantID]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
CREATE SPATIAL INDEX [SPATIAL_GeospatialArea_GeospatialAreaFeature] ON [dbo].[GeospatialArea]
(
	[GeospatialAreaFeature]
)USING  GEOMETRY_AUTO_GRID 
WITH (BOUNDING_BOX =(-125, 32, -105, 53), 
CELLS_PER_OBJECT = 8, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]