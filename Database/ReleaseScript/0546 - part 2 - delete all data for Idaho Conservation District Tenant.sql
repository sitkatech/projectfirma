--IdahoAssociatonOfSoilConservationDistricts
--TenantID = 9

DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;

delete from dbo.PersonStewardOrganization where TenantID = @tenantIdDataToDelete
delete from dbo.PersonStewardTaxonomyBranch where TenantID = @tenantIdDataToDelete

/*
-- There's two-way bindings here between Person and Organziation that make things difficult
update dbo.Organization set PrimaryContactPersonID = null where TenantID = @tenantIdDataToDelete
alter table dbo.Person alter column OrganizationID int null
update dbo.Person set OrganizationID = null where TenantID = @tenantIdDataToDelete
*/
delete from dbo.[Notification] where TenantID = @tenantIdDataToDelete


delete from dbo.SupportRequestLog where TenantID = @tenantIdDataToDelete
delete from dbo.CustomPageImage where TenantID = @tenantIdDataToDelete
delete from dbo.FirmaHomePageImage where TenantID = @tenantIdDataToDelete

-- Problems start here?

-- PF framework needs TenantAttributes to be present for all Tenants. Since we aren't killing Tenants, these need to stay too.
--delete from dbo.TenantAttribute where TenantID = @tenantIdDataToDelete --and TenantID != 1
delete from dbo.FundingSource where TenantID = @tenantIdDataToDelete
-- We might not need every Org, but it's not a big table so figuring it out isn't interesting - just keep everything.
--delete from dbo.Organization where TenantID = @tenantIdDataToDelete

delete from dbo.GeospatialAreaImage where TenantID = @tenantIdDataToDelete
delete from dbo.DocumentLibraryDocument where TenantID = @tenantIdDataToDelete


delete from dbo.FileResourceData where TenantID = @tenantIdDataToDelete and FileResourceInfoID in (
	select FileResourceInfoID from dbo.FileResourceInfo where TenantID = @tenantIdDataToDelete and FileResourceInfoID not in 
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
);
go

DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;

-- Kill all the Files infos we can, but we have to retain what TenantAttribute needs, as well as Organization
delete from dbo.FileResourceInfo where TenantID = @tenantIdDataToDelete and FileResourceInfoID not in 
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

delete from dbo.ReleaseNote where UpdatePersonID in (select p.PersonID from dbo.Person as p where TenantID = @tenantIdDataToDelete)
delete from dbo.ImportExternalProjectStaging where CreatePersonID in (select p.PersonID from dbo.Person as p where TenantID = @tenantIdDataToDelete)
delete from dbo.PersonStewardGeospatialArea where PersonID in (select p.PersonID from dbo.Person as p where TenantID = @tenantIdDataToDelete)

delete from dbo.Person where TenantID = @tenantIdDataToDelete and PersonID not in
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
go


DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;


PRINT 'before delete from dbo.EvaluationCriteria line  100ish'
delete from dbo.ProjectEvaluationSelectedValue where TenantID = @tenantIdDataToDelete
delete from dbo.EvaluationCriteriaValue where TenantID = @tenantIdDataToDelete
delete from dbo.EvaluationCriteria where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectEvaluation where TenantID = @tenantIdDataToDelete
delete from dbo.Evaluation where TenantID = @tenantIdDataToDelete



delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.AttachmentTypeFileResourceMimeType where TenantID = @tenantIdDataToDelete
delete from dbo.AttachmentTypeTaxonomyTrunk where TenantID = @tenantIdDataToDelete
delete from dbo.AttachmentType where TenantID = @tenantIdDataToDelete
delete from dbo.ClassificationSystem where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectCustomAttributeUpdate where TenantID = @tenantIdDataToDelete


delete from dbo.Tag where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectGeospatialAreaUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureReportingPeriodTarget where TenantID = @tenantIdDataToDelete

delete from dbo.CostType where TenantID = @tenantIdDataToDelete
delete from dbo.ImportExternalProjectStaging where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectTag where TenantID = @tenantIdDataToDelete

delete from dbo.MatchmakerOrganizationTaxonomyBranch where TenantID = @tenantIdDataToDelete

