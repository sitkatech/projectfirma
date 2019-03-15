if exists(select 1 from sys.objects where object_id = object_id(N'dbo.pTenantCopy'))
  drop procedure dbo.pTenantCopy
go
create procedure dbo.pTenantCopy
(
	@TenantIDFrom int, @TenantIDTo int, @TenantName varchar(100), @ToolDisplayName varchar(100), @createDate datetime
)
as
	insert into dbo.TenantAttribute(TenantID, TaxonomyLevelID, DefaultBoundingBox, MinimumYear, TenantShortDisplayName, ToolDisplayName, ShowProposalsToThePublic, RecaptchaPublicKey, RecaptchaPrivateKey)
	values
	(@TenantIDTo, 2, 0xE61000000104050000000100000040285FC06911DAA3DB1C47400100000040285FC08D97B8A52102454001000000B0415DC08D97B8A52102454001000000B0415DC06911DAA3DB1C47400100000040285FC06911DAA3DB1C474001000000020000000001000000FFFFFFFF0000000003, 2017, @TenantName, @ToolDisplayName, 1, '6LfZQQoUAAAAAIJ_2lD6ct0lBHQB9j5kv8p994SP', '6LfZQQoUAAAAAOeNQDcXlTV9JM7PBQE3jCqlDBSB')


	insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
	select FirmaPageTypeID, @TenantIDTo as TenantID
	from dbo.FirmaPage fp
	where fp.TenantID = @TenantIDFrom

	insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps, IsDefaultOrganizationType)
	values
	(@TenantIDTo, 'Federal', 'FED', '#1f77b4', 0, 0),
	(@TenantIDTo, 'Local', 'LOC', '#aec7e8', 0, 0),
	(@TenantIDTo, 'Private', 'PRI', '#ff7f0e', 0, 1),
	(@TenantIDTo, 'State', 'ST', '#ffbb78', 0, 0)

	declare @privateOrgTypeIDForTenant int
	select @privateOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Private'


	insert into dbo.Organization(TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl)
	select @TenantIDTo as TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, @privateOrgTypeIDForTenant, IsActive, OrganizationUrl
	from dbo.Organization
	where OrganizationID in (6, 7) -- Sitka, Unknown Org

	declare @sitkaOrgIDForTenant int
	select @sitkaOrgIDForTenant = OrganizationID from dbo.Organization o where o.TenantID = @TenantIDTo and o.OrganizationName = 'Sitka Technology Group'

	insert into dbo.RelationshipType(TenantID, RelationshipTypeName, CanStewardProjects, IsPrimaryContact, CanOnlyBeRelatedOnceToAProject)
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
