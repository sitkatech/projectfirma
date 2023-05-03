insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(91, 'ProgressDashboardIntro', 'Progress Dashboard Intro', 1)

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(13, 91, 'Progress Dashboard Intro')