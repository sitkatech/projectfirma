INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition], CanCustomizeLabel) 
VALUES 
(254, N'TaxonomyTierThreeDescription', N'Taxonomy Tier Three Description', N'<p>The long-form description of the entries in the project taxonomy system.</p>', 1),
(255, N'TaxonomyTierTwoDescription', N'Taxonomy Tier Two Description', N'<p>The long-form description of the entries in the project taxonomy system.</p>', 1),
(256, N'TaxonomyTierOneDescription', N'Taxonomy Tier One Description', N'<p>The long-form description of the entries in the project taxonomy system.</p>', 1)

insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select 
	t.tenantid,
	254,
	null,
	'Description'
from dbo.tenant t

insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select 
	t.tenantid,
	255,
	null,
	'Description'
from dbo.tenant t

insert into dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
select 
	t.tenantid,
	256,
	null,
	'Description'
from dbo.tenant t