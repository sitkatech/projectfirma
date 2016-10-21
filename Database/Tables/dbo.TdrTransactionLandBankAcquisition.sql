SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransactionLandBankAcquisition](
	[TdrTransactionLandBankAcquisitionID] [int] IDENTITY(1,1) NOT NULL,
	[TdrTransactionID] [int] NOT NULL,
	[SendingParcelID] [int] NOT NULL,
	[SendingQuantity] [int] NOT NULL,
	[SendingIPESScore] [smallint] NULL,
	[SendingBaileyRatingID] [int] NULL,
	[LandBankID] [int] NOT NULL,
	[ReceivingCommodityConvertedToID] [int] NULL,
	[TransferPrice] [money] NOT NULL,
 CONSTRAINT [PK_TdrTransactionLandBankAcquisition_TdrTransactionLandBankAcquisitionID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionLandBankAcquisitionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TdrTransactionLandBankAcquisition_TdrTransactionID] UNIQUE NONCLUSTERED 
(
	[TdrTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionLandBankAcquisition_BaileyRating_SendingBaileyRatingID_BaileyRatingID] FOREIGN KEY([SendingBaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition] CHECK CONSTRAINT [FK_TdrTransactionLandBankAcquisition_BaileyRating_SendingBaileyRatingID_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionLandBankAcquisition_Commodity_ReceivingCommodityConvertedToID_CommodityID] FOREIGN KEY([ReceivingCommodityConvertedToID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition] CHECK CONSTRAINT [FK_TdrTransactionLandBankAcquisition_Commodity_ReceivingCommodityConvertedToID_CommodityID]
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionLandBankAcquisition_LandBank_LandBankID] FOREIGN KEY([LandBankID])
REFERENCES [dbo].[LandBank] ([LandBankID])
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition] CHECK CONSTRAINT [FK_TdrTransactionLandBankAcquisition_LandBank_LandBankID]
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionLandBankAcquisition_Parcel_SendingParcelID_ParcelID] FOREIGN KEY([SendingParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition] CHECK CONSTRAINT [FK_TdrTransactionLandBankAcquisition_Parcel_SendingParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionLandBankAcquisition_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition] CHECK CONSTRAINT [FK_TdrTransactionLandBankAcquisition_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionLandBankAcquisition_SendingIPESScore_ValidRange] CHECK  (([SendingIPESScore]>=(0) AND [SendingIPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition] CHECK CONSTRAINT [CK_TdrTransactionLandBankAcquisition_SendingIPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionLandBankAcquisition_SendingIPESScoreXOrSendingBaileyRatingID] CHECK  (([SendingIPESScore] IS NOT NULL AND [SendingBaileyRatingID] IS NULL OR [SendingIPESScore] IS NULL AND [SendingBaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition] CHECK CONSTRAINT [CK_TdrTransactionLandBankAcquisition_SendingIPESScoreXOrSendingBaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionLandBankAcquisition_SendingQuantity_ValidRange] CHECK  (([SendingQuantity]>=(1) AND [SendingQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionLandBankAcquisition] CHECK CONSTRAINT [CK_TdrTransactionLandBankAcquisition_SendingQuantity_ValidRange]