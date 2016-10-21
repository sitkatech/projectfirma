SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransactionConversionWithTransfer](
	[TdrTransactionConversionWithTransferID] [int] IDENTITY(1,1) NOT NULL,
	[TdrTransactionID] [int] NOT NULL,
	[SendingOwnershipID] [int] NOT NULL,
	[SendingParcelID] [int] NOT NULL,
	[SendingLandBankID] [int] NULL,
	[ReceivingOwnershipID] [int] NOT NULL,
	[ReceivingParcelID] [int] NOT NULL,
	[SendingIPESScore] [smallint] NULL,
	[SendingBaileyRatingID] [int] NULL,
	[ReceivingIPESScore] [smallint] NULL,
	[ReceivingBaileyRatingID] [int] NULL,
	[SendingQuantity] [int] NOT NULL,
	[ReceivingQuantity] [int] NOT NULL,
	[CommodityConvertedToID] [int] NOT NULL,
	[TransferPrice] [money] NULL,
	[TransferApprovalDate] [smalldatetime] NULL,
 CONSTRAINT [PK_TdrTransactionConversionWithTransfer_TdrTransactionConversionWithTransferID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionConversionWithTransferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TdrTransactionConversionWithTransfer_TdrTransactionID] UNIQUE NONCLUSTERED 
(
	[TdrTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_BaileyRating_ReceivingBaileyRatingID_BaileyRatingID] FOREIGN KEY([ReceivingBaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_BaileyRating_ReceivingBaileyRatingID_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_BaileyRating_SendingBaileyRatingID_BaileyRatingID] FOREIGN KEY([SendingBaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_BaileyRating_SendingBaileyRatingID_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Commodity_CommodityConvertedToID_CommodityID] FOREIGN KEY([CommodityConvertedToID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Commodity_CommodityConvertedToID_CommodityID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_LandBank_SendingLandBankID_LandBankID] FOREIGN KEY([SendingLandBankID])
REFERENCES [dbo].[LandBank] ([LandBankID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_LandBank_SendingLandBankID_LandBankID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Ownership_ReceivingOwnershipID_OwnershipID] FOREIGN KEY([ReceivingOwnershipID])
REFERENCES [dbo].[Ownership] ([OwnershipID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Ownership_ReceivingOwnershipID_OwnershipID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Ownership_SendingOwnershipID_OwnershipID] FOREIGN KEY([SendingOwnershipID])
REFERENCES [dbo].[Ownership] ([OwnershipID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Ownership_SendingOwnershipID_OwnershipID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Parcel_ReceivingParcelID_ParcelID] FOREIGN KEY([ReceivingParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Parcel_ReceivingParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Parcel_SendingParcelID_ParcelID] FOREIGN KEY([SendingParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_Parcel_SendingParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversionWithTransfer_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [FK_TdrTransactionConversionWithTransfer_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversionWithTransfer_ReceivingIPESScore_ValidRange] CHECK  (([ReceivingIPESScore]>=(0) AND [ReceivingIPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [CK_TdrTransactionConversionWithTransfer_ReceivingIPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversionWithTransfer_ReceivingIPESScoreXOrReceivingBaileyRatingID] CHECK  (([ReceivingIPESScore] IS NOT NULL AND [ReceivingBaileyRatingID] IS NULL OR [ReceivingIPESScore] IS NULL AND [ReceivingBaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [CK_TdrTransactionConversionWithTransfer_ReceivingIPESScoreXOrReceivingBaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversionWithTransfer_ReceivingQuantity_ValidRange] CHECK  (([ReceivingQuantity]>=(1) AND [ReceivingQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [CK_TdrTransactionConversionWithTransfer_ReceivingQuantity_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversionWithTransfer_SendingIPESScore_ValidRange] CHECK  (([SendingIPESScore]>=(0) AND [SendingIPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [CK_TdrTransactionConversionWithTransfer_SendingIPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversionWithTransfer_SendingIPESScoreXOrSendingBaileyRatingID] CHECK  (([SendingIPESScore] IS NOT NULL AND [SendingBaileyRatingID] IS NULL OR [SendingIPESScore] IS NULL AND [SendingBaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [CK_TdrTransactionConversionWithTransfer_SendingIPESScoreXOrSendingBaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversionWithTransfer_SendingParcelID_ReceivingParcelID_NotEqual] CHECK  (([SendingParcelID] IS NULL AND [ReceivingParcelID] IS NULL OR [SendingParcelID]<>[ReceivingParcelID]))
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [CK_TdrTransactionConversionWithTransfer_SendingParcelID_ReceivingParcelID_NotEqual]
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversionWithTransfer_SendingQuantity_ValidRange] CHECK  (([SendingQuantity]>=(1) AND [SendingQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionConversionWithTransfer] CHECK CONSTRAINT [CK_TdrTransactionConversionWithTransfer_SendingQuantity_ValidRange]