INSERT [dbo].[FirmaPageType] ([FirmaPageTypeID], [FirmaPageTypeName], [FirmaPageTypeDisplayName], [FirmaPageRenderTypeID])
VALUES
(81, 'ManageProjectFactSheet', 'Manage Project Fact Sheet', 1)

INSERT [dbo].[FirmaPage] ([TenantID], [FirmaPageTypeID], [FirmaPageContent])SELECT TenantID,
81,
'<p>Manage settings for Project Fact Sheets</p>'
FROM [dbo].[Tenant]

UPDATE [dbo].[FirmaPage] SET FirmaPageContent = '<p>Manage settings for Near Term Action Fact Sheets</p>'
WHERE TenantID = 11 and FirmaPageTypeID = 81

