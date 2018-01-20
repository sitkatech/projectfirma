INSERT INTO dbo.FirmaPageType
VALUES (48, 'PendingProjects', 'Pending Projects', 1)

INSERT INTO dbo.FirmaPage
(TenantID, FirmaPageTypeID, FirmaPageContent)
SELECT 
	TenantID AS TenantID,
	48 AS FirmaPageTypeID,
	'This page shows a list of projects pending inclusion in the RCD Project Tracker. Projects on this list must be reviewed and approved by a system administrator before they become visible to public visitors to the RCD Project Tracker.' as FirmaPageContent
FROM dbo.Tenant 