SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget](
	[GeospatialAreaPerformanceMeasureTargetID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodID] [int] NOT NULL,
	[GeospatialAreaPerformanceMeasureTargetValue] [float] NULL,
	[GeospatialAreaPerformanceMeasureTargetValueLabel] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_GeospatialAreaPerformanceMeasureTarget_GeospatialAreaPerformanceMeasureTargetID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaPerformanceMeasureTargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureTarget_GeospatialAreaID_PerformanceMeasureReportingPeriodID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaID] ASC,
	[PerformanceMeasureReportingPeriodID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaPerformanceMeasureTarget_GeospatialAreaPerformanceMeasureTargetID_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaPerformanceMeasureTargetID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_GeospatialArea_GeospatialAreaID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_GeospatialArea_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID] FOREIGN KEY([PerformanceMeasureReportingPeriodID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaPerformanceMeasureTarget] CHECK CONSTRAINT [FK_GeospatialAreaPerformanceMeasureTarget_Tenant_TenantID]