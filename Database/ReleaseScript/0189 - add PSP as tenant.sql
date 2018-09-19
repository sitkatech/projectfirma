insert into dbo.Tenant(TenantID, TenantName, CanonicalHostNameLocal, CanonicalHostNameQa, CanonicalHostNameProd, ReportingYearStartDate, UseFiscalYears, UsesTechnicalAssistanceParameters)
values 
(11, 'ActionAgendaForPugetSound', 'actionagendatracker.localhost.projectfirma.com', 'actionagendatracker.qa.projectfirma.com', 'actionagendatracker.projectfirma.com', '1/1/1990', 0, 0)

	alter table dbo.FileResource add OrganizationIDFromTenant int null
	alter table dbo.FileResource add ProjectImageIDFromTenant int null
	GO

	declare @TenantIDFrom int, @TenantIDTo int, @TenantName varchar(100), @ToolDisplayName varchar(100), @createDate datetime, @primaryContactPersonID int
	select @TenantIDFrom = 4, @TenantIDTo = 11, @TenantName = 'Action Agenda for Puget Sound', @ToolDisplayName = 'Action Agenda for Puget Sound', @createDate = '9/18/18 2:00 PM'

	insert into dbo.TenantAttribute(TenantID, DefaultBoundingBox, MinimumYear, PrimaryContactPersonID, TenantDisplayName, ToolDisplayName, RecaptchaPublicKey, RecaptchaPrivateKey, 
	ShowProposalsToThePublic, TaxonomyLevelID, AssociatePerfomanceMeasureTaxonomyLevelID, IsActive, ProjectExternalDataSourceEnabled, 
	AccomplishmentsDashboardFundingDisplayTypeID, AccomplishmentsDashboardAccomplishmentsButtonText, AccomplishmentsDashboardExpendituresButtonText, AccomplishmentsDashboardOrganizationsButtonText, AccomplishmentsDashboardIncludeReportingOrganizationType, ShowLeadImplementerLogoOnFactSheet, EnableAccomplishmentsDashboard)
	values
	(@TenantIDTo, 0xE61000000104050000000100000040285FC06911DAA3DB1C47400100000040285FC08D97B8A52102454001000000B0415DC08D97B8A52102454001000000B0415DC06911DAA3DB1C47400100000040285FC06911DAA3DB1C474001000000020000000001000000FFFFFFFF0000000003, 2010, @primaryContactPersonID, @TenantName, @ToolDisplayName, '6LfZQQoUAAAAAIJ_2lD6ct0lBHQB9j5kv8p994SP', '6LfZQQoUAAAAAOeNQDcXlTV9JM7PBQE3jCqlDBSB', 
	1, 2, 2, 1, 0, 
	1, NULL, NULL, NULL, 1, 0, 1)

	insert into dbo.TaxonomyTrunk(TenantID, TaxonomyTrunkName)
	values(@TenantIDTo, 'Default')


	insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
	select FirmaPageTypeID, @TenantIDTo as TenantID
	from dbo.FirmaPage fp
	where fp.TenantID = @TenantIDFrom

	insert into dbo.FieldDefinitionData(FieldDefinitionID, TenantID)
	select FieldDefinitionID, @TenantIDTo as TenantID
	from dbo.FieldDefinitionData fdd
	where fdd.TenantID = @TenantIDFrom

	insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps, IsDefaultOrganizationType, IsFundingType)
	values
	(@TenantIDTo, 'Federal', 'FED', '#1f77b4', 0, 0, 1),
	(@TenantIDTo, 'Local', 'LOC', '#aec7e8', 0, 0, 1),
	(@TenantIDTo, 'Private', 'PRI', '#ff7f0e', 0, 1, 1),
	(@TenantIDTo, 'State', 'ST', '#ffbb78', 0, 0, 1)

	declare @privateOrgTypeIDForTenant int
	select @privateOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Private'

	insert into dbo.Organization(TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl)
	select @TenantIDTo as TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, @privateOrgTypeIDForTenant, IsActive, OrganizationUrl
	from dbo.Organization
	where OrganizationID in (6, 7) -- Sitka, Unknown Org

	declare @federalOrgTypeIDForTenant int
	select @federalOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Federal'

	insert into dbo.Organization(TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl)
	values (@TenantIDTo, '63B81DA4-8D3C-4858-A4AA-D2DA36E8DB7F', 'Puget Sound Partnership', 'PSP', @federalOrgTypeIDForTenant, 1, 'http://www.psp.wa.gov/')

	declare @sitkaOrgIDForTenant int
	select @sitkaOrgIDForTenant = OrganizationID from dbo.Organization o where o.TenantID = @TenantIDTo and o.OrganizationName = 'Sitka Technology Group'

	insert into dbo.Person(TenantID, PersonGuid, FirstName, LastName, Email, Phone, IsActive, OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, CreateDate, UpdateDate, LastActivityDate)
	select @TenantIDTo as TenantID, p.PersonGuid, p.FirstName, p.LastName, p.Email, p.Phone, p.IsActive, @sitkaOrgIDForTenant as OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, @createDate, @createDate, @createDate
	from dbo.Person p
	where TenantID = @TenantIDFrom and Email like '%sitkatech.com%'

	select @primaryContactPersonID = p.PersonID from dbo.Person p where p.Email = 'liz.christeleit@sitkatech.com' and TenantID = @TenantIDTo

	insert into dbo.FileResource(TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate, OrganizationIDFromTenant)
	select @TenantIDTo as TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, @primaryContactPersonID as CreatePersonID, fr.CreateDate, o.OrganizationID as OrganizationIDFromTenant
	from dbo.Organization o
	join dbo.FileResource fr on o.LogoFileResourceID = fr.FileResourceID
	where o.TenantID = @TenantIDFrom
	
	insert into dbo.RelationshipType(TenantID, RelationshipTypeName, CanStewardProjects, IsPrimaryContact, CanOnlyBeRelatedOnceToAProject, ShowOnFactSheet, ReportInAccomplishmentsDashboard)
	values
	(@TenantIDTo, 'Lead Implementer', 0, 1, 1, 1, 0),
	(@TenantIDTo, 'Funder', 0, 0, 0, 1, 0),
	(@TenantIDTo, 'Partner', 0, 0, 0, 1, 0)

	insert into dbo.OrganizationTypeRelationshipType(OrganizationTypeID, RelationshipTypeID, TenantID)
	select OrganizationTypeID, RelationshipTypeID, @TenantIDTo as TenantID
	from dbo.OrganizationType ot
	cross join dbo.RelationshipType rt
	where ot.TenantID = @TenantIDTo and rt.TenantID = @TenantIDTo

	update dbo.TenantAttribute
	set PrimaryContactPersonID = @primaryContactPersonID
	where TenantID = @TenantIDTo

	insert into dbo.FundingTypeData(TenantID, FundingTypeID, FundingTypeDisplayName, FundingTypeShortName, SortOrder)
	SELECT @TenantIDTo as TenantID
		  ,FundingTypeID
		  ,FundingTypeDisplayName
		  ,FundingTypeShortName
		  ,SortOrder
	FROM dbo.FundingTypeData
	where TenantID = @TenantIDFrom

	insert into dbo.RelationshipType(TenantID, RelationshipTypeName, CanStewardProjects, IsPrimaryContact, CanOnlyBeRelatedOnceToAProject, RelationshipTypeDescription)
	select @TenantIDTo as TenantID, rt.RelationshipTypeName, rt.CanStewardProjects, rt.IsPrimaryContact, rt.CanOnlyBeRelatedOnceToAProject, rt.RelationshipTypeDescription
	from dbo.RelationshipType rt
	left join dbo.RelationshipType rt2 on rt.RelationshipTypeName = rt2.RelationshipTypeName
	where rt.TenantID = @TenantIDFrom and rt2.RelationshipTypeID is null

	alter table dbo.FileResource DROP COLUMN OrganizationIDFromTenant
	alter table dbo.FileResource DROP COLUMN ProjectImageIDFromTenant
