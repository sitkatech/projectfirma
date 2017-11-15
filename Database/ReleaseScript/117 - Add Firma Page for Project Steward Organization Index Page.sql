insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(46, 'ProjectStewardOrganizationList', 'ProjectStewardOrganizationList', 1)

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 46, ''),
(2, 46, ''),
(3, 46, ''),
(4, 46, ''),
(5, 46, ''),
(6, 46, '')

insert into dbo.FieldDefinition(FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition, CanCustomizeLabel) 
values
(249, N'ProjectStewardOrganizationListItem', N'Project Steward Organization List Item', N'<p>Name of organization that can steward projects to be shown in a navigation list.</p>', 1)

insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
values
(1, 249, '', ''),
(2, 249, '', ''),
(3, 249, '', 'Participating RCD'),
(4, 249, '', ''),
(5, 249, '', ''),
(6, 249, '', '')