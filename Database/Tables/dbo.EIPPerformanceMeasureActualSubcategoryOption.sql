SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption](
	[EIPPerformanceMeasureActualSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[EIPPerformanceMeasureActualID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureActualSubcategoryOption_EIPPerformanceMeasureActualSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureActualSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_EIPPerformanceMeasureActual_EIPPerformanceMeasureActualID] FOREIGN KEY([EIPPerformanceMeasureActualID])
REFERENCES [dbo].[EIPPerformanceMeasureActual] ([EIPPerformanceMeasureActualID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_EIPPerformanceMeasureActual_EIPPerformanceMeasureActualID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_EIPPerformanceMeasureActual_EIPPerformanceMeasureActualID_EIPPerformanceMeasureI] FOREIGN KEY([EIPPerformanceMeasureActualID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasureActual] ([EIPPerformanceMeasureActualID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_EIPPerformanceMeasureActual_EIPPerformanceMeasureActualID_EIPPerformanceMeasureI]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID]