SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelCommodityBaileyRatingConfirmationStatus](
	[ParcelCommodityBaileyRatingConfirmationStatusID] [int] NOT NULL,
	[ParcelCommodityBaileyRatingConfirmationStatusName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ParcelCommodityBaileyRatingConfirmationStatus_ParcelCommodityBaileyRatingConfirmationStatusID] PRIMARY KEY CLUSTERED 
(
	[ParcelCommodityBaileyRatingConfirmationStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
