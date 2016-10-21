SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadAgencyRightOfWayCoverage](
	[LeadAgencyRightOfWayCoverageID] [int] IDENTITY(1,1) NOT NULL,
	[LeadAgencyID] [int] NOT NULL,
	[CommodityID] [int] NOT NULL,
	[RightOfWayCoverageAmount] [int] NOT NULL,
	[BaileyRatingID] [int] NULL,
	[RightOfWayCoverageEffectiveDate] [datetime] NOT NULL,
	[RightOfWayCoverageNotes] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[LastUpdatePersonID] [int] NOT NULL,
 CONSTRAINT [PK_LeadAgencyRightOfWayCoverage_LeadAgencyRightOfWayCoverageID] PRIMARY KEY CLUSTERED 
(
	[LeadAgencyRightOfWayCoverageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyRightOfWayCoverage_BaileyRating_BaileyRatingID] FOREIGN KEY([BaileyRatingID])
REFERENCES [dbo].[BaileyRating] ([BaileyRatingID])
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage] CHECK CONSTRAINT [FK_LeadAgencyRightOfWayCoverage_BaileyRating_BaileyRatingID]
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyRightOfWayCoverage_Commodity_CommodityID] FOREIGN KEY([CommodityID])
REFERENCES [dbo].[Commodity] ([CommodityID])
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage] CHECK CONSTRAINT [FK_LeadAgencyRightOfWayCoverage_Commodity_CommodityID]
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyRightOfWayCoverage_LeadAgency_LeadAgencyID] FOREIGN KEY([LeadAgencyID])
REFERENCES [dbo].[LeadAgency] ([LeadAgencyID])
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage] CHECK CONSTRAINT [FK_LeadAgencyRightOfWayCoverage_LeadAgency_LeadAgencyID]
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage]  WITH CHECK ADD  CONSTRAINT [FK_LeadAgencyRightOfWayCoverage_Person_LastUpdatePersonID_PersonID] FOREIGN KEY([LastUpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage] CHECK CONSTRAINT [FK_LeadAgencyRightOfWayCoverage_Person_LastUpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage]  WITH CHECK ADD  CONSTRAINT [CK_LeadAgencyRightOfWayCoverage_OnlyHardOrSoftCoverageAndRestorationCredit] CHECK  (([CommodityID]=(10) OR [CommodityID]=(3) OR [CommodityID]=(2)))
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage] CHECK CONSTRAINT [CK_LeadAgencyRightOfWayCoverage_OnlyHardOrSoftCoverageAndRestorationCredit]
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage]  WITH CHECK ADD  CONSTRAINT [CK_LeadAgencyRightOfWayCoverage_OnlyHardOrSoftCoverageRequiresBaileyRating] CHECK  ((([CommodityID]=(3) OR [CommodityID]=(2)) AND [BaileyRatingID] IS NOT NULL OR [BaileyRatingID] IS NULL))
GO
ALTER TABLE [dbo].[LeadAgencyRightOfWayCoverage] CHECK CONSTRAINT [CK_LeadAgencyRightOfWayCoverage_OnlyHardOrSoftCoverageRequiresBaileyRating]