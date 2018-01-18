--Create the ProjectUpdateSection table
CREATE TABLE [dbo].[ProjectUpdateSection](
	[ProjectUpdateSectionID] [int] NOT NULL,
	[ProjectUpdateSectionName] [varchar](50) NOT NULL,
	[ProjectUpdateSectionDisplayName] [varchar](50) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[HasCompletionStatus] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectUpdateSection_ProjectUpdateSectionID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateSectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdateSection_ProjectUpdateSectionDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateSectionDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdateSection_ProjectUpdateSectionName] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateSectionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--Create the ProjectCreateSection table
CREATE TABLE [dbo].[ProjectCreateSection](
	[ProjectCreateSectionID] [int] NOT NULL,
	[ProjectCreateSectionName] [varchar](50) NOT NULL,
	[ProjectCreateSectionDisplayName] [varchar](50) NOT NULL,
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
GO

