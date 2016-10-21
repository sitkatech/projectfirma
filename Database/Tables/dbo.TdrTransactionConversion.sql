SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransactionConversion](
	[TdrTransactionConversionID] [int] IDENTITY(1,1) NOT NULL,
	[TdrTransactionID] [int] NOT NULL,
	[LandBankID] [int] NULL,
	[ParcelID] [int] NOT NULL,
	[OwnershipID] [int] NOT NULL,
	[CommodityConvertedToID] [int] NOT NULL,
	[IPESScore] [smallint] NULL,
	[BaileyRatingID] [int] NULL,
	[SendingQuantity] [int] NOT NULL,
	[ReceivingQuantity] [int] NOT NULL,
 CONSTRAINT [PK_TdrTransactionConversion_TdrTransactionConversionID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionConversionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TdrTransactionConversion_TdrTransactionID] UNIQUE NONCLUSTERED 
(
	[TdrTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversion_BaileyRating_BaileyRatingID] FOREIGN KEY([BaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [FK_TdrTransactionConversion_BaileyRating_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversion_Commodity_CommodityConvertedToID_CommodityID] FOREIGN KEY([CommodityConvertedToID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [FK_TdrTransactionConversion_Commodity_CommodityConvertedToID_CommodityID]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversion_LandBank_LandBankID] FOREIGN KEY([LandBankID])
REFERENCES [dbo].[LandBank] ([LandBankID])
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [FK_TdrTransactionConversion_LandBank_LandBankID]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversion_Ownership_OwnershipID] FOREIGN KEY([OwnershipID])
REFERENCES [dbo].[Ownership] ([OwnershipID])
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [FK_TdrTransactionConversion_Ownership_OwnershipID]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversion_Parcel_ParcelID] FOREIGN KEY([ParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [FK_TdrTransactionConversion_Parcel_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionConversion_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [FK_TdrTransactionConversion_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversion_IPESScore_ValidRange] CHECK  (([IPESScore]>=(0) AND [IPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [CK_TdrTransactionConversion_IPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversion_IPESScoreXOrBaileyRatingID] CHECK  (([IPESScore] IS NOT NULL AND [BaileyRatingID] IS NULL OR [IPESScore] IS NULL AND [BaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [CK_TdrTransactionConversion_IPESScoreXOrBaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversion_ReceivingQuantity_ValidRange] CHECK  (([ReceivingQuantity]>=(1) AND [ReceivingQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [CK_TdrTransactionConversion_ReceivingQuantity_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionConversion]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionConversion_SendingQuantity_ValidRange] CHECK  (([SendingQuantity]>=(1) AND [SendingQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionConversion] CHECK CONSTRAINT [CK_TdrTransactionConversion_SendingQuantity_ValidRange]