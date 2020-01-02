insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (322,N'FinalStatusReportStatus', N'Final Status Report')

 insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (323,N'IsFinalStatusReport', N'Is Final Status Report')

 
 insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (324,N'ProjectStatusLessonsLearned', N'Lessons Learned')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(322,N'Final Status Report')

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(323,N'Is Final Status Report')

 
 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(324,N'Lessons Learned')