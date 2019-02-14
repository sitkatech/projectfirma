SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReleaseNote](
	[ReleaseNoteID] [int] IDENTITY(1,1) NOT NULL,
	[Note] [dbo].[html] NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ReleaseNote_ReleaseNoteID] PRIMARY KEY CLUSTERED 
(
	[ReleaseNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ReleaseNote]  WITH CHECK ADD  CONSTRAINT [FK_ReleaseNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ReleaseNote] CHECK CONSTRAINT [FK_ReleaseNote_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ReleaseNote]  WITH CHECK ADD  CONSTRAINT [FK_ReleaseNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ReleaseNote] CHECK CONSTRAINT [FK_ReleaseNote_Person_UpdatePersonID_PersonID]