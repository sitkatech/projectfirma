--begin tran

INSERT INTO dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(79, 'ReportCenterAddReport', 'Add a Report' , 2)

INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    79,
    '<p>When you upload your report template to the Report Center it will be validated to ensure that the report runs successfully. After successfully uploading a report, you can run it on the projects selected from the report center projects grid.</p>'
from Tenant where TenantID <> 11

INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    79,
    '<p>When you upload your report template to the Report Center it will be validated to ensure that the report runs successfully. After successfully uploading a report, you can run it on the Near Term Actions selected from the report center Near Term Actions grid.</p>'
from Tenant where TenantID = 11


--rollback tran
