--begin tran

INSERT INTO dbo.FirmaPageType (FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values (78, 'ReportProjects', 'Report Projects' , 1)

INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    78,
    '<p>Filter, sort, and select projects from the grid below using the checkboxes. The selected projects will be provided to the chosen report template in the order that they appear in the grid.</p>'
from Tenant where TenantID != 11

INSERT INTO dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    78,
    '<p>Filter, sort, and select Near Term Actions from the grid below using the checkboxes. The selected Near Term Actions will be provided to the chosen report template in the order that they appear in the grid.</p>'
from Tenant where TenantID = 11

--rollback tran