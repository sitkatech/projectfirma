alter table dbo.TenantAttribute add ProjectExternalDataSourceApiUrl varchar(500) null
alter table dbo.TenantAttribute add ProjectExternalSourceOfRecordName varchar(256) null
alter table dbo.TenantAttribute add ProjectExternalSourceOfRecordUrl varchar(500) null

alter table dbo.Project add ExternalID int null

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(392, N'ProjectExternalID', N'External ID')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(392, '')