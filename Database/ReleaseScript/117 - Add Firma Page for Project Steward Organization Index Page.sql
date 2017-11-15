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
(249, N'ProjectStewardOrganizationIndex', N'Project Steward Organization Index', N'<p>List of organizations that can steward projects.</p>', 1)

insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
values
(1, 249, '', ''),
(2, 249, '', ''),
(3, 249, '', 'Participating RCD'),
(4, 249, '', ''),
(5, 249, '', ''),
(6, 249, '', '')