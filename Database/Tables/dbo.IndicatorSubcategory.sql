SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndicatorSubcategory](
	[IndicatorSubcategoryID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[IndicatorSubcategoryName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IndicatorSubcategoryDisplayName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NULL,
	[ChartConfigurationJson] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ChartType] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SwapChartAxes] [bit] NULL,
	[EIPPerformanceMeasureID] [int] NULL,
	[SustainabilityIndicatorID] [int] NULL,
	[ThresholdIndicatorID] [int] NULL,
 CONSTRAINT [PK_IndicatorSubcategory_IndicatorSubcategoryID] PRIMARY KEY CLUSTERED 
(
	[IndicatorSubcategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[IndicatorSubcategoryID] ASC,
	[EIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_IndicatorSubcategory_IndicatorSubcategoryID_SustainabilityIndicatorID] UNIQUE NONCLUSTERED 
(
	[IndicatorSubcategoryID] ASC,
	[SustainabilityIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_IndicatorSubcategory_IndicatorSubcategoryID_ThresholdIndicatorID] UNIQUE NONCLUSTERED 
(
	[IndicatorSubcategoryID] ASC,
	[ThresholdIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_IndicatorSubcategory_IndicatorSubcategoryName] UNIQUE NONCLUSTERED 
(
	[IndicatorSubcategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[IndicatorSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorSubcategory_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[IndicatorSubcategory] CHECK CONSTRAINT [FK_IndicatorSubcategory_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[IndicatorSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorSubcategory_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[IndicatorSubcategory] CHECK CONSTRAINT [FK_IndicatorSubcategory_Indicator_IndicatorID]
GO
ALTER TABLE [dbo].[IndicatorSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorSubcategory_SustainabilityIndicator_SustainabilityIndicatorID] FOREIGN KEY([SustainabilityIndicatorID])
REFERENCES [dbo].[SustainabilityIndicator] ([SustainabilityIndicatorID])
GO
ALTER TABLE [dbo].[IndicatorSubcategory] CHECK CONSTRAINT [FK_IndicatorSubcategory_SustainabilityIndicator_SustainabilityIndicatorID]
GO
ALTER TABLE [dbo].[IndicatorSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_IndicatorSubcategory_ThresholdIndicator_ThresholdIndicatorID] FOREIGN KEY([ThresholdIndicatorID])
REFERENCES [dbo].[ThresholdIndicator] ([ThresholdIndicatorID])
GO
ALTER TABLE [dbo].[IndicatorSubcategory] CHECK CONSTRAINT [FK_IndicatorSubcategory_ThresholdIndicator_ThresholdIndicatorID]
GO
ALTER TABLE [dbo].[IndicatorSubcategory]  WITH CHECK ADD  CONSTRAINT [CK_IndicatorSubcategory_OnlyOneLTInfoAreaAsSource] CHECK  (([EIPPerformanceMeasureID] IS NOT NULL AND [SustainabilityIndicatorID] IS NULL AND [ThresholdIndicatorID] IS NULL OR [EIPPerformanceMeasureID] IS NULL AND [SustainabilityIndicatorID] IS NOT NULL AND [ThresholdIndicatorID] IS NULL OR [EIPPerformanceMeasureID] IS NULL AND [SustainabilityIndicatorID] IS NULL AND [ThresholdIndicatorID] IS NOT NULL))
GO
ALTER TABLE [dbo].[IndicatorSubcategory] CHECK CONSTRAINT [CK_IndicatorSubcategory_OnlyOneLTInfoAreaAsSource]