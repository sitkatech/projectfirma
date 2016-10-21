SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program](
	[ProgramID] [int] IDENTITY(1,1) NOT NULL,
	[FocusAreaID] [int] NOT NULL,
	[ProgramNumber] [tinyint] NOT NULL,
	[ProgramName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProgramDescription] [dbo].[html] NULL,
	[AssociatedPrograms] [dbo].[html] NULL,
 CONSTRAINT [PK_Program_ProgramID] PRIMARY KEY CLUSTERED 
(
	[ProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Program_FocusAreaID_ProgramNumber] UNIQUE NONCLUSTERED 
(
	[FocusAreaID] ASC,
	[ProgramNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Program_ProgramName] UNIQUE NONCLUSTERED 
(
	[ProgramName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_FocusArea_FocusAreaID] FOREIGN KEY([FocusAreaID])
REFERENCES [dbo].[FocusArea] ([FocusAreaID])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_FocusArea_FocusAreaID]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [CK_Program_ProgramNumberBetween1And99] CHECK  (([ProgramNumber]>=(1) AND [ProgramNumber]<=(99)))
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [CK_Program_ProgramNumberBetween1And99]