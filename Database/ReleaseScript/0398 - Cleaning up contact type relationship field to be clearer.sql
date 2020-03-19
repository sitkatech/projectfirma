


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



ALTER TABLE [dbo].[OrganizationRelationshipType] DROP CONSTRAINT [CK_OrganizationRelationshipType_CanOnlyBeRelatedOnceToAProjectMustBeTrueIfIsPrimaryContact]
GO

EXEC sp_rename 'dbo.OrganizationRelationshipType.CanOnlyBeRelatedOnceToAProject', 'IsOrganizationRelationshipTypeRequired', 'COLUMN';
go

ALTER TABLE [dbo].[OrganizationRelationshipType]  WITH CHECK ADD  CONSTRAINT [CK_OrganizationRelationshipType_IsOrganizationRelationshipTypeRequiredMustBeTrueIfIsPrimaryContact] CHECK  (([IsPrimaryContact]=(1) AND [IsOrganizationRelationshipTypeRequired]=(1) OR [IsPrimaryContact]=(0)))
GO

ALTER TABLE [dbo].[OrganizationRelationshipType] CHECK CONSTRAINT [CK_OrganizationRelationshipType_IsOrganizationRelationshipTypeRequiredMustBeTrueIfIsPrimaryContact]
GO


INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])
VALUES
(351, N'IsOrganizationRelationshipTypeRequired', N'Is Organization Relationship Type Required?')

INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition])
VALUES
(351, N'When defining a project''s organizations, this organization type is required and there can only be one organization assigned to this organization type.')

INSERT into [dbo].[FieldDefinitionData] ([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
VALUES
(11, 351, N'When defining a near term action''s organizations, this organization type is required and there can only be one organization assigned to this organization type.', N'Is Organization Relationship Type Required?')

INSERT [dbo].[FirmaPageType] ([FirmaPageTypeID], [FirmaPageTypeName], [FirmaPageTypeDisplayName], [FirmaPageRenderTypeID])
VALUES
(83, 'ManageOrganizationTypes', 'Manage Organization Types', 1)

INSERT [dbo].[FirmaPage] ([TenantID], [FirmaPageTypeID], [FirmaPageContent])SELECT TenantID,
83,
'<p>Define and update the set of organization types you want available to projects. You can control whether each organization type is required or not. If required, users will only be able to select one organization as that organization type. If not required, users will be to add as many organizations as they like as that organization type.</p>'
FROM [dbo].[Tenant]

UPDATE [dbo].[FirmaPage] SET FirmaPageContent = '<p>Define and update the set of organization types you want available to near term actions. You can control whether each organization type is required or not. If required, users will only be able to select one organization as that organization type. If not required, users will be to add as many organizations as they like as that organization type.</p>'
WHERE TenantID = 11 and FirmaPageTypeID = 83