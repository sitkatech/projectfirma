SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransactionAllocation](
	[TdrTransactionAllocationID] [int] IDENTITY(1,1) NOT NULL,
	[TdrTransactionID] [int] NOT NULL,
	[SendingAllocationPoolID] [int] NOT NULL,
	[ReceivingOwnershipID] [int] NOT NULL,
	[ReceivingParcelID] [int] NOT NULL,
	[AllocatedQuantity] [int] NOT NULL,
	[ReceivingIPESScore] [smallint] NULL,
	[ReceivingBaileyRatingID] [int] NULL,
	[ResidentialAllocationFeeReceived] [bit] NULL,
 CONSTRAINT [PK_TdrTransactionAllocation_TdrTransactionAllocationID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionAllocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TdrTransactionAllocation_TdrTransactionID] UNIQUE NONCLUSTERED 
(
	[TdrTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransactionAllocation]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocation_BaileyRating_ReceivingBaileyRatingID_BaileyRatingID] FOREIGN KEY([ReceivingBaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocation] CHECK CONSTRAINT [FK_TdrTransactionAllocation_BaileyRating_ReceivingBaileyRatingID_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocation]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocation_CommodityPool_SendingAllocationPoolID_CommodityPoolID] FOREIGN KEY([SendingAllocationPoolID])
REFERENCES [dbo].[CommodityPool] ([CommodityPoolID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocation] CHECK CONSTRAINT [FK_TdrTransactionAllocation_CommodityPool_SendingAllocationPoolID_CommodityPoolID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocation]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocation_Ownership_ReceivingOwnershipID_OwnershipID] FOREIGN KEY([ReceivingOwnershipID])
REFERENCES [dbo].[Ownership] ([OwnershipID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocation] CHECK CONSTRAINT [FK_TdrTransactionAllocation_Ownership_ReceivingOwnershipID_OwnershipID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocation]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocation_Parcel_ReceivingParcelID_ParcelID] FOREIGN KEY([ReceivingParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocation] CHECK CONSTRAINT [FK_TdrTransactionAllocation_Parcel_ReceivingParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocation]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocation_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocation] CHECK CONSTRAINT [FK_TdrTransactionAllocation_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocation]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionAllocation_AllocatedQuantity_ValidRange] CHECK  (([AllocatedQuantity]>=(1) AND [AllocatedQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionAllocation] CHECK CONSTRAINT [CK_TdrTransactionAllocation_AllocatedQuantity_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionAllocation]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionAllocation_ReceivingIPESScore_ValidRange] CHECK  (([ReceivingIPESScore]>=(0) AND [ReceivingIPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionAllocation] CHECK CONSTRAINT [CK_TdrTransactionAllocation_ReceivingIPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionAllocation]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionAllocation_ReceivingIPESScoreXOrReceivingBaileyRatingID] CHECK  (([ReceivingIPESScore] IS NOT NULL AND [ReceivingBaileyRatingID] IS NULL OR [ReceivingIPESScore] IS NULL AND [ReceivingBaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionAllocation] CHECK CONSTRAINT [CK_TdrTransactionAllocation_ReceivingIPESScoreXOrReceivingBaileyRatingID]