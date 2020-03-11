INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])
VALUES
(349, N'FactSheetLogo', N'Fact Sheet Logo')

INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition])
VALUES
(349, N'This logo appears on all Project Fact Sheets')

INSERT into [dbo].[FieldDefinitionData] ([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
VALUES
(11, 349, N'This logo appears on all Near Term Action Fact Sheets', N'Fact Sheet Logo')

