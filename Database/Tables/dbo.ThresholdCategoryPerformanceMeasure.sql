SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdCategoryPerformanceMeasure](
	[ThresholdCategoryPerformanceMeasureID] [int] NOT NULL,
	[ThresholdCategoryID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IsPrimaryChart] [bit] NOT NULL,
 CONSTRAINT [PK_ThresholdCategoryPerformanceMeasure_ThresholdCategoryPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[ThresholdCategoryPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdCategoryPerformanceMeasure_ThresholdCategoryID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[ThresholdCategoryID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdCategoryPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdCategoryPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[ThresholdCategoryPerformanceMeasure] CHECK CONSTRAINT [FK_ThresholdCategoryPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[ThresholdCategoryPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdCategoryPerformanceMeasure_ThresholdCategory_ThresholdCategoryID] FOREIGN KEY([ThresholdCategoryID])
REFERENCES [dbo].[ThresholdCategory] ([ThresholdCategoryID])
GO
ALTER TABLE [dbo].[ThresholdCategoryPerformanceMeasure] CHECK CONSTRAINT [FK_ThresholdCategoryPerformanceMeasure_ThresholdCategory_ThresholdCategoryID]