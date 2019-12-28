SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluationStatus](
	[EvaluationStatusID] [int] NOT NULL,
	[EvaluationStatusName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EvaluationStatusDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_EvaluationStatus_EvaluationStatusID] PRIMARY KEY CLUSTERED 
(
	[EvaluationStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
