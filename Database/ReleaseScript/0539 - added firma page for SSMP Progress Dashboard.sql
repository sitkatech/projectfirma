insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(91, 'ProgressDashboardIntro', 'Progress Dashboard Intro', 1),
(92, 'ProgressDashboardAcresControlledByTheNumbers', 'Acres Controlled By The Numbers', 1),
(93, 'ProgressDashboardAcresControlledPieCharts', 'Acres Controlled Pie Charts', 1)

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(13, 91, 'Progress Dashboard Intro'),
(13, 92, 'Acres Controlled By The Numbers'),
(13, 93, 'Acres Controlled Pie Charts')
