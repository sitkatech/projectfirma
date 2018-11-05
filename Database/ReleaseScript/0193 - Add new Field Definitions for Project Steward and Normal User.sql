INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName], [DefaultDefinition], CanCustomizeLabel) 
VALUES 
(266, N'NormalUser', N'Normal User', N'Users with this role can propose new Projects, update existing Projects where their organization is the Lead Implementer, and view almost every page within the Project Tracker.', 1),
(267, N'ProjectStewardshipArea', N'Project Stewardship Area', 'Indicates which attribute of a project is used to determine if a Project Steward is permitted to edit that project.', 1)

Insert into FieldDefinitionData([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
select
TenantID, 266, Null, Null
From Tenant
Insert into FieldDefinitionData([TenantID], [FieldDefinitionID], [FieldDefinitionDataValue], [FieldDefinitionLabel])
select
TenantID, 267, Null, Null
From Tenant