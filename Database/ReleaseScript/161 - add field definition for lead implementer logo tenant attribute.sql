insert into FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition, CanCustomizeLabel)
values (258, N'ShowLeadImplementerLogoOnFactSheet', N'Show Lead Implementer Logo on Project Fact Sheet?', N'<p>When this option is set, project fact sheets will include the lead implementer''s logo under the website logo. When not set, only the website logo will be shown on fact sheets.', 1)

insert into FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select 
TenantID,
258 as FieldDefinitionID,
NULL as FieldDefinitionDataValue,
NULL as FieldDefinitionLabel
from tenant