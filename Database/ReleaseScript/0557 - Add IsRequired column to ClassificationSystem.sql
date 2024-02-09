
alter table dbo.[ClassificationSystem] add IsRequired bit null
go
update dbo.[ClassificationSystem] set IsRequired = 1
alter table dbo.[ClassificationSystem] alter column IsRequired bit not null


INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(391, N'IsClassificationSystemRequired', N'Is Classification System Required?')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(391, 'When defining a project''s classifications, at least one must be selected for the classification system if it is marked as required.')