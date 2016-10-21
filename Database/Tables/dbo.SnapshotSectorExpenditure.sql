SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotSectorExpenditure](
	[SnapshotSectorExpenditureID] [int] IDENTITY(1,1) NOT NULL,
	[SnapshotID] [int] NOT NULL,
	[SectorID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ExpenditureAmount] [money] NOT NULL,
 CONSTRAINT [PK_SnapshotSectorExpenditure_SnapshotSectorExpenditureID] PRIMARY KEY CLUSTERED 
(
	[SnapshotSectorExpenditureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SnapshotSectorExpenditure_SnapshotID_SectorID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[SnapshotID] ASC,
	[SectorID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotSectorExpenditure_Sector_SectorID] FOREIGN KEY([SectorID])
REFERENCES [dbo].[Sector] ([SectorID])
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure] CHECK CONSTRAINT [FK_SnapshotSectorExpenditure_Sector_SectorID]
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotSectorExpenditure_Snapshot_SnapshotID] FOREIGN KEY([SnapshotID])
REFERENCES [dbo].[Snapshot] ([SnapshotID])
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure] CHECK CONSTRAINT [FK_SnapshotSectorExpenditure_Snapshot_SnapshotID]
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure]  WITH CHECK ADD  CONSTRAINT [CK_SnapshotSectorExpenditure_ExpenditureAmountWholeDollarOnlyNoCents] CHECK  (([ExpenditureAmount]%(1)=(0.0)))
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure] CHECK CONSTRAINT [CK_SnapshotSectorExpenditure_ExpenditureAmountWholeDollarOnlyNoCents]