CREATE TABLE dbo.ProjectOrganizationUpdate(
	ProjectOrganizationUpdateID int IDENTITY(1, 1) NOT NULL,
	TenantID int NOT NULL,
	ProjectUpdateBatchID int NOT NULL,
	OrganizationID int NOT NULL,
	RelationshipTypeID int NOT NULL,
 CONSTRAINT PK_ProjectOrganizationUpdate_ProjectOrganizationUpdateID PRIMARY KEY CLUSTERED 
(
	ProjectOrganizationUpdateID ASC
),
 CONSTRAINT AK_ProjectOrganizationUpdate_ProjectOrganizationUpdateID_TenantID UNIQUE NONCLUSTERED 
(
	ProjectOrganizationUpdateID ASC,
	TenantID ASC
)
)
GO

ALTER TABLE dbo.ProjectOrganizationUpdate  WITH CHECK ADD  CONSTRAINT FK_ProjectOrganizationUpdate_Organization_OrganizationID FOREIGN KEY(OrganizationID)
REFERENCES dbo.Organization (OrganizationID)
GO

ALTER TABLE dbo.ProjectOrganizationUpdate CHECK CONSTRAINT FK_ProjectOrganizationUpdate_Organization_OrganizationID
GO

ALTER TABLE dbo.ProjectOrganizationUpdate  WITH CHECK ADD  CONSTRAINT FK_ProjectOrganizationUpdate_Organization_OrganizationID_TenantID FOREIGN KEY(OrganizationID, TenantID)
REFERENCES dbo.Organization (OrganizationID, TenantID)
GO

ALTER TABLE dbo.ProjectOrganizationUpdate CHECK CONSTRAINT FK_ProjectOrganizationUpdate_Organization_OrganizationID_TenantID
GO

ALTER TABLE dbo.ProjectOrganizationUpdate  WITH CHECK ADD  CONSTRAINT FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID FOREIGN KEY(ProjectUpdateBatchID)
REFERENCES dbo.ProjectUpdateBatch (ProjectUpdateBatchID)
GO

ALTER TABLE dbo.ProjectOrganizationUpdate CHECK CONSTRAINT FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID
GO

ALTER TABLE dbo.ProjectOrganizationUpdate  WITH CHECK ADD  CONSTRAINT FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID FOREIGN KEY(ProjectUpdateBatchID, TenantID)
REFERENCES dbo.ProjectUpdateBatch (ProjectUpdateBatchID, TenantID)
GO

ALTER TABLE dbo.ProjectOrganizationUpdate CHECK CONSTRAINT FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID
GO

ALTER TABLE dbo.ProjectOrganizationUpdate  WITH CHECK ADD  CONSTRAINT FK_ProjectOrganizationUpdate_RelationshipType_RelationshipTypeID FOREIGN KEY(RelationshipTypeID)
REFERENCES dbo.RelationshipType (RelationshipTypeID)
GO

ALTER TABLE dbo.ProjectOrganizationUpdate CHECK CONSTRAINT FK_ProjectOrganizationUpdate_RelationshipType_RelationshipTypeID
GO

ALTER TABLE dbo.ProjectOrganizationUpdate  WITH CHECK ADD  CONSTRAINT FK_ProjectOrganizationUpdate_RelationshipType_RelationshipTypeID_TenantID FOREIGN KEY(RelationshipTypeID, TenantID)
REFERENCES dbo.RelationshipType (RelationshipTypeID, TenantID)
GO

ALTER TABLE dbo.ProjectOrganizationUpdate CHECK CONSTRAINT FK_ProjectOrganizationUpdate_RelationshipType_RelationshipTypeID_TenantID
GO

ALTER TABLE dbo.ProjectOrganizationUpdate  WITH CHECK ADD  CONSTRAINT FK_ProjectOrganizationUpdate_Tenant_TenantID FOREIGN KEY(TenantID)
REFERENCES dbo.Tenant (TenantID)
GO

ALTER TABLE dbo.ProjectOrganizationUpdate CHECK CONSTRAINT FK_ProjectOrganizationUpdate_Tenant_TenantID
GO
