SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType](
	[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureTargetValueTypeID] [int] NOT NULL,
 CONSTRAINT [PK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetVal] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_GeospatialAreaID_PerformanceMeasureID_PerformanceMeasureTar] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaID] ASC,
	[PerformanceMeasureID] ASC,
	[PerformanceMeasureTargetValueTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_GeospatialArea_GeospatialAreaID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_GeospatialArea_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_PerformanceMeasureTargetValueType_PerformanceMeasureTargetV] FOREIGN KEY([PerformanceMeasureTargetValueTypeID])
REFERENCES [dbo].[PerformanceMeasureTargetValueType] ([PerformanceMeasureTargetValueTypeID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_PerformanceMeasureTargetValueType_PerformanceMeasureTargetV]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasurePerformanceMeasureTargetValueType_Tenant_TenantID]