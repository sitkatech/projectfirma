SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomGridColumn](
	[ProjectCustomGridColumnID] [int] NOT NULL,
	[ProjectCustomGridColumnName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectCustomGridColumnDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsOptional] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectCustomGridColumn_ProjectCustomGridColumnID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomGridColumnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomGridColumn_ProjectCustomGridColumnDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectCustomGridColumnDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomGridColumn_ProjectCustomGridColumnName] UNIQUE NONCLUSTERED 
(
	[ProjectCustomGridColumnName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
