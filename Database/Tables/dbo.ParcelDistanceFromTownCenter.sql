SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelDistanceFromTownCenter](
	[ParcelDistanceFromTownCenterID] [int] IDENTITY(1,1) NOT NULL,
	[TownCenterID] [int] NOT NULL,
	[ParcelID] [int] NOT NULL,
	[DistanceInMiles] [decimal](18, 5) NULL,
	[DistanceFromTownCenterSummaryTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ParcelDistanceFromTownCenter_ParcelDistanceFromTownCenterID] PRIMARY KEY CLUSTERED 
(
	[ParcelDistanceFromTownCenterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelDistanceFromTownCenter_TownCenterID_ParcelID] UNIQUE NONCLUSTERED 
(
	[TownCenterID] ASC,
	[ParcelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ParcelDistanceFromTownCenter]  WITH CHECK ADD  CONSTRAINT [FK_ParcelDistanceFromTownCenter_DistanceFromTownCenterSummaryType_DistanceFromTownCenterSummaryTypeID] FOREIGN KEY([DistanceFromTownCenterSummaryTypeID])
REFERENCES [dbo].[DistanceFromTownCenterSummaryType] ([DistanceFromTownCenterSummaryTypeID])
GO
ALTER TABLE [dbo].[ParcelDistanceFromTownCenter] CHECK CONSTRAINT [FK_ParcelDistanceFromTownCenter_DistanceFromTownCenterSummaryType_DistanceFromTownCenterSummaryTypeID]
GO
ALTER TABLE [dbo].[ParcelDistanceFromTownCenter]  WITH CHECK ADD  CONSTRAINT [FK_ParcelDistanceFromTownCenter_Parcel_ParcelID] FOREIGN KEY([ParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[ParcelDistanceFromTownCenter] CHECK CONSTRAINT [FK_ParcelDistanceFromTownCenter_Parcel_ParcelID]
GO
ALTER TABLE [dbo].[ParcelDistanceFromTownCenter]  WITH CHECK ADD  CONSTRAINT [FK_ParcelDistanceFromTownCenter_TownCenter_TownCenterID] FOREIGN KEY([TownCenterID])
REFERENCES [dbo].[TownCenter] ([TownCenterID])
GO
ALTER TABLE [dbo].[ParcelDistanceFromTownCenter] CHECK CONSTRAINT [FK_ParcelDistanceFromTownCenter_TownCenter_TownCenterID]