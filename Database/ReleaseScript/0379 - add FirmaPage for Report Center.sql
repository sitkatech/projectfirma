--begin tran

INSERT INTO dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values (77, 'ReportCenter', 'Report Center' , 1)

INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    77,
    '<p>In the Report Center you can review and upload report Word Document (.docx) templates. Report templates uploaded here can be used on their appropriate pages within the report center based on the model that is selected.</p>'
from Tenant

--rollback tran