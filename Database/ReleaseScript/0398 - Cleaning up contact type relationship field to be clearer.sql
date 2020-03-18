


EXEC sp_rename 'dbo.ContactRelationshipType.CanOnlyBeRelatedOnceToAProject', 'IsContactRelationshipTypeRequired', 'COLUMN';
go


INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])
VALUES
(350, N'IsContactRelationshipTypeRequired', N'Is Contact Relationship Type Required?')

INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition])
VALUES
(350, N'When defining a project''s contacts, this contact type is required and there can only be one contact assigned to this contact type.')

INSERT into [dbo].[FieldDefinitionData] ([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
VALUES
(11, 350, N'When defining a near term action''s contacts, this contact type is required and there can only be one contact assigned to this contact type.', N'Is Contact Relationship Type Required?')




INSERT [dbo].[FirmaPageType] ([FirmaPageTypeID], [FirmaPageTypeName], [FirmaPageTypeDisplayName], [FirmaPageRenderTypeID])
VALUES
(82, 'ManageContactTypes', 'Manage Contact Types', 1)

INSERT [dbo].[FirmaPage] ([TenantID], [FirmaPageTypeID], [FirmaPageContent])SELECT TenantID,
82,
'<p>Define and update the set of contact types you want available to projects. You can control whether each contact type is required or not. If required, users will only be able to select one person as that contact type (e.g. "Technical Lead"). If not required, users will be to add as many people as they like as that contact type (e.g. "Scientific Advisor").</p>'
FROM [dbo].[Tenant]

UPDATE [dbo].[FirmaPage] SET FirmaPageContent = '<p>Define and update the set of contact types you want available to near term actions. You can control whether each contact type is required or not. If required, users will only be able to select one person as that contact type (e.g. "Technical Lead"). If not required, users will be to add as many people as they like as that contact type (e.g. "Scientific Advisor").</p>'
WHERE TenantID = 11 and FirmaPageTypeID = 82



