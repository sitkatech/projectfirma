--select * from dbo.Tenant

--RCD Project Tracker
--TenantID = 3

begin tran

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


delete from dbo.Project
where TenantID != @tenantIdDataToKeep




delete from dbo.ProjectStatus where TenantID != @tenantIdDataToKeep
delete from dbo.FirmaPageImage where TenantID != @tenantIdDataToKeep
delete from dbo.DocumentLibraryDocumentRole where TenantID != @tenantIdDataToKeep
delete from dbo.FirmaPage where TenantID != @tenantIdDataToKeep
delete from dbo.AssessmentSubGoal where TenantID != @tenantIdDataToKeep
delete from dbo.FieldDefinitionDataImage where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectRelevantCostTypeUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeTypeRole where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectOrganizationUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectNoteUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.FileResourceData where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureSubcategoryOption where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeValue where TenantID != @tenantIdDataToKeep

delete from dbo.FundingSourceCustomAttributeValue where TenantID != @tenantIdDataToKeep
delete from dbo.FundingSourceCustomAttribute where TenantID != @tenantIdDataToKeep
delete from dbo.FundingSourceCustomAttributeType where TenantID != @tenantIdDataToKeep

-- NO, don't delete the Tenant itself.
--delete from dbo.Tenant where TenantID != @tenantIdDataToKeep
delete from dbo.OrganizationBoundaryStaging where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectUpdateSetting where TenantID != @tenantIdDataToKeep
delete from dbo.TaxonomyLeafPerformanceMeasure where TenantID != @tenantIdDataToKeep
delete from dbo.TaxonomyLeaf where TenantID != @tenantIdDataToKeep
delete from dbo.AssessmentQuestion where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectUpdateHistory where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectProjectStatus where TenantID != @tenantIdDataToKeep
delete from dbo.TrainingVideo where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectContact where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectImageUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeGroupProjectCategory where TenantID != @tenantIdDataToKeep
delete from dbo.TaxonomyBranch where TenantID != @tenantIdDataToKeep
delete from dbo.ReportTemplate where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureSubcategory where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectContactUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureNote where TenantID != @tenantIdDataToKeep

delete from dbo.AttachmentTypeTaxonomyTrunk where TenantID != @tenantIdDataToKeep
delete from dbo.TaxonomyTrunk where TenantID != @tenantIdDataToKeep
delete from dbo.[Classification] where TenantID != @tenantIdDataToKeep
delete from dbo.OrganizationImage where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomGridConfiguration where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeType where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectNoFundingSourceIdentified where TenantID != @tenantIdDataToKeep
delete from dbo.Evaluation where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureImage where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasure where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureActualUpdate where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectGeospatialArea where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttribute where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureImage where TenantID != @tenantIdDataToKeep





delete from dbo.PersonStewardOrganization where TenantID != @tenantIdDataToKeep
delete from dbo.PersonStewardTaxonomyBranch where TenantID != @tenantIdDataToKeep

/*
-- There's two-way bindings here between Person and Organziation that make things difficult
update dbo.Organization set PrimaryContactPersonID = null where TenantID != @tenantIdDataToKeep
alter table dbo.Person alter column OrganizationID int null
update dbo.Person set OrganizationID = null where TenantID != @tenantIdDataToKeep
*/
delete from dbo.Notification where TenantID != @tenantIdDataToKeep


delete from dbo.SupportRequestLog where TenantID != @tenantIdDataToKeep
delete from dbo.CustomPageImage where TenantID != @tenantIdDataToKeep
delete from dbo.FirmaHomePageImage where TenantID != @tenantIdDataToKeep

-- Problems start here?

