INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(382, N'AboutMenu', N'About'),
(383, N'ProjectsMenu', N'Projects'),
(384, N'ProgramInfoMenu', N'Program Info'),
(385, N'ResultsMenu', N'Results'),
(386, N'ReportsMenu', N'Reports')

insert dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(382, N'About Menu'),
(383, N'Projects Menu'),
(384, N'Program Info Menu'),
(385, N'Results Menu'),
(386, N'Reports Menu')