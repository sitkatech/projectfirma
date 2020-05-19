-- Fixing after failures from AssureThatEveryChildTableHasADualForeignKeyWithTenantID

alter table dbo.Project
add constraint FK_Project_Person_SubmittedByPersonID_TenantID_PersonID_TenantID
foreign key (SubmittedByPersonID, TenantID)
references dbo.Person(PersonID, TenantID)

ALTER TABLE [dbo].DocumentLibrary ADD  CONSTRAINT [AK_DocumentLibrary_DocumentLibraryID_TenantID] UNIQUE NONCLUSTERED 
(
    DocumentLibraryID ASC,
    [TenantID] ASC
) ON [PRIMARY]
GO

alter table dbo.CustomPage
add constraint FK_CustomPage_DocumentLibrary_DocumentLibraryID_TenantID
foreign key (DocumentLibraryID, TenantID)
references dbo.DocumentLibrary(DocumentLibraryID, TenantID)

alter table dbo.DocumentLibraryDocumentCategory 
add constraint FK_DocumentLibraryDocumentCategory_DocumentLibrary_DocumentLibraryID_TenantID 
foreign key (DocumentLibraryID, TenantID) 
references dbo.DocumentLibrary(DocumentLibraryID, TenantID)