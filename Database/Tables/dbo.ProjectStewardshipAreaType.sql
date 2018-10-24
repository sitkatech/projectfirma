SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectStewardshipAreaType](
	[ProjectStewardshipAreaTypeID] [int] NOT NULL,
	[ProjectStewardshipAreaTypeName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectStewardshipAreaTypeDisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectStewardshipAreaTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectStewardshipAreaTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeName] UNIQUE NONCLUSTERED 
(
	[ProjectStewardshipAreaTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
