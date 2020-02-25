
alter table dbo.TenantAttribute
add EnableProjectCategories bit null default 0;
go

update dbo.TenantAttribute set EnableProjectCategories = 0 where EnableProjectCategories is null;

go

alter table dbo.TenantAttribute
alter column EnableProjectCategories bit not null;

go

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(340, N'ProjectCategory', 'Project Category'),
(341, N'EnableProjectCategory', 'Enable Project Categories')
go


INSERT INTO [dbo].[FieldDefinitionDefault] ([FieldDefinitionID],[DefaultDefinition])
     VALUES
			(340, N'<p>Project Category</p>'),
            (341, N'<p>Enabling Project Categories adds support for additional project categories such as "Administrative" projects. By default without this enabled, all projects are of the category "Normal". This also enables the capability of Custom Attribute Groups to be assigned to these Project Categories.</p>')

GO


INSERT INTO FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
values (11, 340, '<p>Near Term Action Category</p>', 'Near Term Action Category')


INSERT INTO FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
values (11, 341, '<p>Enabling Near Term Action Categories adds support for additional near term action categories such as "Administrative" near term actions. By default without this enabled, all near term actions are of the category "Normal". This also enables the capability of Custom Attribute Groups to be assigned to these Near Term Action Categories.</p>', 'Enable Near Term Action Categories')