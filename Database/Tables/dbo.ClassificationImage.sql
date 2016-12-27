SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassificationImage](
	[ClassificationImageID] [int] IDENTITY(1,1) NOT NULL,
	[ClassificationID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_ClassificationImage_ClassificationImageID] PRIMARY KEY CLUSTERED 
(
	[ClassificationImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ClassificationImage_ClassificationImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[ClassificationImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ClassificationImage]  WITH CHECK ADD  CONSTRAINT [FK_ClassificationImage_Classification_ClassificationID] FOREIGN KEY([ClassificationID])
REFERENCES [dbo].[Classification] ([ClassificationID])
GO
ALTER TABLE [dbo].[ClassificationImage] CHECK CONSTRAINT [FK_ClassificationImage_Classification_ClassificationID]
GO
ALTER TABLE [dbo].[ClassificationImage]  WITH CHECK ADD  CONSTRAINT [FK_ClassificationImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ClassificationImage] CHECK CONSTRAINT [FK_ClassificationImage_FileResource_FileResourceID]