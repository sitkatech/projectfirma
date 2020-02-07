--begin tran

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(343, N'ReportCenterReportTitle', 'Title'),
(344, N'ReportCenterReportDescription', 'Description'),
(345, N'ReportCenterReportFile', 'File'),
(346, N'ReportCenterReportModel', 'Model')

INSERT into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
VALUES
(343, '<p>A unique name that succinctly describes the context/purpose of this report.</p>'),
(344, '<p>Expand on the context of this report to help others better understand the contents, audience, purpose, etc. of this report.</p>'),
(345, '<p>Select the document which is the template for this report.</p>'),
(346, '<p>Select the model that this report template will be used for.</p>')

--rollback tran
