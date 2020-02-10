
alter table dbo.TenantAttribute
add EnableProjectTypes bit null default 0;
go

update dbo.TenantAttribute set EnableProjectTypes = 0 where EnableProjectTypes is null;

go

alter table dbo.TenantAttribute
alter column EnableProjectTypes bit not null;

go

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(340, N'ProjectType', 'Project Type'),
(341, N'EnableProjectType', 'Enable Project Types')
go


INSERT INTO [dbo].[FieldDefinitionDefault] ([FieldDefinitionID],[DefaultDefinition])
     VALUES
			(340, N'<p>Project Type</p>'),
            (341, N'<p>Enabling Project Types adds support for additional project types such as "Administrative" projects. By default without this enabled, all projects are of the type "Normal". This also enables the capability of Custom Attribute Groups to be assigned to these Project Types.</p>')

GO


INSERT INTO FieldDefinitionData (TenantID, FieldDefinitionID, FieldDefinitionDataValue, FieldDefinitionLabel)
values (11, 340, '<p>Near Term Action Type</p>', 'Near Term Action Type')


