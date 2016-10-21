SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption](
	[SnapshotEIPPerformanceMeasureSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[SnapshotEIPPerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryOptionID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[IndicatorSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_SnapshotEIPPerformanceMeasureSubcategoryOption_SnapshotEIPPerformanceMeasureSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[SnapshotEIPPerformanceMeasureSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID] FOREIGN KEY([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[IndicatorSubcategory] ([IndicatorSubcategoryID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_IndicatorSubcategory_IndicatorSubcategoryID_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID] FOREIGN KEY([IndicatorSubcategoryOptionID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID]
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID] FOREIGN KEY([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
REFERENCES [dbo].[IndicatorSubcategoryOption] ([IndicatorSubcategoryOptionID], [IndicatorSubcategoryID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_IndicatorSubcategoryOption_IndicatorSubcategoryOptionID_IndicatorSubcategoryID]
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_SnapshotEIPPerformanceMeasure_SnapshotEIPPerformanceMeasureID] FOREIGN KEY([SnapshotEIPPerformanceMeasureID])
REFERENCES [dbo].[SnapshotEIPPerformanceMeasure] ([SnapshotEIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_SnapshotEIPPerformanceMeasure_SnapshotEIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_SnapshotEIPPerformanceMeasure_SnapshotEIPPerformanceMeasureID_EIPPerformanceMe] FOREIGN KEY([SnapshotEIPPerformanceMeasureID], [EIPPerformanceMeasureID])
REFERENCES [dbo].[SnapshotEIPPerformanceMeasure] ([SnapshotEIPPerformanceMeasureID], [EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasureSubcategoryOption] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasureSubcategoryOption_SnapshotEIPPerformanceMeasure_SnapshotEIPPerformanceMeasureID_EIPPerformanceMe]