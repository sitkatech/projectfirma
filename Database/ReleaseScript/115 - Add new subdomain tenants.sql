alter table dbo.Tenant add IsSubDomain bit
GO
update dbo.Tenant set IsSubDomain = 0

alter table dbo.Tenant alter column IsSubDomain bit not null


insert into dbo.Tenant(TenantID, TenantName, TenantDomain, IsSubDomain) 
values 
(4, 'InternationYearOfTheSalmon', 'iysdemo.projectfirma.com', 1),
(5, 'DemoProjectFirma', 'demo.projectfirma.com', 1),
(6, 'NationalForestFoundation', 'nffdemo.projectfirma.com', 1)

-- move IYS stuff to tenant ID 4
DELETE dbo.ProjectWatershed where TenantID = 1
DELETE dbo.ProjectWatershedUpdate where TenantID = 1

exec sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
exec sp_msforeachtable 'ALTER TABLE ? DISABLE TRIGGER ALL'


update dbo.Person set TenantID = 4 where TenantID = 1
update dbo.Project set TenantID = 4 where TenantID = 1
update dbo.AssessmentGoal set TenantID = 4 where TenantID = 1
update dbo.AssessmentQuestion set TenantID = 4 where TenantID = 1
update dbo.AssessmentSubGoal set TenantID = 4 where TenantID = 1
update dbo.AuditLog set TenantID = 4 where TenantID = 1
update dbo.Classification set TenantID = 4 where TenantID = 1
update dbo.ClassificationPerformanceMeasure set TenantID = 4 where TenantID = 1
update dbo.CostParameterSet set TenantID = 4 where TenantID = 1
update dbo.County set TenantID = 4 where TenantID = 1
update dbo.FieldDefinitionData set TenantID = 4 where TenantID = 1
update dbo.FieldDefinitionDataImage set TenantID = 4 where TenantID = 1
update dbo.FileResource set TenantID = 4 where TenantID = 1
update dbo.FirmaHomePageImage set TenantID = 4 where TenantID = 1
update dbo.FirmaPage set TenantID = 4 where TenantID = 1
update dbo.FirmaPageImage set TenantID = 4 where TenantID = 1
update dbo.FundingSource set TenantID = 4 where TenantID = 1
update dbo.FundingTypeData set TenantID = 4 where TenantID = 1
update dbo.MappedRegion set TenantID = 4 where TenantID = 1
update dbo.MonitoringProgram set TenantID = 4 where TenantID = 1
update dbo.MonitoringProgramDocument set TenantID = 4 where TenantID = 1
update dbo.MonitoringProgramPartner set TenantID = 4 where TenantID = 1
update dbo.Notification set TenantID = 4 where TenantID = 1
update dbo.NotificationProject set TenantID = 4 where TenantID = 1
update dbo.Organization set TenantID = 4 where TenantID = 1
update dbo.OrganizationBoundaryStaging set TenantID = 4 where TenantID = 1
update dbo.OrganizationType set TenantID = 4 where TenantID = 1
update dbo.OrganizationTypeRelationshipType set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasure set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureActual set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureActualSubcategoryOption set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureActualSubcategoryOptionUpdate set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureActualUpdate set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureExpected set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureExpectedSubcategoryOption set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureMonitoringProgram set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureNote set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureSubcategory set TenantID = 4 where TenantID = 1
update dbo.PerformanceMeasureSubcategoryOption set TenantID = 4 where TenantID = 1
update dbo.ProjectAssessmentQuestion set TenantID = 4 where TenantID = 1
update dbo.ProjectBudget set TenantID = 4 where TenantID = 1
update dbo.ProjectBudgetUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectClassification set TenantID = 4 where TenantID = 1
update dbo.ProjectExemptReportingYear set TenantID = 4 where TenantID = 1
update dbo.ProjectExemptReportingYearUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectExternalLink set TenantID = 4 where TenantID = 1
update dbo.ProjectExternalLinkUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectFundingSourceExpenditure set TenantID = 4 where TenantID = 1
update dbo.ProjectFundingSourceExpenditureUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectFundingSourceRequest set TenantID = 4 where TenantID = 1
update dbo.ProjectFundingSourceRequestUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectImage set TenantID = 4 where TenantID = 1
update dbo.ProjectImageUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectLocation set TenantID = 4 where TenantID = 1
update dbo.ProjectLocationStaging set TenantID = 4 where TenantID = 1
update dbo.ProjectLocationStagingUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectLocationUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectNote set TenantID = 4 where TenantID = 1
update dbo.ProjectNoteUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectOrganization set TenantID = 4 where TenantID = 1
update dbo.ProjectTag set TenantID = 4 where TenantID = 1
update dbo.ProjectUpdate set TenantID = 4 where TenantID = 1
update dbo.ProjectUpdateBatch set TenantID = 4 where TenantID = 1
update dbo.ProjectUpdateHistory set TenantID = 4 where TenantID = 1
update dbo.ProjectWatershed set TenantID = 4 where TenantID = 1
update dbo.ProjectWatershedUpdate set TenantID = 4 where TenantID = 1
update dbo.RelationshipType set TenantID = 4 where TenantID = 1
update dbo.Snapshot set TenantID = 4 where TenantID = 1
update dbo.SnapshotOrganizationTypeExpenditure set TenantID = 4 where TenantID = 1
update dbo.SnapshotPerformanceMeasure set TenantID = 4 where TenantID = 1
update dbo.SnapshotPerformanceMeasureSubcategoryOption set TenantID = 4 where TenantID = 1
update dbo.SnapshotProject set TenantID = 4 where TenantID = 1
update dbo.StateProvince set TenantID = 4 where TenantID = 1
update dbo.SupportRequestLog set TenantID = 4 where TenantID = 1
update dbo.Tag set TenantID = 4 where TenantID = 1
update dbo.TaxonomyTierOne set TenantID = 4 where TenantID = 1
update dbo.TaxonomyTierThree set TenantID = 4 where TenantID = 1
update dbo.TaxonomyTierTwo set TenantID = 4 where TenantID = 1
update dbo.TaxonomyTierTwoPerformanceMeasure set TenantID = 4 where TenantID = 1
update dbo.TenantAttribute set TenantID = 4 where TenantID = 1

