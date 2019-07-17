insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID)
select a.TenantID, a.FieldDefinitionID
from
(
	select t.TenantID, FieldDefinitionID
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 241
) a left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
where fdd.FieldDefinitionDataID is null

update dbo.FieldDefinitionData
set FieldDefinitionLabel = 'Goal Statement'
where FieldDefinitionID = 241

insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID)
select a.TenantID, a.FieldDefinitionID
from
(
	select t.TenantID, FieldDefinitionID
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 240
) a left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
where fdd.FieldDefinitionDataID is null

update dbo.FieldDefinitionData
set FieldDefinitionLabel = 'Description'
where FieldDefinitionID = 240



-- remove ChartLastUpdateDate field definition
delete
from dbo.FieldDefinitionData
where FieldDefinitionID in (247)
