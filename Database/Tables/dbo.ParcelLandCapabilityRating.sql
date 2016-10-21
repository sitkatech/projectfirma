SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelLandCapabilityRating](
	[ParcelLandCapabilityRatingID] [int] IDENTITY(1,1) NOT NULL,
	[ParcelLandCapabilityID] [int] NOT NULL,
	[LandCapabilityTypeID] [int] NOT NULL,
	[BaileyRatingID] [int] NULL,
	[IPESScore] [smallint] NULL,
	[SquareFootage] [int] NULL,
 CONSTRAINT [PK_ParcelLandCapabilityRating_ParcelLandCapabilityRatingID] PRIMARY KEY CLUSTERED 
(
	[ParcelLandCapabilityRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelLandCapabilityRating_ParcelLandCapabilityID_BaileyRatingID] UNIQUE NONCLUSTERED 
(
	[ParcelLandCapabilityID] ASC,
	[BaileyRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating]  WITH CHECK ADD  CONSTRAINT [FK_ParcelLandCapabilityRating_BaileyRating_BaileyRatingID] FOREIGN KEY([BaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating] CHECK CONSTRAINT [FK_ParcelLandCapabilityRating_BaileyRating_BaileyRatingID]
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating]  WITH CHECK ADD  CONSTRAINT [FK_ParcelLandCapabilityRating_LandCapabilityType_LandCapabilityTypeID] FOREIGN KEY([LandCapabilityTypeID])
REFERENCES [dbo].[LandCapabilityType] ([LandCapabilityTypeID])
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating] CHECK CONSTRAINT [FK_ParcelLandCapabilityRating_LandCapabilityType_LandCapabilityTypeID]
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating]  WITH CHECK ADD  CONSTRAINT [FK_ParcelLandCapabilityRating_ParcelLandCapability_ParcelLandCapabilityID] FOREIGN KEY([ParcelLandCapabilityID])
REFERENCES [dbo].[ParcelLandCapability] ([ParcelLandCapabilityID])
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating] CHECK CONSTRAINT [FK_ParcelLandCapabilityRating_ParcelLandCapability_ParcelLandCapabilityID]
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating]  WITH CHECK ADD  CONSTRAINT [CK_ParcelLandCapabilityRating_IPESScoreXOrBaileyRatingID] CHECK  (([IPESScore] IS NOT NULL AND [BaileyRatingID] IS NULL OR [IPESScore] IS NULL AND [BaileyRatingID] IS NOT NULL))
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating] CHECK CONSTRAINT [CK_ParcelLandCapabilityRating_IPESScoreXOrBaileyRatingID]
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating]  WITH CHECK ADD  CONSTRAINT [CK_ParcelLandCapabilityRating_LandCapabilityTypeHasRequiredValues] CHECK  (([LandCapabilityTypeID]=(1) AND [BaileyRatingID] IS NOT NULL AND [IPESScore] IS NULL OR [LandCapabilityTypeID]=(2) AND [BaileyRatingID] IS NULL AND [IPESScore] IS NOT NULL))
GO
ALTER TABLE [dbo].[ParcelLandCapabilityRating] CHECK CONSTRAINT [CK_ParcelLandCapabilityRating_LandCapabilityTypeHasRequiredValues]