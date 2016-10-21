SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationObjective](
	[TransportationObjectiveID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationStrategyID] [int] NOT NULL,
	[TransportationObjectiveName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TransportationObjectiveDescription] [dbo].[html] NULL,
	[FundingTypeID] [int] NOT NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_TransportationObjective_TransportationObjectiveID] PRIMARY KEY CLUSTERED 
(
	[TransportationObjectiveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationObjective_TransportationObjectiveName] UNIQUE NONCLUSTERED 
(
	[TransportationObjectiveName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TransportationObjective]  WITH CHECK ADD  CONSTRAINT [FK_TransportationObjective_FundingType_FundingTypeID] FOREIGN KEY([FundingTypeID])
REFERENCES [dbo].[FundingType] ([FundingTypeID])
GO
ALTER TABLE [dbo].[TransportationObjective] CHECK CONSTRAINT [FK_TransportationObjective_FundingType_FundingTypeID]
GO
ALTER TABLE [dbo].[TransportationObjective]  WITH CHECK ADD  CONSTRAINT [FK_TransportationObjective_TransportationStrategy_TransportationStrategyID] FOREIGN KEY([TransportationStrategyID])
REFERENCES [dbo].[TransportationStrategy] ([TransportationStrategyID])
GO
ALTER TABLE [dbo].[TransportationObjective] CHECK CONSTRAINT [FK_TransportationObjective_TransportationStrategy_TransportationStrategyID]