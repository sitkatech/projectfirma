SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption](
	[SnapshotPerformanceMeasureSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[SnapshotPerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasureSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[SnapshotPerformanceMeasureSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [PerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID] FOREIGN KEY([SnapshotPerformanceMeasureID])
REFERENCES [dbo].[SnapshotPerformanceMeasure] ([SnapshotPerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID_PerformanceMe] FOREIGN KEY([SnapshotPerformanceMeasureID], [PerformanceMeasureID])
REFERENCES [dbo].[SnapshotPerformanceMeasure] ([SnapshotPerformanceMeasureID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasureSubcategoryOption_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID_PerformanceMe]