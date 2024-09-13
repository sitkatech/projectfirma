


  alter table dbo.[TenantAttribute] add AreReportsPublic bit not null default 0

  INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
  (393, N'ReportVisibility', N'Report Visibility')

  insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
  values (393, 'Restricted reports will only be visible to ESA Admins, Admins, and Project Stewards. Public reports will be available to ESA Admins, Admins, and Project Stewards, Normal Users, Unassigned Users, and Public users.')