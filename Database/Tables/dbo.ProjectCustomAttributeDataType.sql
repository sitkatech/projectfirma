SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCustomAttributeDataType](
	[ProjectCustomAttributeDataTypeID] [int] NOT NULL,
	[ProjectCustomAttributeDataTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectCustomAttributeDataTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectCustomAttributeDataTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeDataTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeName] UNIQUE NONCLUSTERED 
(
	[ProjectCustomAttributeDataTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
