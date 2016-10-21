SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdIndicator](
	[ThresholdIndicatorID] [int] IDENTITY(1,1) NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[ThresholdReportingCategoryID] [int] NOT NULL,
	[UseCustomDateRange] [bit] NOT NULL,
	[ThresholdStandardTypeID] [int] NOT NULL,
	[ApplicableStandard] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StandardNarrative] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TRPAIndicator] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Relevance] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HumanAndEnvironmentalDrivers] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OptionalChartImageFileResourceID] [int] NULL,
 CONSTRAINT [PK_ThresholdIndicator_ThresholdIndicatorID] PRIMARY KEY CLUSTERED 
(
	[ThresholdIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdIndicator_IndicatorID] UNIQUE NONCLUSTERED 
(
	[IndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdIndicator]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicator_FileResource_OptionalChartImageFileResourceID_FileResourceID] FOREIGN KEY([OptionalChartImageFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ThresholdIndicator] CHECK CONSTRAINT [FK_ThresholdIndicator_FileResource_OptionalChartImageFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[ThresholdIndicator]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicator_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[ThresholdIndicator] CHECK CONSTRAINT [FK_ThresholdIndicator_Indicator_IndicatorID]
GO
ALTER TABLE [dbo].[ThresholdIndicator]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicator_ThresholdReportingCategory_ThresholdReportingCategoryID] FOREIGN KEY([ThresholdReportingCategoryID])
REFERENCES [dbo].[ThresholdReportingCategory] ([ThresholdReportingCategoryID])
GO
ALTER TABLE [dbo].[ThresholdIndicator] CHECK CONSTRAINT [FK_ThresholdIndicator_ThresholdReportingCategory_ThresholdReportingCategoryID]
GO
ALTER TABLE [dbo].[ThresholdIndicator]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdIndicator_ThresholdStandardType_ThresholdStandardTypeID] FOREIGN KEY([ThresholdStandardTypeID])
REFERENCES [dbo].[ThresholdStandardType] ([ThresholdStandardTypeID])
GO
ALTER TABLE [dbo].[ThresholdIndicator] CHECK CONSTRAINT [FK_ThresholdIndicator_ThresholdStandardType_ThresholdStandardTypeID]