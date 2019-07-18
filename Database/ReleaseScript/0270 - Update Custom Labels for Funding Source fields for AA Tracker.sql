-- insert rows using "Funding Program" instead of "Funding Source" for Action Agenda Tracker

-- ID 8 = "Funding Source". This should exist already, but attempt to add it just in case
insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionLabel)
select a.TenantID, a.FieldDefinitionID, 'Funding Program'
from
(
	select t.TenantID, FieldDefinitionID
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 8 and t.TenantID = 11
) a left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
where fdd.FieldDefinitionDataID is null

select * from FieldDefinitionData  where TenantID = 11 and FieldDefinitionID = 8

Update dbo.FieldDefinitionData set FieldDefinitionLabel = 'Funding Program' where TenantID = 11 and FieldDefinitionID = 8

-- ID 283 = "Funding Source Custom Attribute"
insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionLabel)
select a.TenantID, a.FieldDefinitionID, 'Funding Program Custom Attribute'
from
(
	select t.TenantID, FieldDefinitionID
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 282 and t.TenantID = 11
) a left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
where fdd.FieldDefinitionDataID is null

-- ID 283 = "Funding Source Custom Attribute Data Type"
insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionLabel)
select a.TenantID, a.FieldDefinitionID, 'Funding Program Custom Attribute Data Type'
from
(
	select t.TenantID, FieldDefinitionID
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 283 and t.TenantID = 11
) a left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
where fdd.FieldDefinitionDataID is null

-- ID 284 = "Funding Source Custom Attribute Editable By"
insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionLabel)
select a.TenantID, a.FieldDefinitionID, 'Funding Program Custom Attribute Editable By'
from
(
	select t.TenantID, FieldDefinitionID
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 284 and t.TenantID = 11
) a left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
where fdd.FieldDefinitionDataID is null

-- ID 285 = "Funding Source Custom Attribute Viewable By"
insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionLabel)
select a.TenantID, a.FieldDefinitionID, 'Funding Program Custom Attribute Viewable By'
from
(
	select t.TenantID, FieldDefinitionID
	from dbo.FieldDefinition fd
	cross join dbo.Tenant t
	where fd.FieldDefinitionID = 285 and t.TenantID = 11
) a left join dbo.FieldDefinitionData fdd on a.FieldDefinitionID = fdd.FieldDefinitionID and a.TenantID = fdd.TenantID
where fdd.FieldDefinitionDataID is null