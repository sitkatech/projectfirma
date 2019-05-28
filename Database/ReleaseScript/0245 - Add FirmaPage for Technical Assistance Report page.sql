
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(58, 'TechnicalAssistanceReport', 'Technical Assistance Report', 1)
go

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(9, 58, '<p>Technical Assistance Report introductory text.</p>')