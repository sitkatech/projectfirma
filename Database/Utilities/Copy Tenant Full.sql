ALTER TABLE dbo.TaxonomyTierThree DROP CONSTRAINT AK_TaxonomyTierThree_TaxonomyTierThreeName
GO

ALTER TABLE dbo.TaxonomyTierThree ADD  CONSTRAINT AK_TaxonomyTierThree_TaxonomyTierThreeName_TenantID UNIQUE (TaxonomyTierThreeName, TenantID)
GO

ALTER TABLE dbo.TaxonomyTierTwo DROP CONSTRAINT AK_TaxonomyTierTwo_TaxonomyTierTwoName
GO

ALTER TABLE dbo.TaxonomyTierTwo ADD  CONSTRAINT AK_TaxonomyTierTwo_TaxonomyTierTwoName_TenantID UNIQUE (TaxonomyTierTwoName, TenantID)
GO

ALTER TABLE dbo.TaxonomyTierOne DROP CONSTRAINT AK_TaxonomyTierOne_TaxonomyTierOneName
GO

ALTER TABLE dbo.TaxonomyTierOne ADD  CONSTRAINT AK_TaxonomyTierOne_TaxonomyTierOneName_TenantID UNIQUE (TaxonomyTierOneName, TenantID)
GO

alter table dbo.PerformanceMeasureSubcategory add PerformanceMeasureSubcategoryIDFromTenant int null
GO

alter table dbo.PerformanceMeasureActual add PerformanceMeasureActualIDFromTenant int null
GO

declare	@TenantIDFrom int, @TenantIDTo int, @createDate datetime

select @TenantIDFrom = 4, @TenantIDTo = 5


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

insert into dbo.OrganizationType(TenantID, OrganizationTypeName, OrganizationTypeAbbreviation, LegendColor, ShowOnProjectMaps, IsDefaultOrganizationType)
select distinct @TenantIDTo as TenantID, ot.OrganizationTypeName, ot.OrganizationTypeAbbreviation, ot.LegendColor, ot.ShowOnProjectMaps, ot.IsDefaultOrganizationType
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

insert into dbo.Classification(TenantID, ClassificationName, ClassificationDescription, ThemeColor, DisplayName, GoalStatement)
select @TenantIDTo as TenantID, ClassificationName, ClassificationDescription, ThemeColor, DisplayName, GoalStatement
from dbo.Classification fs
where fs.TenantID = @TenantIDFrom

declare @MattPersonID int
select @MattPersonID = PersonID from dbo.Person p where p.TenantID = @TenantIDTo and p.Email = 'matt@sitkatech.com'


insert into dbo.Project(TenantID, TaxonomyTierOneID, ProjectStageID, ProjectName, ProjectDescription, ImplementationStartYear, CompletionYear, EstimatedTotalCost, ProjectLocationPoint, PerformanceMeasureActualYearsExemptionExplanation, IsFeatured, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID, EstimatedAnnualOperatingCost, FundingTypeID, ProjectWatershedNotes, ProjectApprovalStatusID, ProposingPersonID, ProposingDate, PerformanceMeasureNotes, SubmissionDate, ApprovalDate)
select @TenantIDTo as TenantID, tt2.TaxonomyTierOneID, ProjectStageID, ProjectName, ProjectDescription, ImplementationStartYear, CompletionYear, EstimatedTotalCost, ProjectLocationPoint, PerformanceMeasureActualYearsExemptionExplanation, IsFeatured, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID, EstimatedAnnualOperatingCost, FundingTypeID, ProjectWatershedNotes, ProjectApprovalStatusID, @MattPersonID as ProposingPersonID, ProposingDate, PerformanceMeasureNotes, SubmissionDate, ApprovalDate
from dbo.Project p
join dbo.TaxonomyTierOne tt on p.TaxonomyTierOneID = tt.TaxonomyTierOneID
join dbo.TaxonomyTierOne tt2 on tt.TaxonomyTierOneName = tt2.TaxonomyTierOneName and tt2.TenantID = @TenantIDTo
where p.TenantID = @TenantIDFrom and p.ProposingPersonID != 27 -- Jian Peng


SELECT *
FROM PerformanceMeasureSubcategoryOption pmso
where pmso.TenantID = @TenantIDFrom

SELECT *
FROM PerformanceMeasureSubcategoryOption pmso
where pmso.TenantID = @TenantIDTo


insert into dbo.ProjectFundingSourceExpenditure(TenantID, ProjectID, FundingSourceID, CalendarYear, ExpenditureAmount)
select @TenantIDTo as TenantID, p2.ProjectID, fs2.FundingSourceID, CalendarYear, ExpenditureAmount
from dbo.ProjectFundingSourceExpenditure pfs
join dbo.Project p on pfs.ProjectID = p.ProjectID
join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
join dbo.FundingSource fs on pfs.FundingSourceID = fs.FundingSourceID
join dbo.FundingSource fs2 on fs.FundingSourceName = fs2.FundingSourceName and fs2.TenantID = @TenantIDTo
where pfs.TenantID = @TenantIDFrom


insert into dbo.PerformanceMeasureActual(TenantID, ProjectID, PerformanceMeasureID, CalendarYear, ActualValue, PerformanceMeasureActualIDFromTenant)
select @TenantIDTo as TenantID, p2.ProjectID, pm2.PerformanceMeasureID, CalendarYear, ActualValue, pma.PerformanceMeasureActualID as PerformanceMeasureActualIDFromTenant
from dbo.PerformanceMeasureActual pma
join dbo.PerformanceMeasure pm on pma.PerformanceMeasureID = pm.PerformanceMeasureID
join dbo.PerformanceMeasure pm2 on pm.PerformanceMeasureDisplayName = pm2.PerformanceMeasureDisplayName and pm2.TenantID = 5
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


insert into dbo.AuditLog(TenantID, PersonID, AuditLogDate, AuditLogEventTypeID, TableName, RecordID, ColumnName, OriginalValue, NewValue, AuditDescription, ProjectID)
select @TenantIDTo as TenantID, per2.PersonID, AuditLogDate, AuditLogEventTypeID, TableName, RecordID, ColumnName, OriginalValue, NewValue, AuditDescription, p2.ProjectID
from dbo.Project p
join dbo.Project p2 on p.ProjectName = p2.ProjectName and p2.TenantID = @TenantIDTo
join dbo.AuditLog al on p.ProjectID = al.ProjectID
join dbo.Person per on al.PersonID = per.PersonID
join dbo.Person per2 on per.Email = per2.Email and per2.TenantID = @TenantIDTo
where p.TenantID = @TenantIDFrom

alter table dbo.PerformanceMeasureActual DROP COLUMN PerformanceMeasureActualIDFromTenant
alter table dbo.PerformanceMeasureSubcategory DROP COLUMN PerformanceMeasureSubcategoryIDFromTenant
GO

select *
from PerformanceMeasureActual p
where p.TenantID = 5 and p.ProjectID = 3189

select *
from PerformanceMeasureActual p
where p.TenantID = 4 and p.ProjectID = 13