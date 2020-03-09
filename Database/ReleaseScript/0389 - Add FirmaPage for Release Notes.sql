--begin tran

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(80, 'ReleaseNotes', 'Release Notes' , 1)

go

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select 
    TenantID,
    80,
    '<p>Interested staying informed about this platform and the growing community using it? Sign up to receive periodic <a href="http://go.sitkatech.com/ProjectFirmaCommunity" title="Open a new tab to sign up for ProjectFirma Community Updates" target="_blank">ProjectFirma Community Updates <span class="glyphicon glyphicon-new-window" aria-hidden="true"></span></a></p>'
 from dbo.Tenant

--rollback tran