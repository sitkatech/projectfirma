
-- Create Table for Project Notes per GeospatialAreaType
create table dbo.ProjectGeospatialAreaTypeNote(
ProjectGeospatialAreaTypeNoteID int not null identity(1,1) constraint PK_ProjectGeospatialAreaTypeNote_ProjectGeospatialAreaTypeNoteID primary key,
TenantID int not null constraint FK_ProjectGeospatialAreaTypeNote_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
ProjectID int not null constraint FK_ProjectGeospatialAreaTypeNote_Project_ProjectID foreign key references dbo.Project(ProjectID),
GeospatialAreaTypeID int not null constraint FK_ProjectGeospatialAreaTypeNote_GeospatialAreaType_GeospatialAreaTypeID foreign key references dbo.GeospatialAreaType,
Notes varchar(4000) not null,
constraint AK_ProjectGeospatialAreaTypeNote_ProjectID_GeospatialAreaTypeID unique (ProjectID, GeospatialAreaTypeID),
)

-- Create Table for Project Update Notes per GeospatialAreaType
create table dbo.ProjectGeospatialAreaTypeNoteUpdate(
ProjectGeospatialAreaTypeNoteID int not null identity(1,1) constraint PK_ProjectGeospatialAreaTypeNoteUpdate_ProjectGeospatialAreaTypeNoteUpdateID primary key,
TenantID int not null constraint FK_ProjectGeospatialAreaTypeNoteUpdate_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
ProjectUpdateBatchID int not null constraint FK_ProjectGeospatialAreaTypeNoteUpdate_ProjectUpdateBatch_ProjectUpdateBatchID foreign key references dbo.ProjectUpdateBatch(ProjectUpdateBatchID),
GeospatialAreaTypeID int not null constraint FK_ProjectGeospatialAreaTypeNoteUpdate_GeospatialAreaType_GeospatialAreaTypeID foreign key references dbo.GeospatialAreaType,
Notes varchar(4000) not null,
constraint AK_ProjectGeospatialAreaTypeNoteUpdate_ProjectUpdateBatchID_GeospatialAreaTypeID unique (ProjectUpdateBatchID, GeospatialAreaTypeID),
)

-- Migrate existing Project Geospatial Area Notes

insert into dbo.ProjectGeospatialAreaTypeNote (TenantID, ProjectID, GeospatialAreaTypeID, Notes)
select p.TenantID,
p.ProjectID,
gat.GeospatialAreaTypeID,
p.ProjectGeospatialAreaNotes
from Project p
join dbo.GeospatialAreaType gat on p.TenantID = gat.TenantID
where p.ProjectGeospatialAreaNotes is not null

-- Remove unneeded field from Project
alter table dbo.Project
drop column ProjectGeospatialAreaNotes

-- Migrate existing Project Update Geospatial Area Notes
insert into dbo.ProjectGeospatialAreaTypeNoteUpdate (TenantID, ProjectUpdateBatchID, GeospatialAreaTypeID, Notes)
select pu.TenantID,
pu.ProjectUpdateBatchID,
gat.GeospatialAreaTypeID,
pu.ProjectGeospatialAreaNotes
from dbo.ProjectUpdate pu
join dbo.GeospatialAreaType gat on pu.TenantID = pu.TenantID
where pu.ProjectGeospatialAreaNotes is not null

-- Remove unneeded field from ProjectUpdate
alter table dbo.ProjectUpdate
drop column ProjectGeospatialAreaNotes

select * from ProjectGeospatialAreaTypeNote
select * from ProjectGeospatialAreaTypeNoteUpdate

