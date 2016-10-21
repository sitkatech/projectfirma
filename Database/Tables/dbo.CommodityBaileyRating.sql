SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommodityBaileyRating](
	[CommodityBaileyRatingID] [int] IDENTITY(1,1) NOT NULL,
	[CommodityID] [int] NOT NULL,
	[BaileyRatingID] [int] NULL,
 CONSTRAINT [PK_CommodityBaileyRating_CommodityBaileyRatingID] PRIMARY KEY CLUSTERED 
(
	[CommodityBaileyRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CommodityBaileyRating_CommodityID_BaileyRatingID] UNIQUE NONCLUSTERED 
(
	[CommodityID] ASC,
	[BaileyRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CommodityBaileyRating]  WITH CHECK ADD  CONSTRAINT [FK_CommodityBaileyRating_BaileyRating_BaileyRatingID] FOREIGN KEY([BaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[CommodityBaileyRating] CHECK CONSTRAINT [FK_CommodityBaileyRating_BaileyRating_BaileyRatingID]
GO
ALTER TABLE [dbo].[CommodityBaileyRating]  WITH CHECK ADD  CONSTRAINT [FK_CommodityBaileyRating_Commodity_CommodityID] FOREIGN KEY([CommodityID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[CommodityBaileyRating] CHECK CONSTRAINT [FK_CommodityBaileyRating_Commodity_CommodityID]