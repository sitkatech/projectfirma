insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(62, 'FundingStatusHeader', 'Funding Status Header', 2)
go 

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(11, 62, '')

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(63, 'FundingStatusFooter', 'Funding Status Footer', 2)
go 

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(11, 63, '')