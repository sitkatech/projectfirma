alter table dbo.RelationshipType add CanApproveProjects bit null

go

update dbo.RelationshipType set CanApproveProjects = 0

update dbo.RelationshipType set CanApproveProjects = 1 where TenantID = 3 and RelationshipTypeName = 'Associated RCD'

insert into dbo.RelationshipType(TenantID, RelationshipTypeName, CanApproveProjects)
select
	t.TenantID,
	'Lead Implementer' as RelationshipTypeName,
	1 as CanApproveProjects
from dbo.Tenant t
where t.TenantID in (1, 2, 3)

go

alter table dbo.RelationshipType alter column CanApproveProjects bit not null
