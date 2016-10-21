SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionPriorityImage](
	[ActionPriorityImageID] [int] IDENTITY(1,1) NOT NULL,
	[ActionPriorityID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
 CONSTRAINT [PK_ActionPriorityImage_ActionPriorityImageID] PRIMARY KEY CLUSTERED 
(
	[ActionPriorityImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ActionPriorityImage_ActionPriorityImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[ActionPriorityImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ActionPriorityImage]  WITH CHECK ADD  CONSTRAINT [FK_ActionPriorityImage_ActionPriority_ActionPriorityID] FOREIGN KEY([ActionPriorityID])
REFERENCES [dbo].[ActionPriority] ([ActionPriorityID])
GO
ALTER TABLE [dbo].[ActionPriorityImage] CHECK CONSTRAINT [FK_ActionPriorityImage_ActionPriority_ActionPriorityID]
GO
ALTER TABLE [dbo].[ActionPriorityImage]  WITH CHECK ADD  CONSTRAINT [FK_ActionPriorityImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ActionPriorityImage] CHECK CONSTRAINT [FK_ActionPriorityImage_FileResource_FileResourceID]