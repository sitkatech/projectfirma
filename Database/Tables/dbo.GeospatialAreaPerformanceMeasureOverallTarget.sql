SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget](
	[GeospatialAreaPerformanceMeasureOverallTargetID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[GeospatialAreaPerformanceMeasureTargetValue] [float] NOT NULL,
	[GeospatialAreaPerformanceMeasureTargetValueLabel] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaPerformanceMeasureOverallTargetID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaPerformanceMeasureOverallTargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialAreaPerformanceMeasureOverallTargetID_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaPerformanceMeasureOverallTargetID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_GeospatialArea_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureOverallTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureOverallTarget_Tenant_TenantID]