

UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'Status', FieldDefinitionDisplayName = N'Status'
WHERE FieldDefinitionID = 302;

UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'StatusUpdate', FieldDefinitionDisplayName = N'Status Update'
WHERE FieldDefinitionID = 303;

UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'StatusHistory', FieldDefinitionDisplayName = N'Status History'
WHERE FieldDefinitionID = 304;

UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'UpdateHistory', FieldDefinitionDisplayName = N'Update History'
WHERE FieldDefinitionID = 305;

UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'StatusLegend', FieldDefinitionDisplayName = N'Status Legend'
WHERE FieldDefinitionID = 306;

UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'StatusUpdateCreatedBy', FieldDefinitionDisplayName = N'Status Update Created By'
WHERE FieldDefinitionID = 307;

UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'StatusUpdateDate', FieldDefinitionDisplayName = N'Status Update Date'
WHERE FieldDefinitionID = 308;

UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'StatusComments', FieldDefinitionDisplayName = N'Status Comments'
WHERE FieldDefinitionID = 309;


UPDATE dbo.FieldDefinition  
SET FieldDefinitionName = N'StatusLessonsLearned', FieldDefinitionDisplayName = N'Lessons Learned'
WHERE FieldDefinitionID = 324;



INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
--(338, N'EnableProjectEvaluations', 'Enable Project Evaluations'),
(339, N'UseProjectTimeline', 'Use Project Timeline')
--adding default definitions for new field definitions
 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(339, N'Use Project Timeline')

 --insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 --values(338, N'Enable Project Evaluations')