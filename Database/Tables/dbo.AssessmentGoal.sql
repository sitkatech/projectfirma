SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentGoal](
	[AssessmentGoalID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AssessmentGoalNumber] [int] NOT NULL,
	[AssessmentGoalTitle] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AssessmentGoalDescription] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_AssessmentGoal_AssessmentGoalID] PRIMARY KEY CLUSTERED 
(
	[AssessmentGoalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AssessmentGoal_AssessmentGoalID_TenantID] UNIQUE NONCLUSTERED 
(
	[AssessmentGoalID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AssessmentGoal_AssessmentGoalNumber_TenantID] UNIQUE NONCLUSTERED 
(
	[AssessmentGoalNumber] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AssessmentGoal_AssessmentGoalTitle_TenantID] UNIQUE NONCLUSTERED 
(
	[AssessmentGoalTitle] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AssessmentGoal]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentGoal_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AssessmentGoal] CHECK CONSTRAINT [FK_AssessmentGoal_Tenant_TenantID]