--begin tran

update dbo.FieldDefinitionData
set FieldDefinitionDataValue = REPLACE(FieldDefinitionDataValue, 'Backward and Forward Looking Fact Sheets, ', '')
where FieldDefinitionID = 281

Update dbo.FieldDefinitionDefault 
set DefaultDefinition = REPLACE(DefaultDefinition, 'on Fact Sheets and ', '')
where FieldDefinitionID = 281

--rollback tran