exec sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'
exec sp_msforeachtable 'ALTER TABLE ? ENABLE TRIGGER ALL'
DBCC CHECKCONSTRAINTS WITH ALL_CONSTRAINTS



if exists(select 1 from sys.objects where object_id = object_id(N'dbo.pTenantCopy'))
  drop procedure dbo.pTenantCopy
go
create procedure dbo.pTenantCopy
(
	@TenantIDFrom int, @TenantIDTo int, @TenantName varchar(100), @ToolDisplayName varchar(100), @createDate datetime
)
as
	insert into dbo.TenantAttribute(TenantID, NumberOfTaxonomyTiersToUse, DefaultBoundingBox, MinimumYear, TenantDisplayName, ToolDisplayName, ShowProposalsToThePublic, RecaptchaPublicKey, RecaptchaPrivateKey)
	values
	(@TenantIDTo, 2, 0xE61000000104050000000100000040285FC06911DAA3DB1C47400100000040285FC08D97B8A52102454001000000B0415DC08D97B8A52102454001000000B0415DC06911DAA3DB1C47400100000040285FC06911DAA3DB1C474001000000020000000001000000FFFFFFFF0000000003, 2017, @TenantName, @ToolDisplayName, 1, '6LfZQQoUAAAAAIJ_2lD6ct0lBHQB9j5kv8p994SP', '6LfZQQoUAAAAAOeNQDcXlTV9JM7PBQE3jCqlDBSB')


	insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
	select FirmaPageTypeID, @TenantIDTo as TenantID
	from dbo.FirmaPage fp
	where fp.TenantID = @TenantIDFrom

	insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps)
	values
	(@TenantIDTo, 'Federal', 'FED', '#1f77b4', 0),
	(@TenantIDTo, 'Local', 'LOC', '#aec7e8', 0),
	(@TenantIDTo, 'Private', 'PRI', '#ff7f0e', 0),
	(@TenantIDTo, 'State', 'ST', '#ffbb78', 0)

	declare @privateOrgTypeIDForTenant int
	select @privateOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Private'


	insert into dbo.Organization(TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl)
	select @TenantIDTo as TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, @privateOrgTypeIDForTenant, IsActive, OrganizationUrl
	from dbo.Organization
	where OrganizationID in (6, 7) -- Sitka, Unknown Org

	declare @sitkaOrgIDForTenant int
	select @sitkaOrgIDForTenant = OrganizationID from dbo.Organization o where o.TenantID = @TenantIDTo and o.OrganizationName = 'Sitka Technology Group'

	insert into dbo.RelationshipType(TenantID, RelationshipTypeName, CanApproveProjects, IsPrimaryContact, CanOnlyBeRelatedOnceToAProject)
	values
	(@TenantIDTo, 'Lead Implementer', 0, 1, 1),
	(@TenantIDTo, 'Funder', 0, 0, 0),
	(@TenantIDTo, 'Stakeholder', 0, 0, 0)

	insert into dbo.OrganizationTypeRelationshipType(OrganizationTypeID, RelationshipTypeID, TenantID)
	select OrganizationTypeID, RelationshipTypeID, @TenantIDTo as TenantID
	from dbo.OrganizationType ot
	cross join dbo.RelationshipType rt
	where ot.TenantID = @TenantIDTo and rt.TenantID = @TenantIDTo


	insert into dbo.Person(TenantID, PersonGuid, FirstName, LastName, Email, Phone, IsActive, OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, CreateDate, UpdateDate, LastActivityDate)
	select @TenantIDTo as TenantID, p.PersonGuid, p.FirstName, p.LastName, p.Email, p.Phone, p.IsActive, @sitkaOrgIDForTenant as OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, @createDate, @createDate, @createDate
	from dbo.Person p
	where TenantID = @TenantIDFrom and Email like '%sitkatech.com%'

	declare @primaryContactPersonID int
	select @primaryContactPersonID = p.PersonID from dbo.Person p where p.Email = 'matt.deniston@sitkatech.com'

	update dbo.TenantAttribute
	set PrimaryContactPersonID = @primaryContactPersonID
	where TenantID = @TenantIDTo

	update dbo.Organization
	set PrimaryContactPersonID = (select PersonID from dbo.Person where TenantID = @TenantIDTo and Email = 'john.burns@sitkatech.com')
	where OrganizationID = @sitkaOrgIDForTenant
GO


exec pTenantCopy @TenantIDFrom = 4, @TenantIDTo = 1, @TenantName= 'Project Firma Tracker', @ToolDisplayName = 'Project Tracker for Sitka', @createDate = '1/1/2017'
exec pTenantCopy @TenantIDFrom = 4, @TenantIDTo = 5, @TenantName= 'Project Firma - Demo', @ToolDisplayName = 'Project Tracker - Demo', @createDate = '11/1/2017'
exec pTenantCopy @TenantIDFrom = 4, @TenantIDTo = 6, @TenantName= 'National Forest Foundation', @ToolDisplayName = 'Project Tracker for the National Forest Foundation', @createDate = '11/1/2017'

update dbo.TenantAttribute
set MapServiceUrl = 'https://localhost-mapserver.projectfirma.com/geoserver/ProjectFirma/wms'
, WatershedLayerName = 'ProjectFirma:Watershed'
where TenantID = 1

update dbo.TenantAttribute
set MapServiceUrl = null, WatershedLayerName = null
where TenantID = 4

