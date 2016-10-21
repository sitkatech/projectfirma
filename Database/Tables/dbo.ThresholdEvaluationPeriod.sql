SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdEvaluationPeriod](
	[ThresholdEvaluationPeriodID] [int] IDENTITY(1,1) NOT NULL,
	[ThresholdEvaluationYear] [int] NOT NULL,
 CONSTRAINT [PK_ThresholdEvaluationPeriod_ThresholdEvaluationPeriodID] PRIMARY KEY CLUSTERED 
(
	[ThresholdEvaluationPeriodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
