SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionPriority](
	[ActionPriorityID] [int] IDENTITY(1,1) NOT NULL,
	[ProgramID] [int] NOT NULL,
	[ActionPriorityNumber] [tinyint] NOT NULL,
	[ActionPriorityName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ActionPriorityDescription] [dbo].[html] NULL,
 CONSTRAINT [PK_ActionPriority_ActionPriorityID] PRIMARY KEY CLUSTERED 
(
	[ActionPriorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ActionPriority_ActionPriorityName] UNIQUE NONCLUSTERED 
(
	[ActionPriorityName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ActionPriority_ProgramID_ActionPriorityNumber] UNIQUE NONCLUSTERED 
(
	[ProgramID] ASC,
	[ActionPriorityNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ActionPriority]  WITH CHECK ADD  CONSTRAINT [FK_ActionPriority_Program_ProgramID] FOREIGN KEY([ProgramID])
REFERENCES [dbo].[Program] ([ProgramID])
GO
ALTER TABLE [dbo].[ActionPriority] CHECK CONSTRAINT [FK_ActionPriority_Program_ProgramID]
GO
ALTER TABLE [dbo].[ActionPriority]  WITH CHECK ADD  CONSTRAINT [CK_ActionPriority_ActionPriorityNumberBetween1And99] CHECK  (([ActionPriorityNumber]>=(1) AND [ActionPriorityNumber]<=(99)))
GO
ALTER TABLE [dbo].[ActionPriority] CHECK CONSTRAINT [CK_ActionPriority_ActionPriorityNumberBetween1And99]