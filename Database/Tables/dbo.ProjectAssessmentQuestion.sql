SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAssessmentQuestion](
	[ProjectAssessmentQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[AssessmentQuestionID] [int] NOT NULL,
	[Answer] [bit] NULL,
 CONSTRAINT [PK_ProjectAssessmentQuestion_ProjectAssessmentQuestionID] PRIMARY KEY CLUSTERED 
(
	[ProjectAssessmentQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectAssessmentQuestion_ProjectID_AssessmentQuestionID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[AssessmentQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssessmentQuestion_AssessmentQuestion_AssessmentQuestionID] FOREIGN KEY([AssessmentQuestionID])
REFERENCES [dbo].[AssessmentQuestion] ([AssessmentQuestionID])
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion] CHECK CONSTRAINT [FK_ProjectAssessmentQuestion_AssessmentQuestion_AssessmentQuestionID]
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssessmentQuestion_AssessmentQuestion_AssessmentQuestionID_TenantID] FOREIGN KEY([AssessmentQuestionID], [TenantID])
REFERENCES [dbo].[AssessmentQuestion] ([AssessmentQuestionID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion] CHECK CONSTRAINT [FK_ProjectAssessmentQuestion_AssessmentQuestion_AssessmentQuestionID_TenantID]
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssessmentQuestion_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion] CHECK CONSTRAINT [FK_ProjectAssessmentQuestion_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssessmentQuestion_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion] CHECK CONSTRAINT [FK_ProjectAssessmentQuestion_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssessmentQuestion_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectAssessmentQuestion] CHECK CONSTRAINT [FK_ProjectAssessmentQuestion_Tenant_TenantID]