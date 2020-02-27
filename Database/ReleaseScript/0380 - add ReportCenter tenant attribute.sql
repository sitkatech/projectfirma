--begin tran

ALTER TABLE dbo.TenantAttribute
ADD EnableReports bit null

go

UPDATE dbo.TenantAttribute
    set EnableReports = 0 
    where EnableReports is null

go 

ALTER TABLE dbo.TenantAttribute
ALTER COLUMN EnableReports bit not null

go

-- Field Definition default
INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(342, N'EnableReports', 'Enable Reports')

go

INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition]) 
VALUES 
(342, '<p>This will enable the word document reporting functionality, including adding a new menu group for Reports where users can upload word document report templates and run reports on select models within the system.</p>')

go




--rollback tran