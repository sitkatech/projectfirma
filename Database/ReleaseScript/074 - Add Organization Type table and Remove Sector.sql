
CREATE TABLE dbo.OrganizationType(
	OrganizationTypeID int NOT NULL IDENTITY(1,1) constraint PK_OrganizationType_OrganizationTypeID PRIMARY KEY,
	TenantID int NOT NULL constraint FK_OrganizationType_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),	
	OrganizationTypeName varchar(200) NOT NULL,
	OrganizationTypeAbbreviation varchar(100) NOT NULL,
	LegendColor varchar(10) NOT NULL
)

go

alter table dbo.OrganizationType add constraint AK_OrganizationType_OrganizationTypeID_TenantID UNIQUE (OrganizationTypeID, TenantID)
alter table dbo.OrganizationType add constraint AK_OrganizationType_OrganizationTypeName_TenantID UNIQUE (OrganizationTypeName, TenantID) 

insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor)
select distinct TenantID, SectorDisplayName, SectorAbbreviation, LegendColor
from dbo.Organization org 
	inner join dbo.Sector sect 
	on org.SectorID = sect.SectorID

go

alter table dbo.Organization add OrganizationTypeID int NULL
alter table dbo.Organization add constraint FK_Organization_OrganizationType_OrganizationTypeID foreign key (OrganizationTypeID) references dbo.OrganizationType(OrganizationTypeID)

go

update org
set org.OrganizationTypeID = y.OrganizationTypeID
from dbo.Organization org 
inner join (
	select OrganizationTypeID, SectorID, TenantID
	from dbo.OrganizationType orgType join dbo.Sector sect
	on orgType.OrganizationTypeName = sect.SectorDisplayName
) y on org.SectorID = y.SectorID and org.TenantID = y.TenantID


alter table dbo.Organization drop constraint FK_Organization_Sector_SectorID
alter table dbo.Organization drop column SectorID


alter table dbo.SnapshotSectorExpenditure add OrganizationTypeID int NULL
alter table dbo.SnapshotSectorExpenditure add constraint FK_SnapshotSectorExpenditure_OrganizationType_OrganizationTypeID foreign key (OrganizationTypeID) references dbo.OrganizationType(OrganizationTypeID)
alter table dbo.SnapshotSectorExpenditure add constraint FK_SnapshotSectorExpenditure_OrganizationType_OrganizationTypeID_TenantID foreign key (OrganizationTypeID, TenantID) references dbo.OrganizationType(OrganizationTypeID, TenantID)

go

update sse
set sse.OrganizationTypeID = y.OrganizationTypeID
from dbo.SnapshotSectorExpenditure sse 
inner join (
	select OrganizationTypeID, SectorID, TenantID
	from dbo.OrganizationType orgType join dbo.Sector sect
	on orgType.OrganizationTypeName = sect.SectorDisplayName
) y on sse.SectorID = y.SectorID and sse.TenantID = y.TenantID

alter table dbo.SnapshotSectorExpenditure alter column OrganizationTypeID int NOT NULL

alter table dbo.SnapshotSectorExpenditure add constraint AK_SnapshotSectorExpenditure_SnapshotID_OrganizationTypeID_CalendarYear unique (SnapshotID, OrganizationTypeID, CalendarYear)

alter table dbo.SnapshotSectorExpenditure drop constraint FK_SnapshotSectorExpenditure_Sector_SectorID
alter table dbo.SnapshotSectorExpenditure drop constraint AK_SnapshotSectorExpenditure_SnapshotID_SectorID_CalendarYear
alter table dbo.SnapshotSectorExpenditure drop column SectorID

go

drop table dbo.Sector


CREATE TABLE dbo.RelationshipType(
	RelationshipTypeID int NOT NULL IDENTITY(1,1) constraint PK_RelationshipType_RelationshipTypeID PRIMARY KEY,
	TenantID int NOT NULL constraint FK_RelationshipType_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),	
	RelationshipTypeName varchar(200) NOT NULL,	
)

alter table dbo.RelationshipType add constraint AK_RelationshipType_RelationshipTypeID_TenantID UNIQUE (RelationshipTypeID, TenantID)
alter table dbo.RelationshipType add constraint AK_RelationshipType_RelationshipTypeName_TenantID UNIQUE (RelationshipTypeName, TenantID) 

go

CREATE TABLE dbo.OrganizationTypeRelationshipType(
	OrganizationTypeRelationshipTypeID int NOT NULL IDENTITY(1,1) constraint PK_OrganizationTypeRelationshipType_OrganizationTypeRelationshipTypeID PRIMARY KEY,
	TenantID int NOT NULL constraint FK_OrganizationTypeRelationshipType_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),	
	OrganizationTypeID int NOT Null constraint FK_OrganizationTypeRelationshipType_OrganizationType_OrganizationTypeID FOREIGN KEY REFERENCES dbo.OrganizationType (OrganizationTypeID),
	RelationshipTypeID int NOT Null constraint FK_OrganizationTypeRelationshipType_RelationshipType_RelationshipTypeID FOREIGN KEY REFERENCES dbo.RelationshipType (RelationshipTypeID)
)

