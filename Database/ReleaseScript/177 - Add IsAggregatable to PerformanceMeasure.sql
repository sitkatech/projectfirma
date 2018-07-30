alter table dbo.PerformanceMeasure
add IsAggregatable bit null
go

update dbo.PerformanceMeasure
set IsAggregatable = 1

update dbo.PerformanceMeasure
set IsAggregatable = 0
where PerformanceMeasureID = 2147 -- SWC's PM Technical Assistance Hours

alter table dbo.PerformanceMeasure
alter column IsAggregatable bit not null

insert into dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition, CanCustomizeLabel)
values
(264, 'PerformanceMeasureIsAggregatable', 'Is Aggregatable', 'Indicates whether the values for this Performance Measure can be aggregated across subcategory options.', 1)

insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select
TenantID as TenantID,
264 as FieldDefinitionID,
null as FieldDefinitionDataValue,
null as FieldDefinitionLabel
from Tenant