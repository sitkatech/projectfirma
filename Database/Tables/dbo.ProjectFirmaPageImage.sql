SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFirmaPageImage](
	[ProjectFirmaPageImageID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectFirmaPageID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectFirmaPageImage_ProjectFirmaPageImageID] PRIMARY KEY CLUSTERED 
(
	[ProjectFirmaPageImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFirmaPageImage_ProjectFirmaPageImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[ProjectFirmaPageImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectFirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFirmaPageImage_ProjectFirmaPage_ProjectFirmaPageID] FOREIGN KEY([ProjectFirmaPageID])
REFERENCES [dbo].[ProjectFirmaPage] ([ProjectFirmaPageID])
GO
ALTER TABLE [dbo].[ProjectFirmaPageImage] CHECK CONSTRAINT [FK_ProjectFirmaPageImage_ProjectFirmaPage_ProjectFirmaPageID]
GO
ALTER TABLE [dbo].[ProjectFirmaPageImage]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFirmaPageImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ProjectFirmaPageImage] CHECK CONSTRAINT [FK_ProjectFirmaPageImage_FileResource_FileResourceID]