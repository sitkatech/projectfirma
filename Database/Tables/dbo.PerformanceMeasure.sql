SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasure](
	[PerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[CriticalDefinitions] [dbo].[html] NULL,
	[AccountingPeriodAndScale] [dbo].[html] NULL,
	[ProjectReporting] [dbo].[html] NULL,
 CONSTRAINT [PK_PerformanceMeasure_PerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasure_IndicatorID] UNIQUE NONCLUSTERED 
(
	[IndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasure_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[PerformanceMeasure] CHECK CONSTRAINT [FK_PerformanceMeasure_Indicator_IndicatorID]