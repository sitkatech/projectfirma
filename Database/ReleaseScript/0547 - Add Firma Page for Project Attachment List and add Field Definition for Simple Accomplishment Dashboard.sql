insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(94, 'ProjectAttachmentList', 'Project Attachment List', 1)

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 94, ''),
(2, 94, ''),
(3, 94, ''),
(4, 94, ''),
(5, 94, ''),
(6, 94, ''),
(7, 94, ''),
(8, 94, ''),
(9, 94, ''),
(11, 94, ''),
(12, 94, ''),
(13, 94, '')



INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(387, N'EnableSimpleAccomplishmentsDashboard', N'Enable Simple Accomplishments Dashboard')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(387, 'When this option is set to Yes, Admins will be able to create Performance Measure Groups. Data from Performance Measure Groups will roll into a simplified version of the Accomplishments Dashboard.')