SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate](
	[EIPPerformanceMeasureActualSubcategoryOptionUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[EIPPerformanceMeasureActualUpdateID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_EIPPerformanceMeasureActualSubcategoryOptionUpdateID] PRIMARY KEY CLUSTERED 
(
	[EIPPerformanceMeasureActualSubcategoryOptionUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_EIPPerformanceMeasureActualUpdate_EIPPerformanceMeasureActualUpdateID] FOREIGN KEY([EIPPerformanceMeasureActualUpdateID])
REFERENCES [dbo].[EIPPerformanceMeasureActualUpdate] ([EIPPerformanceMeasureActualUpdateID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_EIPPerformanceMeasureActualUpdate_EIPPerformanceMeasureActualUpdateID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_EIPPerformanceMeasureActualUpdate_EIPPerformanceMeasureActualUpdateID_EIPP] FOREIGN KEY([EIPPerformanceMeasureActualUpdateID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasureActualUpdate] ([EIPPerformanceMeasureActualUpdateID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_EIPPerformanceMeasureActualUpdate_EIPPerformanceMeasureActualUpdateID_EIPP]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate]  WITH CHECK ADD  CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcatego] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[EIPPerformanceMeasureActualSubcategoryOptionUpdate] CHECK CONSTRAINT [FK_EIPPerformanceMeasureActualSubcategoryOptionUpdate_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcatego]