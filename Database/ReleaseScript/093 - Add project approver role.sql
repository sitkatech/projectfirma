alter table dbo.RelationshipType add CanApproveProjects bit null
alter table dbo.RelationshipType add IsPrimaryContact bit null

delete from dbo.FieldDefinitionDataImage where FieldDefinitionDataID = (select top 1 FieldDefinitionDataID from dbo.FieldDefinitionData where FieldDefinitionID = 12)
delete from dbo.FieldDefinitionData where FieldDefinitionID = 12

create table dbo.ProposedProjectOrganization(
	ProposedProjectOrganizationID int not null identity(1, 1) constraint PK_ProposedProjectOrganization_ProposedProjectOrganizationID primary key,
	TenantID int not null constraint FK_ProposedProjectOrganization_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProposedProjectID int not null constraint FK_ProposedProjectOrganization_ProposedProject_ProposedProjectID foreign key references dbo.ProposedProject(ProposedProjectID),
	OrganizationID int not null constraint FK_ProposedProjectOrganization_Organization_OrganizationID foreign key references dbo.Organization(OrganizationID),
	RelationshipTypeID int not null constraint FK_ProposedProjectOrganization_RelationshipType_RelationshipTypeID foreign key references dbo.RelationshipType(RelationshipTypeID),
	-- Double keys for tenant
	constraint AK_ProposedProjectOrganization_ProposedProjectOrganization_TenantID unique(ProposedProjectOrganizationID, TenantID),
	constraint FK_ProposedProjectOrganization_ProposedProject_ProposedProjectID_Tenant_TenantID foreign key (ProposedProjectID, TenantID) references dbo.ProposedProject(ProposedProjectID, TenantID),
	constraint FK_ProposedProjectOrganization_Organization_OrganizationID_Tenant_TenantID foreign key (OrganizationID, TenantID) references dbo.Organization(OrganizationID, TenantID),
	constraint FK_ProposedProjectOrganization_RelationshipType_RelationshipTypeID_Tenant_TenantID foreign key (RelationshipTypeID, TenantID) references dbo.RelationshipType(RelationshipTypeID, TenantID)
)

go

update dbo.RelationshipType set CanApproveProjects = 0, IsPrimaryContact = 0
update dbo.RelationshipType set CanApproveProjects = 1 where TenantID = 3 and RelationshipTypeName = 'Associated RCD'

insert into dbo.RelationshipType(TenantID, RelationshipTypeName, CanApproveProjects, IsPrimaryContact)
select
	t.TenantID,
	'Lead Implementer' as RelationshipTypeName,
	0 as CanApproveProjects,
	1 as IsPrimaryContact
from dbo.Tenant t
where t.TenantID in (1, 2, 3)

insert into dbo.OrganizationTypeRelationshipType(TenantID, OrganizationTypeID, RelationshipTypeID)
select
	o.TenantID,
	o.OrganizationTypeID,
	(select top 1 r.RelationshipTypeID from dbo.RelationshipType r where r.TenantID = o.TenantID and r.RelationshipTypeName = 'Lead Implementer') as RelationshipTypeID
from dbo.OrganizationType o
where o.TenantID in (1, 2, 3)

go

insert into dbo.ProjectOrganization(TenantID, ProjectID, OrganizationID, RelationshipTypeID)
select
	p.TenantID,
	p.ProjectID,
	p.LeadImplementerOrganizationID,
	(select top 1 RelationshipTypeID from dbo.RelationshipType where TenantID = p.TenantID and RelationshipTypeName = 'Lead Implementer') as RelationshipTypeID
from dbo.Project p
where p.LeadImplementerOrganizationID is not null

insert into dbo.ProposedProjectOrganization(TenantID, ProposedProjectID, OrganizationID, RelationshipTypeID)
select
	p.TenantID,
	p.ProposedProjectID,
	p.LeadImplementerOrganizationID,
	(select top 1 RelationshipTypeID from dbo.RelationshipType where TenantID = p.TenantID and RelationshipTypeName = 'Lead Implementer') as RelationshipTypeID
from dbo.ProposedProject p
where p.LeadImplementerOrganizationID is not null

alter table dbo.Project drop constraint FK_Project_Organization_LeadImplementerOrganizationID_OrganizationID
alter table dbo.Project drop constraint FK_Project_Organization_LeadImplementerOrganizationID_TenantID_OrganizationID_TenantID

alter table dbo.ProposedProject drop constraint FK_ProposedProject_Organization_LeadImplementerOrganizationID_OrganizationID
alter table dbo.ProposedProject drop constraint FK_ProposedProject_Organization_LeadImplementerOrganizationID_TenantID_OrganizationID_TenantID

go

alter table dbo.RelationshipType alter column CanApproveProjects bit not null
alter table dbo.RelationshipType alter column IsPrimaryContact bit not null

create unique index CK_RelationshipType_CanApproveProjects_OneTruePerTenant on dbo.RelationshipType (TenantID, CanApproveProjects) where CanApproveProjects = 1
create unique index CK_RelationshipType_IsPrimaryContact_OneTruePerTenant on dbo.RelationshipType (TenantID, IsPrimaryContact) where IsPrimaryContact = 1

alter table dbo.Project drop column LeadImplementerOrganizationID
alter table dbo.ProposedProject drop column LeadImplementerOrganizationID

-- A unit test told me to add this :/
alter table dbo.Organization add constraint FK_Organization_OrganizationType_OrganizationTypeID_TenantID foreign key (OrganizationTypeID, TenantID) references dbo.OrganizationType(OrganizationTypeID, TenantID)
