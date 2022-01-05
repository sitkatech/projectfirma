--select * from dbo.Tenant

--RCD Project Tracker
--TenantID = 3

--begin tran

DECLARE @tenantIdDataToKeep INT;
SET @tenantIdDataToKeep = 3;


delete from dbo.ProjectOrganization
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectExternalLink
where TenantID != @tenantIdDataToKeep


delete from dbo.PerformanceMeasureExpectedSubcategoryOption
where TenantID != @tenantIdDataToKeep


delete from dbo.PerformanceMeasureExpected
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectImageUpdate
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectImage
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectLocation
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectClassification
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectNote
where TenantID != @tenantIdDataToKeep


delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate
where TenantID != @tenantIdDataToKeep


delete from dbo.PerformanceMeasureActualSubcategoryOption
where TenantID != @tenantIdDataToKeep


delete from dbo.PerformanceMeasureActualUpdate
where TenantID != @tenantIdDataToKeep


delete from dbo.PerformanceMeasureActual
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectGeospatialArea
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectUpdate
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectUpdateHistory
where TenantID != @tenantIdDataToKeep


delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectFundingSourceExpenditureUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectFundingSourceExpenditure where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectGeospatialAreaUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectExternalLinkUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectOrganizationUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectGeospatialAreaTypeNoteUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectExemptReportingYearUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectAttachmentUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectLocationStagingUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectLocationUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectNoteUpdate
where TenantID != @tenantIdDataToKeep

go
PRINT 'after go. line 113'


DECLARE @tenantIdDataToKeep INT;
SET @tenantIdDataToKeep = 3;

delete from dbo.TechnicalAssistanceRequestUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.PerformanceMeasureExpectedUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectCustomAttributeUpdateValue
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectCustomAttributeUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectRelevantCostTypeUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectContactUpdate
where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectNoFundingSourceIdentifiedUpdate where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectFundingSourceBudgetUpdate where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectFundingSourceBudget where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectClassificationUpdate where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectUpdateBatch
where TenantID != @tenantIdDataToKeep


delete from dbo.PerformanceMeasureActualUpdate
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectLocationStaging
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectTag
where TenantID != @tenantIdDataToKeep


delete from dbo.NotificationProject
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectGeospatialAreaTypeNote
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectExemptReportingYear
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectAttachment
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectCustomAttributeValue
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectCustomAttribute
where TenantID != @tenantIdDataToKeep


delete from dbo.TechnicalAssistanceRequest
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectInternalNote
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectContact
where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectRelevantCostType
where TenantID != @tenantIdDataToKeep


delete from dbo.SecondaryProjectTaxonomyLeaf
where TenantID != @tenantIdDataToKeep

go
PRINT 'after go. line 205'


DECLARE @tenantIdDataToKeep INT;
SET @tenantIdDataToKeep = 3;


delete from dbo.FirmaPageImage where TenantID != @tenantIdDataToKeep
delete from dbo.DocumentLibraryDocumentRole where TenantID != @tenantIdDataToKeep
delete from dbo.FirmaPage where TenantID != @tenantIdDataToKeep
delete from dbo.AssessmentSubGoal where TenantID != @tenantIdDataToKeep
delete from dbo.FieldDefinitionDataImage where TenantID != @tenantIdDataToKeep
go
PRINT 'after go. line 218'


DECLARE @tenantIdDataToKeep INT;
SET @tenantIdDataToKeep = 3;

delete from dbo.ProjectRelevantCostTypeUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeTypeRole where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectOrganizationUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectNoteUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.FileResourceData where TenantID != @tenantIdDataToKeep

delete from dbo.PerformanceMeasureSubcategoryOption where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureSubcategory where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeValue where TenantID != @tenantIdDataToKeep
--LOG_BACKUP full here
go
PRINT 'after go. line 235'


DECLARE @tenantIdDataToKeep INT;
SET @tenantIdDataToKeep = 3;

delete from dbo.FundingSourceCustomAttributeValue where TenantID != @tenantIdDataToKeep
delete from dbo.FundingSourceCustomAttribute where TenantID != @tenantIdDataToKeep
delete from dbo.FundingSourceCustomAttributeType where TenantID != @tenantIdDataToKeep

-- NO, don't delete the Tenant itself.
--delete from dbo.Tenant where TenantID != @tenantIdDataToKeep
delete from dbo.OrganizationBoundaryStaging where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectUpdateSetting where TenantID != @tenantIdDataToKeep




delete from dbo.AssessmentQuestion where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectUpdateHistory where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectProjectStatus where TenantID != @tenantIdDataToKeep
delete from dbo.TrainingVideo where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectContact where TenantID != @tenantIdDataToKeep
go
PRINT 'after go. line 259'

DECLARE @tenantIdDataToKeep INT;
SET @tenantIdDataToKeep = 3;


delete from dbo.ProjectImageUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeGroupProjectCategory where TenantID != @tenantIdDataToKeep

delete from dbo.ReportTemplate where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectContactUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureNote where TenantID != @tenantIdDataToKeep

delete from dbo.MatchmakerOrganizationClassification where TenantID != @tenantIdDataToKeep
delete from dbo.[Classification] where TenantID != @tenantIdDataToKeep
delete from dbo.OrganizationImage where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomGridConfiguration where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeType where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectNoFundingSourceIdentified where TenantID != @tenantIdDataToKeep



delete from dbo.ProjectGeospatialArea where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttribute where TenantID != @tenantIdDataToKeep

go

--good to here




--rollback tran