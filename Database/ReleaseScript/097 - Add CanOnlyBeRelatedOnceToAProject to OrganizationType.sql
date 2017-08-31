alter table dbo.RelationshipType add CanOnlyBeRelatedOnceToAProject bit null
GO

update dbo.RelationshipType
set CanOnlyBeRelatedOnceToAProject = 0

update dbo.RelationshipType
set CanOnlyBeRelatedOnceToAProject = 1
where RelationshipTypeID in (6, 10, 11, 12)


update dbo.RelationshipType
set CanOnlyBeRelatedOnceToAProject = 1, RelationshipTypeName = 'State Senate Voting District'
where RelationshipTypeID = 9

insert into dbo.RelationshipType(TenantID, RelationshipTypeName, IsPrimaryContact, CanApproveProjects, CanOnlyBeRelatedOnceToAProject)
values(3, 'State Assembly Voting District', 0, 0, 1)

alter table dbo.RelationshipType alter column CanOnlyBeRelatedOnceToAProject bit not null

delete
from dbo.OrganizationTypeRelationshipType
where OrganizationTypeID in (19, 20) and RelationshipTypeID = 12


update dbo.OrganizationTypeRelationshipType
set RelationshipTypeID = 13
where OrganizationTypeID = 19 and RelationshipTypeID = 9