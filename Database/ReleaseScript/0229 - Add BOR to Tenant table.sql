--begin tran

declare @NewBorTenantID int;
set @NewBorTenantID = 12;

if not exists (select 1 from dbo.Tenant where TenantName = 'BureauOfReclamation')
begin
    insert into dbo.Tenant(TenantID, TenantName, CanonicalHostNameLocal, CanonicalHostNameQa, CanonicalHostNameProd, ReportingYearStartDate, UseFiscalYears, UsesTechnicalAssistanceParameters, ArePerformanceMeasuresExternallySourced)
    --values (@NewBorTenantID, 'BureauOfReclamation', 'bor.locahost.projectfirma.com', 'qa.bor.somethingorother.gov', 'bor.somethingorother.gov', '1990-01-01', 0, 0, 0)
    -- This will work until the inevitable vanity URLs arrive:
    values (@NewBorTenantID, 'BureauOfReclamation', 'bor.locahost.projectfirma.com', 'bor.qa.projectfirma.com', 'bor.projectfirma.com', '1990-01-01', 0, 0, 0)
end
else
begin
    set @NewBorTenantID = (select TenantID from dbo.Tenant where TenantName = 'BureauOfReclamation')
end

insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor,. ShowOnProjectMaps, IsDefaultOrganizationType, IsFundingType)
values
(@NewBorTenantID, 'Federal', 'FED', '#1f77b4', 0, 0, 1)

declare @NewBorFedOrganizationTypeID int
set @NewBorFedOrganizationTypeID = (select ot.OrganizationTypeID from dbo.OrganizationType as ot where ot.TenantID = @NewBorTenantID and ot.OrganizationTypeName = 'Federal')

insert into dbo.Organization
(TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, PrimaryContactPersonID, IsActive, OrganizationUrl, LogoFileResourceID, OrganizationTypeID, OrganizationBoundary)
values
(@NewBorTenantID, (select ko.OrganizationGuid from Keystone.dbo.Organization as ko where ko.FullName = 'U.S. Bureau of Reclamation'), 'U.S. Bureau of Reclamation', 'USBR', null, 1, 'https://www.usbr.gov/', null, @NewBorFedOrganizationTypeID, null)

declare @NewBorOrganizationID int;
set @NewBorOrganizationID = SCOPE_IDENTITY()

if not exists (select 1 from dbo.Person where Email = 'stewart@sitkatech.com' and TenantID = @NewBorTenantID)
begin
    insert into dbo.Person
    (TenantID, PersonGuid, FirstName, LastName, Email, RoleID, CreateDate, UpdateDate, LastActivityDate, IsActive, OrganizationID, ReceiveSupportEmails, WebServiceAccessToken, LoginName)
    values
    (@NewBorTenantID, (select ku.UserGuid from Keystone.dbo.[User] as ku where ku.Email = 'stewart@sitkatech.com'), 'Stewart', 'Loving-Gibbard', 'stewart@sitkatech.com', 8, GETDATE(), null, null, 1, @NewBorOrganizationID, 1, null, 'stewlg')
end

declare @StewLgPersonID int;
set @StewLgPersonID = (select p.PersonID from dbo.Person as p where p.FirstName = 'Stewart' and p.LastName = 'Loving-Gibbard' and TenantID = @NewBorTenantID)

--select @StewLgPersonID
--select * from TenantAttribute

/*

-- Key that's blowing:

ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK 
ADD CONSTRAINT [FK_TenantAttribute_Person_PrimaryContactPersonID_TenantID_PersonID_TenantID] 
   FOREIGN KEY([PrimaryContactPersonID], [TenantID])
   REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO



*/


