  Update dbo.ProjectCustomAttributeType Set IncludeInNtaGrid = 0 Where IncludeInNtaGrid is Null
  
  go

  Alter Table dbo.ProjectCustomAttributeType Alter Column IncludeInNtaGrid Bit Not Null

