SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTypeCommodity](
	[TransactionTypeCommodityID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeID] [int] NOT NULL,
	[CommodityID] [int] NOT NULL,
 CONSTRAINT [PK_TransactionTypeCommodity_TransactionTypeCommodityID] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeCommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransactionTypeCommodity_TransactionTypeCommodityID_TransactionTypeID_CommodityID] UNIQUE NONCLUSTERED 
(
	[TransactionTypeCommodityID] ASC,
	[TransactionTypeID] ASC,
	[CommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransactionTypeCommodity_TransactionTypeID_CommodityID] UNIQUE NONCLUSTERED 
(
	[TransactionTypeID] ASC,
	[CommodityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TransactionTypeCommodity]  WITH CHECK ADD  CONSTRAINT [FK_TransactionTypeCommodity_Commodity_CommodityID] FOREIGN KEY([CommodityID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[TransactionTypeCommodity] CHECK CONSTRAINT [FK_TransactionTypeCommodity_Commodity_CommodityID]
GO
ALTER TABLE [dbo].[TransactionTypeCommodity]  WITH CHECK ADD  CONSTRAINT [FK_TransactionTypeCommodity_TransactionType_TransactionTypeID] FOREIGN KEY([TransactionTypeID])
REFERENCES [dbo].[TransactionType] ([TransactionTypeID])
GO
ALTER TABLE [dbo].[TransactionTypeCommodity] CHECK CONSTRAINT [FK_TransactionTypeCommodity_TransactionType_TransactionTypeID]