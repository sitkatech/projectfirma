SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationSimpleType](
	[ProjectLocationSimpleTypeID] [int] NOT NULL,
	[ProjectLocationSimpleTypeName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayInstructions] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationSimpleType_ProjectLocationSimpleTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationSimpleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationSimpleType_ProjectLocationSimpleTypeName] UNIQUE NONCLUSTERED 
(
	[ProjectLocationSimpleTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
