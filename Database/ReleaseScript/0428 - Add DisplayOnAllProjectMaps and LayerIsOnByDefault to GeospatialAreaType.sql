Use ProjectFirma

Alter table dbo.GeospatialAreaType add DisplayOnAllProjectMaps bit null
Alter table dbo.GeospatialAreaType add LayerIsOnByDefault bit null
go

update dbo.GeospatialAreaType set DisplayOnAllProjectMaps = 1
update dbo.GeospatialAreaType set LayerIsOnByDefault = 1

Alter table dbo.GeospatialAreaType alter column DisplayOnAllProjectMaps bit not null
Alter table dbo.GeospatialAreaType alter column LayerIsOnByDefault bit not null

-- remove 'external' from default definition
update dbo.FieldDefinitionDefault set DefaultDefinition = 'When this option is set, display the map layer on various maps throughout the site similar to geospatial areas (e.g watersheds). When not set, the map layer will only appear on the Project Map.' where FieldDefinitionID = 318