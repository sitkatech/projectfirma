INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(390, N'AccomplishmentDashboardMenu', N'Accomplishment Dashboard')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(390, 'Accomplishment Dashboard Menu')

insert into dbo.FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionLabel)
values
(4, 390, 'Project Impact Dashboard')