delete from dbo.AttachmentTypeTaxonomyTrunk where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectExemptReportingYearUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.PersonStewardGeospatialArea where TenantID = @tenantIdDataToDelete

go




DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;

delete from dbo.ProjectCustomAttributeUpdateValue where TenantID = @tenantIdDataToDelete
delete from dbo.GeospatialAreaPerformanceMeasureReportingPeriodTarget where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectClassification where TenantID = @tenantIdDataToDelete
delete from dbo.SupportRequestLog where TenantID = @tenantIdDataToDelete
delete from dbo.MatchmakerOrganizationTaxonomyTrunk where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectLocationUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectAttachment where TenantID = @tenantIdDataToDelete

delete from dbo.CustomPageImage where TenantID = @tenantIdDataToDelete
delete from dbo.CustomPageRole where TenantID = @tenantIdDataToDelete
delete from dbo.CustomPage where TenantID = @tenantIdDataToDelete

delete from dbo.FundingSource where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectExemptReportingYear where TenantID = @tenantIdDataToDelete
delete from dbo.MatchmakerOrganizationTaxonomyLeaf where TenantID = @tenantIdDataToDelete
delete from dbo.ClassificationPerformanceMeasure where TenantID = @tenantIdDataToDelete

delete from dbo.AuditLog where TenantID = @tenantIdDataToDelete
delete from dbo.MatchMakerAreaOfInterestLocation where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectAttachmentUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.FundingSourceCustomAttributeTypeRole where TenantID = @tenantIdDataToDelete
delete from dbo.GeospatialAreaPerformanceMeasureNoTarget where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectInternalNote where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectLocation where TenantID = @tenantIdDataToDelete
go



DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;


PRINT 'before delete from dbo.FieldDefinitionData ---- line 167ish'
delete from dbo.FieldDefinitionData where TenantID = @tenantIdDataToDelete
delete from dbo.MatchmakerOrganizationPerformanceMeasure where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectAssessmentQuestion where TenantID = @tenantIdDataToDelete
delete from dbo.FundingSourceCustomAttribute where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureExpectedSubcategoryOption where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectImage where TenantID = @tenantIdDataToDelete
delete from dbo.GeospatialAreaPerformanceMeasureFixedTarget where TenantID = @tenantIdDataToDelete


delete from dbo.[Notification] where TenantID = @tenantIdDataToDelete

delete from dbo.PersonSettingGridColumnSettingFilter where TenantID = @tenantIdDataToDelete
delete from dbo.PersonSettingGridColumnSetting where TenantID = @tenantIdDataToDelete
delete from dbo.PersonSettingGridColumn where TenantID = @tenantIdDataToDelete
delete from dbo.PersonSettingGridTable where TenantID = @tenantIdDataToDelete


delete from dbo.OrganizationMatchmakerKeyword where TenantID = @tenantIdDataToDelete
delete from dbo.MatchmakerKeyword where TenantID = @tenantIdDataToDelete
delete from dbo.FirmaHomePageImage where TenantID = @tenantIdDataToDelete
-- No, we need to keep this around
--delete from dbo.TenantAttribute where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureFixedTarget where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureExpected where TenantID = @tenantIdDataToDelete

delete from dbo.NotificationProject where TenantID = @tenantIdDataToDelete
go



DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;

-- Order problems here?
delete from dbo.ProjectGeospatialAreaTypeNote where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectGeospatialAreaTypeNoteUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.GeospatialArea where TenantID = @tenantIdDataToDelete
delete from dbo.GeospatialAreaType where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectLocationStaging where TenantID = @tenantIdDataToDelete

delete from dbo.StateProvince where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureExpectedUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.FirmaSession where TenantID = @tenantIdDataToDelete

delete from dbo.ExternalMapLayer where TenantID = @tenantIdDataToDelete
delete from dbo.OrganizationTypeOrganizationRelationshipType where TenantID = @tenantIdDataToDelete
-- Organization needs this
--delete from dbo.OrganizationType where TenantID = @tenantIdDataToDelete
delete from dbo.DocumentLibraryDocumentCategory where TenantID = @tenantIdDataToDelete
delete from dbo.DocumentLibrary where TenantID = @tenantIdDataToDelete
delete from dbo.County where TenantID = @tenantIdDataToDelete


