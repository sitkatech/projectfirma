SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankedCommodity](
	[BankedCommodityID] [int] IDENTITY(1,1) NOT NULL,
	[ParcelID] [int] NOT NULL,
	[CommodityBaileyRatingID] [int] NOT NULL,
	[BankedQuantity] [int] NOT NULL,
	[BankedDate] [datetime] NOT NULL,
	[BankedCommodityNotes] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccelaCAPRecordID] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[LastUpdatePersonID] [int] NOT NULL,
 CONSTRAINT [PK_BankedCommodity_BankedCommodityID] PRIMARY KEY CLUSTERED 
(
	[BankedCommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BankedCommodity]  WITH CHECK ADD  CONSTRAINT [FK_BankedCommodity_CommodityBaileyRating_CommodityBaileyRatingID] FOREIGN KEY([CommodityBaileyRatingID])
REFERENCES [dbo].[CommodityBaileyRating] ([CommodityBaileyRatingID])
GO
ALTER TABLE [dbo].[BankedCommodity] CHECK CONSTRAINT [FK_BankedCommodity_CommodityBaileyRating_CommodityBaileyRatingID]
GO
ALTER TABLE [dbo].[BankedCommodity]  WITH CHECK ADD  CONSTRAINT [FK_BankedCommodity_Parcel_ParcelID] FOREIGN KEY([ParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[BankedCommodity] CHECK CONSTRAINT [FK_BankedCommodity_Parcel_ParcelID]
GO
ALTER TABLE [dbo].[BankedCommodity]  WITH CHECK ADD  CONSTRAINT [FK_BankedCommodity_Person_LastUpdatePersonID_PersonID] FOREIGN KEY([LastUpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[BankedCommodity] CHECK CONSTRAINT [FK_BankedCommodity_Person_LastUpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[BankedCommodity]  WITH CHECK ADD  CONSTRAINT [CK_BankedCommodity_BankedQuantity_GreaterThanZero] CHECK  (([BankedQuantity]>(0)))
GO
ALTER TABLE [dbo].[BankedCommodity] CHECK CONSTRAINT [CK_BankedCommodity_BankedQuantity_GreaterThanZero]