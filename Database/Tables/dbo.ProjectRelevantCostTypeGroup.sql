SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectRelevantCostTypeGroup](
	[ProjectRelevantCostTypeGroupID] [int] NOT NULL,
	[ProjectRelevantCostTypeGroupName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectRelevantCostTypeGroupDisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupID] PRIMARY KEY CLUSTERED 
(
	[ProjectRelevantCostTypeGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectRelevantCostTypeGroupDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupName] UNIQUE NONCLUSTERED 
(
	[ProjectRelevantCostTypeGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
