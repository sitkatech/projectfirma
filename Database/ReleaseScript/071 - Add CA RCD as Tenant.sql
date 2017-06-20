insert into dbo.Tenant(TenantID, TenantName, TenantDomain) 
values 
(3, 'CaliforniaAssocationOfResourceConversationDistricts', 'rcdprojects.org')

insert into dbo.TenantAttribute(TenantID, NumberOfTaxonomyTiersToUse, DefaultBoundingBox, MinimumYear, TenantDisplayName)
values
(3, 2, 0xE610000001040500000001000000782C5FC03E8957CD6508454001000000782C5FC05862B829FF1F404001000000A07F5CC05862B829FF1F404001000000A07F5CC03E8957CD6508454001000000782C5FC03E8957CD6508454001000000020000000001000000FFFFFFFF0000000003, 2017, 'RCD Projects')


insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
select FirmaPageTypeID, 3 as TenantID
from FirmaPage
where TenantID = 1


insert into dbo.Organization(TenantID, OrganizationGuid, OrganizationName, OrganizationAbbreviation, SectorID, IsActive, OrganizationUrl)
select 3 as TenantID, OrganizationGuid, OrganizationName, OrganizationAbbreviation, SectorID, IsActive, OrganizationUrl
from dbo.Organization
where OrganizationID in (6, 7, 56)

declare @sitkaOrgIDForTenant int
select @sitkaOrgIDForTenant = OrganizationID from dbo.Organization o where o.TenantID = 3 and o.OrganizationName = 'Sitka Technology Group'

declare @createDate datetime
set @createDate = '6/20/2017'

insert into dbo.Person(TenantID, PersonGuid, FirstName, LastName, Email, Phone, IsActive, OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, CreateDate, UpdateDate, LastActivityDate)
select 3 as TenantID, p.PersonGuid, p.FirstName, p.LastName, p.Email, p.Phone, p.IsActive, @sitkaOrgIDForTenant as OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, @createDate, @createDate, @createDate
from dbo.Person p
where TenantID = 2 and Email like '%sitkatech.com%' or Email like '%mcrcd.org%'

declare @primaryContactPersonID int
select @primaryContactPersonID = p.PersonID from dbo.Person p where p.Email = 'patricia.hickey@mcrcd.org'

update dbo.TenantAttribute
set PrimaryContactPersonID = @primaryContactPersonID
where TenantID = 3

update dbo.Organization
set PrimaryContactPersonID = @primaryContactPersonID
where TenantID = 3 and OrganizationName = 'Mendocino County RCD'

update dbo.Organization
set PrimaryContactPersonID = (select PersonID from dbo.Person where TenantID = 3 and Email = 'john.burns@sitkatech.com')
where OrganizationID = @sitkaOrgIDForTenant