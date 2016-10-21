SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadAgencyTransactionTypeCommodityLogChangeType](
	[LeadAgencyTransactionTypeCommodityLogChangeTypeID] [int] NOT NULL,
	[LeadAgencyTransactionTypeCommodityLogChangeTypeName] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LeadAgencyTransactionTypeCommodityLogChangeTypeDisplayName] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_LeadAgencyTransactionTypeCommodityLogChangeType_LeadAgencyTransactionTypeCommodityLogChangeTypeID] PRIMARY KEY CLUSTERED 
(
	[LeadAgencyTransactionTypeCommodityLogChangeTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_LeadAgencyTransactionTypeCommodityLogChangeType_LeadAgencyTransactionTypeCommodityLogChangeTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[LeadAgencyTransactionTypeCommodityLogChangeTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_LeadAgencyTransactionTypeCommodityLogChangeType_LeadAgencyTransactionTypeCommodityLogChangeTypeName] UNIQUE NONCLUSTERED 
(
	[LeadAgencyTransactionTypeCommodityLogChangeTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
