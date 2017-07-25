delete FDD
from dbo.FieldDefinitionData as FDD inner join dbo.FieldDefinition as FD
on FDD.FieldDefinitionID = FD.FieldDefinitionID
where FD.FieldDefinitionName = 'Funder';

delete FDD
from dbo.FieldDefinitionData as FDD inner join dbo.FieldDefinition as FD
on FDD.FieldDefinitionID = FD.FieldDefinitionID
where FD.FieldDefinitionName = 'Implementer';

delete from dbo.FieldDefinition where FieldDefinitionName = 'Funder';
delete from dbo.FieldDefinition where FieldDefinitionName = 'Implementer';

alter table dbo.FieldDefinition
add CanCustomizeLabel bit null
go

update dbo.FieldDefinition
set CanCustomizeLabel = 1;

update dbo.FieldDefinition
set CanCustomizeLabel = 0
where FieldDefinitionName = 'Password' or FieldDefinitionName = 'Project';

alter table dbo.FieldDefinition
alter column CanCustomizeLabel bit not null
go