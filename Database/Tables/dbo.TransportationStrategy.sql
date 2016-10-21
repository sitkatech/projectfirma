SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationStrategy](
	[TransportationStrategyID] [int] IDENTITY(1,1) NOT NULL,
	[TransportationStrategyName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TransportationStrategyDescription] [dbo].[html] NULL,
	[TransportationStrategyColor] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_TransportationStrategy_TransportationStrategyID] PRIMARY KEY CLUSTERED 
(
	[TransportationStrategyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationStrategy_TransportationStrategyName] UNIQUE NONCLUSTERED 
(
	[TransportationStrategyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
