SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureReportingPeriodTarget](
	[PerformanceMeasureReportingPeriodTargetID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodID] [int] NOT NULL,
	[PerformanceMeasureTargetValue] [float] NULL,
	[PerformanceMeasureTargetValueLabel] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureTargetID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureReportingPeriodTargetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriodID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportingPeriodID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureTargetID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportingPeriodTargetID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget] CHECK CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget] CHECK CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget] CHECK CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID] FOREIGN KEY([PerformanceMeasureReportingPeriodID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID], [TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget] CHECK CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriodTarget] CHECK CONSTRAINT [FK_PerformanceMeasureReportingPeriodTarget_Tenant_TenantID]