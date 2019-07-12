SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundingSourceCustomAttributeDataType](
	[FundingSourceCustomAttributeDataTypeID] [int] NOT NULL,
	[FundingSourceCustomAttributeDataTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FundingSourceCustomAttributeDataTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeID] PRIMARY KEY CLUSTERED 
(
	[FundingSourceCustomAttributeDataTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[FundingSourceCustomAttributeDataTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_FundingSourceCustomAttributeDataType_FundingSourceCustomAttributeDataTypeName] UNIQUE NONCLUSTERED 
(
	[FundingSourceCustomAttributeDataTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
