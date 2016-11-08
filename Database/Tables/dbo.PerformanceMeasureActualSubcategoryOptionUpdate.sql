SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate](
	[PerformanceMeasureActualSubcategoryOptionUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[PerformanceMeasureActualUpdateID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualSubcategoryOptionUpdateID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureActualSubcategoryOptionUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [PerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryI] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryI]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID] FOREIGN KEY([PerformanceMeasureActualUpdateID])
REFERENCES [dbo].[PerformanceMeasureActualUpdate] ([PerformanceMeasureActualUpdateID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID]
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID_PerformanceMe] FOREIGN KEY([PerformanceMeasureActualUpdateID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureActualUpdate] ([PerformanceMeasureActualUpdateID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[PerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_PerformanceMeasureActualSubcategoryOptionUpdate_PerformanceMeasureActualUpdate_PerformanceMeasureActualUpdateID_PerformanceMe]