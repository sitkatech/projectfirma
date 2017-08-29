alter table dbo.ProposedProject add ProjectWatershedNotes varchar(4000) null
alter table dbo.ProjectUpdate add ProjectWatershedNotes varchar(4000) null
alter table dbo.Project add ProjectWatershedNotes varchar(4000) null

alter table dbo.ProjectUpdateBatch add WatershedComment varchar(1000) null

CREATE TABLE dbo.ProposedProjectWatershed(
	ProposedProjectWatershedID int NOT NULL IDENTITY(1,1) CONSTRAINT PK_ProposedProjectWatershed_ProposedProjectWatershedID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_ProposedProjectWatershed_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant(TenantID),
	ProposedProjectID int NOT NULL CONSTRAINT FK_ProposedProjectWatershed_ProposedProject_ProposedProjectID FOREIGN KEY REFERENCES dbo.ProposedProject(ProposedProjectID),
	WatershedID int NOT NULL CONSTRAINT FK_ProposedProjectWatershed_Watershed_WatershedID FOREIGN KEY REFERENCES dbo.Watershed (WatershedID),
	CONSTRAINT AK_ProposedProjectWatershed_ProposedProjectID_WatershedID UNIQUE NONCLUSTERED (ProposedProjectID, WatershedID),
	CONSTRAINT FK_ProposedProjectWatershed_ProposedProject_ProposedProjectID_TenantID FOREIGN KEY(ProposedProjectID, TenantID) REFERENCES dbo.ProposedProject(ProposedProjectID, TenantID),
	CONSTRAINT FK_ProposedProjectWatershed_Watershed_WatershedID_TenantID FOREIGN KEY(WatershedID, TenantID) REFERENCES dbo.Watershed (WatershedID, TenantID)
)


CREATE TABLE dbo.ProjectWatershedUpdate(
	ProjectWatershedUpdateID int NOT NULL IDENTITY(1,1) CONSTRAINT PK_ProjectWatershedUpdate_ProjectWatershedUpdateID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_ProjectWatershedUpdate_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant(TenantID),
	ProjectUpdateBatchID int NOT NULL CONSTRAINT FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID FOREIGN KEY REFERENCES dbo.ProjectUpdateBatch(ProjectUpdateBatchID),
	WatershedID int NOT NULL CONSTRAINT FK_ProjectWatershedUpdate_Watershed_WatershedID FOREIGN KEY REFERENCES dbo.Watershed (WatershedID),
	CONSTRAINT AK_ProjectWatershedUpdate_ProjectUpdateBatchID_WatershedID UNIQUE NONCLUSTERED (ProjectUpdateBatchID, WatershedID),
	CONSTRAINT FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID FOREIGN KEY(ProjectUpdateBatchID, TenantID) REFERENCES dbo.ProjectUpdateBatch (ProjectUpdateBatchID, TenantID),
	CONSTRAINT FK_ProjectWatershedUpdate_Watershed_WatershedID_TenantID FOREIGN KEY(WatershedID, TenantID) REFERENCES dbo.Watershed (WatershedID, TenantID)
)

go

alter table dbo.Project drop constraint FK_Project_ProjectLocationArea_ProjectLocationAreaID
alter table dbo.Project drop constraint FK_Project_ProjectLocationArea_ProjectLocationAreaID_TenantID
alter table dbo.Project drop constraint CK_Project_ProjectLocationPointXorProjectLocationArea
alter table dbo.ProposedProject drop constraint FK_ProposedProject_ProjectLocationArea_ProjectLocationAreaID
alter table dbo.ProposedProject drop constraint FK_ProposedProject_ProjectLocationArea_ProjectLocationAreaID_TenantID
alter table dbo.ProposedProject drop constraint CK_ProposedProject_ProjectLocationPointXorProposedProjectLocationArea
alter table dbo.ProjectUpdate drop constraint FK_ProjectUpdate_ProjectLocationArea_ProjectLocationAreaID
alter table dbo.ProjectUpdate drop constraint FK_ProjectUpdate_ProjectLocationArea_ProjectLocationAreaID_TenantID
alter table dbo.ProjectUpdate drop constraint CK_ProjectUpdate_ProjectUpdateLocationPointXorProjectUpdateLocationArea

go

-- Update project, proposed project, and project update and insert previously named areas into project watershed tables
insert into dbo.ProjectWatershed
select p.TenantID, p.ProjectID, w.WatershedID
from
	dbo.Project p
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2
except
select pw.TenantID, pw.ProjectID, pw.WatershedID
from
	dbo.ProjectWatershed pw


insert into dbo.ProposedProjectWatershed
select p.TenantID, p.ProposedProjectID, w.WatershedID
from
	dbo.ProposedProject p
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2

insert into dbo.ProjectWatershedUpdate
select p.TenantID, pub.ProjectUpdateBatchID, w.WatershedID
from
	dbo.ProjectUpdate p
	join dbo.ProjectUpdateBatch pub on p.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2

go

-- Update project, proposed project, and project update and set instances where the project area is used for simple to have
-- no location and a standard explanation
update dbo.Project
set
	ProjectLocationSimpleTypeID = 3,
	ProjectLocationNotes = 'No simple location set.'
from
	dbo.Project p
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2

update dbo.ProposedProject
set
	ProjectLocationSimpleTypeID = 3,
	ProjectLocationNotes = 'No simple location set.'
from
	dbo.ProposedProject p
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2

update dbo.ProjectUpdate
set
	ProjectLocationSimpleTypeID = 3,
	ProjectLocationNotes = 'No simple location set.'
from
	dbo.ProjectUpdate p
	join dbo.ProjectLocationArea pla on p.ProjectLocationAreaID = pla.ProjectLocationAreaID
	join dbo.Watershed w on w.WatershedID = pla.WatershedID
where p.ProjectLocationSimpleTypeID = 2

go

alter table dbo.Project drop column ProjectLocationAreaID
alter table dbo.ProposedProject drop column ProjectLocationAreaID
alter table dbo.ProjectUpdate drop column ProjectLocationAreaID

drop table dbo.ProjectLocationAreaStateProvince
drop table dbo.ProjectLocationAreaWatershed
drop table dbo.ProjectLocationArea
drop table dbo.ProjectLocationAreaGroup
drop table dbo.ProjectLocationAreaGroupType
