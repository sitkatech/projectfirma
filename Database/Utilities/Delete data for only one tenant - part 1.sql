--select * from dbo.Tenant

--IdahoAssociatonOfSoilConservationDistricts
--TenantID = 9

--begin tran

DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;


delete from dbo.ProjectOrganization
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectExternalLink
where TenantID = @tenantIdDataToDelete


delete from dbo.PerformanceMeasureExpectedSubcategoryOption
where TenantID = @tenantIdDataToDelete


delete from dbo.PerformanceMeasureExpected
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectImageUpdate
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectImage
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectLocation
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectClassification
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectNote
where TenantID = @tenantIdDataToDelete


delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate
where TenantID = @tenantIdDataToDelete


delete from dbo.PerformanceMeasureActualSubcategoryOption
where TenantID = @tenantIdDataToDelete


delete from dbo.PerformanceMeasureActualUpdate
where TenantID = @tenantIdDataToDelete


delete from dbo.PerformanceMeasureActual
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectGeospatialArea
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectUpdate
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectUpdateHistory
where TenantID = @tenantIdDataToDelete


delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectFundingSourceExpenditureUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectFundingSourceExpenditure where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectGeospatialAreaUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectExternalLinkUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectOrganizationUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectGeospatialAreaTypeNoteUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectExemptReportingYearUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectAttachmentUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectLocationStagingUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectLocationUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectNoteUpdate
where TenantID = @tenantIdDataToDelete

go
PRINT 'after go. line 113'


DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;

delete from dbo.PerformanceMeasureExpectedUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectCustomAttributeUpdateValue
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectCustomAttributeUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectRelevantCostTypeUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectContactUpdate
where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectNoFundingSourceIdentifiedUpdate where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectFundingSourceBudgetUpdate where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectFundingSourceBudget where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectClassificationUpdate where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectUpdateBatchClassificationSystem  where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectUpdateBatch
where TenantID = @tenantIdDataToDelete


delete from dbo.PerformanceMeasureActualUpdate
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectLocationStaging
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectTag
where TenantID = @tenantIdDataToDelete


delete from dbo.NotificationProject
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectGeospatialAreaTypeNote
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectExemptReportingYear
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectAttachment
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectCustomAttributeValue
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectCustomAttribute
where TenantID = @tenantIdDataToDelete



delete from dbo.ProjectInternalNote
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectContact
where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectRelevantCostType
where TenantID = @tenantIdDataToDelete


delete from dbo.SecondaryProjectTaxonomyLeaf
where TenantID = @tenantIdDataToDelete

go
PRINT 'after go. line 205'


DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;


delete from dbo.FirmaPageImage where TenantID = @tenantIdDataToDelete
delete from dbo.DocumentLibraryDocumentRole where TenantID = @tenantIdDataToDelete
delete from dbo.FirmaPage where TenantID = @tenantIdDataToDelete
delete from dbo.AssessmentSubGoal where TenantID = @tenantIdDataToDelete
delete from dbo.FieldDefinitionDataImage where TenantID = @tenantIdDataToDelete
go
PRINT 'after go. line 218'


DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;

delete from dbo.ProjectRelevantCostTypeUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectCustomAttributeTypeRole where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectOrganizationUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectNoteUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.FileResourceData where TenantID = @tenantIdDataToDelete

delete from dbo.PerformanceMeasureSubcategoryOption where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureSubcategory where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectCustomAttributeValue where TenantID = @tenantIdDataToDelete
--LOG_BACKUP full here
go
PRINT 'after go. line 235'


DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;

delete from dbo.FundingSourceCustomAttributeValue where TenantID = @tenantIdDataToDelete
delete from dbo.FundingSourceCustomAttribute where TenantID = @tenantIdDataToDelete
delete from dbo.FundingSourceCustomAttributeType where TenantID = @tenantIdDataToDelete

-- NO, don't delete the Tenant itself.
--delete from dbo.Tenant where TenantID = @tenantIdDataToDelete
delete from dbo.OrganizationBoundaryStaging where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectUpdateSetting where TenantID = @tenantIdDataToDelete




delete from dbo.AssessmentQuestion where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectUpdateHistory where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectProjectStatus where TenantID = @tenantIdDataToDelete
delete from dbo.TrainingVideo where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectContact where TenantID = @tenantIdDataToDelete
go
PRINT 'after go. line 259'

DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;


delete from dbo.ProjectImageUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectCustomAttributeGroupProjectCategory where TenantID = @tenantIdDataToDelete

delete from dbo.ReportTemplate where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectContactUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureNote where TenantID = @tenantIdDataToDelete

delete from dbo.MatchmakerOrganizationClassification where TenantID = @tenantIdDataToDelete
delete from dbo.[Classification] where TenantID = @tenantIdDataToDelete
delete from dbo.OrganizationImage where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectCustomGridConfiguration where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectCustomAttributeType where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectNoFundingSourceIdentified where TenantID = @tenantIdDataToDelete



delete from dbo.ProjectGeospatialArea where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectCustomAttribute where TenantID = @tenantIdDataToDelete

go

--good to here




--rollback tran