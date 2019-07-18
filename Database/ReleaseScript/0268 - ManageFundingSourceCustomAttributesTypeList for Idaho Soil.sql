--insert into dbo.FirmaPage(FirmaPageTypeID, TenantID) values(52, 12);
--insert into dbo.FirmaPage(FirmaPageTypeID, TenantID) values(53, 12);
--insert into dbo.FirmaPage(FirmaPageTypeID, TenantID) values(54, 12);
--insert into dbo.FirmaPage(FirmaPageTypeID, TenantID) values(55, 12);

--select * from dbo.FirmaPage

--select * from dbo.FirmaPageType

-- Could Not find Firma Page Type 'ManageFundingSourceCustomAttributeTypeInstructions'(60) in Firma Pages for Tenant IdahoAssociatonOfSoilConservationDistricts(9)
-- Could Not find Firma Page Type 'ManageFundingSourceCustomAttributeTypesList'(61) in Firma Pages for Tenant IdahoAssociatonOfSoilConservationDistricts(9)

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(9, 60, '<p>Custom Attributes can only be created for funding sources. Keep in mind that changing the properties of a custom attribute here may result in all values for that attribute being deleted.</p> ')
GO

insert into FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(9, 61, '<p>Custom Attributes defined and listed here show up on the &quot;Basics&quot; step of funding source workflows and in funding source detail pages. Keep in mind that Custom Attributes are not full-fledged attributes of an funding source, which means can&#39;t be used in reports,&nbsp;and Sitka can&#39;t write conditional logic based on the value for a given custom attribute. Administrators should define Custom Attributes BEFORE end users start adding funding sources. Changing a Custom Attribute&#39;s data type after funding sources have been added could result in data loss.</p> ')