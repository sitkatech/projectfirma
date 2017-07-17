CREATE TABLE dbo.FirmaHomePageImage(
	FirmaHomePageImageID int NOT NULL IDENTITY(1,1) CONSTRAINT PK_FirmaHomePageImage_FirmaHomePageImageID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_FirmaHomePageImage_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),
	FileResourceID int NOT NULL CONSTRAINT FK_FirmaHomePageImage_FileResource_FileResourceID FOREIGN KEY REFERENCES dbo.FileResource (FileResourceID),
	Caption varchar(300) NOT NULL,
	SortOrder int NOT NULL,
	constraint FK_FirmaHomePageImage_FileResource_FileResourceID_TenantID foreign key (FileResourceID, TenantID) references dbo.FileResource (FileResourceID, TenantID)
)
