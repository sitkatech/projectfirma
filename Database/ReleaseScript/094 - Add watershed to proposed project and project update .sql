alter table dbo.ProposedProject add ProjectWatershedNotes varchar(4000) null
alter table dbo.ProjectUpdate add ProjectWatershedNotes varchar(4000) null
alter table dbo.Project add ProjectWatershedNotes varchar(4000) null

alter table dbo.ProjectUpdateBatch add WatershedComment varchar(1000) null

CREATE TABLE dbo.ProposedProjectWatershed(
	ProposedProjectWatershedID int NOT NULL IDENTITY(1,1) CONSTRAINT PK_ProposedProjectWatershed_ProposedProjectWatershedID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_ProposedProjectWatershed_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant(TenantID),
	ProposedProjectID int NOT NULL CONSTRAINT FK_ProposedProjectWatershed_ProposedProject_ProposedProjectID FOREIGN KEY REFERENCES dbo.ProposedProject(ProposedProjectID),
	WatershedID int NOT NULL CONSTRAINT FK_ProposedProjectWatershed_Watershed_WatershedID FOREIGN KEY REFERENCES dbo.Watershed (WatershedID),
	CONSTRAINT AK_ProposedProjectWatershed_ProposedProjectID_WatershedID UNIQUE NONCLUSTERED (ProposedProjectID, WatershedID),
	CONSTRAINT FK_ProposedProjectWatershed_ProposedProject_ProposedProjectID_TenantID FOREIGN KEY(ProposedProjectID, TenantID) REFERENCES dbo.ProposedProject(ProposedProjectID, TenantID),
	CONSTRAINT FK_ProposedProjectWatershed_Watershed_WatershedID_TenantID FOREIGN KEY(WatershedID, TenantID) REFERENCES dbo.Watershed (WatershedID, TenantID)
)


CREATE TABLE dbo.ProjectWatershedUpdate(
	ProjectWatershedUpdateID int NOT NULL IDENTITY(1,1) CONSTRAINT PK_ProjectWatershedUpdate_ProjectWatershedUpdateID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_ProjectWatershedUpdate_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant(TenantID),
	ProjectUpdateBatchID int NOT NULL CONSTRAINT FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID FOREIGN KEY REFERENCES dbo.ProjectUpdateBatch(ProjectUpdateBatchID),
	WatershedID int NOT NULL CONSTRAINT FK_ProjectWatershedUpdate_Watershed_WatershedID FOREIGN KEY REFERENCES dbo.Watershed (WatershedID),
	CONSTRAINT AK_ProjectWatershedUpdate_ProjectUpdateBatchID_WatershedID UNIQUE NONCLUSTERED (ProjectUpdateBatchID, WatershedID),
	CONSTRAINT FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID FOREIGN KEY(ProjectUpdateBatchID, TenantID) REFERENCES dbo.ProjectUpdateBatch (ProjectUpdateBatchID, TenantID),
	CONSTRAINT FK_ProjectWatershedUpdate_Watershed_WatershedID_TenantID FOREIGN KEY(WatershedID, TenantID) REFERENCES dbo.Watershed (WatershedID, TenantID)
)
