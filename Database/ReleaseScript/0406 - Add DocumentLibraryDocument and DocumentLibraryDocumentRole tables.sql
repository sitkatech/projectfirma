--add Alternate Key and Foreign Keys that were missed with ProjectFirma/#1076
alter table dbo.DocumentLibrary add constraint AK_DocumentLibrary_DocumentLibraryID_TenantID unique (DocumentLibraryID, TenantID)

--alter table dbo.DocumentLibraryDocumentCategory add constraint AK_DocumentLibraryDocumentCategory_DocumentLibraryDocumentCategoryID_TenantID unique (DocumentLibraryDocumentCategoryID, TenantID)
alter table dbo.DocumentLibraryDocumentCategory add constraint FK_DocumentLibraryDocumentCategory_DocumentLibrary_DocumentLibraryID_TenantID foreign key (DocumentLibraryID, TenantID) references dbo.DocumentLibrary(DocumentLibraryID, TenantID)



create table dbo.DocumentLibraryDocument (
	DocumentLibraryDocumentID int identity(1,1) not null constraint PK_DocumentLibraryDocument_DocumentLibraryDocumentID primary key,
	TenantID int not null constraint FK_DocumentLibraryDocument_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	DocumentLibraryID int not null constraint FK_DocumentLibraryDocument_DocumentLibrary_DocumentLibraryID foreign key references dbo.DocumentLibrary(DocumentLibraryID),
	DocumentCategoryID int not null constraint FK_DocumentLibraryDocument_DocumentCategory_DocumentCategoryID foreign key references dbo.DocumentCategory(DocumentCategoryID),
	DocumentTitle varchar(200) not null,
	DocumentDescription varchar(1000) null,
	FileResourceID int not null constraint FK_DocumentLibraryDocument_FileResource_FileResourceID foreign key references dbo.FileResource(FileResourceID),
	SortOrder int null,
	LastUpdateDate datetime not null,
	LastUpdatePersonID int not null constraint FK_DocumentLibraryDocument_Person_LastUpdatePersonID_PersonID foreign key references dbo.Person(PersonID)
)

alter table dbo.DocumentLibraryDocument add constraint AK_DocumentLibraryDocument_DocumentLibraryDocumentID_TenantID unique (DocumentLibraryDocumentID, TenantID) 
alter table dbo.DocumentLibraryDocument add constraint FK_DocumentLibraryDocument_DocumentLibrary_DocumentLibraryID_TenantID foreign key (DocumentLibraryID, TenantID) references dbo.DocumentLibrary(DocumentLibraryID, TenantID)
alter table dbo.DocumentLibraryDocument add constraint FK_DocumentLibraryDocument_FileResource_FileResourceID_TenantID foreign key (FileResourceID, TenantID) references dbo.FileResource(FileResourceID, TenantID)
alter table dbo.DocumentLibraryDocument add constraint FK_DocumentLibraryDocument_Person_LastUpdatePersonID_TenantID_PersonID_TenantID foreign key (LastUpdatePersonID, TenantID) references dbo.Person(PersonID, TenantID)


insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])
values
(355, N'DocumentLibrary', N'Document Library'),
(356, N'DocumentLibraryDocumentViewableBy', N'Document Viewable By')

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
values
(355, ''),
(356, '')


CREATE TABLE dbo.DocumentLibraryDocumentRole(
	DocumentLibraryDocumentRoleID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_DocumentLibraryDocumentRole_DocumentLibraryDocumentRoleID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_DocumentLibraryDocumentRole_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant(TenantID),
	DocumentLibraryDocumentID int NOT NULL CONSTRAINT FK_DocumentLibraryDocumentRole_DocumentLibraryDocument_DocumentLibraryDocumentID FOREIGN KEY REFERENCES dbo.DocumentLibraryDocument (DocumentLibraryDocumentID),
	RoleID int NULL CONSTRAINT FK_DocumentLibraryDocumentRole_Role_RoleID REFERENCES dbo.[Role](RoleID),
)

ALTER TABLE dbo.DocumentLibraryDocumentRole  ADD  CONSTRAINT FK_DocumentLibraryDocumentRole_DocumentLibraryDocument_DocumentLibraryDocumentID_TenantID FOREIGN KEY(DocumentLibraryDocumentID, TenantID)
REFERENCES dbo.DocumentLibraryDocument (DocumentLibraryDocumentID, TenantID)