delete from dbo.ProjectLocationStagingUpdate where TenantID = @tenantIdDataToDelete
go


DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;

PRINT 'before delete from dbo.ContactRelationshipType ---- line 235ish'
delete from dbo.ContactRelationshipType where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureActualSubcategoryOption where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.OrganizationRelationshipType where TenantID = @tenantIdDataToDelete
delete from dbo.SecondaryProjectTaxonomyLeaf where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureReportingPeriod where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectExternalLink where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectStatus where TenantID = @tenantIdDataToDelete

delete from dbo.ProjectCustomAttributeGroup where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectUpdateBatch where TenantID = @tenantIdDataToDelete

delete from dbo.Project where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectExternalLinkUpdate where TenantID = @tenantIdDataToDelete


delete from dbo.TaxonomyLeafPerformanceMeasure where TenantID = @tenantIdDataToDelete
delete from dbo.TaxonomyLeaf where TenantID = @tenantIdDataToDelete
delete from dbo.TaxonomyBranch where TenantID = @tenantIdDataToDelete
delete from dbo.AttachmentTypeTaxonomyTrunk where TenantID = @tenantIdDataToDelete
delete from dbo.TaxonomyTrunk where TenantID = @tenantIdDataToDelete
go

DECLARE @tenantIdDataToDelete INT;
SET @tenantIdDataToDelete = 9;
delete from dbo.PerformanceMeasureImage where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureSubcategoryOption where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureSubcategory where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureImage where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasure where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureActualUpdate where TenantID = @tenantIdDataToDelete


delete from dbo.FirmaPageImage where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectRelevantCostType where TenantID = @tenantIdDataToDelete
delete from dbo.PerformanceMeasureActual where TenantID = @tenantIdDataToDelete
delete from dbo.AssessmentGoal where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectOrganization where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectNote where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectUpdate where TenantID = @tenantIdDataToDelete
delete from dbo.ProjectCustomGridConfiguration where TenantID = @tenantIdDataToDelete





update dbo.Organization
set PrimaryContactPersonID = null,
    LogoFileResourceInfoID = null
where TenantID in (@tenantIdDataToDelete)

/*
select * from dbo.TenantAttribute
where (TenantID != 1 and TenantID = @tenantIdDataToDelete)
*/

update dbo.TenantAttribute
set TenantSquareLogoFileResourceInfoID = null,
    TenantBannerLogoFileResourceInfoID = null,
    TenantStyleSheetFileResourceInfoID = null,
    TenantFactSheetLogoFileResourceInfoID = null,
    PrimaryContactPersonID = null
where TenantID in (@tenantIdDataToDelete)

--select * from dbo.FileResourceInfo
--where (TenantID != 1 and TenantID != 12)

delete from dbo.FileResourceInfo
where TenantID  in (@tenantIdDataToDelete)

delete from dbo.ReleaseNote

delete from dbo.Person
where TenantID in (@tenantIdDataToDelete)

delete from dbo.Organization
where TenantID  in (@tenantIdDataToDelete)

delete from dbo.OrganizationType
where TenantID in (@tenantIdDataToDelete)


delete from dbo.FirmaPage
where TenantID in (@tenantIdDataToDelete)

delete from dbo.TenantAttribute
where TenantID in (@tenantIdDataToDelete)



update dbo.Tenant
set CanonicalHostNameLocal = 'local.xxx',
    CanonicalHostNameQa = 'qa.xxx',
    CanonicalHostNameProd = 'prod.xxx',
    --UseFiscalYears = 0,
    --UsesTechnicalAssistanceParameters = 0,
    --ArePerformanceMeasuresExternallySourced = 0,
    --AreOrganizationsExternallySourced = 0,
    --AreFundingSourcesExternallySourced = 0,
    TenantEnabled = 0
where TenantID  in (@tenantIdDataToDelete)

--select * from dbo.Tenant

--delete from dbo.Tenant
--where (TenantID = @tenantIdDataToDelete)


