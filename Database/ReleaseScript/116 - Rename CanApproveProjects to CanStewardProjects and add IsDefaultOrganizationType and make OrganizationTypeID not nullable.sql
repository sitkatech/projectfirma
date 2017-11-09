DROP INDEX CK_RelationshipType_CanApproveProjects_OneTruePerTenant ON dbo.RelationshipType
GO

exec sp_rename 'dbo.RelationshipType.CanApproveProjects', 'CanStewardProjects', 'COLUMN'
GO

CREATE UNIQUE NONCLUSTERED INDEX CK_RelationshipType_CanStewardProjects_OneTruePerTenant ON dbo.RelationshipType
(
	TenantID ASC,
	CanStewardProjects ASC
)
WHERE (CanStewardProjects=(1))
go


alter table dbo.OrganizationType add IsDefaultOrganizationType bit null
GO

update dbo.OrganizationType
set IsDefaultOrganizationType = 0

update dbo.OrganizationType
set IsDefaultOrganizationType = 1
where OrganizationTypeName = 'Private'


alter table dbo.OrganizationType alter column IsDefaultOrganizationType bit not null
GO

update o
set o.OrganizationTypeID = (select top 1 ot.OrganizationTypeID from dbo.OrganizationType ot where ot.TenantID = o.TenantID and ot.IsDefaultOrganizationType = 1 order by ot.OrganizationTypeID)
from dbo.Organization o
where o.OrganizationTypeID is null

alter table dbo.Organization alter column OrganizationTypeID int not null
