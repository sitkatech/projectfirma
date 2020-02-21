

-- These empty strings instead of nulls actually do work in the interface, but they are
-- very confusing when looking directly at the data, PLUS when normally we save an empty
-- label, it stores a null, so it is isn't consistent with normal user data either.
-- 
-- So, first, clean them up.
update dbo.FieldDefinitionData
set  FieldDefinitionLabel = null
where FieldDefinitionLabel = ''
GO

update dbo.FieldDefinitionData
set  FieldDefinitionDataValue = null
where FieldDefinitionDataValue = ''
GO

-- Second, prevent recurrence. (Yes, Tom is probably right that these values above happened in a release script,
-- but we want to be very sure.)

ALTER TABLE [dbo].FieldDefinitionData  WITH CHECK ADD  CONSTRAINT [CK_FieldDefinitionData_FieldDefinitionLabel_IsNotEmptyString] CHECK  (FieldDefinitionLabel != '')
GO

ALTER TABLE [dbo].FieldDefinitionData  WITH CHECK ADD  CONSTRAINT [CK_FieldDefinitionData_FieldDefinitionDataValue_IsNotEmptyString] CHECK  (FieldDefinitionDataValue != '')
GO

-- Oh, also, Stewart Gordon did this and he's wrong.
update dbo.FieldDefinition
set FieldDefinitionDisplayName = 'Report Description'
where FieldDefinitionID = 344

--select * from dbo.FieldDefinition where FieldDefinitionID = 344






