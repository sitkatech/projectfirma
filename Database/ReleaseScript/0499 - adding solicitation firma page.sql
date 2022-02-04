INSERT [dbo].[FirmaPageType] ([FirmaPageTypeID], [FirmaPageTypeName], [FirmaPageTypeDisplayName], [FirmaPageRenderTypeID])
VALUES
(86, 'SolicitationIndex', 'Solicitation Index', 1)

INSERT [dbo].[FirmaPage] ([TenantID], [FirmaPageTypeID], [FirmaPageContent])SELECT TenantID,
86,
'<p>This page is for defining Solicitation types available for users to select when using the Project create workflow.</p>'
FROM [dbo].[Tenant]

