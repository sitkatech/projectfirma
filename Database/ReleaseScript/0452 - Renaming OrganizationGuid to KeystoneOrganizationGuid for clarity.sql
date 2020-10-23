
DROP INDEX [AK_Organization_OrganizationGuid_TenantID] ON [dbo].[Organization]
GO

EXEC sp_rename 'dbo.Organization.OrganizationGuid', 'KeystoneOrganizationGuid', 'COLUMN';
GO

CREATE UNIQUE NONCLUSTERED INDEX [AK_Organization_KeystoneOrganizationGuid_TenantID] ON [dbo].[Organization]
(
	KeystoneOrganizationGuid ASC,
	TenantID ASC
)
WHERE (KeystoneOrganizationGuid IS NOT NULL)
ON [PRIMARY]
GO




