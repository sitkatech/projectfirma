SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdateBatch](
	[ProjectUpdateBatchID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[LastUpdateDate] [datetime] NOT NULL,
	[PerformanceMeasureActualYearsExemptionExplanation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastUpdatePersonID] [int] NOT NULL,
	[BasicsComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExpendituresComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReportedPerformanceMeasuresComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
	[GeospatialAreaComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExpectedFundingComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExpectedFundingDiffLog] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OrganizationsComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OrganizationsDiffLog] [dbo].[html] NULL,
	[NoExpendituresToReportExplanation] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExpectedPerformanceMeasuresComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TechnicalAssistanceRequestsComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactsComment] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExpectedFundingUpdateNote] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactsDiffLog] [dbo].[html] NULL,
 CONSTRAINT [PK_ProjectUpdateBatch_ProjectUpdateBatchID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateBatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX [OnlyOneActiveUpdatePerProject] ON [dbo].[ProjectUpdateBatch]
(
	[TenantID] ASC,
	[ProjectID] ASC
)
WHERE ([ProjectUpdateStateID]<(4))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_Person_LastUpdatePersonID_PersonID] FOREIGN KEY([LastUpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_Person_LastUpdatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_Person_LastUpdatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([LastUpdatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_Person_LastUpdatePersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_ProjectUpdateState_ProjectUpdateStateID] FOREIGN KEY([ProjectUpdateStateID])
REFERENCES [dbo].[ProjectUpdateState] ([ProjectUpdateStateID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_ProjectUpdateState_ProjectUpdateStateID]
GO
ALTER TABLE [dbo].[ProjectUpdateBatch]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateBatch_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdateBatch] CHECK CONSTRAINT [FK_ProjectUpdateBatch_Tenant_TenantID]