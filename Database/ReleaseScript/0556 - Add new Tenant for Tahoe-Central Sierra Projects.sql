
insert into dbo.Tenant(TenantID, TenantName, CanonicalHostNameLocal, CanonicalHostNameQa, CanonicalHostNameProd, FiscalYearStartDate, UseFiscalYears, ArePerformanceMeasuresExternallySourced, AreOrganizationsExternallySourced, AreFundingSourcesExternallySourced, TenantEnabled)
values 
(14, 'TCSProjectTracker', 'tcsprojecttracker.localhost.projectfirma.com', 'tcsprojecttracker.qa.projectfirma.com', 'tcsprojecttracker.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 1)


	alter table dbo.FileResourceInfo add LogoFileResourceInfoIDFromTenant int null
	alter table dbo.FileResourceInfo add ProjectImageIDFromTenant int null
	GO

	declare @TenantIDFrom int, @TenantIDTo int, @TenantName varchar(100), @ToolDisplayName varchar(100), @createDate datetime, @primaryContactPersonID int
	select @TenantIDFrom = 5, @TenantIDTo = 14, @TenantName = 'TCS Project Tracker', @ToolDisplayName = 'Tahoe-Central Sierra Project Tracker', @createDate = CURRENT_TIMESTAMP

	insert into dbo.TenantAttribute(TenantID, DefaultBoundingBox, 
	MinimumYear, PrimaryContactPersonID, TenantShortDisplayName, ToolDisplayName,
	KeystoneOpenIDClientIdentifier, KeystoneOpenIDClientSecret, GeoServerNamespace, 
	BudgetTypeID, TaxonomyLevelID, AssociatePerfomanceMeasureTaxonomyLevelID, AccomplishmentsDashboardFundingDisplayTypeID, AccomplishmentsDashboardIncludeReportingOrganizationType, 
	ShowProposalsToThePublic,  IsActive, ProjectExternalDataSourceEnabled, ShowLeadImplementerLogoOnFactSheet, EnableAccomplishmentsDashboard, EnableSecondaryProjectTaxonomyLeaf, 

	CanManageCustomAttributes, ExcludeTargetedFundingOrganizations, UseProjectTimeline, EnableEvaluations, EnableProjectCategories, EnableReports, EnableMatchmaker, MatchmakerAlgorithmIncludesProjectGeospatialAreas, AreGeospatialAreasExternallySourced, 
	ShowPhotoCreditOnFactSheet, TrackAccomplishments, ShowExpectedPerformanceMeasuresOnFactSheet, EnableStatusUpdates, EnableSolicitations, EnableSimpleAccomplishmentsDashboard, SetTargetsByGeospatialArea, ReportFinancialsAtProjectLevel)
	values
	(@TenantIDTo, 0xE61000000104050000000100D33FF3535EC0B9B6B271B9E343400100D33FF3535EC05B2B37C4854F43400100F73F67F85DC05B2B37C4854F43400100F73F67F85DC0B9B6B271B9E343400100D33FF3535EC0B9B6B271B9E3434001000000020000000001000000FFFFFFFF0000000003, 
	2010, @primaryContactPersonID, @TenantName, @ToolDisplayName,
	'TCSProjectTracker', 'CE6730FE-D0BD-405D-8026-FB4F25B3124D', 'TCSProjectTracker', 
	2, 1, 1, 1, 1,
	0, 1, 0, 0, 0, 0, 
	1, 0, 0, 0, 0, 0, 0, 0, 0,
	0, 1, 0, 0, 0, 0, 0, 1)

	declare @newTaxonomyTrunkID int

	insert into dbo.TaxonomyTrunk(TenantID, TaxonomyTrunkName)
	values(@TenantIDTo, 'Default')

	select @newTaxonomyTrunkID = SCOPE_IDENTITY()

	insert into dbo.TaxonomyBranch(TenantID, TaxonomyTrunkID, TaxonomyBranchName)
	values(@TenantIDTo, @newTaxonomyTrunkID, 'Default')

	insert into dbo.FirmaPage(FirmaPageTypeID, TenantID)
	select FirmaPageTypeID, @TenantIDTo as TenantID
	from dbo.FirmaPage fp
	where fp.TenantID = @TenantIDFrom

	insert into dbo.FieldDefinitionData(FieldDefinitionID, TenantID)
	select FieldDefinitionID, @TenantIDTo as TenantID
	from dbo.FieldDefinitionData fdd
	where fdd.TenantID = @TenantIDFrom

	insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps, IsDefaultOrganizationType, IsFundingType, LayerOnByDefault)
	values
	(@TenantIDTo, 'Federal', 'FED', '#1f77b4', 0, 0, 1, 0),
	(@TenantIDTo, 'Local', 'LOC', '#aec7e8', 0, 0, 1, 0),
	(@TenantIDTo, 'Private', 'PRI', '#ff7f0e', 0, 1, 1, 0),
	(@TenantIDTo, 'State', 'ST', '#ffbb78', 0, 0, 1, 0)

	declare @privateOrgTypeIDForTenant int
	select @privateOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Private'

	insert into dbo.Organization(TenantID, KeystoneOrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl, IsUnknownOrUnspecified, UseOrganizationBoundaryForMatchmaker)
	select @TenantIDTo as TenantID, KeystoneOrganizationGuid, OrganizationName, OrganizationShortName, @privateOrgTypeIDForTenant, IsActive, OrganizationUrl, IsUnknownOrUnspecified, UseOrganizationBoundaryForMatchmaker
	from dbo.Organization
	where OrganizationID in (1421, 1422) -- ESA Sitka, Unknown Org

	declare @federalOrgTypeIDForTenant int
	select @federalOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Federal'

	-- TODO create an Salton Sea org in keystone?
	--insert into dbo.Organization(TenantID, KeystoneOrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl)
	--values (@TenantIDTo, 'C57B7361-2426-4FE2-9AFF-B1DD743D4058', 'Washington State Department of Natural Resources', 'WA DNR', @federalOrgTypeIDForTenant, 1, 'http://www.dnr.wa.gov')

	declare @sitkaOrgIDForTenant int
	select @sitkaOrgIDForTenant = OrganizationID from dbo.Organization o where o.TenantID = @TenantIDTo and o.OrganizationName = 'ESA Sitka'

	-- copy users from SSMP because the emails are updated (e.g. Liz uses ESA email). Make everyone here an ESA Admin
	insert into dbo.Person(TenantID, PersonGuid, FirstName, LastName, Email, Phone, IsActive, OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, CreateDate, UpdateDate, LastActivityDate)
	select @TenantIDTo as TenantID, p.PersonGuid, p.FirstName, p.LastName, p.Email, p.Phone, p.IsActive, @sitkaOrgIDForTenant as OrganizationID,  ReceiveSupportEmails, LoginName, 8, @createDate, @createDate, @createDate
		from dbo.Person p
	where TenantID = 13
	and email in (
	'jrodrigues@esassoc.com',
	'shannon.bulloch@sitkatech.com',
	'lchristeleit@esassoc.com',
	'matt@sitkatech.com',
	'mauricio.herrera@sitkatech.com')


	select @primaryContactPersonID = p.PersonID from dbo.Person p where p.Email = 'jrodrigues@esassoc.com' and TenantID = @TenantIDTo

	insert into dbo.FileResourceInfo(TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, CreatePersonID, CreateDate, LogoFileResourceInfoIDFromTenant)
	select @TenantIDTo as TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), @primaryContactPersonID as CreatePersonID, fr.CreateDate, fr.FileResourceInfoID as LogoFileResourceInfoIDFromTenant
	from dbo.Organization o
	join dbo.FileResourceInfo fr on o.LogoFileResourceInfoID = fr.FileResourceInfoID
	where o.OrganizationID = 1421 -- ESA Sitka

	-- file resource data for the above file resource info
	insert into dbo.FileResourceData(TenantID, FileResourceInfoID, [Data])
	select @TenantIDTo as TenantID, fr.FileResourceInfoID, frd.[Data]
	from dbo.FileResourceInfo fr
	join dbo.FileResourceData frd on frd.FileResourceInfoID = fr.LogoFileResourceInfoIDFromTenant
	where fr.LogoFileResourceInfoIDFromTenant is not null

	update dbo.Organization set LogoFileResourceInfoID = (select FileResourceInfoID from FileResourceInfo fr where fr.TenantID = @TenantIDTo and fr.LogoFileResourceInfoIDFromTenant is not null) where TenantID = @TenantIDTo and OrganizationName = 'ESA Sitka'
	
	insert into dbo.OrganizationRelationshipType(TenantID, OrganizationRelationshipTypeName, CanStewardProjects, IsPrimaryContact, IsOrganizationRelationshipTypeRequired, ShowOnFactSheet, ReportInAccomplishmentsDashboard)
	values
	(@TenantIDTo, 'Lead Implementer', 0, 1, 1, 1, 0),
	(@TenantIDTo, 'Funder', 0, 0, 0, 1, 0),
	(@TenantIDTo, 'Partner', 0, 0, 0, 1, 0)

	insert into dbo.OrganizationTypeOrganizationRelationshipType(OrganizationTypeID, OrganizationRelationshipTypeID, TenantID)
	select OrganizationTypeID, OrganizationRelationshipTypeID, @TenantIDTo as TenantID
	from dbo.OrganizationType ot
	cross join dbo.OrganizationRelationshipType rt
	where ot.TenantID = @TenantIDTo and rt.TenantID = @TenantIDTo

	update dbo.TenantAttribute
	set PrimaryContactPersonID = @primaryContactPersonID
	where TenantID = @TenantIDTo


	insert into dbo.OrganizationRelationshipType(TenantID, OrganizationRelationshipTypeName, CanStewardProjects, IsPrimaryContact, IsOrganizationRelationshipTypeRequired, OrganizationRelationshipTypeDescription)
	select @TenantIDTo as TenantID, rt.OrganizationRelationshipTypeName, rt.CanStewardProjects, rt.IsPrimaryContact, rt.IsOrganizationRelationshipTypeRequired, rt.OrganizationRelationshipTypeDescription
	from dbo.OrganizationRelationshipType rt
	left join dbo.OrganizationRelationshipType rt2 on rt.OrganizationRelationshipTypeName = rt2.OrganizationRelationshipTypeName
	where rt.TenantID = @TenantIDFrom and rt2.OrganizationRelationshipTypeID is null

		insert into dbo.ProjectUpdateSetting (TenantID, ProjectUpdateKickOffDate, ProjectUpdateCloseOutDate, ProjectUpdateReminderInterval, EnableProjectUpdateReminders, SendPeriodicReminders, SendCloseOutNotification, ProjectUpdateKickOffIntroContent, ProjectUpdateReminderIntroContent, ProjectUpdateCloseOutIntroContent, DaysBeforeCloseOutDateForReminder)
    select @TenantIDTo, ProjectUpdateKickOffDate, ProjectUpdateCloseOutDate, ProjectUpdateReminderInterval, EnableProjectUpdateReminders, SendPeriodicReminders, SendCloseOutNotification, ProjectUpdateKickOffIntroContent, ProjectUpdateReminderIntroContent, ProjectUpdateCloseOutIntroContent, DaysBeforeCloseOutDateForReminder from dbo.ProjectUpdateSetting where TenantID = @TenantIDFrom


	insert into dbo.ProjectCustomGridConfiguration(TenantID, ProjectCustomGridTypeID, ProjectCustomGridColumnID, ProjectCustomAttributeTypeID, GeospatialAreaTypeID, IsEnabled, SortOrder, ClassificationSystemID)
	select @TenantIDTo as TenantID, pcgc.ProjectCustomGridTypeID, pcgc.ProjectCustomGridColumnID, pcgc.ProjectCustomAttributeTypeID, pcgc.GeospatialAreaTypeID, pcgc.IsEnabled, pcgc.SortOrder, pcgc.ClassificationSystemID
	from dbo.ProjectCustomGridConfiguration pcgc
	where pcgc.TenantID = @TenantIDFrom and ProjectCustomAttributeTypeID is null and GeospatialAreaTypeID is null and ClassificationSystemID is null


	alter table dbo.FileResourceInfo DROP COLUMN LogoFileResourceInfoIDFromTenant
	alter table dbo.FileResourceInfo DROP COLUMN ProjectImageIDFromTenant