SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectWorkflowSectionGrouping](
	[ProjectWorkflowSectionGroupingID] [int] NOT NULL,
	[ProjectWorkflowSectionGroupingName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectWorkflowSectionGroupingDisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingID] PRIMARY KEY CLUSTERED 
(
	[ProjectWorkflowSectionGroupingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectWorkflowSectionGroupingDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingName] UNIQUE NONCLUSTERED 
(
	[ProjectWorkflowSectionGroupingName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
