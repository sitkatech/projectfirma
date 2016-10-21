SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationGoal](
	[TransportationGoalID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationGoalNumber] [int] NOT NULL,
	[TransportationGoalTitle] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TransportationGoalDescription] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TransportationGoal_TransportationGoalID] PRIMARY KEY CLUSTERED 
(
	[TransportationGoalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationGoal_TransportationGoalNumber] UNIQUE NONCLUSTERED 
(
	[TransportationGoalNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationGoal_TransportationGoalTitle] UNIQUE NONCLUSTERED 
(
	[TransportationGoalTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
