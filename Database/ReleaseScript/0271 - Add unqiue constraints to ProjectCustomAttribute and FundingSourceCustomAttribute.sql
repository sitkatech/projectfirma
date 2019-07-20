USE [ProjectFirma]

-- can have only one row per TenantID, ProjectID, ProjectCustomAttributeTypeID
ALTER TABLE dbo.ProjectCustomAttribute
ADD CONSTRAINT AK_ProjectCustomAttribute_TenantID_ProjectID_ProjectCustomAttributeTypeID UNIQUE (TenantID, ProjectID, ProjectCustomAttributeTypeID)

-- can have only one row per TenantID, FundingSourceID, FundingSourceCustomAttributeTypeID
ALTER TABLE dbo.FundingSourceCustomAttribute
ADD CONSTRAINT AK_FundingSourceCustomAttribute_TenantID_FundingSourceID_FundingSourceCustomAttributeTypeID UNIQUE (TenantID, FundingSourceID, FundingSourceCustomAttributeTypeID)