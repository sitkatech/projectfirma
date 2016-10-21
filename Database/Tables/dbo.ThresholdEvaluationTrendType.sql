SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdEvaluationTrendType](
	[ThresholdEvaluationTrendTypeID] [int] NOT NULL,
	[ThresholdEvaluationTrendTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThresholdEvaluationTrendTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ThresholdEvaluationTrendType_ThresholdEvaluationTrendTypeID] PRIMARY KEY CLUSTERED 
(
	[ThresholdEvaluationTrendTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationTrendType_ThresholdEvaluationTrendTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationTrendTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationTrendType_ThresholdEvaluationTrendTypeName] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationTrendTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
