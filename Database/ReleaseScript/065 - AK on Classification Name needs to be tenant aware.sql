ALTER TABLE dbo.Classification DROP CONSTRAINT AK_Classification_ClassificationName
ALTER TABLE dbo.Classification DROP CONSTRAINT AK_Classification_DisplayName
GO

ALTER TABLE dbo.Classification ADD  CONSTRAINT AK_Classification_ClassificationName_TenantID UNIQUE (ClassificationName, TenantID)
ALTER TABLE dbo.Classification ADD  CONSTRAINT AK_Classification_DisplayName_TenantID UNIQUE (DisplayName, TenantID)

