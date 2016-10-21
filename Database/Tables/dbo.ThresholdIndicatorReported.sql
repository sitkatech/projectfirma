SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdIndicatorReported](
	[ThresholdIndicatorReportedID] [int] IDENTITY(1,1) NOT NULL,
	[ThresholdIndicatorID] [int] NOT NULL,
	[ThresholdIndicatorReportingPeriodID] [int] NOT NULL,
	[ReportedValue] [float] NOT NULL,
 CONSTRAINT [PK_ThresholdIndicatorReported_ThresholdIndicatorReportedID] PRIMARY KEY CLUSTERED 
(
	[ThresholdIndicatorReportedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdIndicatorReported_ThresholdIndicatorReportedID_ThresholdIndicatorID] UNIQUE NONCLUSTERED 
(
	[ThresholdIndicatorReportedID] ASC,
	[ThresholdIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdIndicatorReported]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReported_ThresholdIndicator_ThresholdIndicatorID] FOREIGN KEY([ThresholdIndicatorID])
REFERENCES [dbo].[ThresholdIndicator] ([ThresholdIndicatorID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReported] CHECK CONSTRAINT [FK_ThresholdIndicatorReported_ThresholdIndicator_ThresholdIndicatorID]
GO
ALTER TABLE [dbo].[ThresholdIndicatorReported]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicatorReported_ThresholdIndicatorReportingPeriod_ThresholdIndicatorReportingPeriodID] FOREIGN KEY([ThresholdIndicatorReportingPeriodID])
REFERENCES [dbo].[ThresholdIndicatorReportingPeriod] ([ThresholdIndicatorReportingPeriodID])
GO
ALTER TABLE [dbo].[ThresholdIndicatorReported] CHECK CONSTRAINT [FK_ThresholdIndicatorReported_ThresholdIndicatorReportingPeriod_ThresholdIndicatorReportingPeriodID]