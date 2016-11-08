SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption](
	[PerformanceMeasureExpectedSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureExpectedID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpectedSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureExpectedSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [PerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID] FOREIGN KEY([PerformanceMeasureExpectedID])
REFERENCES [dbo].[PerformanceMeasureExpected] ([PerformanceMeasureExpectedID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID]
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureExpectedID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureExpected] ([PerformanceMeasureExpectedID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureExpected_PerformanceMeasureExpectedID_PerformanceMeasureID]