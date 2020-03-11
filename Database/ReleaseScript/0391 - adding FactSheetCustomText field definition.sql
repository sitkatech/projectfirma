INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])
VALUES
(348, N'FactSheetCustomText', N'Fact Sheet Custom Text')

INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition])
VALUES
(348, N'Fact Sheet Custom Text displays at the bottom of all Project Fact Sheets')

INSERT into [dbo].[FieldDefinitionData] ([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
VALUES
(11, 348, N'Fact Sheet Custom Text displays at the bottom of all Near Term Action Fact Sheets', N'Fact Sheet Custom Text')

