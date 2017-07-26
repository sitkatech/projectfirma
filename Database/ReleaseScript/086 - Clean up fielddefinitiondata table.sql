update fdd
set fdd.FieldDefinitionDataValue = null
from dbo.FieldDefinitionData fdd
join dbo.FieldDefinition fd on fdd.FieldDefinitionID = fd.FieldDefinitionID
where fdd.FieldDefinitionDataValue = fd.DefaultDefinition + char(13) + char(10) or fdd.FieldDefinitionDataValue = fd.DefaultDefinition + char(13) or fdd.FieldDefinitionDataValue = fd.DefaultDefinition + char(10)


update fdd
set FieldDefinitionDataValue = null
from dbo.FieldDefinitionData fdd
join dbo.FieldDefinition fd on fdd.FieldDefinitionID = fd.FieldDefinitionID
where fdd.FieldDefinitionID in (76, 92)
