SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentQuestion](
	[AssessmentQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[AssessmentSubGoalID] [int] NOT NULL,
	[AssessmentQuestionText] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ArchiveDate] [date] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_AssessmentQuestion_AssessmentQuestionID] PRIMARY KEY CLUSTERED 
(
	[AssessmentQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AssessmentQuestion_AssessmentQuestionText] UNIQUE NONCLUSTERED 
(
	[AssessmentQuestionText] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentQuestion_AssessmentSubGoal_AssessmentSubGoalID] FOREIGN KEY([AssessmentSubGoalID])
REFERENCES [dbo].[AssessmentSubGoal] ([AssessmentSubGoalID])
GO
ALTER TABLE [dbo].[AssessmentQuestion] CHECK CONSTRAINT [FK_AssessmentQuestion_AssessmentSubGoal_AssessmentSubGoalID]
GO
ALTER TABLE [dbo].[AssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentQuestion_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AssessmentQuestion] CHECK CONSTRAINT [FK_AssessmentQuestion_Tenant_TenantID]