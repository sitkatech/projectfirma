drop table dbo.ProjectDocument
go

drop table dbo.ProjectDocumentUpdate
go



delete from dbo.ProjectCreateSection where ProjectCreateSectionName = 'NotesAndDocuments'

delete from dbo.ProjectUpdateSection where ProjectUpdateSectionName = 'NotesAndDocuments'

