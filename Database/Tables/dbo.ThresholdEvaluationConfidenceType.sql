SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdEvaluationConfidenceType](
	[ThresholdEvaluationConfidenceTypeID] [int] NOT NULL,
	[ThresholdEvaluationConfidenceTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThresholdEvaluationConfidenceTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ThresholdEvaluationConfidenceType_ThresholdEvaluationConfidenceTypeID] PRIMARY KEY CLUSTERED 
(
	[ThresholdEvaluationConfidenceTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationConfidenceType_ThresholdEvaluationConfidenceTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationConfidenceTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationConfidenceType_ThresholdEvaluationConfidenceTypeName] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationConfidenceTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
