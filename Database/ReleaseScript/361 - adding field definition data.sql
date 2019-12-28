insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (322,N'FinalStatusReportStatus', N'Final Status Report')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(322,N'Final Status Report')