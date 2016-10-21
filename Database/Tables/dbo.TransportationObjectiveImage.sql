SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationObjectiveImage](
	[TransportationObjectiveImageID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationObjectiveID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_TransportationObjectiveImage_TransportationObjectiveImageID] PRIMARY KEY CLUSTERED 
(
	[TransportationObjectiveImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationObjectiveImage_TransportationObjectiveImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[TransportationObjectiveImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TransportationObjectiveImage]  WITH CHECK ADD  CONSTRAINT [FK_TransportationObjectiveImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TransportationObjectiveImage] CHECK CONSTRAINT [FK_TransportationObjectiveImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[TransportationObjectiveImage]  WITH CHECK ADD  CONSTRAINT [FK_TransportationObjectiveImage_TransportationObjective_TransportationObjectiveID] FOREIGN KEY([TransportationObjectiveID])
REFERENCES [dbo].[TransportationObjective] ([TransportationObjectiveID])
GO
ALTER TABLE [dbo].[TransportationObjectiveImage] CHECK CONSTRAINT [FK_TransportationObjectiveImage_TransportationObjective_TransportationObjectiveID]