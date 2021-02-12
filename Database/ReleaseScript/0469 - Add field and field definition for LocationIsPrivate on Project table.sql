
alter table dbo.Project
add LocationIsPrivate bit null
go 

update dbo.Project
set LocationIsPrivate = 0
go

alter table dbo.Project
alter column LocationIsPrivate bit not null
go 

alter table dbo.ProjectUpdate
add LocationIsPrivate bit null
go 

update dbo.ProjectUpdate
set LocationIsPrivate = 0
go

alter table dbo.ProjectUpdate
alter column LocationIsPrivate bit not null
go 

insert into dbo.FieldDefinition(FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName)
values
(370, 'ProjectLocationIsPrivate', 'Location Privacy')
go

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
values
(370, 'Hides this project''s location from most users.')