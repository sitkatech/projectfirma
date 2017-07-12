SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotSectorExpenditure](
	[SnapshotSectorExpenditureID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SnapshotID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ExpenditureAmount] [money] NOT NULL,
	[OrganizationTypeID] [int] NOT NULL,
 CONSTRAINT [PK_SnapshotSectorExpenditure_SnapshotSectorExpenditureID] PRIMARY KEY CLUSTERED 
(
	[SnapshotSectorExpenditureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SnapshotSectorExpenditure_SnapshotID_OrganizationTypeID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[SnapshotID] ASC,
	[OrganizationTypeID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotSectorExpenditure_OrganizationType_OrganizationTypeID] FOREIGN KEY([OrganizationTypeID])
REFERENCES [dbo].[OrganizationType] ([OrganizationTypeID])
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure] CHECK CONSTRAINT [FK_SnapshotSectorExpenditure_OrganizationType_OrganizationTypeID]
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotSectorExpenditure_Snapshot_SnapshotID] FOREIGN KEY([SnapshotID])
REFERENCES [dbo].[Snapshot] ([SnapshotID])
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure] CHECK CONSTRAINT [FK_SnapshotSectorExpenditure_Snapshot_SnapshotID]
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotSectorExpenditure_Snapshot_SnapshotID_TenantID] FOREIGN KEY([SnapshotID], [TenantID])
REFERENCES [dbo].[Snapshot] ([SnapshotID], [TenantID])
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure] CHECK CONSTRAINT [FK_SnapshotSectorExpenditure_Snapshot_SnapshotID_TenantID]
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotSectorExpenditure_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure] CHECK CONSTRAINT [FK_SnapshotSectorExpenditure_Tenant_TenantID]
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure]  WITH CHECK ADD  CONSTRAINT [CK_SnapshotSectorExpenditure_ExpenditureAmountWholeDollarOnlyNoCents] CHECK  (([ExpenditureAmount]%(1)=(0.0)))
GO
ALTER TABLE [dbo].[SnapshotSectorExpenditure] CHECK CONSTRAINT [CK_SnapshotSectorExpenditure_ExpenditureAmountWholeDollarOnlyNoCents]