ALTER TABLE dbo.OrganizationTypeRelationshipType ADD CONSTRAINT FK_OrganizationTypeRelationshipType_OrganizationType_OrganizationTypeID_TenantID FOREIGN KEY(OrganizationTypeID, TenantID) REFERENCES dbo.OrganizationType (OrganizationTypeID, TenantID)
ALTER TABLE dbo.OrganizationTypeRelationshipType ADD CONSTRAINT FK_OrganizationTypeRelationshipType_RelationshipType_RelationshipTypeID_TenantID FOREIGN KEY(RelationshipTypeID, TenantID) REFERENCES dbo.RelationshipType (RelationshipTypeID, TenantID)
alter table dbo.OrganizationTypeRelationshipType add constraint AK_OrganizationTypeRelationshipType_OrganizationTypeRelationshipTypeID_TenantID UNIQUE (OrganizationTypeRelationshipTypeID, TenantID)
alter table dbo.OrganizationTypeRelationshipType add constraint AK_OrganizationTypeRelationshipType_OrganizationTypeID_RelationshipTypeID_TenantID UNIQUE (OrganizationTypeID, RelationshipTypeID, TenantID)

go

insert into dbo.RelationshipType(TenantID, RelationshipTypeName)
select distinct TenantID, 'Funder'
from dbo.ProjectFundingOrganization

insert into dbo.RelationshipType(TenantID, RelationshipTypeName)
select distinct TenantID, 'Implementer'
from dbo.ProjectImplementingOrganization

go

CREATE TABLE dbo.ProjectOrganization(
	ProjectOrganizationID int NOT NULL IDENTITY(1,1) constraint PK_ProjectOrganization_ProjectOrganizationID PRIMARY KEY,
	TenantID int NOT NULL constraint FK_ProjectOrganization_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),
	ProjectID int NOT NULL constraint FK_ProjectOrganization_Project_ProjectID FOREIGN KEY REFERENCES dbo.Project (ProjectID),
	OrganizationID int NOT NULL constraint FK_ProjectOrganization_Organization_OrganizationID FOREIGN KEY REFERENCES dbo.Organization (OrganizationID),
	RelationshipTypeID int NOT NULL constraint FK_ProjectOrganization_RelationshipType_RelationshipTypeID FOREIGN KEY REFERENCES dbo.RelationshipType (RelationshipTypeID),
)

ALTER TABLE dbo.ProjectOrganization ADD CONSTRAINT FK_ProjectOrganization_Project_ProjectID_TenantID FOREIGN KEY(ProjectID, TenantID) REFERENCES dbo.Project (ProjectID, TenantID)
ALTER TABLE dbo.ProjectOrganization ADD CONSTRAINT FK_ProjectOrganization_Organization_OrganizationID_TenantID FOREIGN KEY(OrganizationID, TenantID) REFERENCES dbo.Organization (OrganizationID, TenantID)
alter table dbo.ProjectOrganization add constraint AK_ProjectOrganization_ProjectOrganizationID_TenantID UNIQUE (ProjectOrganizationID, TenantID)
alter table dbo.ProjectOrganization add constraint FK_ProjectOrganization_RelationshipType_RelationshipTypeID_TenantID foreign key (RelationshipTypeID, TenantID) references dbo.RelationshipType(RelationshipTypeID, TenantID)

go

alter table dbo.Project add LeadImplementerOrganizationID int null
alter table dbo.Project add constraint FK_Project_Organization_LeadImplementerOrganizationID_OrganizationID foreign key (LeadImplementerOrganizationID) references dbo.Organization(OrganizationID)
alter table dbo.Project add constraint FK_Project_Organization_LeadImplementerOrganizationID_TenantID_OrganizationID_TenantID foreign key (LeadImplementerOrganizationID, TenantID) references dbo.Organization(OrganizationID, TenantID)

go

update p
set p.LeadImplementerOrganizationID = y.OrganizationID
from dbo.Project p 
inner join (
	select pio.OrganizationID, p.ProjectID, p.TenantID
	from dbo.Project p join dbo.ProjectImplementingOrganization pio
	on p.ProjectID = pio.ProjectID
	where pio.IsLeadOrganization = 1
) y on p.ProjectID = y.ProjectID and p.TenantID = y.TenantID

insert into dbo.OrganizationTypeRelationshipType (TenantID, OrganizationTypeID, RelationshipTypeID)
select distinct pfo.TenantID, o.OrganizationTypeID, rt.RelationshipTypeID
from dbo.ProjectFundingOrganization pfo 
inner join dbo.Organization o 
	on pfo.OrganizationID = o.OrganizationID
inner join dbo.RelationshipType rt
	on pfo.TenantID = rt.TenantID
	where rt.RelationshipTypeName = 'Funder'

insert into dbo.OrganizationTypeRelationshipType (TenantID, OrganizationTypeID, RelationshipTypeID)
select distinct pio.TenantID, o.OrganizationTypeID, rt.RelationshipTypeID
from dbo.ProjectImplementingOrganization pio 
inner join dbo.Organization o 
	on pio.OrganizationID = o.OrganizationID
inner join dbo.RelationshipType rt
	on pio.TenantID = rt.TenantID
	where rt.RelationshipTypeName = 'Implementer'

insert into dbo.ProjectOrganization
select pfo.TenantID, pfo.ProjectID, o.OrganizationID, rt.RelationshipTypeID
from dbo.ProjectFundingOrganization pfo
inner join dbo.Organization o
	on pfo.OrganizationID = o.OrganizationID
inner join dbo.RelationshipType rt
	on pfo.TenantID = rt.TenantID
	where rt.RelationshipTypeName = 'Funder'

insert into dbo.ProjectOrganization
select pio.TenantID, pio.ProjectID, o.OrganizationID, rt.RelationshipTypeID
from dbo.ProjectImplementingOrganization pio
inner join dbo.Organization o
	on pio.OrganizationID = o.OrganizationID
inner join dbo.RelationshipType rt
	on pio.TenantID = rt.TenantID
	where rt.RelationshipTypeName = 'Implementer'

DROP TABLE dbo.ProjectFundingOrganization
DROP TABLE dbo.ProjectImplementingOrganization




