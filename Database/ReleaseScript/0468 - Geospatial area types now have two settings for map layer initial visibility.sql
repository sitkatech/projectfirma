
-- Rename existing field
exec sp_rename 'dbo.GeospatialAreaType.LayerIsOnByDefault', 'OnByDefaultOnProjectMap', 'COLUMN'
go

-- Add new field
alter table dbo.GeospatialAreaType
add OnByDefaultOnOtherMaps bit null
go

-- Set default (it doesn't look like any of these settings are being used)
update dbo.GeospatialAreaType
set OnByDefaultOnOtherMaps = 1
go

-- Turn off initial visibility of Watersheds for RCD on Project Map
update dbo.GeospatialAreaType
set OnByDefaultOnProjectMap = 0
where GeospatialAreaTypeID = 3

-- Make non-nullable
alter table dbo.GeospatialAreaType
alter column OnByDefaultOnOtherMaps bit not null
go

-- Field definitions
-- Relabel existing field definition
update dbo.FieldDefinition
set FieldDefinitionName = 'GeospatialAreaTypeOnByDefaultOnProjectMap', FieldDefinitionDisplayName = 'Layer is on by default on Project Map?'
where FieldDefinitionID = 319

-- Add field definition for new field
insert into dbo.FieldDefinition(FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName)
values
(369, 'GeospatialAreaTypeOnByDefaultOnOtherMaps', 'Layer on by default on all maps other than the Project Map?')
go

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
values
(369, 'This setting determines whether the layer is visible by default on all maps other than the Project Map.')