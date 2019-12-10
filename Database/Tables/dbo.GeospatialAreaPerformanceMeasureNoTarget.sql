SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget](
	[GeospatialAreaPerformanceMeasureNoTargetID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
 CONSTRAINT [PK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialAreaPerformanceMeasureNoTargetID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaPerformanceMeasureNoTargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialAreaID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialAreaPerformanceMeasureTargetID_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaPerformanceMeasureNoTargetID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialArea_GeospatialAreaID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_GeospatialArea_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureNoTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureNoTarget_Tenant_TenantID]