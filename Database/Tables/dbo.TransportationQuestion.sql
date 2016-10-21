SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationQuestion](
	[TransportationQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationSubGoalID] [int] NOT NULL,
	[TransportationQuestionText] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ArchiveDate] [date] NULL,
 CONSTRAINT [PK_TransportationQuestion_TransportationQuestionID] PRIMARY KEY CLUSTERED 
(
	[TransportationQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationQuestion_TransportationQuestionText] UNIQUE NONCLUSTERED 
(
	[TransportationQuestionText] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TransportationQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TransportationQuestion_TransportationSubGoal_TransportationSubGoalID] FOREIGN KEY([TransportationSubGoalID])
REFERENCES [dbo].[TransportationSubGoal] ([TransportationSubGoalID])
GO
ALTER TABLE [dbo].[TransportationQuestion] CHECK CONSTRAINT [FK_TransportationQuestion_TransportationSubGoal_TransportationSubGoalID]