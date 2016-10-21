SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasure](
	[EIPPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[EIPPerformanceMeasureTypeID] [int] NOT NULL,
	[CriticalDefinitions] [dbo].[html] NULL,
	[AccountingPeriodAndScale] [dbo].[html] NULL,
	[ProjectReporting] [dbo].[html] NULL,
	[EIPContext] [dbo].[html] NULL,
 CONSTRAINT [PK_EIPPerformanceMeasure_EIPPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EIPPerformanceMeasure_IndicatorID] UNIQUE NONCLUSTERED 
(
	[IndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasure_EIPPerformanceMeasureType_EIPPerformanceMeasureTypeID] FOREIGN KEY([EIPPerformanceMeasureTypeID])
REFERENCES [dbo].[EIPPerformanceMeasureType] ([EIPPerformanceMeasureTypeID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasure] CHECK CONSTRAINT [FK_EIPPerformanceMeasure_EIPPerformanceMeasureType_EIPPerformanceMeasureTypeID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasure_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasure] CHECK CONSTRAINT [FK_EIPPerformanceMeasure_Indicator_IndicatorID]