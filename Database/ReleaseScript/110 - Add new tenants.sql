alter table dbo.Tenant add IsSubDomain bit
GO
update dbo.Tenant set IsSubDomain = 0

alter table dbo.Tenant alter column IsSubDomain bit not null


insert into dbo.Tenant(TenantID, TenantName, TenantDomain, IsSubDomain) 
values 
(4, 'InternationYearOfTheSalmon', 'iysdemo.projectfirma.com', 1),
(5, 'DemoProjectFirma', 'demo.projectfirma.com', 1),
(6, 'NationalForestFoundation', 'nffdemo.projectfirma.com', 1)

update dbo.TenantAttribute
set TenantDisplayName = 'Project Firma Project Tracker'
where TenantID = 1


if exists(select 1 from sys.objects where object_id = object_id(N'dbo.pTenantCopy'))
  drop procedure dbo.pTenantCopy
go
create procedure dbo.pTenantCopy
(
	@TenantIDFrom int, @TenantIDTo int, @TenantName varchar(100), @ToolDisplayName varchar(100), @createDate datetime
)
as
	insert into dbo.TenantAttribute(TenantID, NumberOfTaxonomyTiersToUse, DefaultBoundingBox, MinimumYear, TenantDisplayName, ToolDisplayName, ShowProposalsToThePublic)
	values
	(@TenantIDTo, 2, 0xE61000000104050000000100000040285FC06911DAA3DB1C47400100000040285FC08D97B8A52102454001000000B0415DC08D97B8A52102454001000000B0415DC06911DAA3DB1C47400100000040285FC06911DAA3DB1C474001000000020000000001000000FFFFFFFF0000000003, 2017, @TenantName, @ToolDisplayName, 1)


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


exec pTenantCopy @TenantIDFrom = 1, @TenantIDTo = 4, @TenantName= 'International Year of the Salmon', @ToolDisplayName = 'Project Tracker for the International Year of the Salmon', @createDate = '11/1/2017'
exec pTenantCopy @TenantIDFrom = 1, @TenantIDTo = 5, @TenantName= 'Project Firma - Demo', @ToolDisplayName = 'Project Tracker - Demo', @createDate = '11/1/2017'
exec pTenantCopy @TenantIDFrom = 1, @TenantIDTo = 6, @TenantName= 'National Forest Foundation', @ToolDisplayName = 'Project Tracker for the National Forest Foundation', @createDate = '11/1/2017'