insert into TenantAttribute(TenantID, DefaultBoundingBox, 
                            MinimumYear, PrimaryContactPersonID, 
                            TenantSquareLogoFileResourceID, TenantBannerLogoFileResourceID, TenantStyleSheetFileResourceID, 
                            TenantShortDisplayName, ToolDisplayName, RecaptchaPublicKey, RecaptchaPrivateKey, 
                            ShowProposalsToThePublic, TaxonomyLevelID, AssociatePerfomanceMeasureTaxonomyLevelID, IsActive, ProjectExternalDataSourceEnabled, 
                            AccomplishmentsDashboardFundingDisplayTypeID, AccomplishmentsDashboardAccomplishmentsButtonText, AccomplishmentsDashboardExpendituresButtonText,
                            AccomplishmentsDashboardOrganizationsButtonText, AccomplishmentsDashboardIncludeReportingOrganizationType, ShowLeadImplementerLogoOnFactSheet, 
                            EnableAccomplishmentsDashboard, ProjectStewardshipAreaTypeID, EnableSecondaryProjectTaxonomyLeaf, KeystoneOpenIDClientIdentifier, KeystoneOpenIDClientSecret)



values
(@NewBorTenantID, 0xE6100000010405000000010000007A0C5FC008E822E7DE374840010000007A0C5FC0AC610816DF73474001000000F6275EC0AC610816DF73474001000000F6275EC008E822E7DE374840010000007A0C5FC008E822E7DE37484001000000020000000001000000FFFFFFFF0000000003,
2016, @StewLgPersonID, 
--11012, 11013, NULL,
null, null, null,
'AlevinBOR',  -- Surely not right, just to get something down for discussion
'AlevinBOR',
(select ta.RecaptchaPublicKey from TenantAttribute as ta where TenantAttributeID = 1),
(select ta.RecaptchaPrivateKey from TenantAttribute as ta where TenantAttributeID = 1),
1,
2,
2,
1,
0,
1,
null,
null,
null,
1,
1,
1,
null,
0, 
'BureauOfReclamation',
(select ClientSecret from Keystone.dbo.Client where ClientIdentifier = 'BureauOfReclamation'))

--select * from FirmaPageType

-- Custom Footer
------------------
declare @CustomFooterFirmaPageTypeID int
set @CustomFooterFirmaPageTypeID = (select FirmaPageTypeID from FirmaPageType where FirmaPageTypeName = 'CustomFooter');

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(@NewBorTenantID, @CustomFooterFirmaPageTypeID, null)

-- Home Page
--------------
declare @HomePageFirmaPageTypeID int
set @HomePageFirmaPageTypeID = (select FirmaPageTypeID from FirmaPageType where FirmaPageTypeName = 'HomePage');

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(@NewBorTenantID, @HomePageFirmaPageTypeID, null)

-- Home Additional Info
-------------------------
declare @AdditionalInfoFirmaPageTypeID int
set @AdditionalInfoFirmaPageTypeID = (select FirmaPageTypeID from FirmaPageType where FirmaPageTypeName = 'HomeAdditionalInfo');

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(@NewBorTenantID, @AdditionalInfoFirmaPageTypeID, null)

-- Home Map Info
-----------------
declare @HomeMapFirmaPageTypeID int
set @HomeMapFirmaPageTypeID = (select FirmaPageTypeID from FirmaPageType where FirmaPageTypeName = 'HomeMapInfo');

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(@NewBorTenantID, @HomeMapFirmaPageTypeID, null)


-- Need an Unknown Organization for this new tenant
--select * from dbo.Organization
--where OrganizationName like '%Unknown%'

insert into OrganizationType 
(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps, IsDefaultOrganizationType, IsFundingType)
values
(@NewBorTenantID, 'Unknown', 'Unknown', '#808080', 1, 1, 1) 

insert into dbo.Organization
(TenantID, OrganizationName, OrganizationShortName, IsActive, OrganizationTypeID)
values
(@NewBorTenantID, '(Unknown or Unspecified Organization)', 'N/A', 0, (select MAX(OrganizationTypeID) from OrganizationType))


--select * from dbo.Tenant
--select * from dbo.TenantAttribute

--select * from dbo.Organization

--select * from dbo.Person where FirstName = 'Stewart' and LastName = 'Loving-Gibbard'

--rollback tran