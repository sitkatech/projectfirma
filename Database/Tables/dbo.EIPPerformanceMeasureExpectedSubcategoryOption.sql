SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption](
	[EIPPerformanceMeasureExpectedSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[EIPPerformanceMeasureExpectedID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureExpectedSubcategoryOption_EIPPerformanceMeasureExpectedSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureExpectedSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_EIPPerformanceMeasureExpected_EIPPerformanceMeasureExpectedID] FOREIGN KEY([EIPPerformanceMeasureExpectedID])
REFERENCES [dbo].[EIPPerformanceMeasureExpected] ([EIPPerformanceMeasureExpectedID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_EIPPerformanceMeasureExpected_EIPPerformanceMeasureExpectedID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_EIPPerformanceMeasureExpected_EIPPerformanceMeasureExpectedID_EIPPerformanceMe] FOREIGN KEY([EIPPerformanceMeasureExpectedID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasureExpected] ([EIPPerformanceMeasureExpectedID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_EIPPerformanceMeasureExpected_EIPPerformanceMeasureExpectedID_EIPPerformanceMe]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureExpectedSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID]