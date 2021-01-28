

-- Add new field
alter table dbo.OrganizationType
add LayerOnByDefault bit null
go

--- Set default to match current behavior
update dbo.OrganizationType
set LayerOnByDefault = 1
go

-- Make non-nullable
alter table dbo.OrganizationType
alter column LayerOnByDefault bit not null 

-- Add field definition for new field
insert into dbo.FieldDefinition(FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName)
values
(368, 'OrganizationTypeLayerOnByDefault', 'Layer on by Default?')
go

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
values
(368, 'This setting determines whether the layer is visible by default on the maps on which it appears.')
