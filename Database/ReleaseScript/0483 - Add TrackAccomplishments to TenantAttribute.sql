alter table dbo.TenantAttribute add TrackAccomplishments bit null
go

update dbo.TenantAttribute set TrackAccomplishments = 1
go

alter table dbo.TenantAttribute alter column TrackAccomplishments bit not null

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES
(372, N'TrackAccomplishments', N'Track Accomplishments')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(372, '')