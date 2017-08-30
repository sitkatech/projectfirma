INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition], CanCustomizeLabel) 
VALUES 
(12, N'IsPrimaryContactOrganization', N'Is Primary Contact Organization', N'<p>The entity with primary responsibility for organizing, planning, and executing implementation activities for a project or program. This is usually the lead implementer.</p>', 1),
(13, N'CanApproveProjectsOrganization', N'Can Approve Projects Organization', N'<p>The entity with primary responsibility for approving a project.</p>', 1)

insert into dbo.FieldDefinitionData(FieldDefinitionID, TenantID, FieldDefinitionLabel)
values
(12, 1, 'Lead Implementer'),
(12, 2, 'Lead Implementer'),
(12, 3, 'Lead Implementer'),
(13, 3, 'Associated RCD')