SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParcelImage](
	[ParcelImageID] [int] IDENTITY(1,1) NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[ParcelID] [int] NOT NULL,
	[Caption] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Credit] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsKeyPhoto] [bit] NOT NULL,
 CONSTRAINT [PK_ParcelImage_ParcelImageID] PRIMARY KEY CLUSTERED 
(
	[ParcelImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ParcelImage_FileResourceID_ParcelID] UNIQUE NONCLUSTERED 
(
	[FileResourceID] ASC,
	[ParcelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ParcelImage]  WITH CHECK ADD  CONSTRAINT [FK_ParcelImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ParcelImage] CHECK CONSTRAINT [FK_ParcelImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[ParcelImage]  WITH CHECK ADD  CONSTRAINT [FK_ParcelImage_Parcel_ParcelID] FOREIGN KEY([ParcelID])
REFERENCES [dbo].[Parcel] ([ParcelID])
GO
ALTER TABLE [dbo].[ParcelImage] CHECK CONSTRAINT [FK_ParcelImage_Parcel_ParcelID]