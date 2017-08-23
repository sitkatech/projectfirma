alter table dbo.ProposedProject add ProjectWatershedNotes varchar(4000) null
alter table dbo.ProjectUpdate add ProjectWatershedNotes varchar(4000) null
alter table dbo.Project add ProjectWatershedNotes varchar(4000) null

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
	ProjectUpdateID int NOT NULL CONSTRAINT FK_ProjectWatershedUpdate_ProjectUpdate_ProjectUpdateID FOREIGN KEY REFERENCES dbo.ProjectUpdate(ProjectUpdateID),
	WatershedID int NOT NULL CONSTRAINT FK_ProjectWatershedUpdate_Watershed_WatershedID FOREIGN KEY REFERENCES dbo.Watershed (WatershedID),
	CONSTRAINT AK_ProjectWatershedUpdate_ProjectUpdateID_WatershedID UNIQUE NONCLUSTERED (ProjectUpdateID, WatershedID),
	--CONSTRAINT FK_ProjectWatershedUpdate_ProjectUpdate_ProjectUpdateID_TenantID FOREIGN KEY(ProjectUpdateID, TenantID) REFERENCES dbo.ProjectUpdate (ProjectUpdateID, TenantID),
	CONSTRAINT FK_ProjectWatershedUpdate_Watershed_WatershedID_TenantID FOREIGN KEY(WatershedID, TenantID) REFERENCES dbo.Watershed (WatershedID, TenantID)
)
