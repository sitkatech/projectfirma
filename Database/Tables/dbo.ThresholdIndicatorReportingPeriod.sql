SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdIndicatorReportingPeriod](
	[ThresholdIndicatorReportingPeriodID] [int] IDENTITY(1,1) NOT NULL,
	[ThresholdIndicatorID] [int] NOT NULL,
	[ThresholdIndicatorReportingPeriodBeginDate] [datetime] NOT NULL,
	[ThresholdIndicatorReportingPeriodEndDate] [datetime] NULL,
	[ThresholdIndicatorReportingPeriodLabel] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TargetValue] [float] NULL,
	[TargetValueDescription] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ThresholdIndicatorReportingPeriod_ThresholdIndicatorReportingPeriodID] PRIMARY KEY CLUSTERED 
(
	[ThresholdIndicatorReportingPeriodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdIndicatorReportingPeriod_ThresholdIndicatorReportingPeriodLabel_ThresholdIndicatorID] UNIQUE NONCLUSTERED 
(
	[ThresholdIndicatorReportingPeriodLabel] ASC,
	[ThresholdIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdIndicatorReportingPeriod]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReportingPeriod_ThresholdIndicator_ThresholdIndicatorID] FOREIGN KEY([ThresholdIndicatorID])
REFERENCES [dbo].[ThresholdIndicator] ([ThresholdIndicatorID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportingPeriod] CHECK CONSTRAINT [FK_ThresholdIndicatorReportingPeriod_ThresholdIndicator_ThresholdIndicatorID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportingPeriod]  WITH CHECK ADD  CONSTRAINT [CK_ThresholdIndicatorReportingPeriod_BeginDateBeforeEndDate] CHECK  (([ThresholdIndicatorReportingPeriodBeginDate]<=[ThresholdIndicatorReportingPeriodEndDate]))
GO
ALTER TABLE [dbo].[ThresholdIndicatorReportingPeriod] CHECK CONSTRAINT [CK_ThresholdIndicatorReportingPeriod_BeginDateBeforeEndDate]