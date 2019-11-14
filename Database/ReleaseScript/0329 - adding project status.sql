CREATE TABLE [dbo].[ProjectStatus](
	[ProjectStatusID] [int] NOT NULL,
	[ProjectStatusName] [varchar](100) NOT NULL,
	[ProjectStatusDisplayName] [varchar](100) NOT NULL,
	[ProjectStatusSortOrder] [int] NOT NULL,
	[ProjectStatusColor] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ProjectStatus_ProjectStatusID] PRIMARY KEY CLUSTERED 
(
	[ProjectStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStatus_ProjectStatusDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectStatusDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStatus_ProjectStatusName] UNIQUE NONCLUSTERED 
(
	[ProjectStatusName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

