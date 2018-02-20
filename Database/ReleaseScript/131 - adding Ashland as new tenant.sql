update dbo.TenantAttribute
set TenantDisplayName = 'Demo Project Firma', ToolDisplayName = 'Demo Project Tracker'
where TenantID = 5

insert into dbo.Tenant(TenantID, TenantName, TenantDomain, TenantSubdomain)
values 
(8, 'AshlandForestAllLandsRestorationInitiative', 'projectfirma.com', 'ashlanddemo')


	alter table dbo.PerformanceMeasureSubcategory add PerformanceMeasureSubcategoryIDFromTenant int null
	alter table dbo.PerformanceMeasureActual add PerformanceMeasureActualIDFromTenant int null
	alter table dbo.FileResource add OrganizationIDFromTenant int null
	alter table dbo.FileResource add ProjectImageIDFromTenant int null
	alter table dbo.FileResource add ClassificationIDFromTenant int null
	alter table dbo.FileResource add FirmaPageIDFromTenant int null
	alter table dbo.FirmaPage add FirmaPageIDFromTenant int null
	GO

	declare @TenantIDFrom int, @TenantIDTo int, @TenantName varchar(100), @ToolDisplayName varchar(100), @createDate datetime
	select @TenantIDFrom = 5, @TenantIDTo = 8, @TenantName = 'Ashland Forest All-lands Restoration Initiative (AFARI)', @ToolDisplayName = 'Ashland Forest Project Tracker', @createDate = '2/17/18 10:00 PM'

	insert into dbo.TenantAttribute(TenantID, NumberOfTaxonomyTiersToUse, DefaultBoundingBox, MinimumYear, TenantDisplayName, ToolDisplayName, ShowProposalsToThePublic, RecaptchaPublicKey, RecaptchaPrivateKey, MapServiceUrl, WatershedLayerName)
	values
	(@TenantIDTo, 2, 0xE61000000104050000000100000040285FC06911DAA3DB1C47400100000040285FC08D97B8A52102454001000000B0415DC08D97B8A52102454001000000B0415DC06911DAA3DB1C47400100000040285FC06911DAA3DB1C474001000000020000000001000000FFFFFFFF0000000003, 2017, @TenantName, @ToolDisplayName, 1, '6LfZQQoUAAAAAIJ_2lD6ct0lBHQB9j5kv8p994SP', '6LfZQQoUAAAAAOeNQDcXlTV9JM7PBQE3jCqlDBSB', 'https://mapserver.projectfirma.com/geoserver/AshlandDemoProjectFirma/wms', 'AshlandDemoProjectFirma:Watershed')


	insert into dbo.FirmaPage(FirmaPageTypeID, TenantID, FirmaPageContent, FirmaPageIDFromTenant)
	select FirmaPageTypeID, @TenantIDTo as TenantID, fp.FirmaPageContent, fp.FirmaPageID as FirmaPageIDFromTenant
	from dbo.FirmaPage fp
	where fp.TenantID = @TenantIDFrom


	insert into dbo.FieldDefinitionData(FieldDefinitionID, TenantID, FieldDefinitionLabel, FieldDefinitionDataValue)
	select FieldDefinitionID, @TenantIDTo as TenantID, FieldDefinitionLabel, FieldDefinitionDataValue
	from dbo.FieldDefinitionData fdd
	where fdd.TenantID = @TenantIDFrom

	insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps, IsDefaultOrganizationType, IsFundingType)
	select @TenantIDTo as TenantID, ot.OrganizationTypeName, ot.OrganizationTypeAbbreviation, ot.LegendColor, ot.ShowOnProjectMaps, ot.IsDefaultOrganizationType, ot.IsFundingType
	from dbo.OrganizationType ot
	where ot.TenantID = @TenantIDFrom

	declare @privateOrgTypeIDForTenant int
	select @privateOrgTypeIDForTenant = OrganizationTypeID from dbo.OrganizationType o where o.TenantID = @TenantIDTo and o.OrganizationTypeName = 'Private'

	insert into dbo.Organization(TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl)
	select @TenantIDTo as TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, @privateOrgTypeIDForTenant, IsActive, OrganizationUrl
	from dbo.Organization
	where OrganizationID in (6, 7) -- Sitka, Unknown Org

	declare @sitkaOrgIDForTenant int
	select @sitkaOrgIDForTenant = OrganizationID from dbo.Organization o where o.TenantID = @TenantIDTo and o.OrganizationName = 'Sitka Technology Group'

	insert into dbo.Person(TenantID, PersonGuid, FirstName, LastName, Email, Phone, IsActive, OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, CreateDate, UpdateDate, LastActivityDate)
	select @TenantIDTo as TenantID, p.PersonGuid, p.FirstName, p.LastName, p.Email, p.Phone, p.IsActive, @sitkaOrgIDForTenant as OrganizationID,  ReceiveSupportEmails, LoginName, RoleID, @createDate, @createDate, @createDate
	from dbo.Person p
	where TenantID = @TenantIDFrom and Email like '%sitkatech.com%'

	declare @primaryContactPersonID int
	select @primaryContactPersonID = p.PersonID from dbo.Person p where p.Email = 'matt@sitkatech.com'

	insert into dbo.FileResource(TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate, OrganizationIDFromTenant)
	select @TenantIDTo as TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, @primaryContactPersonID as CreatePersonID, fr.CreateDate, o.OrganizationID as OrganizationIDFromTenant
	from dbo.Organization o
	join dbo.FileResource fr on o.LogoFileResourceID = fr.FileResourceID
	where o.TenantID = @TenantIDFrom
	

	insert into dbo.Organization(TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, IsActive, OrganizationUrl, LogoFileResourceID, OrganizationTypeID, OrganizationBoundary)
	select @TenantIDTo as TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, IsActive, OrganizationUrl, fr.FileResourceID as LogoFileResourceID, otnew.OrganizationTypeID, OrganizationBoundary
	from dbo.Organization o
	join dbo.OrganizationType ot on o.OrganizationTypeID = ot.OrganizationTypeID
	join dbo.OrganizationType otnew on ot.OrganizationTypeName = otnew.OrganizationTypeName and otnew.TenantID = @TenantIDTo
	left join dbo.FileResource fr on o.OrganizationID = fr.OrganizationIDFromTenant and fr.TenantID = @TenantIDTo
	where o.TenantID = @TenantIDFrom and o.OrganizationName not in ('Sitka Technology Group', '(Unknown or Unspecified Organization)')

	insert into dbo.FileResource(TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate, FirmaPageIDFromTenant)
	select @TenantIDTo as TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, @primaryContactPersonID as CreatePersonID, fr.CreateDate, fpi.FirmaPageID as FirmaPageIDFromTenant
	from dbo.FirmaPageImage fpi
	join dbo.FileResource fr on fpi.FileResourceID = fr.FileResourceID
	where fpi.TenantID = @TenantIDFrom

	insert into dbo.FirmaPageImage(TenantID, FirmaPageID, FileResourceID)
	select @TenantIDTo as TenantID, fp.FirmaPageID, fr.FileResourceID
	from dbo.FirmaPageImage fpi
	join dbo.FirmaPage fp on fpi.FirmaPageID = fp.FirmaPageIDFromTenant
	join dbo.FileResource fr on fpi.FirmaPageID = fr.FirmaPageIDFromTenant and fr.TenantID = @TenantIDTo
	where fpi.TenantID = @TenantIDFrom



	insert into dbo.RelationshipType(TenantID, RelationshipTypeName, CanStewardProjects, IsPrimaryContact, CanOnlyBeRelatedOnceToAProject)
	values
	(@TenantIDTo, 'Lead Implementer', 0, 1, 1),
	(@TenantIDTo, 'Funder', 0, 0, 0),
	(@TenantIDTo, 'Stakeholder', 0, 0, 0)

	insert into dbo.OrganizationTypeRelationshipType(OrganizationTypeID, RelationshipTypeID, TenantID)
	select OrganizationTypeID, RelationshipTypeID, @TenantIDTo as TenantID
	from dbo.OrganizationType ot
	cross join dbo.RelationshipType rt
	where ot.TenantID = @TenantIDTo and rt.TenantID = @TenantIDTo


	update dbo.TenantAttribute
	set PrimaryContactPersonID = @primaryContactPersonID
	where TenantID = @TenantIDTo



	insert into dbo.FundingTypeData(TenantID, FundingTypeID, FundingTypeDisplayName, FundingTypeShortName, SortOrder)
	SELECT @TenantIDTo as TenantID
		  ,FundingTypeID
		  ,FundingTypeDisplayName
		  ,FundingTypeShortName
		  ,SortOrder
	FROM dbo.FundingTypeData
	where TenantID = @TenantIDFrom

	insert into dbo.RelationshipType(TenantID, RelationshipTypeName, CanStewardProjects, IsPrimaryContact, CanOnlyBeRelatedOnceToAProject, RelationshipTypeDescription)
	select @TenantIDTo as TenantID, rt.RelationshipTypeName, rt.CanStewardProjects, rt.IsPrimaryContact, rt.CanOnlyBeRelatedOnceToAProject, rt.RelationshipTypeDescription
	from dbo.RelationshipType rt
	left join dbo.RelationshipType rt2 on rt.RelationshipTypeName = rt2.RelationshipTypeName
	where rt.TenantID = @TenantIDFrom and rt2.RelationshipTypeID is null

	insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps, IsDefaultOrganizationType, IsFundingType)
	select distinct @TenantIDTo as TenantID, ot.OrganizationTypeName, ot.OrganizationTypeAbbreviation, ot.LegendColor, ot.ShowOnProjectMaps, ot.IsDefaultOrganizationType, 1 as IsFundingType
	from dbo.Organization o
	join dbo.OrganizationType ot on o.OrganizationTypeID = ot.OrganizationTypeID
	left join dbo.OrganizationType ot2 on ot.OrganizationTypeName = ot2.OrganizationTypeName and ot2.TenantID = @TenantIDTo
	where o.TenantID = @TenantIDFrom and ot2.OrganizationTypeID is null

	insert into dbo.OrganizationTypeRelationshipType(OrganizationTypeID, RelationshipTypeID, TenantID)
	select a.OrganizationTypeID, a.RelationshipTypeID, @TenantIDTo as TenantID
	from
	(
		select ot2.OrganizationTypeID, rt2.RelationshipTypeID
		from dbo.OrganizationType ot
		join dbo.OrganizationTypeRelationshipType otrt on ot.OrganizationTypeID = otrt.OrganizationTypeID
		join dbo.OrganizationType ot2 on ot.OrganizationTypeName = ot2.OrganizationTypeName and ot2.TenantID = @TenantIDTo
		join dbo.RelationshipType rt on otrt.RelationshipTypeID = rt.RelationshipTypeID
		join dbo.RelationshipType rt2 on rt.RelationshipTypeName = rt2.RelationshipTypeName and rt2.TenantID = @TenantIDTo
		where ot.TenantID = @TenantIDFrom
	) a left join dbo.OrganizationTypeRelationshipType otrt on a.OrganizationTypeID = otrt.OrganizationTypeID and a.RelationshipTypeID = otrt.RelationshipTypeID and otrt.TenantID = @TenantIDTo
	where otrt.OrganizationTypeRelationshipTypeID is null

	insert into dbo.Organization(TenantID, OrganizationGuid, OrganizationName, OrganizationShortName, OrganizationTypeID, IsActive, OrganizationUrl)
	select @TenantIDTo as TenantID, o.OrganizationGuid, o.OrganizationName, o.OrganizationShortName, ot2.OrganizationTypeID, o.IsActive, o.OrganizationUrl
	from dbo.Organization o
	join dbo.OrganizationType ot on o.OrganizationTypeID = ot.OrganizationTypeID
	left join dbo.OrganizationType ot2 on ot.OrganizationTypeName = ot2.OrganizationTypeName and ot2.TenantID = @TenantIDTo
	left join dbo.Organization o2 on o.OrganizationName = o2.OrganizationName and o2.TenantID = @TenantIDTo
	where o.TenantID = @TenantIDFrom and o2.OrganizationID is null

	insert into dbo.PerformanceMeasure(TenantID, CriticalDefinitions, ProjectReporting, PerformanceMeasureDisplayName, MeasurementUnitTypeID, PerformanceMeasureTypeID, PerformanceMeasureDefinition, DataSourceText, ExternalDataSourceUrl, ChartTitle, ChartCaption, SwapChartAxes, CanCalculateTotal)
	select @TenantIDTo as TenantID, CriticalDefinitions, ProjectReporting, PerformanceMeasureDisplayName, MeasurementUnitTypeID, PerformanceMeasureTypeID, PerformanceMeasureDefinition, DataSourceText, ExternalDataSourceUrl, ChartTitle, ChartCaption, SwapChartAxes, CanCalculateTotal
	from dbo.PerformanceMeasure pm
	where pm.TenantID = @TenantIDFrom

	insert into dbo.PerformanceMeasureSubcategory(TenantID, PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName, ChartConfigurationJson, GoogleChartTypeID, PerformanceMeasureSubcategoryIDFromTenant)
	select @TenantIDTo as TenantID, pm2.PerformanceMeasureID, PerformanceMeasureSubcategoryDisplayName, ChartConfigurationJson, GoogleChartTypeID, pms.PerformanceMeasureSubcategoryID as PerformanceMeasureSubcategoryIDFromTenant
	from dbo.PerformanceMeasureSubcategory pms
	join dbo.PerformanceMeasure pm on pms.PerformanceMeasureID = pm.PerformanceMeasureID
	join dbo.PerformanceMeasure pm2 on pm.PerformanceMeasureDisplayName = pm2.PerformanceMeasureDisplayName and pm2.TenantID = @TenantIDTo
	where pms.TenantID = @TenantIDFrom

	insert into dbo.PerformanceMeasureSubcategoryOption(TenantID, PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, SortOrder, ShortName)
	select @TenantIDTo as TenantID, pm.PerformanceMeasureSubcategoryID, PerformanceMeasureSubcategoryOptionName, SortOrder, ShortName
	from dbo.PerformanceMeasureSubcategoryOption pms
	join dbo.PerformanceMeasureSubcategory pm on pms.PerformanceMeasureSubcategoryID = pm.PerformanceMeasureSubcategoryIDFromTenant
	where pms.TenantID = @TenantIDFrom



	insert into dbo.TaxonomyTierThree(TenantID, TaxonomyTierThreeName, TaxonomyTierThreeDescription, ThemeColor, TaxonomyTierThreeCode)
	select @TenantIDTo as TenantID, TaxonomyTierThreeName, TaxonomyTierThreeDescription, ThemeColor, TaxonomyTierThreeCode
	from dbo.TaxonomyTierThree 
	where TenantID = @TenantIDFrom

	insert into dbo.TaxonomyTierTwo(TenantID, TaxonomyTierThreeID, TaxonomyTierTwoName, TaxonomyTierTwoDescription, ThemeColor, TaxonomyTierTwoCode)
	select @TenantIDTo as TenantID, tthree2.TaxonomyTierThreeID, ttwo.TaxonomyTierTwoName, ttwo.TaxonomyTierTwoDescription, ttwo.ThemeColor, ttwo.TaxonomyTierTwoCode
	from dbo.TaxonomyTierTwo ttwo
	join dbo.TaxonomyTierThree tthree on ttwo.TaxonomyTierThreeID = tthree.TaxonomyTierThreeID
	join dbo.TaxonomyTierThree tthree2 on tthree.TaxonomyTierThreeName = tthree2.TaxonomyTierThreeName and tthree2.TenantID = @TenantIDTo
	where ttwo.TenantID = @TenantIDFrom

	insert into dbo.TaxonomyTierOne(TenantID, TaxonomyTierTwoID, TaxonomyTierOneName, TaxonomyTierOneDescription, TaxonomyTierOneCode)
	select @TenantIDTo as TenantID, tTwo2.TaxonomyTierTwoID, tOne.TaxonomyTierOneName, tOne.TaxonomyTierOneDescription, tOne.TaxonomyTierOneCode
	from dbo.TaxonomyTierOne tOne
	join dbo.TaxonomyTierTwo tTwo on tOne.TaxonomyTierTwoID = tTwo.TaxonomyTierTwoID
	join dbo.TaxonomyTierTwo tTwo2 on tTwo.TaxonomyTierTwoName = tTwo2.TaxonomyTierTwoName and tTwo2.TenantID = @TenantIDTo
	where tOne.TenantID = @TenantIDFrom

	insert into dbo.FundingSource(TenantID, OrganizationID, FundingSourceName, IsActive, FundingSourceDescription)
	select @TenantIDTo as TenantID, o2.OrganizationID, fs.FundingSourceName, fs.IsActive, fs.FundingSourceDescription
	from dbo.FundingSource fs
	join dbo.Organization o on fs.OrganizationID = o.OrganizationID 
	join dbo.Organization o2 on o.OrganizationName = o2.OrganizationName and o2.TenantID = @TenantIDTo
	where fs.TenantID = @TenantIDFrom

	insert into dbo.FileResource(TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate, ClassificationIDFromTenant)
	select @TenantIDTo as TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, @primaryContactPersonID as CreatePersonID, fr.CreateDate, pim.ClassificationID as ClassificationIDFromTenant
	from dbo.Classification pim
	join dbo.FileResource fr on pim.KeyImageFileResourceID = fr.FileResourceID
	where pim.TenantID = @TenantIDFrom



	insert into dbo.Classification(TenantID, ClassificationName, ClassificationDescription, ThemeColor, DisplayName, GoalStatement, KeyImageFileResourceID)
	select @TenantIDTo as TenantID, ClassificationName, ClassificationDescription, ThemeColor, DisplayName, GoalStatement, fr.FileResourceID as KeyImageFileResourceID
	from dbo.Classification c
	join dbo.FileResource fr on c.ClassificationID = fr.ClassificationIDFromTenant and fr.TenantID = @TenantIDTo
	where c.TenantID = @TenantIDFrom

	declare @MattPersonID int
	select @MattPersonID = PersonID from dbo.Person p where p.TenantID = @TenantIDTo and p.Email = 'matt@sitkatech.com'

	insert into dbo.Project(TenantID, TaxonomyTierOneID, ProjectStageID, ProjectName, ProjectDescription, ImplementationStartYear, CompletionYear, EstimatedTotalCost, ProjectLocationPoint, PerformanceMeasureActualYearsExemptionExplanation, IsFeatured, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID, EstimatedAnnualOperatingCost, FundingTypeID, ProjectWatershedNotes, ProjectApprovalStatusID, ProposingPersonID, ProposingDate, PerformanceMeasureNotes, SubmissionDate, ApprovalDate)
	select @TenantIDTo as TenantID, tt2.TaxonomyTierOneID, ProjectStageID, ProjectName, ProjectDescription, ImplementationStartYear, CompletionYear, EstimatedTotalCost, ProjectLocationPoint, PerformanceMeasureActualYearsExemptionExplanation, IsFeatured, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID, EstimatedAnnualOperatingCost, FundingTypeID, ProjectWatershedNotes, ProjectApprovalStatusID, @MattPersonID as ProposingPersonID, ProposingDate, PerformanceMeasureNotes, SubmissionDate, ApprovalDate
	from dbo.Project p
	join dbo.TaxonomyTierOne tt on p.TaxonomyTierOneID = tt.TaxonomyTierOneID
	join dbo.TaxonomyTierOne tt2 on tt.TaxonomyTierOneName = tt2.TaxonomyTierOneName and tt2.TenantID = @TenantIDTo
	where p.TenantID = @TenantIDFrom and p.ProposingPersonID != 27 -- Jian Peng

	insert into dbo.ProjectFundingSourceExpenditure(TenantID, ProjectID, FundingSourceID, CalendarYear, ExpenditureAmount)
	select @TenantIDTo as TenantID, p2.ProjectID, fs2.FundingSourceID, CalendarYear, ExpenditureAmount
	from dbo.ProjectFundingSourceExpenditure pfs
	join dbo.Project p on pfs.ProjectID = p.ProjectID
	join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
	join dbo.FundingSource fs on pfs.FundingSourceID = fs.FundingSourceID
	join dbo.FundingSource fs2 on fs.FundingSourceName = fs2.FundingSourceName and fs2.TenantID = @TenantIDTo
	where pfs.TenantID = @TenantIDFrom

	insert into dbo.ProjectOrganization(TenantID, ProjectID, OrganizationID, RelationshipTypeID)
	select @TenantIDTo as TenantID, p2.ProjectID, fs2.OrganizationID, rt2.RelationshipTypeID
	from dbo.ProjectOrganization pfs
	join dbo.Project p on pfs.ProjectID = p.ProjectID
	join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
	join dbo.Organization fs on pfs.OrganizationID = fs.OrganizationID
	join dbo.Organization fs2 on fs.OrganizationName = fs2.OrganizationName and fs2.TenantID = @TenantIDTo
	join dbo.RelationshipType rt on pfs.RelationshipTypeID = rt.RelationshipTypeID
	join dbo.RelationshipType rt2 on rt.RelationshipTypeName = rt2.RelationshipTypeName and rt2.TenantID = @TenantIDTo
	where pfs.TenantID = @TenantIDFrom

	insert into dbo.ProjectClassification(TenantID, ProjectID, ClassificationID, ProjectClassificationNotes)
	select @TenantIDTo as TenantID, p2.ProjectID, fs2.ClassificationID, pfs.ProjectClassificationNotes
	from dbo.ProjectClassification pfs
	join dbo.Project p on pfs.ProjectID = p.ProjectID
	join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
	join dbo.Classification fs on pfs.ClassificationID = fs.ClassificationID
	join dbo.Classification fs2 on fs.ClassificationName = fs2.ClassificationName and fs2.TenantID = @TenantIDTo
	where pfs.TenantID = @TenantIDFrom


	insert into dbo.PerformanceMeasureActual(TenantID, ProjectID, PerformanceMeasureID, CalendarYear, ActualValue, PerformanceMeasureActualIDFromTenant)
	select @TenantIDTo as TenantID, p2.ProjectID, pm2.PerformanceMeasureID, CalendarYear, ActualValue, pma.PerformanceMeasureActualID as PerformanceMeasureActualIDFromTenant
	from dbo.PerformanceMeasureActual pma
	join dbo.PerformanceMeasure pm on pma.PerformanceMeasureID = pm.PerformanceMeasureID
	join dbo.PerformanceMeasure pm2 on pm.PerformanceMeasureDisplayName = pm2.PerformanceMeasureDisplayName and pm2.TenantID = @TenantIDTo
	join dbo.Project p on pma.ProjectID = p.ProjectID
	join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
	where pma.TenantID = @TenantIDFrom

	insert into dbo.PerformanceMeasureActualSubcategoryOption(TenantID, PerformanceMeasureActualID, PerformanceMeasureSubcategoryOptionID, PerformanceMeasureID, PerformanceMeasureSubcategoryID)
	select @TenantIDTo as TenantID, pma.PerformanceMeasureActualID, a.PerformanceMeasureSubcategoryOptionID, pma.PerformanceMeasureID, a.PerformanceMeasureSubcategoryID
	from dbo.PerformanceMeasureActualSubcategoryOption pmasco
	join dbo.PerformanceMeasureActual pma on pmasco.PerformanceMeasureActualID = pma.PerformanceMeasureActualIDFromTenant
	join dbo.PerformanceMeasureSubcategoryOption pmsco on pmasco.PerformanceMeasureSubcategoryOptionID = pmsco.PerformanceMeasureSubcategoryOptionID
	join
	(
	select pmsc.PerformanceMeasureID, pmsc.PerformanceMeasureSubcategoryID, pmsco2.PerformanceMeasureSubcategoryOptionID, pmsco2.PerformanceMeasureSubcategoryOptionName
	from dbo.PerformanceMeasureSubcategory pmsc
	join dbo.PerformanceMeasureSubcategoryOption pmsco2 on pmsc.PerformanceMeasureSubcategoryID = pmsco2.PerformanceMeasureSubcategoryID
	where pmsco2.TenantID = @TenantIDTo
	) a on pma.PerformanceMeasureID = a.PerformanceMeasureID and pmsco.PerformanceMeasureSubcategoryOptionName = a.PerformanceMeasureSubcategoryOptionName
	where pmasco.TenantID = @TenantIDFrom

	insert into dbo.FileResource(TenantID, FileResourceMimeTypeID, OriginalBaseFilename, OriginalFileExtension, FileResourceGUID, FileResourceData, CreatePersonID, CreateDate, ProjectImageIDFromTenant)
	select @TenantIDTo as TenantID, fr.FileResourceMimeTypeID, fr.OriginalBaseFilename, fr.OriginalFileExtension, NEWID(), fr.FileResourceData, @primaryContactPersonID as CreatePersonID, fr.CreateDate, pim.ProjectImageID as ProjectImageIDFromTenant
	from dbo.ProjectImage pim
	join dbo.FileResource fr on pim.FileResourceID = fr.FileResourceID
	where pim.TenantID = @TenantIDFrom

	insert into dbo.ProjectImage(TenantID, ProjectID, ProjectImageTimingID, Caption, Credit, ExcludeFromFactSheet, IsKeyPhoto, FileResourceID)
	select @TenantIDTo as TenantID, p2.ProjectID, pim.ProjectImageTimingID, pim.Caption, pim.Credit, pim.ExcludeFromFactSheet, pim.IsKeyPhoto, fr.FileResourceID
	from dbo.ProjectImage pim
	join dbo.Project p on pim.ProjectID = p.ProjectID
	join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
	join dbo.FileResource fr on pim.ProjectImageID = fr.ProjectImageIDFromTenant and fr.TenantID = @TenantIDTo
	where pim.TenantID = @TenantIDFrom


	insert into dbo.ProjectLocation(TenantID, ProjectID, ProjectLocationGeometry, Annotation)
	select @TenantIDTo as TenantID, p2.ProjectID, pl.ProjectLocationGeometry, pl.Annotation
	from dbo.ProjectLocation pl
	join dbo.Project p on pl.ProjectID = p.ProjectID
	join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
	where pl.TenantID = @TenantIDFrom


	
	insert into dbo.TaxonomyTierTwoPerformanceMeasure(TenantID, TaxonomyTierTwoID, PerformanceMeasureID, IsPrimaryTaxonomyTierTwo)
	select @TenantIDTo as TenantID, tt2.TaxonomyTierTwoID, pm2.PerformanceMeasureID, ttpm.IsPrimaryTaxonomyTierTwo
	from dbo.TaxonomyTierTwoPerformanceMeasure ttpm
	join dbo.PerformanceMeasure pm on ttpm.PerformanceMeasureID = pm.PerformanceMeasureID
	join dbo.PerformanceMeasure pm2 on pm.PerformanceMeasureDisplayName = pm2.PerformanceMeasureDisplayName and pm2.TenantID = @TenantIDTo
	join dbo.TaxonomyTierTwo tt on ttpm.TaxonomyTierTwoID = tt.TaxonomyTierTwoID
	join dbo.TaxonomyTierTwo tt2 on tt.TaxonomyTierTwoName = tt2.TaxonomyTierTwoName and tt2.TenantID = @TenantIDTo
	where ttpm.TenantID = @TenantIDFrom



	insert into dbo.AuditLog(TenantID, PersonID, AuditLogDate, AuditLogEventTypeID, TableName, RecordID, ColumnName, OriginalValue, NewValue, AuditDescription, ProjectID)
	select @TenantIDTo as TenantID, per2.PersonID, AuditLogDate, AuditLogEventTypeID, TableName, RecordID, ColumnName, OriginalValue, NewValue, AuditDescription, p2.ProjectID
	from dbo.Project p
	join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
	join dbo.AuditLog al on p.ProjectID = al.ProjectID
	join dbo.Person per on al.PersonID = per.PersonID
	join dbo.Person per2 on per.Email = per2.Email and per2.TenantID = @TenantIDTo
	where p.TenantID = @TenantIDFrom


	alter table dbo.PerformanceMeasureSubcategory drop column PerformanceMeasureSubcategoryIDFromTenant
	alter table dbo.PerformanceMeasureActual drop column PerformanceMeasureActualIDFromTenant
	alter table dbo.FileResource drop column OrganizationIDFromTenant
	alter table dbo.FileResource drop column ProjectImageIDFromTenant
	alter table dbo.FileResource drop column ClassificationIDFromTenant
	alter table dbo.FileResource drop column FirmaPageIDFromTenant
	alter table dbo.FirmaPage drop column FirmaPageIDFromTenant
	GO
