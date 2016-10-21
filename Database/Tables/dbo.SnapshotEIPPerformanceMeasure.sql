SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotEIPPerformanceMeasure](
	[SnapshotEIPPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[SnapshotID] [int] NOT NULL,
	[EIPPerformanceMeasureID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ActualValue] [float] NOT NULL,
 CONSTRAINT [PK_SnapshotEIPPerformanceMeasure_SnapshotEIPPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[SnapshotEIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SnapshotEIPPerformanceMeasure_SnapshotEIPPerformanceMeasureID_EIPPerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[SnapshotEIPPerformanceMeasureID] ASC,
	[EIPPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasure_EIPPerformanceMeasure_EIPPerformanceMeasureID] FOREIGN KEY([EIPPerformanceMeasureID])
REFERENCES [dbo].[EIPPerformanceMeasure] ([EIPPerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasure] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasure_EIPPerformanceMeasure_EIPPerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotEIPPerformanceMeasure_Snapshot_SnapshotID] FOREIGN KEY([SnapshotID])
REFERENCES [dbo].[Snapshot] ([SnapshotID])
GO
ALTER TABLE [dbo].[SnapshotEIPPerformanceMeasure] CHECK CONSTRAINT [FK_SnapshotEIPPerformanceMeasure_Snapshot_SnapshotID]