SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdEvaluationStatusType](
	[ThresholdEvaluationStatusTypeID] [int] NOT NULL,
	[ThresholdEvaluationStatusTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThresholdEvaluationStatusTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ThresholdEvaluationStatusType_ThresholdEvaluationStatusTypeID] PRIMARY KEY CLUSTERED 
(
	[ThresholdEvaluationStatusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationStatusType_ThresholdEvaluationStatusTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationStatusTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationStatusType_ThresholdEvaluationStatusTypeName] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationStatusTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
