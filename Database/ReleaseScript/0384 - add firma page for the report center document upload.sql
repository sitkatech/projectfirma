--begin tran

INSERT INTO dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(79, 'ReportsAddReport', 'Add a Report' , 2)

INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    79,
    '<p>When you upload your report template to the Reports area it will be validated to ensure that the report runs successfully. After successfully uploading a report, you can run it on the projects selected from the reports projects grid.</p>'
from Tenant where TenantID <> 11

INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    79,
    '<p>When you upload your report template to the Reports area it will be validated to ensure that the report runs successfully. After successfully uploading a report, you can run it on the Near Term Actions selected from the reports Near Term Actions grid.</p>'
from Tenant where TenantID = 11


--rollback tran
