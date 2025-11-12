-- Add the 'Domain' column to the 'dbo.Organization' table
ALTER TABLE dbo.Organization
ADD Domain NVARCHAR(255) NULL;
GO

-- Add a unique constraint to ensure (TenantId, Domain) is unique
-- Allow multiple NULLs in Domain, but ensures that non-NULL Domain values are unique per TenantId
CREATE UNIQUE INDEX IX_Organization_TenantId_Domain
ON dbo.Organization (TenantId, Domain)
WHERE Domain IS NOT NULL;
GO
