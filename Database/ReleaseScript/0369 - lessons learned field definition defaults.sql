--begin tran

-- enable Project Evaluations 
UPDATE FieldDefinitionDefault set 
DefaultDefinition = '<p>Allows Admins to create evaluations where they can rank projects with custom defined criteria.</p>'
where FieldDefinitionID = 338

GO

UPDATE FieldDefinitionData set 
FieldDefinitionDataValue = '<p>Allows Admins to create evaluations where they can rank Near Term Actions with custom defined criteria.</p>'
where FieldDefinitionID = 338 and TenantID = 11


-- enable project timeline
UPDATE FieldDefinitionDefault set 
DefaultDefinition = '<p>Enables the project timeline which allows users to enter status updates throughout the life of a project. Additionally, users can enter a "Final" status update that includes a field for "lessons learned" once a project is in the "Complete" stage.</p>'
where FieldDefinitionID = 339

INSERT INTO FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
values (11, 339, '<p>Enables the Near Term Action timeline which allows users to enter status updates throughout the life of an Action. Additionally, users can enter a "Final" status update that includes a field for "lessons learned" once an Action is in the "Complete" stage.</p>', 'Use Near Term Action Timeline')

--rollback tran