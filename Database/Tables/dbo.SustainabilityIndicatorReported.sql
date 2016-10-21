SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SustainabilityIndicatorReported](
	[SustainabilityIndicatorReportedID] [int] IDENTITY(1,1) NOT NULL,
	[SustainabilityIndicatorID] [int] NOT NULL,
	[SustainabilityIndicatorReportingPeriodID] [int] NOT NULL,
	[ReportedValue] [float] NOT NULL,
 CONSTRAINT [PK_SustainabilityIndicatorReported_SustainabilityIndicatorReportedID] PRIMARY KEY CLUSTERED 
(
	[SustainabilityIndicatorReportedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SustainabilityIndicatorReported_SustainabilityIndicatorReportedID_SustainabilityIndicatorID] UNIQUE NONCLUSTERED 
(
	[SustainabilityIndicatorReportedID] ASC,
	[SustainabilityIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SustainabilityIndicatorReported]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReported_SustainabilityIndicator_SustainabilityIndicatorID] FOREIGN KEY([SustainabilityIndicatorID])
REFERENCES [dbo].[SustainabilityIndicator] ([SustainabilityIndicatorID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReported] CHECK CONSTRAINT [FK_SustainabilityIndicatorReported_SustainabilityIndicator_SustainabilityIndicatorID]
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReported]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReported_SustainabilityIndicatorReportingPeriod_SustainabilityIndicatorReportingPeriodID] FOREIGN KEY([SustainabilityIndicatorReportingPeriodID])
REFERENCES [dbo].[SustainabilityIndicatorReportingPeriod] ([SustainabilityIndicatorReportingPeriodID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReported] CHECK CONSTRAINT [FK_SustainabilityIndicatorReported_SustainabilityIndicatorReportingPeriod_SustainabilityIndicatorReportingPeriodID]