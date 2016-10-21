SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FocusAreaImage](
	[FocusAreaImageID] [int] IDENTITY(1,1) NOT NULL,
	[FocusAreaID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_FocusAreaImage_FocusAreaImageID] PRIMARY KEY CLUSTERED 
(
	[FocusAreaImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FocusAreaImage_FocusAreaImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[FocusAreaImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FocusAreaImage]  WITH CHECK ADD  CONSTRAINT [FK_FocusAreaImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[FocusAreaImage] CHECK CONSTRAINT [FK_FocusAreaImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[FocusAreaImage]  WITH CHECK ADD  CONSTRAINT [FK_FocusAreaImage_FocusArea_FocusAreaID] FOREIGN KEY([FocusAreaID])
REFERENCES [dbo].[FocusArea] ([FocusAreaID])
GO
ALTER TABLE [dbo].[FocusAreaImage] CHECK CONSTRAINT [FK_FocusAreaImage_FocusArea_FocusAreaID]