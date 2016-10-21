SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelLandCapability](
	[ParcelLandCapabilityID] [int] IDENTITY(1,1) NOT NULL,
	[ParcelID] [int] NOT NULL,
	[ParcelLandCapabilityDeterminationTypeID] [int] NOT NULL,
	[DeterminationDate] [datetime] NOT NULL,
	[SitePlanFileResourceID] [int] NULL,
	[AccelaCAPRecordID] [int] NULL,
	[LandCapabilityNotes] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[LastUpdatePersonID] [int] NOT NULL,
 CONSTRAINT [PK_ParcelLandCapability_ParcelLandCapabilityID] PRIMARY KEY CLUSTERED 
(
	[ParcelLandCapabilityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelLandCapability_ParcelID] UNIQUE NONCLUSTERED 
(
	[ParcelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelLandCapability_ParcelID_ParcelLandCapabilityDeterminationTypeID_DeterminationDate] UNIQUE NONCLUSTERED 
(
	[ParcelID] ASC,
	[ParcelLandCapabilityDeterminationTypeID] ASC,
	[DeterminationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ParcelLandCapability]  WITH CHECK ADD  CONSTRAINT [FK_ParcelLandCapability_AccelaCAPRecord_AccelaCAPRecordID] FOREIGN KEY([AccelaCAPRecordID])
REFERENCES [dbo].[AccelaCAPRecord] ([AccelaCAPRecordID])
GO
ALTER TABLE [dbo].[ParcelLandCapability] CHECK CONSTRAINT [FK_ParcelLandCapability_AccelaCAPRecord_AccelaCAPRecordID]
GO
ALTER TABLE [dbo].[ParcelLandCapability]  WITH CHECK ADD  CONSTRAINT [FK_ParcelLandCapability_FileResource_SitePlanFileResourceID_FileResourceID] FOREIGN KEY([SitePlanFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ParcelLandCapability] CHECK CONSTRAINT [FK_ParcelLandCapability_FileResource_SitePlanFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[ParcelLandCapability]  WITH CHECK ADD  CONSTRAINT [FK_ParcelLandCapability_Parcel_ParcelID] FOREIGN KEY([ParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[ParcelLandCapability] CHECK CONSTRAINT [FK_ParcelLandCapability_Parcel_ParcelID]
GO
ALTER TABLE [dbo].[ParcelLandCapability]  WITH CHECK ADD  CONSTRAINT [FK_ParcelLandCapability_ParcelLandCapabilityDeterminationType_ParcelLandCapabilityDeterminationTypeID] FOREIGN KEY([ParcelLandCapabilityDeterminationTypeID])
REFERENCES [dbo].[ParcelLandCapabilityDeterminationType] ([ParcelLandCapabilityDeterminationTypeID])
GO
ALTER TABLE [dbo].[ParcelLandCapability] CHECK CONSTRAINT [FK_ParcelLandCapability_ParcelLandCapabilityDeterminationType_ParcelLandCapabilityDeterminationTypeID]
GO
ALTER TABLE [dbo].[ParcelLandCapability]  WITH CHECK ADD  CONSTRAINT [FK_ParcelLandCapability_Person_LastUpdatePersonID_PersonID] FOREIGN KEY([LastUpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ParcelLandCapability] CHECK CONSTRAINT [FK_ParcelLandCapability_Person_LastUpdatePersonID_PersonID]