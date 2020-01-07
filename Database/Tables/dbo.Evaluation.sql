SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[EvaluationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[EvaluationVisibilityID] [int] NOT NULL,
	[EvaluationStatusID] [int] NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[EvaluationName] [varchar](120) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EvaluationDefinition] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EvaluationStartDate] [datetime] NULL,
	[EvaluationEndDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Evaluation_EvaluationID] PRIMARY KEY CLUSTERED 
(
	[EvaluationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Evaluation_EvaluationID_TenantID] UNIQUE NONCLUSTERED 
(
	[EvaluationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_EvaluationStatus_EvaluationStatusID] FOREIGN KEY([EvaluationStatusID])
REFERENCES [dbo].[EvaluationStatus] ([EvaluationStatusID])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_EvaluationStatus_EvaluationStatusID]
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_EvaluationVisibility_EvaluationVisibilityID] FOREIGN KEY([EvaluationVisibilityID])
REFERENCES [dbo].[EvaluationVisibility] ([EvaluationVisibilityID])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_EvaluationVisibility_EvaluationVisibilityID]
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_Person_CreatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([CreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_Person_CreatePersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_Tenant_TenantID]