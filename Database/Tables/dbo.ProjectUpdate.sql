SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdate](
	[ProjectUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[ProjectStageID] [int] NOT NULL,
	[ProjectDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ImplementationStartYear] [int] NULL,
	[CompletionYear] [int] NULL,
	[EstimatedTotalCostDeprecated] [money] NULL,
	[ProjectLocationPoint] [geometry] NULL,
	[ProjectLocationNotes] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlanningDesignStartYear] [int] NULL,
	[ProjectLocationSimpleTypeID] [int] NOT NULL,
	[EstimatedAnnualOperatingCostDeprecated] [decimal](18, 0) NULL,
	[PrimaryContactPersonID] [int] NULL,
	[FundingTypeID] [int] NULL,
	[NoFundingSourceIdentifiedYet] [money] NULL,
 CONSTRAINT [PK_ProjectUpdate_ProjectUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdate_ProjectUpdateBatchID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdate_ProjectUpdateID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdate_FundingType_FundingTypeID] FOREIGN KEY([FundingTypeID])
REFERENCES [dbo].[FundingType] ([FundingTypeID])
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [FK_ProjectUpdate_FundingType_FundingTypeID]
GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdate_Person_PrimaryContactPersonID_PersonID] FOREIGN KEY([PrimaryContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [FK_ProjectUpdate_Person_PrimaryContactPersonID_PersonID]
GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdate_Person_PrimaryContactPersonID_TenantID_PersonID_TenantID] FOREIGN KEY([PrimaryContactPersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [FK_ProjectUpdate_Person_PrimaryContactPersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdate_ProjectLocationSimpleType_ProjectLocationSimpleTypeID] FOREIGN KEY([ProjectLocationSimpleTypeID])
REFERENCES [dbo].[ProjectLocationSimpleType] ([ProjectLocationSimpleTypeID])
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [FK_ProjectUpdate_ProjectLocationSimpleType_ProjectLocationSimpleTypeID]
GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdate_ProjectStage_ProjectStageID] FOREIGN KEY([ProjectStageID])
REFERENCES [dbo].[ProjectStage] ([ProjectStageID])
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [FK_ProjectUpdate_ProjectStage_ProjectStageID]
GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [FK_ProjectUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [FK_ProjectUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [FK_ProjectUpdate_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectUpdate]  WITH CHECK ADD  CONSTRAINT [CK_ProjectUpdate_ProjectLocationPoint_IsPointData] CHECK  (([ProjectLocationPoint] IS NULL OR [ProjectLocationPoint] IS NOT NULL AND [ProjectLocationPoint].[STGeometryType]()='Point'))
GO
ALTER TABLE [dbo].[ProjectUpdate] CHECK CONSTRAINT [CK_ProjectUpdate_ProjectLocationPoint_IsPointData]