  Update dbo.ProjectCustomAttributeType Set IncludeInNtaGrid = 0 Where IncludeInNtaGrid is Null
  
  Go

  Alter Table dbo.ProjectCustomAttributeType Alter Column IncludeInNtaGrid Bit Not Null

  Go
  Exec sp_rename 'ProjectCustomAttributeType.IncludeInNtaGrid', 'IncludeInProjectGrid', 'Column'