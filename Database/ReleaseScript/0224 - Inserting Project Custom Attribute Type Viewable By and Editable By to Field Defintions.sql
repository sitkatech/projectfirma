Insert Into dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition)
Values
(271, N'ProjectCustomAttributeTypeEditableBy', 'Project Custom Attribute Type Editable By' , N''),
(272, N'ProjectCustomAttributeTypeViewableBy', 'Project Custom Attribute Type Viewable By', N'')

Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
Values
(11,271, N'', N''),
(11,272, N'', N'')