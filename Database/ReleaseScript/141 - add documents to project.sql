create table dbo.ProjectDocument (
	ProjectDocumentID int not null identity(1, 1) constraint PK_ProjectDocument_ProjectDocumentID primary key,
	TenantID int not null constraint FK_ProjectDocument_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID int not null constraint FK_ProjectDocument_Project_ProjectID foreign key references dbo.Project(ProjectID),
	FileResourceID int not null constraint FK_ProjectDocument_FileResource_FileResourceID foreign key references dbo.FileResource(FileResourceID),
	DisplayName varchar(200) not null,
	[Description] varchar(1000) null,
	constraint AK_ProjectDocument_ProjectID_FileResourceID unique (ProjectID, FileResourceID),
	constraint FK_ProjectDocument_DisplayName_ProjectID unique (DisplayName, ProjectID),
	constraint FK_ProjectDocument_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID),
	constraint FK_ProjectDocument_FileResource_FileResourceID_TenantID foreign key (FileResourceID, TenantID) references dbo.FileResource(FileResourceID, TenantID)
)
