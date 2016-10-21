SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelAccelaCAPRecord](
	[ParcelAccelaCAPRecordID] [int] IDENTITY(1,1) NOT NULL,
	[ParcelID] [int] NOT NULL,
	[AccelaCAPRecordID] [int] NOT NULL,
 CONSTRAINT [PK_ParcelAccelaCAPRecord_ParcelAccelaCAPRecordID] PRIMARY KEY CLUSTERED 
(
	[ParcelAccelaCAPRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelAccelaCAPRecord_ParcelID_AccelaCAPRecordID] UNIQUE NONCLUSTERED 
(
	[ParcelID] ASC,
	[AccelaCAPRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ParcelAccelaCAPRecord]  WITH CHECK ADD  CONSTRAINT [FK_ParcelAccelaCAPRecord_AccelaCAPRecord_AccelaCAPRecordID] FOREIGN KEY([AccelaCAPRecordID])
REFERENCES [dbo].[AccelaCAPRecord] ([AccelaCAPRecordID])
GO
ALTER TABLE [dbo].[ParcelAccelaCAPRecord] CHECK CONSTRAINT [FK_ParcelAccelaCAPRecord_AccelaCAPRecord_AccelaCAPRecordID]
GO
ALTER TABLE [dbo].[ParcelAccelaCAPRecord]  WITH CHECK ADD  CONSTRAINT [FK_ParcelAccelaCAPRecord_Parcel_ParcelID] FOREIGN KEY([ParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[ParcelAccelaCAPRecord] CHECK CONSTRAINT [FK_ParcelAccelaCAPRecord_Parcel_ParcelID]