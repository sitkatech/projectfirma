SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commodity](
	[CommodityID] [int] NOT NULL,
	[CommodityName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CommodityDisplayName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CommodityUnitTypeID] [int] NOT NULL,
	[IsCoverage] [bit] NOT NULL,
	[CanHaveLandCapability] [bit] NOT NULL,
	[CommodityShortName] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
	[CanHaveCommodityPool] [bit] NOT NULL,
 CONSTRAINT [PK_Commodity_CommodityID] PRIMARY KEY CLUSTERED 
(
	[CommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Commodity_CommodityDisplayName] UNIQUE NONCLUSTERED 
(
	[CommodityDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Commodity_CommodityName] UNIQUE NONCLUSTERED 
(
	[CommodityName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Commodity]  WITH CHECK ADD  CONSTRAINT [FK_Commodity_CommodityUnitType_CommodityUnitTypeID] FOREIGN KEY([CommodityUnitTypeID])
REFERENCES [dbo].[CommodityUnitType] ([CommodityUnitTypeID])
GO
ALTER TABLE [dbo].[Commodity] CHECK CONSTRAINT [FK_Commodity_CommodityUnitType_CommodityUnitTypeID]