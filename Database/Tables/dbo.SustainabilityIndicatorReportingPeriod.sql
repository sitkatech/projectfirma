SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SustainabilityIndicatorReportingPeriod](
	[SustainabilityIndicatorReportingPeriodID] [int] IDENTITY(1,1) NOT NULL,
	[SustainabilityIndicatorID] [int] NOT NULL,
	[SustainabilityIndicatorReportingPeriodBeginDate] [datetime] NOT NULL,
	[SustainabilityIndicatorReportingPeriodEndDate] [datetime] NULL,
	[SustainabilityIndicatorReportingPeriodLabel] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TargetValue] [float] NULL,
	[TargetValueDescription] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_SustainabilityIndicatorReportingPeriod_SustainabilityIndicatorReportingPeriodID] PRIMARY KEY CLUSTERED 
(
	[SustainabilityIndicatorReportingPeriodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SustainabilityIndicatorReportingPeriod_SustainabilityIndicatorReportingPeriodLabel_SustainabilityIndicatorID] UNIQUE NONCLUSTERED 
(
	[SustainabilityIndicatorReportingPeriodLabel] ASC,
	[SustainabilityIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportingPeriod]  WITH CHECK ADD  CONSTRAINT [FK_SustainabilityIndicatorReportingPeriod_SustainabilityIndicator_SustainabilityIndicatorID] FOREIGN KEY([SustainabilityIndicatorID])
REFERENCES [dbo].[SustainabilityIndicator] ([SustainabilityIndicatorID])
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportingPeriod] CHECK CONSTRAINT [FK_SustainabilityIndicatorReportingPeriod_SustainabilityIndicator_SustainabilityIndicatorID]
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportingPeriod]  WITH CHECK ADD  CONSTRAINT [CK_SustainabilityIndicatorReportingPeriod_BeginDateBeforeEndDate] CHECK  (([SustainabilityIndicatorReportingPeriodBeginDate]<=[SustainabilityIndicatorReportingPeriodEndDate]))
GO
ALTER TABLE [dbo].[SustainabilityIndicatorReportingPeriod] CHECK CONSTRAINT [CK_SustainabilityIndicatorReportingPeriod_BeginDateBeforeEndDate]