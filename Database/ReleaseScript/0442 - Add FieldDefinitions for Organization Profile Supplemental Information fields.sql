INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(361, N'OrganizationCash', N'Cash'),
(362, N'OrganizationInKindServices', N'In-Kind Services'),
(363, N'OrganizationCommercialServices', N'Commercial Services')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(361, ''),
(362, ''),
(363, '')