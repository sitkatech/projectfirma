SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureReportedValue](
	[PerformanceMeasureReportedValueID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
	[ReportedValue] [float] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureReportedValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportedValue_PerformanceMeasureReportedValueID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportedValueID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportedValue_Tenant_PerformanceMeasureReportedValueID_TenantID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportedValueID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValue]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValue_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValue] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValue_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValue]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValue_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValue] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValue_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValue]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportedValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportedValue] CHECK CONSTRAINT [FK_PerformanceMeasureReportedValue_Tenant_TenantID]