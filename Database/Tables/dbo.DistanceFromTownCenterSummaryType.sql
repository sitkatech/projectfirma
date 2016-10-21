SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistanceFromTownCenterSummaryType](
	[DistanceFromTownCenterSummaryTypeID] [int] NOT NULL,
	[DistanceFromTownCenterSummaryTypeName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DistanceFromTownCenterSummaryTypeDisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_DistanceFromTownCenterSummaryType_DistanceFromTownCenterSummaryTypeID] PRIMARY KEY CLUSTERED 
(
	[DistanceFromTownCenterSummaryTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_DistanceFromTownCenterSummaryType_DistanceFromTownCenterSummaryTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[DistanceFromTownCenterSummaryTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_DistanceFromTownCenterSummaryType_DistanceFromTownCenterSummaryTypeName] UNIQUE NONCLUSTERED 
(
	[DistanceFromTownCenterSummaryTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
