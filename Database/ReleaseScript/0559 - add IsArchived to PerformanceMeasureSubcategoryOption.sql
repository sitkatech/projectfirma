  alter table dbo.PerformanceMeasureSubcategoryOption add IsArchived bit null
  go
  update dbo.PerformanceMeasureSubcategoryOption set IsArchived = 0
  alter table dbo.PerformanceMeasureSubcategoryOption alter column IsArchived bit not null

  INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(392, N'ArchivePerformanceMeasureSubcategoryOption', N'Archive Performance Measure Subcategory Option')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values (392, 'Options not associated with current projects or project updates can be archived. Options not associated with any projects or project update (including historic project updates) can be deleted.')