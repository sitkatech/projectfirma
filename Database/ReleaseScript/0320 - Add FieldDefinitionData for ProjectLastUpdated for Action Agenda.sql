Insert Into dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition)
Values
(295, N'ProjectLastUpdated', N'Last Updated', N'<p>The date the project was last updated.</p>')

Insert Into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue)
Values (11, 295, '<p>The date the NTA was last updated.</p>')