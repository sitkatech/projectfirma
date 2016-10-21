SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommodityConvertedToCommodity](
	[CommodityConvertedToCommodityID] [int] IDENTITY(1,1) NOT NULL,
	[CommodityID] [int] NOT NULL,
	[ConvertedToCommodityID] [int] NOT NULL,
 CONSTRAINT [PK_CommodityConvertedToCommodity_CommodityConvertedToCommodityID] PRIMARY KEY CLUSTERED 
(
	[CommodityConvertedToCommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CommodityConvertedToCommodity_CommodityID_ConvertedToCommodityID] UNIQUE NONCLUSTERED 
(
	[CommodityID] ASC,
	[ConvertedToCommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CommodityConvertedToCommodity]  WITH CHECK ADD  CONSTRAINT [FK_CommodityConvertedToCommodity_Commodity_CommodityID] FOREIGN KEY([CommodityID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[CommodityConvertedToCommodity] CHECK CONSTRAINT [FK_CommodityConvertedToCommodity_Commodity_CommodityID]
GO
ALTER TABLE [dbo].[CommodityConvertedToCommodity]  WITH CHECK ADD  CONSTRAINT [FK_CommodityConvertedToCommodity_Commodity_ConvertedToCommodityID_CommodityID] FOREIGN KEY([ConvertedToCommodityID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[CommodityConvertedToCommodity] CHECK CONSTRAINT [FK_CommodityConvertedToCommodity_Commodity_ConvertedToCommodityID_CommodityID]