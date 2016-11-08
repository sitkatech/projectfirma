SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureActualSubcategoryOption](
	[PerformanceMeasureActualSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureActualID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActualSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureActualSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [PerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_PerformanceMeasureActualID] FOREIGN KEY([PerformanceMeasureActualID])
REFERENCES [dbo].[PerformanceMeasureActual] ([PerformanceMeasureActualID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_PerformanceMeasureActualID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_PerformanceMeasureActualID_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureActualID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureActual] ([PerformanceMeasureActualID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_PerformanceMeasureActualID_PerformanceMeasureID]