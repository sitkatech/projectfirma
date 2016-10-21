SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelExistingPhysicalInventory](
	[ParcelExistingPhysicalInventoryID] [int] IDENTITY(1,1) NOT NULL,
	[ParcelID] [int] NOT NULL,
	[CommodityBaileyRatingID] [int] NOT NULL,
	[ExistingPhysicalInventoryQuantity] [int] NOT NULL,
	[VerifiedAsOfDate] [datetime] NULL,
	[ExistingPhysicalInventoryNotes] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[LastUpdatePersonID] [int] NOT NULL,
	[EncumberedForPendingPermitQuantity] [int] NOT NULL,
	[BaseAllowableQuantity] [int] NOT NULL,
 CONSTRAINT [PK_ParcelExistingPhysicalInventory_ParcelExistingPhysicalInventoryID] PRIMARY KEY CLUSTERED 
(
	[ParcelExistingPhysicalInventoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory]  WITH CHECK ADD  CONSTRAINT [FK_ParcelExistingPhysicalInventory_CommodityBaileyRating_CommodityBaileyRatingID] FOREIGN KEY([CommodityBaileyRatingID])
REFERENCES [dbo].[CommodityBaileyRating] ([CommodityBaileyRatingID])
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory] CHECK CONSTRAINT [FK_ParcelExistingPhysicalInventory_CommodityBaileyRating_CommodityBaileyRatingID]
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory]  WITH CHECK ADD  CONSTRAINT [FK_ParcelExistingPhysicalInventory_Parcel_ParcelID] FOREIGN KEY([ParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory] CHECK CONSTRAINT [FK_ParcelExistingPhysicalInventory_Parcel_ParcelID]
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory]  WITH CHECK ADD  CONSTRAINT [FK_ParcelExistingPhysicalInventory_Person_LastUpdatePersonID_PersonID] FOREIGN KEY([LastUpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory] CHECK CONSTRAINT [FK_ParcelExistingPhysicalInventory_Person_LastUpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory]  WITH CHECK ADD  CONSTRAINT [CK_ExistingPhysicalInventory_BaseAllowableQuantity_GreaterThanZero] CHECK  (([BaseAllowableQuantity]>=(0)))
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory] CHECK CONSTRAINT [CK_ExistingPhysicalInventory_BaseAllowableQuantity_GreaterThanZero]
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory]  WITH CHECK ADD  CONSTRAINT [CK_ExistingPhysicalInventory_EncumberedForPendingPermitQuantity_GreaterThanZero] CHECK  (([EncumberedForPendingPermitQuantity]>=(0)))
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory] CHECK CONSTRAINT [CK_ExistingPhysicalInventory_EncumberedForPendingPermitQuantity_GreaterThanZero]
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory]  WITH CHECK ADD  CONSTRAINT [CK_ExistingPhysicalInventory_ExistingPhysicalInventoryQuantity_GreaterThanZero] CHECK  (([ExistingPhysicalInventoryQuantity]>=(0)))
GO
ALTER TABLE [dbo].[ParcelExistingPhysicalInventory] CHECK CONSTRAINT [CK_ExistingPhysicalInventory_ExistingPhysicalInventoryQuantity_GreaterThanZero]