SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdCategoryIndicator](
	[ThresholdCategoryIndicatorID] [int] NOT NULL,
	[ThresholdCategoryID] [int] NOT NULL,
	[IndicatorID] [int] NOT NULL,
	[IsPrimaryChart] [bit] NOT NULL,
 CONSTRAINT [PK_ThresholdCategoryIndicator_ThresholdCategoryIndicatorID] PRIMARY KEY CLUSTERED 
(
	[ThresholdCategoryIndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdCategoryIndicator_ThresholdCategoryID_IndicatorID] UNIQUE NONCLUSTERED 
(
	[ThresholdCategoryID] ASC,
	[IndicatorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdCategoryIndicator]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdCategoryIndicator_Indicator_IndicatorID] FOREIGN KEY([IndicatorID])
REFERENCES [dbo].[Indicator] ([IndicatorID])
GO
ALTER TABLE [dbo].[ThresholdCategoryIndicator] CHECK CONSTRAINT [FK_ThresholdCategoryIndicator_Indicator_IndicatorID]
GO
ALTER TABLE [dbo].[ThresholdCategoryIndicator]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdCategoryIndicator_ThresholdCategory_ThresholdCategoryID] FOREIGN KEY([ThresholdCategoryID])
REFERENCES [dbo].[ThresholdCategory] ([ThresholdCategoryID])
GO
ALTER TABLE [dbo].[ThresholdCategoryIndicator] CHECK CONSTRAINT [FK_ThresholdCategoryIndicator_ThresholdCategory_ThresholdCategoryID]