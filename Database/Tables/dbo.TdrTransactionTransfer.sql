SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransactionTransfer](
	[TdrTransactionTransferID] [int] IDENTITY(1,1) NOT NULL,
	[TdrTransactionID] [int] NOT NULL,
	[SendingLandBankID] [int] NULL,
	[SendingParcelID] [int] NOT NULL,
	[SendingQuantity] [int] NOT NULL,
	[SendingIPESScore] [smallint] NULL,
	[SendingBaileyRatingID] [int] NULL,
	[ReceivingOwnershipID] [int] NOT NULL,
	[ReceivingParcelID] [int] NOT NULL,
	[ReceivingQuantity] [int] NOT NULL,
	[ReceivingIPESScore] [smallint] NULL,
	[ReceivingBaileyRatingID] [int] NULL,
	[TransferPrice] [money] NULL,
	[RetiredQuantity] [int] NULL,
 CONSTRAINT [PK_TdrTransactionTransfer_TdrTransactionTransferID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionTransferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TdrTransactionTransfer_TdrTransactionID] UNIQUE NONCLUSTERED 
(
	[TdrTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionTransfer_BaileyRating_ReceivingBaileyRatingID_BaileyRatingID] FOREIGN KEY([ReceivingBaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [FK_TdrTransactionTransfer_BaileyRating_ReceivingBaileyRatingID_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionTransfer_BaileyRating_SendingBaileyRatingID_BaileyRatingID] FOREIGN KEY([SendingBaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [FK_TdrTransactionTransfer_BaileyRating_SendingBaileyRatingID_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionTransfer_LandBank_SendingLandBankID_LandBankID] FOREIGN KEY([SendingLandBankID])
REFERENCES [dbo].[LandBank] ([LandBankID])
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [FK_TdrTransactionTransfer_LandBank_SendingLandBankID_LandBankID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionTransfer_Ownership_ReceivingOwnershipID_OwnershipID] FOREIGN KEY([ReceivingOwnershipID])
REFERENCES [dbo].[Ownership] ([OwnershipID])
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [FK_TdrTransactionTransfer_Ownership_ReceivingOwnershipID_OwnershipID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionTransfer_Parcel_ReceivingParcelID_ParcelID] FOREIGN KEY([ReceivingParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [FK_TdrTransactionTransfer_Parcel_ReceivingParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionTransfer_Parcel_SendingParcelID_ParcelID] FOREIGN KEY([SendingParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [FK_TdrTransactionTransfer_Parcel_SendingParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionTransfer_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [FK_TdrTransactionTransfer_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_ReceivingIPESScore_ValidRange] CHECK  (([ReceivingIPESScore]>=(0) AND [ReceivingIPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_ReceivingIPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_ReceivingIPESScoreXOrReceivingBaileyRatingID] CHECK  (([ReceivingIPESScore] IS NOT NULL AND [ReceivingBaileyRatingID] IS NULL OR [ReceivingIPESScore] IS NULL AND [ReceivingBaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_ReceivingIPESScoreXOrReceivingBaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_ReceivingQuantity_ValidRange] CHECK  (([ReceivingQuantity]>=(1) AND [ReceivingQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_ReceivingQuantity_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_RetiredQuantityNullWhenNotBailey1BCoverageTransfer] CHECK  (([RetiredQuantity] IS NULL OR [SendingBaileyRatingID]=(2)))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_RetiredQuantityNullWhenNotBailey1BCoverageTransfer]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_SendingIPESScore_ValidRange] CHECK  (([SendingIPESScore]>=(0) AND [SendingIPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_SendingIPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_SendingIPESScoreXOrSendingBaileyRatingID] CHECK  (([SendingIPESScore] IS NOT NULL AND [SendingBaileyRatingID] IS NULL OR [SendingIPESScore] IS NULL AND [SendingBaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_SendingIPESScoreXOrSendingBaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_SendingParcelID_ReceivingParcelID_NotEqual] CHECK  (([SendingParcelID] IS NULL AND [ReceivingParcelID] IS NULL OR [SendingParcelID]<>[ReceivingParcelID]))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_SendingParcelID_ReceivingParcelID_NotEqual]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_SendingQuantity_ValidRange] CHECK  (([SendingQuantity]>=(1) AND [SendingQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_SendingQuantity_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionTransfer_SendingQuantityGreaterThanReceivingQuantity] CHECK  (([SendingQuantity]>=[ReceivingQuantity]))
GO
ALTER TABLE [dbo].[TdrTransactionTransfer] CHECK CONSTRAINT [CK_TdrTransactionTransfer_SendingQuantityGreaterThanReceivingQuantity]