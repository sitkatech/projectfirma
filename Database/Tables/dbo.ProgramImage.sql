SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramImage](
	[ProgramImageID] [int] IDENTITY(1,1) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_ProgramImage_ProgramImageID] PRIMARY KEY CLUSTERED 
(
	[ProgramImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProgramImage_ProgramImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[ProgramImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProgramImage]  WITH CHECK ADD  CONSTRAINT [FK_ProgramImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ProgramImage] CHECK CONSTRAINT [FK_ProgramImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[ProgramImage]  WITH CHECK ADD  CONSTRAINT [FK_ProgramImage_Program_ProgramID] FOREIGN KEY([ProgramID])
REFERENCES [dbo].[Program] ([ProgramID])
GO
ALTER TABLE [dbo].[ProgramImage] CHECK CONSTRAINT [FK_ProgramImage_Program_ProgramID]