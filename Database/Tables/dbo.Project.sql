SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[TaxonomyTierOneID] [int] NOT NULL,
	[ProjectStageID] [int] NOT NULL,
	[ProjectName] [varchar](140) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ImplementationStartYear] [int] NULL,
	[CompletionYear] [int] NULL,
	[EstimatedTotalCost] [money] NULL,
	[SecuredFunding] [money] NULL,
	[ProjectLocationPoint] [geometry] NULL,
	[ProjectLocationAreaID] [int] NULL,
	[PerformanceMeasureActualYearsExemptionExplanation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsFeatured] [bit] NOT NULL,
	[ProjectLocationNotes] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PlanningDesignStartYear] [int] NULL,
	[ProjectLocationSimpleTypeID] [int] NOT NULL,
	[EstimatedAnnualOperatingCost] [decimal](18, 0) NULL,
	[FundingTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Project_ProjectID] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Project_ProjectName] UNIQUE NONCLUSTERED 
(
	[ProjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_FundingType_FundingTypeID] FOREIGN KEY([FundingTypeID])
REFERENCES [dbo].[FundingType] ([FundingTypeID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_FundingType_FundingTypeID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectLocationArea_ProjectLocationAreaID] FOREIGN KEY([ProjectLocationAreaID])
REFERENCES [dbo].[ProjectLocationArea] ([ProjectLocationAreaID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectLocationArea_ProjectLocationAreaID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectLocationSimpleType_ProjectLocationSimpleTypeID] FOREIGN KEY([ProjectLocationSimpleTypeID])
REFERENCES [dbo].[ProjectLocationSimpleType] ([ProjectLocationSimpleTypeID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectLocationSimpleType_ProjectLocationSimpleTypeID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectStage_ProjectStageID] FOREIGN KEY([ProjectStageID])
REFERENCES [dbo].[ProjectStage] ([ProjectStageID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectStage_ProjectStageID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_TaxonomyTierOne_TaxonomyTierOneID] FOREIGN KEY([TaxonomyTierOneID])
REFERENCES [dbo].[TaxonomyTierOne] ([TaxonomyTierOneID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_TaxonomyTierOne_TaxonomyTierOneID]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_AnnualCostForOperationsProjectsOnly] CHECK  (([FundingTypeID]=(2) OR [EstimatedAnnualOperatingCost] IS NULL))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_AnnualCostForOperationsProjectsOnly]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_CompletionYearHasToBeSetWhenStageIsInCompletedOrPostImplementation] CHECK  ((NOT ([ProjectStageID]=(8) OR [ProjectStageID]=(4)) OR ([ProjectStageID]=(8) OR [ProjectStageID]=(4)) AND [CompletionYear]<=datepart(year,getdate())))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_CompletionYearHasToBeSetWhenStageIsInCompletedOrPostImplementation]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_EstimatedTotalCostWholeDollarOnlyNoCents] CHECK  (([EstimatedTotalCost]%(1)=(0.0)))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_EstimatedTotalCostWholeDollarOnlyNoCents]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_ImplementationStartYearLessThanEqualToCompletionYear] CHECK  (([ImplementationStartYear] IS NULL OR [CompletionYear] IS NULL OR [CompletionYear]>=[ImplementationStartYear]))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_ImplementationStartYearLessThanEqualToCompletionYear]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_PlanningDesignStartYearLessThanEqualToImplementationYear] CHECK  (([PlanningDesignStartYear] IS NULL OR [ImplementationStartYear] IS NULL OR [ImplementationStartYear]>=[PlanningDesignStartYear]))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_PlanningDesignStartYearLessThanEqualToImplementationYear]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_ProjectLocationPoint_IsPointData] CHECK  (([ProjectLocationPoint] IS NULL OR [ProjectLocationPoint] IS NOT NULL AND [ProjectLocationPoint].[STGeometryType]()='Point'))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_ProjectLocationPoint_IsPointData]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_ProjectLocationPointXorProjectLocationArea] CHECK  (([ProjectLocationAreaID] IS NULL AND [ProjectLocationPoint] IS NULL OR [ProjectLocationAreaID] IS NOT NULL AND [ProjectLocationPoint] IS NULL OR [ProjectLocationAreaID] IS NULL AND [ProjectLocationPoint] IS NOT NULL))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_ProjectLocationPointXorProjectLocationArea]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_SecuredFundingForCapitalProjectsOnly] CHECK  (([FundingTypeID]=(1) OR [SecuredFunding] IS NULL))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_SecuredFundingForCapitalProjectsOnly]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_TotalCostForCapitalProjectsOnly] CHECK  (([FundingTypeID]=(1) OR [EstimatedTotalCost] IS NULL))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_TotalCostForCapitalProjectsOnly]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_TotalOrAnnualCostNotBoth] CHECK  (([EstimatedAnnualOperatingCost] IS NOT NULL AND [EstimatedTotalCost] IS NULL OR [EstimatedAnnualOperatingCost] IS NULL AND [EstimatedTotalCost] IS NOT NULL OR [EstimatedAnnualOperatingCost] IS NULL AND [EstimatedTotalCost] IS NULL))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_TotalOrAnnualCostNotBoth]