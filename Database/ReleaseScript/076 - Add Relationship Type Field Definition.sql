insert into dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition)
values
(245, N'ProjectRelationshipType', N'Project Relationship Type', N'<p>A categorization of a relationship between an organization and a project, e.g. Funder, Implementer.</p>')

go

insert into dbo.FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
values 
(1, 245, null, null),
(2, 245, null, null),
(3, 245, null, null)