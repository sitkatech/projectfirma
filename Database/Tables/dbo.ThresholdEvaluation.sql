SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThresholdEvaluation](
	[ThresholdEvaluationID] [int] IDENTITY(1,1) NOT NULL,
	[ThresholdEvaluationPeriodID] [int] NOT NULL,
	[ThresholdIndicatorID] [int] NOT NULL,
	[ThresholdEvaluationStatusTypeID] [int] NULL,
	[ThresholdEvaluationTrendTypeID] [int] NULL,
	[ThresholdEvaluationConfidenceTypeID] [int] NULL,
	[ThresholdEvaluationManagementStatusTypeID] [int] NULL,
	[StatusRationale] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TrendRationale] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ConfidenceStatus] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ConfidenceTrend] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ConfidenceOverall] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProgramsAndActionsImplementedToImproveConditions] [varchar](8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EffectivenessOfProgramsAndActions] [varchar](8000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InterimTarget] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TargetAttainmentDate] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AnalyticApproachRecommendation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MonitoringApproachRecommendation] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModificationOfTheThresholdStandardOrIndicator] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AttainOrMaintainThreshold] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MapFileResourceID] [int] NULL,
	[MapCaption] [varchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HistoricEvaluationPdfFileResourceID] [int] NULL,
 CONSTRAINT [PK_ThresholdEvaluation_ThresholdEvaluationID] PRIMARY KEY CLUSTERED 
(
	[ThresholdEvaluationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ThresholdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdEvaluation_FileResource_HistoricEvaluationPdfFileResourceID_FileResourceID] FOREIGN KEY([HistoricEvaluationPdfFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ThresholdEvaluation] CHECK CONSTRAINT [FK_ThresholdEvaluation_FileResource_HistoricEvaluationPdfFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[ThresholdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdEvaluation_FileResource_MapFileResourceID_FileResourceID] FOREIGN KEY([MapFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[ThresholdEvaluation] CHECK CONSTRAINT [FK_ThresholdEvaluation_FileResource_MapFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[ThresholdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationConfidenceType_ThresholdEvaluationConfidenceTypeID] FOREIGN KEY([ThresholdEvaluationConfidenceTypeID])
REFERENCES [dbo].[ThresholdEvaluationConfidenceType] ([ThresholdEvaluationConfidenceTypeID])
GO
ALTER TABLE [dbo].[ThresholdEvaluation] CHECK CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationConfidenceType_ThresholdEvaluationConfidenceTypeID]
GO
ALTER TABLE [dbo].[ThresholdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationManagementStatusType_ThresholdEvaluationManagementStatusTypeID] FOREIGN KEY([ThresholdEvaluationManagementStatusTypeID])
REFERENCES [dbo].[ThresholdEvaluationManagementStatusType] ([ThresholdEvaluationManagementStatusTypeID])
GO
ALTER TABLE [dbo].[ThresholdEvaluation] CHECK CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationManagementStatusType_ThresholdEvaluationManagementStatusTypeID]
GO
ALTER TABLE [dbo].[ThresholdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationPeriod_ThresholdEvaluationPeriodID] FOREIGN KEY([ThresholdEvaluationPeriodID])
REFERENCES [dbo].[ThresholdEvaluationPeriod] ([ThresholdEvaluationPeriodID])
GO
ALTER TABLE [dbo].[ThresholdEvaluation] CHECK CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationPeriod_ThresholdEvaluationPeriodID]
GO
ALTER TABLE [dbo].[ThresholdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationStatusType_ThresholdEvaluationStatusTypeID] FOREIGN KEY([ThresholdEvaluationStatusTypeID])
REFERENCES [dbo].[ThresholdEvaluationStatusType] ([ThresholdEvaluationStatusTypeID])
GO
ALTER TABLE [dbo].[ThresholdEvaluation] CHECK CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationStatusType_ThresholdEvaluationStatusTypeID]
GO
ALTER TABLE [dbo].[ThresholdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationTrendType_ThresholdEvaluationTrendTypeID] FOREIGN KEY([ThresholdEvaluationTrendTypeID])
REFERENCES [dbo].[ThresholdEvaluationTrendType] ([ThresholdEvaluationTrendTypeID])
GO
ALTER TABLE [dbo].[ThresholdEvaluation] CHECK CONSTRAINT [FK_ThresholdEvaluation_ThresholdEvaluationTrendType_ThresholdEvaluationTrendTypeID]
GO
ALTER TABLE [dbo].[ThresholdEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ThresholdEvaluation_ThresholdIndicator_ThresholdIndicatorID] FOREIGN KEY([ThresholdIndicatorID])
REFERENCES [dbo].[ThresholdIndicator] ([ThresholdIndicatorID])
GO
ALTER TABLE [dbo].[ThresholdEvaluation] CHECK CONSTRAINT [FK_ThresholdEvaluation_ThresholdIndicator_ThresholdIndicatorID]