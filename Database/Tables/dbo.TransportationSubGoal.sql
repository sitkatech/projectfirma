SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationSubGoal](
	[TransportationSubGoalID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationGoalID] [int] NOT NULL,
	[TransportationSubGoalNumber] [int] NOT NULL,
	[TransportationSubGoalTitle] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TransportationSubGoalDescription] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TransportationSubGoal_TransportationSubGoalID] PRIMARY KEY CLUSTERED 
(
	[TransportationSubGoalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationSubGoal_TransportationSubGoalNumber] UNIQUE NONCLUSTERED 
(
	[TransportationSubGoalNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationSubGoal_TransportationSubGoalTitle] UNIQUE NONCLUSTERED 
(
	[TransportationSubGoalTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TransportationSubGoal]  WITH CHECK ADD  CONSTRAINT [FK_TransportationSubGoal_TransportationGoal_TransportationGoalID] FOREIGN KEY([TransportationGoalID])
REFERENCES [dbo].[TransportationGoal] ([TransportationGoalID])
GO
ALTER TABLE [dbo].[TransportationSubGoal] CHECK CONSTRAINT [FK_TransportationSubGoal_TransportationGoal_TransportationGoalID]