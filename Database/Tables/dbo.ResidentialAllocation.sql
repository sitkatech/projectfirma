SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResidentialAllocation](
	[ResidentialAllocationID] [int] IDENTITY(1,1) NOT NULL,
	[JurisdictionID] [int] NOT NULL,
	[IssuanceYear] [int] NOT NULL,
	[ResidentialAllocationTypeID] [int] NOT NULL,
	[AllocationSequence] [int] NOT NULL,
	[CommodityPoolDisbursementID] [int] NOT NULL,
	[TdrTransactionID] [int] NULL,
	[WithdrawnTdrTransactionID] [int] NULL,
	[IsAllocatedButNoTransactionRecord] [bit] NOT NULL,
	[CommodityPoolID] [int] NOT NULL,
	[AssignedToJurisdictionID] [int] NULL,
 CONSTRAINT [PK_ResidentialAllocation_ResidentialAllocationID] PRIMARY KEY CLUSTERED 
(
	[ResidentialAllocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ResidentialAllocation_JurisdictionID_IssuanceYear_ResidentialAllocationTypeID_AllocationSequence] UNIQUE NONCLUSTERED 
(
	[JurisdictionID] ASC,
	[IssuanceYear] ASC,
	[ResidentialAllocationTypeID] ASC,
	[AllocationSequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX [AK_ResidentialAllocation_JurisdictionID_IssuanceYear_AllocationSequence] ON [dbo].[ResidentialAllocation]
(
	[JurisdictionID] ASC,
	[IssuanceYear] ASC,
	[AllocationSequence] ASC
)
WHERE ([ResidentialAllocationTypeID]<>(4))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [AK_ResidentialAllocation_JurisdictionID_IssuanceYear_ResidentialAllocationTypeID_AllocationSequence_AssignedToJurisdictionID] ON [dbo].[ResidentialAllocation]
(
	[JurisdictionID] ASC,
	[IssuanceYear] ASC,
	[ResidentialAllocationTypeID] ASC,
	[AllocationSequence] ASC,
	[AssignedToJurisdictionID] ASC
)
WHERE ([ResidentialAllocationTypeID]=(4) AND [AssignedToJurisdictionID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [AK_ResidentialAllocation_TdrTransactionID] ON [dbo].[ResidentialAllocation]
(
	[TdrTransactionID] ASC
)
WHERE ([TdrTransactionID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [AK_ResidentialAllocation_WithdrawnTdrTransactionID] ON [dbo].[ResidentialAllocation]
(
	[WithdrawnTdrTransactionID] ASC
)
WHERE ([WithdrawnTdrTransactionID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_CommodityPool_CommodityPoolID] FOREIGN KEY([CommodityPoolID])
REFERENCES [dbo].[CommodityPool] ([CommodityPoolID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_CommodityPool_CommodityPoolID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_CommodityPool_CommodityPoolID_JurisdictionID] FOREIGN KEY([CommodityPoolID], [JurisdictionID])
REFERENCES [dbo].[CommodityPool] ([CommodityPoolID], [JurisdictionID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_CommodityPool_CommodityPoolID_JurisdictionID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_CommodityPoolDisbursement_CommodityPoolDisbursementID] FOREIGN KEY([CommodityPoolDisbursementID])
REFERENCES [dbo].[CommodityPoolDisbursement] ([CommodityPoolDisbursementID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_CommodityPoolDisbursement_CommodityPoolDisbursementID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_CommodityPoolDisbursement_CommodityPoolID_CommodityPoolDisbursementID] FOREIGN KEY([CommodityPoolID], [CommodityPoolDisbursementID])
REFERENCES [dbo].[CommodityPoolDisbursement] ([CommodityPoolID], [CommodityPoolDisbursementID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_CommodityPoolDisbursement_CommodityPoolID_CommodityPoolDisbursementID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_Jurisdiction_AssignedToJurisdictionID_JurisdictionID] FOREIGN KEY([AssignedToJurisdictionID])
REFERENCES [dbo].[Jurisdiction] ([JurisdictionID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_Jurisdiction_AssignedToJurisdictionID_JurisdictionID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_Jurisdiction_JurisdictionID] FOREIGN KEY([JurisdictionID])
REFERENCES [dbo].[Jurisdiction] ([JurisdictionID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_Jurisdiction_JurisdictionID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_ResidentialAllocationType_ResidentialAllocationTypeID] FOREIGN KEY([ResidentialAllocationTypeID])
REFERENCES [dbo].[ResidentialAllocationType] ([ResidentialAllocationTypeID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_ResidentialAllocationType_ResidentialAllocationTypeID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ResidentialAllocation_TdrTransaction_WithdrawnTdrTransactionID_TdrTransactionID] FOREIGN KEY([WithdrawnTdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [FK_ResidentialAllocation_TdrTransaction_WithdrawnTdrTransactionID_TdrTransactionID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [CK_ResidentialAllocation_AssignedToJurisdictionNotNullWhenAllocationPoolTransactionHasTransactionID] CHECK  (([AssignedToJurisdictionID] IS NOT NULL AND [TdrTransactionID] IS NOT NULL AND [ResidentialAllocationTypeID]=(4) OR [AssignedToJurisdictionID] IS NULL AND [TdrTransactionID] IS NULL AND [ResidentialAllocationTypeID]=(4) OR [ResidentialAllocationTypeID]<>(4)))
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [CK_ResidentialAllocation_AssignedToJurisdictionNotNullWhenAllocationPoolTransactionHasTransactionID]
GO
ALTER TABLE [dbo].[ResidentialAllocation]  WITH CHECK ADD  CONSTRAINT [CK_ResidentialAllocation_OnlyTRPAPoolCanHaveAssignedToJurisdictionID] CHECK  (([AssignedToJurisdictionID] IS NOT NULL AND [ResidentialAllocationTypeID]=(4) OR [AssignedToJurisdictionID] IS NULL))
GO
ALTER TABLE [dbo].[ResidentialAllocation] CHECK CONSTRAINT [CK_ResidentialAllocation_OnlyTRPAPoolCanHaveAssignedToJurisdictionID]