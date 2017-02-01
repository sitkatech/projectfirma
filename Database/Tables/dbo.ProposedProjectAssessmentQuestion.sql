SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectAssessmentQuestion](
	[ProposedProjectAssessmentQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[AssessmentQuestionID] [int] NOT NULL,
	[Answer] [bit] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProposedProjectAssessmentQuestion_ProposedProjectAssessmentQuestionID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectAssessmentQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProjectAssessmentQuestion_ProposedProjectID_AssessmentQuestionID] UNIQUE NONCLUSTERED 
(
	[ProposedProjectID] ASC,
	[AssessmentQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectAssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectAssessmentQuestion_AssessmentQuestion_AssessmentQuestionID] FOREIGN KEY([AssessmentQuestionID])
REFERENCES [dbo].[AssessmentQuestion] ([AssessmentQuestionID])
GO
ALTER TABLE [dbo].[ProposedProjectAssessmentQuestion] CHECK CONSTRAINT [FK_ProposedProjectAssessmentQuestion_AssessmentQuestion_AssessmentQuestionID]
GO
ALTER TABLE [dbo].[ProposedProjectAssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectAssessmentQuestion_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectAssessmentQuestion] CHECK CONSTRAINT [FK_ProposedProjectAssessmentQuestion_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectAssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectAssessmentQuestion_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectAssessmentQuestion] CHECK CONSTRAINT [FK_ProposedProjectAssessmentQuestion_Tenant_TenantID]