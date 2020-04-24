INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES (352, N'SyncWithKeystoneOnSave', N'Sync with Keystone on Save')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values (352, 'When selected, this option will sync the Name, Short Name, and Home Page values with the values stored in Keystone for this Organization.')