--begin tran

ALTER TABLE dbo.TenantAttribute
ADD EnableReportCenter bit null

go

UPDATE dbo.TenantAttribute
    set EnableReportCenter = 0 
    where EnableReportCenter is null

go 

ALTER TABLE dbo.TenantAttribute
ALTER COLUMN EnableReportCenter bit not null

go

-- Field Definition default
INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(342, N'EnableReportCenter', 'Enable Report Center')

go

INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition]) 
VALUES 
(342, '<p>This will enable the word document reporting functionality, including adding a new menu group for the Report Center where users can upload word document report templates and run reports on select models within the system.</p>')

go




--rollback tran