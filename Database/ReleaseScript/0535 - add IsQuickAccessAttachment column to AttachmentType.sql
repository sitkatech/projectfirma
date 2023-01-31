alter table dbo.AttachmentType add IsQuickAccessAttachment bit null
go

update dbo.AttachmentType set IsQuickAccessAttachment = 0
alter table dbo.AttachmentType alter column IsQuickAccessAttachment bit not null

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(381, N'QuickAccessAttachment', N'Quick Link on Top of Project Pages')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(381, 'When set to yes, this attachment type will display as a link to download at the top of the project detail page and the top of the project fact sheet.')