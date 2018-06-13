-- We don't need to worry about migrating demo tenants' data, so make all their "funders" "partners" instead
update dbo.RelationshipType set RelationshipTypeName = 'Partner'
where TenantID not in (2,3,6) and RelationshipTypeName = 'Funder'

-- We need to be able to represent a funding source request where we know we're asking for money but we don't know how much
alter table dbo.ProjectFundingSourceRequest
alter column SecuredAmount money null

alter table dbo.ProjectFundingSourceRequest
alter column UnsecuredAmount money null

alter table dbo.ProjectFundingSourceRequestUpdate
alter column SecuredAmount money null

alter table dbo.ProjectFundingSourceRequestUpdate
alter column UnsecuredAmount money null

-- just make sure the temp table doesn't already exist even though it totally shouldn't
if Object_ID('tempdb.dbo.#MissingFundingRelationships') is not null
drop table #MissingFundingRelationships
go

Declare @FunderRelationshipTypes TABLE (RelationshipTypeID int)
Insert Into @FunderRelationshipTypes
SELECT RelationshipTypeID from dbo.RelationshipType where RelationshipTypeName = 'Funder'

-- These are all the ProjectOrganizations that aren't backed by the PFS Expenditure/Request tables
select * into #MissingFundingRelationships from
-- These are the relationships we have to preserve
((Select distinct ProjectID, OrganizationID, TenantID from dbo.ProjectOrganization where RelationshipTypeID in (select RelationshipTypeID from @FunderRelationshipTypes))
EXCEPT
-- These are the relationships that are already implied by the funding tables
(select distinct p.ProjectID, fs.OrganizationID, p.TenantID from dbo.Project p join dbo.ProjectFundingSourceRequest r on p.ProjectID = r.ProjectID join dbo.FundingSource fs on r.FundingSourceID = fs.FundingSourceID
union select distinct p.ProjectID, fs.OrganizationID, p.TenantID from dbo.Project p join dbo.ProjectFundingSourceExpenditure r on p.ProjectID = r.ProjectID join dbo.FundingSource fs on r.FundingSourceID = fs.FundingSourceID))
e

select distinct OrganizationID, TenantID from #MissingFundingRelationships

-- Identify all Organizations currently used in a "Funder" relationship that aren't backed by the PFS Request/Expenditure tables and create "Unspecified" FundingSources for those organizations
Insert into dbo.FundingSource ([TenantID], [OrganizationID], [FundingSourceName], [IsActive], [FundingSourceDescription])
select distinct
TenantID, OrganizationID, 'Unspecified' as FundingSourceName, 0 as IsActive, 'System created Funding Source to account for a funding organization whose specific source is not known' as FundingSourceDescription
from #MissingFundingRelationships

-- create backing PFSR records for the ProjectOrganizations identified above
insert into dbo.ProjectFundingSourceRequest ([TenantID], [ProjectID], [FundingSourceID], [SecuredAmount], [UnsecuredAmount])
select mfr.TenantID as TenantID, mfr.ProjectID as ProjectID, fs.FundingSourceID as FundingSourceID, null as SecuredAmount, null as Unsecuredamount
from #MissingFundingRelationships mfr join dbo.FundingSource fs on mfr.OrganizationID = fs.OrganizationID where fs.FundingSourceName = 'Unspecified'

-- Migration is successful and we can proceed with deleting if we can reconstruct the ProjectOrganizations where "type = funder" from the ProjectFundingSourceRequest and ProjectFundingSourceExpenditure tables
if exists
-- These are the relationships we have to preserve
((Select distinct ProjectID, OrganizationID, TenantID from dbo.ProjectOrganization where RelationshipTypeID in (select RelationshipTypeID from @FunderRelationshipTypes))
EXCEPT
-- These are the relationships that are already implied by the funding tables
(select distinct p.ProjectID, fs.OrganizationID, p.TenantID from dbo.Project p join dbo.ProjectFundingSourceRequest r on p.ProjectID = r.ProjectID join dbo.FundingSource fs on r.FundingSourceID = fs.FundingSourceID
union select distinct p.ProjectID, fs.OrganizationID, p.TenantID from dbo.Project p join dbo.ProjectFundingSourceExpenditure r on p.ProjectID = r.ProjectID join dbo.FundingSource fs on r.FundingSourceID = fs.FundingSourceID))
--So, the EXCEPT should be empty by the time our migration is complete
-- There might be funding table entries that aren't already reflected by the ProjectOrganization table, but we don't need to do anything about those.
begin
	raiserror('Project Funders not migrated correctly.', 16, 1)
end

-- TODO: Delete
delete from dbo.ProjectOrganization where RelationshipTypeID in (select RelationshipTypeID from @FunderRelationshipTypes)
delete from dbo.ProjectOrganizationUpdate where RelationshipTypeID in (select RelationshipTypeID from @FunderRelationshipTypes)
delete from dbo.OrganizationTypeRelationshipType where RelationshipTypeID in (select RelationshipTypeID from @FunderRelationshipTypes)
delete from dbo.RelationshipType where RelationshipTypeID in (select RelationshipTypeID from @FunderRelationshipTypes)