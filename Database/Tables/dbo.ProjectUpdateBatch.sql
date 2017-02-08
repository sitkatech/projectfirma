SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdateBatch](
	[ProjectUpdateBatchID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[PerformanceMeasureActualYearsExemptionExplanation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShowBasicsValidationWarnings] [bit] NOT NULL,
	[ShowPerformanceMeasuresValidationWarnings] [bit] NOT NULL,
	[ShowExpendituresValidationWarnings] [bit] NOT NULL,
	[ShowBudgetsValidationWarnings] [bit] NOT NULL,
	[ShowLocationSimpleValidationWarnings] [bit] NOT NULL,
	[LastUpdatePersonID] [int] NOT NULL,
	[BasicsComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExpendituresComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PerformanceMeasuresComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LocationSimpleComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LocationDetailedComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BudgetsComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectUpdateStateID] [int] NOT NULL,
	[IsPhotosUpdated] [bit] NOT NULL,
	[BasicsDiffLog] [dbo].[html] NULL,
	[PerformanceMeasureDiffLog] [dbo].[html] NULL,
	[ExpendituresDiffLog] [dbo].[html] NULL,
	[BudgetsDiffLog] [dbo].[html] NULL,
	[ExternalLinksDiffLog] [dbo].[html] NULL,
	[NotesDiffLog] [dbo].[html] NULL,
 CONSTRAINT [PK_ProjectUpdateBatch_ProjectUpdateBatchID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateBatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_Person_LastUpdatePersonID_PersonID] FOREIGN KEY([LastUpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_Person_LastUpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_ProjectUpdateState_ProjectUpdateStateID] FOREIGN KEY([ProjectUpdateStateID])
REFERENCES [dbo].[ProjectUpdateState] ([ProjectUpdateStateID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_ProjectUpdateState_ProjectUpdateStateID]