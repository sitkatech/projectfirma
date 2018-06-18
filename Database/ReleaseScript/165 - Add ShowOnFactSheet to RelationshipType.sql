Alter Table dbo.RelationshipType
Add ShowOnFactSheet bit null
go

Update dbo.RelationshipType
set ShowOnFactSheet = 1

Alter Table dbo.RelationshipType
Alter Column ShowOnFactSheet bit not null
go