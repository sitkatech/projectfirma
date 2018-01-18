SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCreateSection](
	[ProjectCreateSectionID] [int] NOT NULL,
	[ProjectCreateSectionName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectCreateSectionDisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
	[HasCompletionStatus] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectCreateSection_ProjectCreateSectionID] PRIMARY KEY CLUSTERED 
(
	[ProjectCreateSectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCreateSection_ProjectCreateSectionDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectCreateSectionDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCreateSection_ProjectCreateSectionName] UNIQUE NONCLUSTERED 
(
	[ProjectCreateSectionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
