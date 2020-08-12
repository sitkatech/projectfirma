Use ProjectFirma

Alter table dbo.GeospatialAreaType add DisplayOnAllProjectMaps bit null
Alter table dbo.GeospatialAreaType add LayerIsOnByDefault bit null
go

update dbo.GeospatialAreaType set DisplayOnAllProjectMaps = 1
update dbo.GeospatialAreaType set LayerIsOnByDefault = 1

Alter table dbo.GeospatialAreaType alter column DisplayOnAllProjectMaps bit not null
Alter table dbo.GeospatialAreaType alter column LayerIsOnByDefault bit not null