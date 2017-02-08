SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentSubGoal](
	[AssessmentSubGoalID] [int] IDENTITY(1,1) NOT NULL,
	[AssessmentGoalID] [int] NOT NULL,
	[AssessmentSubGoalNumber] [int] NOT NULL,
	[AssessmentSubGoalTitle] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AssessmentSubGoalDescription] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_AssessmentSubGoal_AssessmentSubGoalID] PRIMARY KEY CLUSTERED 
(
	[AssessmentSubGoalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AssessmentSubGoal_AssessmentSubGoalNumber] UNIQUE NONCLUSTERED 
(
	[AssessmentSubGoalNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AssessmentSubGoal_AssessmentSubGoalTitle] UNIQUE NONCLUSTERED 
(
	[AssessmentSubGoalTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AssessmentSubGoal]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentSubGoal_AssessmentGoal_AssessmentGoalID] FOREIGN KEY([AssessmentGoalID])
REFERENCES [dbo].[AssessmentGoal] ([AssessmentGoalID])
GO
ALTER TABLE [dbo].[AssessmentSubGoal] CHECK CONSTRAINT [FK_AssessmentSubGoal_AssessmentGoal_AssessmentGoalID]