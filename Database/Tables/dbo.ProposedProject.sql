SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProject](
	[ProposedProjectID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectName] [varchar](140) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LeadImplementerOrganizationID] [int] NOT NULL,
	[ProposingPersonID] [int] NOT NULL,
	[ProposingDate] [datetime] NOT NULL,
	[ImplementationStartYear] [int] NULL,
	[CompletionYear] [int] NULL,
	[EstimatedTotalCost] [money] NULL,
	[SecuredFunding] [money] NULL,
	[ProjectLocationPoint] [geometry] NULL,
	[ProjectLocationAreaID] [int] NULL,
	[ProjectLocationNotes] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlanningDesignStartYear] [int] NULL,
	[ProjectLocationSimpleTypeID] [int] NOT NULL,
	[EstimatedAnnualOperatingCost] [decimal](18, 0) NULL,
	[FundingTypeID] [int] NOT NULL,
	[ProposedProjectStateID] [int] NOT NULL,
	[TaxonomyTierOneID] [int] NULL,
	[PerformanceMeasureNotes] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectID] [int] NULL,
	[SubmissionDate] [datetime] NULL,
	[ApprovalDate] [datetime] NULL,
	[ReviewedByPersonID] [int] NULL,
 CONSTRAINT [PK_ProposedProject_ProposedProjectID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProject_ProjectID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProject_ProjectName_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProject_ProposedProjectID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProposedProjectID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_FundingType_FundingTypeID] FOREIGN KEY([FundingTypeID])
REFERENCES [dbo].[FundingType] ([FundingTypeID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_FundingType_FundingTypeID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Organization_LeadImplementerOrganizationID_OrganizationID] FOREIGN KEY([LeadImplementerOrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Organization_LeadImplementerOrganizationID_OrganizationID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Organization_LeadImplementerOrganizationID_TenantID_OrganizationID_TenantID] FOREIGN KEY([LeadImplementerOrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Organization_LeadImplementerOrganizationID_TenantID_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Person_ProposingPersonID_PersonID] FOREIGN KEY([ProposingPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Person_ProposingPersonID_PersonID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Person_ProposingPersonID_TenantID_PersonID_TenantID] FOREIGN KEY([ProposingPersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Person_ProposingPersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Person_ReviewedByPersonID_PersonID] FOREIGN KEY([ReviewedByPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Person_ReviewedByPersonID_PersonID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Person_ReviewedByPersonID_TenantID_PersonID_TenantID] FOREIGN KEY([ReviewedByPersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Person_ReviewedByPersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_ProjectLocationArea_ProjectLocationAreaID] FOREIGN KEY([ProjectLocationAreaID])
REFERENCES [dbo].[ProjectLocationArea] ([ProjectLocationAreaID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_ProjectLocationArea_ProjectLocationAreaID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_ProjectLocationArea_ProjectLocationAreaID_TenantID] FOREIGN KEY([ProjectLocationAreaID], [TenantID])
REFERENCES [dbo].[ProjectLocationArea] ([ProjectLocationAreaID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_ProjectLocationArea_ProjectLocationAreaID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_ProjectLocationSimpleType_ProjectLocationSimpleTypeID] FOREIGN KEY([ProjectLocationSimpleTypeID])
REFERENCES [dbo].[ProjectLocationSimpleType] ([ProjectLocationSimpleTypeID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_ProjectLocationSimpleType_ProjectLocationSimpleTypeID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_ProposedProjectState_ProposedProjectStateID] FOREIGN KEY([ProposedProjectStateID])
REFERENCES [dbo].[ProposedProjectState] ([ProposedProjectStateID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_ProposedProjectState_ProposedProjectStateID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_TaxonomyTierOne_TaxonomyTierOneID] FOREIGN KEY([TaxonomyTierOneID])
REFERENCES [dbo].[TaxonomyTierOne] ([TaxonomyTierOneID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_TaxonomyTierOne_TaxonomyTierOneID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_TaxonomyTierOne_TaxonomyTierOneID_TenantID] FOREIGN KEY([TaxonomyTierOneID], [TenantID])
REFERENCES [dbo].[TaxonomyTierOne] ([TaxonomyTierOneID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_TaxonomyTierOne_TaxonomyTierOneID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProject_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [FK_ProposedProject_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_AnnualCostForOperationsProposedProjectsOnly] CHECK  (([FundingTypeID]=(2) OR [EstimatedAnnualOperatingCost] IS NULL))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_AnnualCostForOperationsProposedProjectsOnly]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_EstimatedTotalCostWholeDollarOnlyNoCents] CHECK  (([EstimatedTotalCost]%(1)=(0.0)))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_EstimatedTotalCostWholeDollarOnlyNoCents]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_ImplementationStartYearLessThanEqualToCompletionYear] CHECK  (([ImplementationStartYear] IS NULL OR [CompletionYear] IS NULL OR [CompletionYear]>=[ImplementationStartYear]))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_ImplementationStartYearLessThanEqualToCompletionYear]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_MustHaveProjectIDIfStateIsApproved] CHECK  (([ProposedProject].[ProjectID] IS NOT NULL OR [ProposedProject].[ProposedProjectStateID]<>(3)))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_MustHaveProjectIDIfStateIsApproved]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_PlanningDesignStartYearLessThanEqualToImplementationYear] CHECK  (([PlanningDesignStartYear] IS NULL OR [ImplementationStartYear] IS NULL OR [ImplementationStartYear]>=[PlanningDesignStartYear]))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_PlanningDesignStartYearLessThanEqualToImplementationYear]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_ProjectLocationPoint_IsPointData] CHECK  (([ProjectLocationPoint] IS NULL OR [ProjectLocationPoint] IS NOT NULL AND [ProjectLocationPoint].[STGeometryType]()='Point'))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_ProjectLocationPoint_IsPointData]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_ProjectLocationPointXorProposedProjectLocationArea] CHECK  (([ProjectLocationAreaID] IS NULL AND [ProjectLocationPoint] IS NULL OR [ProjectLocationAreaID] IS NOT NULL AND [ProjectLocationPoint] IS NULL OR [ProjectLocationAreaID] IS NULL AND [ProjectLocationPoint] IS NOT NULL))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_ProjectLocationPointXorProposedProjectLocationArea]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_SecuredFundingForCapitalProposedProjectsOnly] CHECK  (([FundingTypeID]=(1) OR [SecuredFunding] IS NULL))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_SecuredFundingForCapitalProposedProjectsOnly]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_TotalCostForCapitalProposedProjectsOnly] CHECK  (([FundingTypeID]=(1) OR [EstimatedTotalCost] IS NULL))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_TotalCostForCapitalProposedProjectsOnly]
GO
ALTER TABLE [dbo].[ProposedProject]  WITH CHECK ADD  CONSTRAINT [CK_ProposedProject_TotalOrAnnualCostNotBoth] CHECK  (([EstimatedAnnualOperatingCost] IS NOT NULL AND [EstimatedTotalCost] IS NULL OR [EstimatedAnnualOperatingCost] IS NULL AND [EstimatedTotalCost] IS NOT NULL OR [EstimatedAnnualOperatingCost] IS NULL AND [EstimatedTotalCost] IS NULL))
GO
ALTER TABLE [dbo].[ProposedProject] CHECK CONSTRAINT [CK_ProposedProject_TotalOrAnnualCostNotBoth]