-- PF framework needs TenantAttributes to be present for all Tenants. Since we aren't killing Tenants, these need to stay too.
--delete from dbo.TenantAttribute where TenantID != @tenantIdDataToKeep --and TenantID != 1
delete from dbo.FundingSource where TenantID != @tenantIdDataToKeep
-- We might not need every Org, but it's not a big table so figuring it out isn't interesting - just keep everything.
--delete from dbo.Organization where TenantID != @tenantIdDataToKeep
-- Kill all the Files infos we can, but we have to retain what TenantAttribute needs, as well as Organization
delete from dbo.FileResourceInfo where TenantID != @tenantIdDataToKeep and FileResourceInfoID not in 
    (
     select distinct TenantSquareLogoFileResourceInfoID as FileResourceInfoID from dbo.TenantAttribute where TenantSquareLogoFileResourceInfoID is not null 
     union
     select distinct TenantBannerLogoFileResourceInfoID as FileResourceInfoID from dbo.TenantAttribute where TenantBannerLogoFileResourceInfoID is not null
     union
     select distinct TenantStyleSheetFileResourceInfoID as FileResourceInfoID from dbo.TenantAttribute where TenantStyleSheetFileResourceInfoID is not null
     union
     select distinct TenantFactSheetLogoFileResourceInfoID as FileResourceInfoID from dbo.TenantAttribute where TenantFactSheetLogoFileResourceInfoID is not null
     union
     select distinct LogoFileResourceInfoID as FileResourceInfoID from dbo.Organization where LogoFileResourceInfoID is not null
     )

--select * from dbo.TenantAttribute
--select * from dbo.FileResourceInfo

delete from dbo.ReleaseNote where UpdatePersonID in (select p.PersonID from dbo.Person as p where TenantID != @tenantIdDataToKeep)
delete from dbo.ImportExternalProjectStaging where CreatePersonID in (select p.PersonID from dbo.Person as p where TenantID != @tenantIdDataToKeep)
delete from dbo.PersonStewardGeospatialArea where PersonID in (select p.PersonID from dbo.Person as p where TenantID != @tenantIdDataToKeep)

delete from dbo.Person where TenantID != @tenantIdDataToKeep and PersonID not in
                    (
                        -- All remaining FileResources should be wanted/needed by TenantAttribute table, which we can't kill entirely.
                        select distinct fri.CreatePersonID as PersonID from dbo.FileResourceInfo as fri
                        union
                        -- Again, respect what the TenantAttribute table needs to keep around
                        select distinct ta.PrimaryContactPersonID as PersonID from dbo.TenantAttribute as ta
                        union
                        -- People mentioned in Orgs need to stick around too
                        select distinct org.PrimaryContactPersonID as PersonID from dbo.Organization as org
                    )
alter table dbo.Person alter column OrganizationID int not null

--select * from dbo.Person
--select * from dbo.Organization

--delete from dbo.FileResourceInfo where TenantID != @tenantIdDataToKeep
delete from dbo.EvaluationCriteria where TenantID != @tenantIdDataToKeep

delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.AttachmentTypeFileResourceMimeType where TenantID != @tenantIdDataToKeep
delete from dbo.AttachmentType where TenantID != @tenantIdDataToKeep
delete from dbo.ClassificationSystem where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.EvaluationCriteriaValue where TenantID != @tenantIdDataToKeep
delete from dbo.Tag where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectGeospatialAreaUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureReportingPeriodTarget where TenantID != @tenantIdDataToKeep

delete from dbo.CostType where TenantID != @tenantIdDataToKeep
delete from dbo.ImportExternalProjectStaging where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectTag where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectEvaluation where TenantID != @tenantIdDataToKeep
delete from dbo.MatchmakerOrganizationTaxonomyBranch where TenantID != @tenantIdDataToKeep

delete from dbo.AttachmentTypeTaxonomyTrunk where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectExemptReportingYearUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.PersonStewardGeospatialArea where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectEvaluationSelectedValue where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomAttributeUpdateValue where TenantID != @tenantIdDataToKeep
delete from dbo.GeospatialAreaPerformanceMeasureReportingPeriodTarget where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectClassification where TenantID != @tenantIdDataToKeep
delete from dbo.SupportRequestLog where TenantID != @tenantIdDataToKeep
delete from dbo.MatchmakerOrganizationTaxonomyTrunk where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectLocationUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectAttachment where TenantID != @tenantIdDataToKeep

delete from dbo.CustomPageImage where TenantID != @tenantIdDataToKeep
delete from dbo.CustomPageRole where TenantID != @tenantIdDataToKeep
delete from dbo.CustomPage where TenantID != @tenantIdDataToKeep

delete from dbo.FundingSource where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectExemptReportingYear where TenantID != @tenantIdDataToKeep
delete from dbo.MatchmakerOrganizationTaxonomyLeaf where TenantID != @tenantIdDataToKeep
delete from dbo.ClassificationPerformanceMeasure where TenantID != @tenantIdDataToKeep

