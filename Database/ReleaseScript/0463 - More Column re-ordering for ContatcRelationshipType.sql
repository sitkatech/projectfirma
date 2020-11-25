
ALTER TABLE dbo.ContactRelationshipType
	DROP CONSTRAINT FK_ContactRelationshipType_ProjectStage_IsContactRelationshipRequiredMinimumProjectStageID_ProjectStageID
GO
ALTER TABLE dbo.ProjectStage SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.ContactRelationshipType
	DROP CONSTRAINT FK_ContactRelationshipType_Tenant_TenantID
GO
ALTER TABLE dbo.Tenant SET (LOCK_ESCALATION = TABLE)
GO
CREATE TABLE dbo.Tmp_ContactRelationshipType
	(
	ContactRelationshipTypeID int NOT NULL IDENTITY (1, 1),
	TenantID int NOT NULL,
	ContactRelationshipTypeName varchar(200) NOT NULL,
	IsContactRelationshipTypeRequired bit NOT NULL,
	IsContactRelationshipRequiredMinimumProjectStageID int NULL,
	ContactRelationshipTypeAcceptsMultipleValues bit NOT NULL,
	ContactRelationshipTypeDescription varchar(360) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_ContactRelationshipType SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_ContactRelationshipType ON
GO
IF EXISTS(SELECT * FROM dbo.ContactRelationshipType)
	 EXEC('INSERT INTO dbo.Tmp_ContactRelationshipType (ContactRelationshipTypeID, TenantID, ContactRelationshipTypeName, IsContactRelationshipTypeRequired, IsContactRelationshipRequiredMinimumProjectStageID, ContactRelationshipTypeAcceptsMultipleValues, ContactRelationshipTypeDescription)
		SELECT ContactRelationshipTypeID, TenantID, ContactRelationshipTypeName, IsContactRelationshipTypeRequired, IsContactRelationshipRequiredMinimumProjectStageID, ContactRelationshipTypeAcceptsMultipleValues, ContactRelationshipTypeDescription FROM dbo.ContactRelationshipType WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_ContactRelationshipType OFF
GO
ALTER TABLE dbo.ProjectContactUpdate
	DROP CONSTRAINT FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID
GO
ALTER TABLE dbo.ProjectContactUpdate
	DROP CONSTRAINT FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID_TenantID
GO
ALTER TABLE dbo.ProjectContact
	DROP CONSTRAINT FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID
GO
ALTER TABLE dbo.ProjectContact
	DROP CONSTRAINT FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID_TenantID
GO
DROP TABLE dbo.ContactRelationshipType
GO
EXECUTE sp_rename N'dbo.Tmp_ContactRelationshipType', N'ContactRelationshipType', 'OBJECT' 
GO
ALTER TABLE dbo.ContactRelationshipType ADD CONSTRAINT
	PK_ContactRelationshipType_ContactRelationshipTypeID PRIMARY KEY CLUSTERED 
	(
	ContactRelationshipTypeID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContactRelationshipType ADD CONSTRAINT
	AK_ContactRelationshipType_ContactRelationshipTypeName_TenantID UNIQUE NONCLUSTERED 
	(
	ContactRelationshipTypeName,
	TenantID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContactRelationshipType ADD CONSTRAINT
	AK_ContactRelationshipType_ContactRelationshipTypeID_TenantID UNIQUE NONCLUSTERED 
	(
	ContactRelationshipTypeID,
	TenantID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ContactRelationshipType ADD CONSTRAINT
	FK_ContactRelationshipType_Tenant_TenantID FOREIGN KEY
	(
	TenantID
	) REFERENCES dbo.Tenant
	(
	TenantID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContactRelationshipType ADD CONSTRAINT
	FK_ContactRelationshipType_ProjectStage_IsContactRelationshipRequiredMinimumProjectStageID_ProjectStageID FOREIGN KEY
	(
	IsContactRelationshipRequiredMinimumProjectStageID
	) REFERENCES dbo.ProjectStage
	(
	ProjectStageID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectContact ADD CONSTRAINT
	FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID FOREIGN KEY
	(
	ContactRelationshipTypeID
	) REFERENCES dbo.ContactRelationshipType
	(
	ContactRelationshipTypeID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectContact ADD CONSTRAINT
	FK_ProjectContact_ContactRelationshipType_ContactRelationshipTypeID_TenantID FOREIGN KEY
	(
	ContactRelationshipTypeID,
	TenantID
	) REFERENCES dbo.ContactRelationshipType
	(
	ContactRelationshipTypeID,
	TenantID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectContact SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.ProjectContactUpdate ADD CONSTRAINT
	FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID FOREIGN KEY
	(
	ContactRelationshipTypeID
	) REFERENCES dbo.ContactRelationshipType
	(
	ContactRelationshipTypeID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectContactUpdate ADD CONSTRAINT
	FK_ProjectContactUpdate_ContactRelationshipType_ContactRelationshipTypeID_TenantID FOREIGN KEY
	(
	ContactRelationshipTypeID,
	TenantID
	) REFERENCES dbo.ContactRelationshipType
	(
	ContactRelationshipTypeID,
	TenantID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProjectContactUpdate SET (LOCK_ESCALATION = TABLE)
