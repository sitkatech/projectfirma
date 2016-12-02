SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerformanceMeasureTargetValueType](
	[PerformanceMeasureTargetValueTypeID] [int] NOT NULL,
	[PerformanceMeasureTargetValueTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PerformanceMeasureTargetValueTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_PerformanceMeasureTargetValueType_PerformanceMeasureTargetValueTypeID] PRIMARY KEY CLUSTERED 
(
	[PerformanceMeasureTargetValueTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureTargetValueType_PerformanceMeasureTargetValueTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureTargetValueTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PerformanceMeasureTargetValueType_PerformanceMeasureTargetValueTypeName] UNIQUE NONCLUSTERED 
(
	[PerformanceMeasureTargetValueTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
