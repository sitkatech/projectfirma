SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccomplishmentsDashboardFundingDisplayType](
	[AccomplishmentsDashboardFundingDisplayTypeID] [int] NOT NULL,
	[AccomplishmentsDashboardFundingDisplayTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccomplishmentsDashboardFundingDisplayTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeID] PRIMARY KEY CLUSTERED 
(
	[AccomplishmentsDashboardFundingDisplayTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[AccomplishmentsDashboardFundingDisplayTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeName] UNIQUE NONCLUSTERED 
(
	[AccomplishmentsDashboardFundingDisplayTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
