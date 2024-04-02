
declare @approvedUpdateStateID int
set @approvedUpdateStateID = 4
DECLARE @ProjectUpdateBatchApproved AS TABLE 
(
	TempID int identity(1,1) not null,
	ProjectUpdateBatchID int  NOT NULL
)
 
 INSERT INTO @ProjectUpdateBatchApproved ( ProjectUpdateBatchID )
 SELECT ProjectUpdateBatchID from dbo.ProjectUpdateBatch where ProjectUpdateStateID = @approvedUpdateStateID



	-- delete everything except for ProjectUpdateHistory and ProjectUpdateBatchClassificationSystem
	delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate where PerformanceMeasureActualUpdateID in (select PerformanceMeasureActualUpdateID from dbo.PerformanceMeasureActualUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved))
	delete from dbo.PerformanceMeasureActualUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)

	delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate where PerformanceMeasureExpectedUpdateID in (select PerformanceMeasureExpectedUpdateID from dbo.PerformanceMeasureExpectedUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved))
	delete from dbo.PerformanceMeasureExpectedUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	
	delete from dbo.ProjectAttachmentUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectClassificationUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectContactUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)

	delete from dbo.ProjectCustomAttributeUpdateValue where ProjectCustomAttributeUpdateID in (select ProjectCustomAttributeUpdateID from dbo.ProjectCustomAttributeUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved))
	delete from dbo.ProjectCustomAttributeUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	
	delete from dbo.ProjectExemptReportingYearUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectExternalLinkUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectFundingSourceBudgetUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectFundingSourceExpenditureUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectGeospatialAreaTypeNoteUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectGeospatialAreaUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectImageUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectLocationStagingUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectLocationUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectNoFundingSourceIdentifiedUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectNoteUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectOrganizationUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectRelevantCostTypeUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)
	delete from dbo.ProjectUpdate where ProjectUpdateBatchID in (select ProjectUpdateBatchID from @ProjectUpdateBatchApproved)

