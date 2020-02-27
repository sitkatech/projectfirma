
INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(347, N'SelectedReportTemplate', 'Selected Report Template')

INSERT into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
VALUES
(347, '<p>Allows you to identify a report to run on the projects selected from the reports grid</p>')


INSERT into dbo.FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue)
values
(11, 347, '<p>Allows you to identify a report to run on the near term actions selected from the reports grid</p>')

--rollback tran