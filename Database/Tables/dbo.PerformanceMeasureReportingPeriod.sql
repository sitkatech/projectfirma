SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureReportingPeriod](
	[PerformanceMeasureReportingPeriodID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureReportingPeriodBeginDate] [datetime] NOT NULL,
	[PerformanceMeasureReportingPeriodEndDate] [datetime] NULL,
	[PerformanceMeasureReportingPeriodLabel] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TargetValue] [float] NULL,
	[TargetValueDescription] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureReportingPeriodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodLabel_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureReportingPeriodLabel] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod] CHECK CONSTRAINT [FK_PerformanceMeasureReportingPeriod_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod]  WITH CHECK ADD  CONSTRAINT [CK_PerformanceMeasureReportingPeriod_BeginDateBeforeEndDate] CHECK  (([PerformanceMeasureReportingPeriodBeginDate]<=[PerformanceMeasureReportingPeriodEndDate]))
GO
ALTER TABLE [dbo].[PerformanceMeasureReportingPeriod] CHECK CONSTRAINT [CK_PerformanceMeasureReportingPeriod_BeginDateBeforeEndDate]