delete from dbo.AuditLog where TenantID != @tenantIdDataToKeep
delete from dbo.MatchMakerAreaOfInterestLocation where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectAttachmentUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.FundingSourceCustomAttributeTypeRole where TenantID != @tenantIdDataToKeep
delete from dbo.GeospatialAreaPerformanceMeasureNoTarget where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectInternalNote where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectLocation where TenantID != @tenantIdDataToKeep

delete from dbo.FieldDefinitionData where TenantID != @tenantIdDataToKeep
delete from dbo.TechnicalAssistanceRequest where TenantID != @tenantIdDataToKeep
delete from dbo.MatchmakerOrganizationPerformanceMeasure where TenantID != @tenantIdDataToKeep

delete from dbo.ProjectAssessmentQuestion where TenantID != @tenantIdDataToKeep
delete from dbo.FundingSourceCustomAttribute where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureExpectedSubcategoryOption where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectImage where TenantID != @tenantIdDataToKeep
delete from dbo.GeospatialAreaPerformanceMeasureFixedTarget where TenantID != @tenantIdDataToKeep
delete from dbo.GeospatialAreaImage where TenantID != @tenantIdDataToKeep

delete from dbo.TechnicalAssistanceRequestUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.Notification where TenantID != @tenantIdDataToKeep

delete from dbo.PersonSettingGridTable where TenantID != @tenantIdDataToKeep
delete from dbo.TechnicalAssistanceParameter where TenantID != @tenantIdDataToKeep
delete from dbo.MatchmakerKeyword where TenantID != @tenantIdDataToKeep
delete from dbo.FirmaHomePageImage where TenantID != @tenantIdDataToKeep
-- No, we need to keep this around
--delete from dbo.TenantAttribute where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureFixedTarget where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureExpected where TenantID != @tenantIdDataToKeep
delete from dbo.PersonSettingGridColumn where TenantID != @tenantIdDataToKeep
delete from dbo.NotificationProject where TenantID != @tenantIdDataToKeep

-- Order problems here?
delete from dbo.ProjectGeospatialAreaTypeNote where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectGeospatialAreaTypeNoteUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.GeospatialArea where TenantID != @tenantIdDataToKeep
delete from dbo.GeospatialAreaType where TenantID != @tenantIdDataToKeep
delete from dbo.OrganizationMatchmakerKeyword where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectLocationStaging where TenantID != @tenantIdDataToKeep

delete from dbo.StateProvince where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureExpectedUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.FirmaSession where TenantID != @tenantIdDataToKeep
delete from dbo.PersonSettingGridColumnSetting where TenantID != @tenantIdDataToKeep
delete from dbo.ExternalMapLayer where TenantID != @tenantIdDataToKeep
delete from dbo.OrganizationTypeOrganizationRelationshipType where TenantID != @tenantIdDataToKeep
-- Organization needs this
--delete from dbo.OrganizationType where TenantID != @tenantIdDataToKeep
delete from dbo.DocumentLibrary where TenantID != @tenantIdDataToKeep
delete from dbo.County where TenantID != @tenantIdDataToKeep
delete from dbo.DocumentLibraryDocumentCategory where TenantID != @tenantIdDataToKeep
delete from dbo.MatchmakerOrganizationClassification where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectLocationStagingUpdate where TenantID != @tenantIdDataToKeep


delete from dbo.PersonSettingGridColumnSettingFilter where TenantID != @tenantIdDataToKeep
delete from dbo.ContactRelationshipType where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureActualSubcategoryOption where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.OrganizationRelationshipType where TenantID != @tenantIdDataToKeep
delete from dbo.SecondaryProjectTaxonomyLeaf where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureReportingPeriod where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectExternalLink where TenantID != @tenantIdDataToKeep


delete from dbo.ProjectCustomAttributeGroup where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectUpdateBatch where TenantID != @tenantIdDataToKeep
delete from dbo.DocumentLibraryDocument where TenantID != @tenantIdDataToKeep
delete from dbo.Project where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectExternalLinkUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.TaxonomyLeafPerformanceMeasure where TenantID != @tenantIdDataToKeep
delete from dbo.FirmaPageImage where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectRelevantCostType where TenantID != @tenantIdDataToKeep
delete from dbo.PerformanceMeasureActual where TenantID != @tenantIdDataToKeep
delete from dbo.AssessmentGoal where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectOrganization where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectNote where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectUpdate where TenantID != @tenantIdDataToKeep
delete from dbo.ProjectCustomGridConfiguration where TenantID != @tenantIdDataToKeep




rollback tran