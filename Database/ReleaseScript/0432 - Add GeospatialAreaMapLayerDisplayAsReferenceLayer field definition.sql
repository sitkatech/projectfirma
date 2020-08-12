INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(359, N'GeospatialAreaMapLayerDisplayAsReferenceLayer', 'Display as Reference Layer?')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(359, 'Geospatial Area map layers always appear on the Project map and relevant Geospatial Area maps. By setting this option, the Geospatial Area map layer will also be added as a Reference layer to all other maps that support the display of Geospatial Areas.')