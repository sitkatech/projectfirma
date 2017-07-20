alter table dbo.OrganizationType add ShowOnProjectMaps bit null
go
update dbo.OrganizationType set ShowOnProjectMaps = 0
go
alter table dbo.OrganizationType alter column ShowOnProjectMaps bit not null
 