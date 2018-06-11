insert into dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName ,FirmaPageRenderTypeID)
 values (51, 'CustomFooter', 'Custom Footer', 1)
 

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 51 as FirmaPageTypeID, '' as FirmaPageContent from Tenant