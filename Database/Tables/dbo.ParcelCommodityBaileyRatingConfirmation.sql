SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation](
	[ParcelCommodityBaileyRatingConfirmationID] [int] IDENTITY(1,1) NOT NULL,
	[ParcelID] [int] NOT NULL,
	[CommodityID] [int] NOT NULL,
	[BaileyRatingID] [int] NULL,
	[ParcelCommodityBaileyRatingConfirmationStatusID] [int] NOT NULL,
	[ConfirmedByPersonID] [int] NOT NULL,
	[ConfirmationDate] [datetime] NOT NULL,
	[ConfirmationNotes] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ParcelCommodityBaileyRatingConfirmation_ParcelCommodityBaileyRatingConfirmationID] PRIMARY KEY CLUSTERED 
(
	[ParcelCommodityBaileyRatingConfirmationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelCommodityBaileyRatingConfirmation_ParcelID_CommodityID_BaileyRatingID] UNIQUE NONCLUSTERED 
(
	[ParcelID] ASC,
	[CommodityID] ASC,
	[BaileyRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation]  WITH CHECK ADD  CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_BaileyRating_BaileyRatingID] FOREIGN KEY([BaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation] CHECK CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_BaileyRating_BaileyRatingID]
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation]  WITH CHECK ADD  CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_Commodity_CommodityID] FOREIGN KEY([CommodityID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation] CHECK CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_Commodity_CommodityID]
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation]  WITH CHECK ADD  CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_Parcel_ParcelID] FOREIGN KEY([ParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation] CHECK CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_Parcel_ParcelID]
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation]  WITH CHECK ADD  CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_ParcelCommodityBaileyRatingConfirmationStatus_ParcelCommodityBaileyRatingConfirmation] FOREIGN KEY([ParcelCommodityBaileyRatingConfirmationStatusID])
REFERENCES [dbo].[ParcelCommodityBaileyRatingConfirmationStatus] ([ParcelCommodityBaileyRatingConfirmationStatusID])
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation] CHECK CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_ParcelCommodityBaileyRatingConfirmationStatus_ParcelCommodityBaileyRatingConfirmation]
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation]  WITH CHECK ADD  CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_Person_ConfirmedByPersonID_PersonID] FOREIGN KEY([ConfirmedByPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ParcelCommodityBaileyRatingConfirmation] CHECK CONSTRAINT [FK_ParcelCommodityBaileyRatingConfirmation_Person_ConfirmedByPersonID_PersonID]