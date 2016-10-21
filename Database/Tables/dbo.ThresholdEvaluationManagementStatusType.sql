SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdEvaluationManagementStatusType](
	[ThresholdEvaluationManagementStatusTypeID] [int] NOT NULL,
	[ThresholdEvaluationManagementStatusTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThresholdEvaluationManagementStatusTypeDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThresholdEvaluationManagementStatusTypeAbbreviation] [varchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ThresholdEvaluationManagementStatusTypeDescription] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ThresholdEvaluationManagementStatusType_ThresholdEvaluationManagementStatusTypeID] PRIMARY KEY CLUSTERED 
(
	[ThresholdEvaluationManagementStatusTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationManagementStatusType_ThresholdEvaluationManagementStatusTypeAbbreviation] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationManagementStatusTypeAbbreviation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationManagementStatusType_ThresholdEvaluationManagementStatusTypeDisplayName] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationManagementStatusTypeDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ThresholdEvaluationManagementStatusType_ThresholdEvaluationManagementStatusTypeName] UNIQUE NONCLUSTERED 
(
	[ThresholdEvaluationManagementStatusTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
