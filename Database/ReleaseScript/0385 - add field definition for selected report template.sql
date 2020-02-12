
INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(347, N'ReportCenterSelectedReportTemplate', 'Selected Report Template')

INSERT into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
VALUES
(347, '<p>Allows you to identify a report to run on the projects selected from the report center grid</p>')


INSERT into dbo.FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue)
values
(11, 347, '<p>Allows you to identify a report to run on the near term actions selected from the report center grid</p>')

--rollback tran