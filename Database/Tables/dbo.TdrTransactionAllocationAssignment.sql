SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransactionAllocationAssignment](
	[TdrTransactionAllocationAssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[TdrTransactionID] [int] NOT NULL,
	[SendingAllocationPoolID] [int] NOT NULL,
	[RetiredSensitiveOwnershipID] [int] NOT NULL,
	[RetiredSensitiveParcelID] [int] NOT NULL,
	[ReceivingOwnershipID] [int] NOT NULL,
	[ReceivingParcelID] [int] NOT NULL,
	[AllocatedQuantity] [int] NOT NULL,
	[ReceivingIPESScore] [smallint] NULL,
	[ReceivingBaileyRatingID] [int] NULL,
	[ResidentialAllocationFeeReceived] [bit] NULL,
 CONSTRAINT [PK_TdrTransactionAllocationAssignment_TdrTransactionAllocationAssignmentID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionAllocationAssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TdrTransactionAllocationAssignment_TdrTransactionID] UNIQUE NONCLUSTERED 
(
	[TdrTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocationAssignment_BaileyRating_ReceivingBaileyRatingID_BaileyRatingID] FOREIGN KEY([ReceivingBaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [FK_TdrTransactionAllocationAssignment_BaileyRating_ReceivingBaileyRatingID_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocationAssignment_CommodityPool_SendingAllocationPoolID_CommodityPoolID] FOREIGN KEY([SendingAllocationPoolID])
REFERENCES [dbo].[CommodityPool] ([CommodityPoolID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [FK_TdrTransactionAllocationAssignment_CommodityPool_SendingAllocationPoolID_CommodityPoolID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocationAssignment_Ownership_ReceivingOwnershipID_OwnershipID] FOREIGN KEY([ReceivingOwnershipID])
REFERENCES [dbo].[Ownership] ([OwnershipID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [FK_TdrTransactionAllocationAssignment_Ownership_ReceivingOwnershipID_OwnershipID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocationAssignment_Ownership_RetiredSensitiveOwnershipID_OwnershipID] FOREIGN KEY([RetiredSensitiveOwnershipID])
REFERENCES [dbo].[Ownership] ([OwnershipID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [FK_TdrTransactionAllocationAssignment_Ownership_RetiredSensitiveOwnershipID_OwnershipID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocationAssignment_Parcel_ReceivingParcelID_ParcelID] FOREIGN KEY([ReceivingParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [FK_TdrTransactionAllocationAssignment_Parcel_ReceivingParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocationAssignment_Parcel_RetiredSensitiveParcelID_ParcelID] FOREIGN KEY([RetiredSensitiveParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [FK_TdrTransactionAllocationAssignment_Parcel_RetiredSensitiveParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionAllocationAssignment_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [FK_TdrTransactionAllocationAssignment_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionAllocationAssignment_AllocatedQuantity_ValidRange] CHECK  (([AllocatedQuantity]>=(1) AND [AllocatedQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [CK_TdrTransactionAllocationAssignment_AllocatedQuantity_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionAllocationAssignment_ReceivingIPESScore_ValidRange] CHECK  (([ReceivingIPESScore]>=(0) AND [ReceivingIPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [CK_TdrTransactionAllocationAssignment_ReceivingIPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionAllocationAssignment_ReceivingIPESScoreXOrReceivingBaileyRatingID] CHECK  (([ReceivingIPESScore] IS NOT NULL AND [ReceivingBaileyRatingID] IS NULL OR [ReceivingIPESScore] IS NULL AND [ReceivingBaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [CK_TdrTransactionAllocationAssignment_ReceivingIPESScoreXOrReceivingBaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionAllocationAssignment_TrpaPoolOnly] CHECK  (([SendingAllocationPoolID]=(74)))
GO
ALTER TABLE [dbo].[TdrTransactionAllocationAssignment] CHECK CONSTRAINT [CK_TdrTransactionAllocationAssignment_TrpaPoolOnly]