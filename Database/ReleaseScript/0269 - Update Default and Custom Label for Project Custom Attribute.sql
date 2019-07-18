-- insert row like with label like 'Near Term Action Custom Attribute'
insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionLabel)
select a.TenantID, a.FieldDefinitionID, CONCAT(fddProject.FieldDefinitionLabel, ' Custom Attribute')
from
(
	select t.TenantID, FieldDefinitionID
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 259
) a left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
left join dbo.FieldDefinitionData fddProject on a.TenantID = fddProject.TenantID and fddProject.FieldDefinitionID = 44
where fdd.FieldDefinitionDataID is null and fddProject.FieldDefinitionLabel is not null

Update dbo.FieldDefinition set FieldDefinitionDisplayName = 'Project Custom Attribute' where FieldDefinitionID = 259;