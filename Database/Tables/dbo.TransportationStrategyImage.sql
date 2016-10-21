SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationStrategyImage](
	[TransportationStrategyImageID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationStrategyID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_TransportationStrategyImage_TransportationStrategyImageID] PRIMARY KEY CLUSTERED 
(
	[TransportationStrategyImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationStrategyImage_TransportationStrategyImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[TransportationStrategyImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TransportationStrategyImage]  WITH CHECK ADD  CONSTRAINT [FK_TransportationStrategyImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TransportationStrategyImage] CHECK CONSTRAINT [FK_TransportationStrategyImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[TransportationStrategyImage]  WITH CHECK ADD  CONSTRAINT [FK_TransportationStrategyImage_TransportationStrategy_TransportationStrategyID] FOREIGN KEY([TransportationStrategyID])
REFERENCES [dbo].[TransportationStrategy] ([TransportationStrategyID])
GO
ALTER TABLE [dbo].[TransportationStrategyImage] CHECK CONSTRAINT [FK_TransportationStrategyImage_TransportationStrategy_TransportationStrategyID]