-- create lookup table for DocumentCategory
create table dbo.DocumentCategory(
	DocumentCategoryID int not null constraint PK_DocumentCategory_DocumentCategoryID primary key,
	DocumentCategoryName varchar(100) not null,
	DocumentCategoryDisplayName varchar(100) not null,
	SortOrder int not null
)

insert into dbo.DocumentCategory(DocumentCategoryID, DocumentCategoryName, DocumentCategoryDisplayName, SortOrder) values 
(1, 'MeetingNotes', 'Meeting Notes', 10),
(2, 'MeetingAgendas', 'Meeting Agendas', 20),
(3, 'RequestForProposals', 'Request for Proposals', 30),
(4, 'ManualsAndGuidance', 'Manuals and Guidance', 40),
(5, 'Presentations', 'Presentations', 50),
(6, 'ProgramInformation', 'Program Information', 60),
(7, 'ProgramManagement', 'Program Management', 70),
(8, 'ProgressReport', 'Progress Report', 80),
(9, 'PoliciesAndPlans', 'Policies and Plans', 90),
(10, 'Monitoring', 'Monitoring', 100),
(11, 'Other', 'Other', 110)

create table dbo.DocumentLibrary (
	DocumentLibraryID int identity(1,1) not null constraint PK_DocumentLibrary_DocumentLibraryID primary key,
	TenantID int not null constraint FK_DocumentLibrary_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	DocumentLibraryName varchar(200) not null,
	DocumentLibraryDescription varchar(500) null
)

create table dbo.DocumentLibraryDocumentCategory(
	DocumentLibraryDocumentCategoryID int identity(1,1) not null constraint PK_DocumentLibraryDocumentCategory_DocumentLibraryDocumentCategoryID primary key,
	TenantID int not null constraint FK_DocumentLibraryDocumentCategory_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	DocumentLibraryID int not null constraint FK_DocumentLibraryDocumentCategory_DocumentLibrary_DocumentLibraryID foreign key references dbo.DocumentLibrary(DocumentLibraryID),
	DocumentCategoryID int not null constraint FK_DocumentLibraryDocumentCategory_DocumentCategory_DocumentCategoryID foreign key references dbo.DocumentCategory(DocumentCategoryID)
)

alter table dbo.CustomPage add DocumentLibraryID int null constraint FK_CustomPage_DocumentLibrary_DocumentLibraryID foreign key references dbo.DocumentLibrary(DocumentLibraryID)

insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])
values
(353, N'DocumentLibraryName', N'Document Library Name')

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
values
(353, 'The name of the document library.')