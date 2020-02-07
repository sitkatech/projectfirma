--begin tran

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(341, N'ReportCenterReportTitle', 'Title'),
(342, N'ReportCenterReportDescription', 'Description'),
(343, N'ReportCenterReportFile', 'File'),
(344, N'ReportCenterReportModel', 'Model')

INSERT into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
VALUES
(341, '<p>A unique name that succinctly describes the context/purpose of this report.</p>'),
(342, '<p>Expand on the context of this report to help others better understand the contents, audience, purpose, etc. of this report.</p>'),
(343, '<p>Select the document which is the template for this report.</p>'),
(344, '<p>Select the model that this report template will be used for.</p>')

--rollback tran
