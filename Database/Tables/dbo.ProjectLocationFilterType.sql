SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationFilterType](
	[ProjectLocationFilterTypeID] [int] NOT NULL,
	[ProjectLocationFilterTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectLocationFilterTypeNameWithIdentifier] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectLocationFilterTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
	[DisplayGroup] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationFilterType_ProjectLocationFilterTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationFilterTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationFilterType_ProjectLocationFilterTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectLocationFilterTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationFilterType_ProjectLocationFilterTypeName] UNIQUE NONCLUSTERED 
(
	[ProjectLocationFilterTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationFilterType_ProjectLocationFilterTypeNameWithIdentifier] UNIQUE NONCLUSTERED 
(
	[ProjectLocationFilterTypeNameWithIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
