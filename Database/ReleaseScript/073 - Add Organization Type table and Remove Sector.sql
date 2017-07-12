
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
from dbo.Organization org inner join dbo.Sector sect on org.SectorID = sect.SectorID

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
