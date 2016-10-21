SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ActionPriorityID] [int] NOT NULL,
	[ProjectStageID] [int] NOT NULL,
	[ProjectNumber] [smallint] NOT NULL,
	[ProjectName] [varchar](140) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ImplementationStartYear] [int] NULL,
	[CompletionYear] [int] NULL,
	[OldEipNumber] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EstimatedTotalCost] [money] NULL,
	[ImplementsMultipleProjects] [bit] NOT NULL,
	[SecuredFunding] [money] NULL,
	[ProjectLocationPoint] [geometry] NULL,
	[ProjectLocationAreaID] [int] NULL,
	[EIPPerformanceMeasureActualYearsExemptionExplanation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsFeatured] [bit] NOT NULL,
	[TransportationObjectiveID] [int] NULL,
	[ProjectLocationNotes] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OnFederalTransportationImprovementProgramList] [bit] NOT NULL,
	[PlanningDesignStartYear] [int] NULL,
	[ProjectLocationSimpleTypeID] [int] NOT NULL,
	[EstimatedAnnualOperatingCost] [decimal](18, 0) NULL,
	[FundingTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Project_ProjectID] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Project_ActionPriorityID_ProjectNumber] UNIQUE NONCLUSTERED 
(
	[ActionPriorityID] ASC,
	[ProjectNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Project_ProjectName] UNIQUE NONCLUSTERED 
(
	[ProjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ActionPriority_ActionPriorityID] FOREIGN KEY([ActionPriorityID])
REFERENCES [dbo].[ActionPriority] ([ActionPriorityID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ActionPriority_ActionPriorityID]
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
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_TransportationObjective_TransportationObjectiveID] FOREIGN KEY([TransportationObjectiveID])
REFERENCES [dbo].[TransportationObjective] ([TransportationObjectiveID])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_TransportationObjective_TransportationObjectiveID]
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
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_ProjectNumberBetween1And9999] CHECK  (([ProjectNumber]>=(1) AND [ProjectNumber]<=(9999)))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_ProjectNumberBetween1And9999]
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
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CK_Project_TransportationObjectiveIDNeedsToBeSetToBeOnFTIPList] CHECK  (([OnFederalTransportationImprovementProgramList]=(0) OR [OnFederalTransportationImprovementProgramList]=(1) AND [TransportationObjectiveID] IS NOT NULL))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CK_Project_TransportationObjectiveIDNeedsToBeSetToBeOnFTIPList]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
CREATE SPATIAL INDEX [SPATIAL_Project_ProjectLocationPoint] ON [dbo].[Project]
(
	[ProjectLocationPoint]
)USING  GEOMETRY_AUTO_GRID 
WITH (BOUNDING_BOX =(-121, 38, -119, 40), 
CELLS_PER_OBJECT = 8, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]