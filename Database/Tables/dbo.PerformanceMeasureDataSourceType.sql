SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureDataSourceType](
	[PerformanceMeasureDataSourceTypeID] [int] NOT NULL,
	[PerformanceMeasureDataSourceTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PerformanceMeasureDataSourceTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsCustomCalculation] [bit] NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureDataSourceType_PerformanceMeasureDataSourceTypeID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureDataSourceTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureDataSourceType_PerformanceMeasureDataSourceTypeName] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureDataSourceTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
