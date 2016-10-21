SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TdrTransactionECMRetirement](
	[TdrTransactionECMRetirementID] [int] IDENTITY(1,1) NOT NULL,
	[TdrTransactionID] [int] NOT NULL,
	[LandBankID] [int] NOT NULL,
	[SendingParcelID] [int] NOT NULL,
	[RetirementQuantity] [int] NOT NULL,
	[SendingIPESScore] [smallint] NULL,
	[SendingBaileyRatingID] [int] NULL,
	[TransferPrice] [money] NOT NULL,
 CONSTRAINT [PK_TdrTransactionECMRetirement_TdrTransactionECMRetirementID] PRIMARY KEY CLUSTERED 
(
	[TdrTransactionECMRetirementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TdrTransactionECMRetirement_TdrTransactionID] UNIQUE NONCLUSTERED 
(
	[TdrTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionECMRetirement_BaileyRating_SendingBaileyRatingID_BaileyRatingID] FOREIGN KEY([SendingBaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement] CHECK CONSTRAINT [FK_TdrTransactionECMRetirement_BaileyRating_SendingBaileyRatingID_BaileyRatingID]
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionECMRetirement_LandBank_LandBankID] FOREIGN KEY([LandBankID])
REFERENCES [dbo].[LandBank] ([LandBankID])
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement] CHECK CONSTRAINT [FK_TdrTransactionECMRetirement_LandBank_LandBankID]
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionECMRetirement_Parcel_SendingParcelID_ParcelID] FOREIGN KEY([SendingParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement] CHECK CONSTRAINT [FK_TdrTransactionECMRetirement_Parcel_SendingParcelID_ParcelID]
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement]  WITH CHECK ADD  CONSTRAINT [FK_TdrTransactionECMRetirement_TdrTransaction_TdrTransactionID] FOREIGN KEY([TdrTransactionID])
REFERENCES [dbo].[TdrTransaction] ([TdrTransactionID])
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement] CHECK CONSTRAINT [FK_TdrTransactionECMRetirement_TdrTransaction_TdrTransactionID]
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionECMRetirement_RetirementQuantity_ValidRange] CHECK  (([RetirementQuantity]>=(1) AND [RetirementQuantity]<=(9999999)))
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement] CHECK CONSTRAINT [CK_TdrTransactionECMRetirement_RetirementQuantity_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionECMRetirement_SendingIPESScore_ValidRange] CHECK  (([SendingIPESScore]>=(0) AND [SendingIPESScore]<=(1150)))
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement] CHECK CONSTRAINT [CK_TdrTransactionECMRetirement_SendingIPESScore_ValidRange]
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement]  WITH CHECK ADD  CONSTRAINT [CK_TdrTransactionECMRetirement_SendingIPESScoreXOrSendingBaileyRatingID] CHECK  (([SendingIPESScore] IS NOT NULL AND [SendingBaileyRatingID] IS NULL OR [SendingIPESScore] IS NULL AND [SendingBaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[TdrTransactionECMRetirement] CHECK CONSTRAINT [CK_TdrTransactionECMRetirement_SendingIPESScoreXOrSendingBaileyRatingID]