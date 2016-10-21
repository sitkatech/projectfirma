SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parcel](
	[ParcelID] [int] IDENTITY(1,1) NOT NULL,
	[ParcelNumber] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeometryXml] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParcelStreetAddress] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParcelCity] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParcelState] [varchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParcelZipCode] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParcelNickname] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParcelNotes] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OwnerName] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[JurisdictionID] [int] NOT NULL,
	[ParcelSize] [int] NULL,
	[VerifiedParcelSize] [int] NULL,
	[LocalPlan] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HRA] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FireDistrict] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BMPStatus] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WatershedID] [int] NULL,
	[ParcelStatusID] [int] NOT NULL,
	[AutoImported] [bit] NOT NULL,
 CONSTRAINT [PK_Parcel_ParcelID] PRIMARY KEY CLUSTERED 
(
	[ParcelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Parcel_ParcelNumber] UNIQUE NONCLUSTERED 
(
	[ParcelNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Jurisdiction_JurisdictionID] FOREIGN KEY([JurisdictionID])
REFERENCES [dbo].[Jurisdiction] ([JurisdictionID])
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Jurisdiction_JurisdictionID]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_ParcelStatus_ParcelStatusID] FOREIGN KEY([ParcelStatusID])
REFERENCES [dbo].[ParcelStatus] ([ParcelStatusID])
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_ParcelStatus_ParcelStatusID]
GO
ALTER TABLE [dbo].[Parcel]  WITH CHECK ADD  CONSTRAINT [FK_Parcel_Watershed_WatershedID] FOREIGN KEY([WatershedID])
REFERENCES [dbo].[Watershed] ([WatershedID])
GO
ALTER TABLE [dbo].[Parcel] CHECK CONSTRAINT [FK_Parcel_Watershed_WatershedID]