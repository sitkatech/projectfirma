SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotPerformanceMeasure](
	[SnapshotPerformanceMeasureID] [int] IDENTITY(1,1) NOT NULL,
	[SnapshotID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ActualValue] [float] NOT NULL,
 CONSTRAINT [PK_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID] PRIMARY KEY CLUSTERED 
(
	[SnapshotPerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SnapshotPerformanceMeasure_SnapshotPerformanceMeasureID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[SnapshotPerformanceMeasureID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasure] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotPerformanceMeasure_Snapshot_SnapshotID] FOREIGN KEY([SnapshotID])
REFERENCES [dbo].[Snapshot] ([SnapshotID])
GO
ALTER TABLE [dbo].[SnapshotPerformanceMeasure] CHECK CONSTRAINT [FK_SnapshotPerformanceMeasure_Snapshot_SnapshotID]