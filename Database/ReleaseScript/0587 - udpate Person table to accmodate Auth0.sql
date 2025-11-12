ALTER TABLE Person DROP CONSTRAINT AK_Person_PersonGuid_TenantID;
ALTER TABLE Person ALTER COLUMN PersonGuid uniqueidentifier NULL;
GO

ALTER TABLE Person Add Auth0ID varchar(100) NULL;
GO