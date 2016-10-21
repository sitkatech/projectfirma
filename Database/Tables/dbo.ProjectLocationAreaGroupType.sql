SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationAreaGroupType](
	[ProjectLocationAreaGroupTypeID] [int] NOT NULL,
	[ProjectLocationAreaGroupTypeName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectLocationAreaGroupTypeDisplayName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationAreaGroupType_ProjectLocationAreaGroupTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationAreaGroupTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationAreaGroupType_ProjectLocationAreaGroupTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectLocationAreaGroupTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationAreaGroupType_ProjectLocationAreaGroupTypeName] UNIQUE NONCLUSTERED 
(
	[ProjectLocationAreaGroupTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
