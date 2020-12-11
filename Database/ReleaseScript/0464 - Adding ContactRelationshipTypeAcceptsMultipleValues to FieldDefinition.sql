INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])
VALUES
(367, N'ContactRelationshipTypeAcceptsMultipleValues', N'Accepts Multiple Values')

INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition])
VALUES
(367, N'Does this Contact Type accept multiple values. If set to Yes, more than one value can be set. If set to No, only one value can be set.')

