insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(95, 'NCRPProjectDashboard', 'NCRP Project Dashboard', 1)

insert into dbo.FirmaPage(FirmaPageTypeID, FirmaPageContent, TenantID)
values
(95, '', 4)
