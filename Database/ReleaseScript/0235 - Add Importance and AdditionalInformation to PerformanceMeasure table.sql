alter table dbo.PerformanceMeasure add Importance dbo.html, AdditionalInformation dbo.html

CREATE TABLE dbo.PerformanceMeasureImage(
	PerformanceMeasureImageID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PerformanceMeasureImage_PerformanceMeasureImageID PRIMARY KEY,
	TenantID int not null constraint FK_PerformanceMeasureImage_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),
	PerformanceMeasureID int NOT NULL CONSTRAINT FK_PerformanceMeasureImage_PerformanceMeasure_PerformanceMeasureID FOREIGN KEY REFERENCES dbo.PerformanceMeasure (PerformanceMeasureID),
	FileResourceID int NOT NULL CONSTRAINT FK_PerformanceMeasureImage_FileResource_FileResourceID FOREIGN KEY REFERENCES dbo.FileResource (FileResourceID),
	constraint FK_PerformanceMeasureImage_FileResource_FileResourceID_TenantID FOREIGN KEY (FileResourceID, TenantID) REFERENCES dbo.FileResource (FileResourceID, TenantID),
	constraint FK_PerformanceMeasureImage_PerformanceMeasure_PerformanceMeasureID_TenantID FOREIGN KEY (PerformanceMeasureID, TenantID) REFERENCES dbo.PerformanceMeasure (PerformanceMeasureID, TenantID)
)