--begin tran

ALTER TABLE dbo.FirmaSession
	DROP CONSTRAINT FK_FirmaSession_Person_PersonID
GO
ALTER TABLE dbo.FirmaSession
	DROP CONSTRAINT FK_FirmaSession_Person_OriginalPersonID_PersonID
GO
ALTER TABLE dbo.FirmaSession
	DROP CONSTRAINT FK_FirmaSession_Person_PersonID_TenantID
GO
ALTER TABLE dbo.FirmaSession
	DROP CONSTRAINT FK_FirmaSession_Person_OriginalPersonID_TenantID_PersonID_TenantID
GO
ALTER TABLE dbo.Person SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.FirmaSession
	DROP CONSTRAINT FK_FirmaSession_Tenant_TenantID
GO
ALTER TABLE dbo.Tenant SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.FirmaSession ADD
    LastActivityDate datetime NULL
GO
ALTER TABLE dbo.FirmaSession ADD CONSTRAINT
	FK_FirmaSession_Tenant_TenantID FOREIGN KEY
	(
	TenantID
	) REFERENCES dbo.Tenant
	(
	TenantID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FirmaSession ADD CONSTRAINT
	FK_FirmaSession_Person_PersonID FOREIGN KEY
	(
	PersonID
	) REFERENCES dbo.Person
	(
	PersonID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FirmaSession ADD CONSTRAINT
	FK_FirmaSession_Person_OriginalPersonID_PersonID FOREIGN KEY
	(
	OriginalPersonID
	) REFERENCES dbo.Person
	(
	PersonID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FirmaSession ADD CONSTRAINT
	FK_FirmaSession_Person_PersonID_TenantID FOREIGN KEY
	(
	PersonID,
	TenantID
	) REFERENCES dbo.Person
	(
	PersonID,
	TenantID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FirmaSession ADD CONSTRAINT
	FK_FirmaSession_Person_OriginalPersonID_TenantID_PersonID_TenantID FOREIGN KEY
	(
	OriginalPersonID,
	TenantID
	) REFERENCES dbo.Person
	(
	PersonID,
	TenantID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.FirmaSession SET (LOCK_ESCALATION = TABLE)
GO

update dbo.FirmaSession
set LastActivityDate = CreateDate
where LastActivityDate is null and CreateDate is not null
GO

--rollback tran