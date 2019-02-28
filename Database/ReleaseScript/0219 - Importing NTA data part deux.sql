alter table dbo.Project add NTAID int null
GO

insert into dbo.Project(NTAID, TenantID, TaxonomyLeafID, ProjectStageID, ProjectName, ProjectDescription, ImplementationStartYear, CompletionYear, EstimatedTotalCost, ProjectLocationPoint, ProjectLocationNotes, PlanningDesignStartYear, ProjectLocationSimpleTypeID
, FundingTypeID, ProjectApprovalStatusID, PrimaryContactPersonID, IsFeatured)
select n.NTAID, 11 as TenantID, tl.TaxonomyLeafID, ps.ProjectStageID, n.[Near Term Action Name] as ProjectName, n.[Description] as ProjectDescription, n.[Implementation Start Year], n.[Completion Year], n.[Estimated Total Cost]
, case when n.Latitude is not null and n.Longitude is not null then 
geometry::STGeomFromText(concat('POINT(', n.Longitude, ' ', n.Latitude, ')'), 4326) 
else null end as ProjectLocationPoint
, n.[NTA Location Notes] as ProjectLocationNotes, n.[Planning/Design Start Year], 1 as ProjectLocationSimpleTypeID, ft.FundingTypeID
, 3 as ProjectApprovalStatusID, isnull(p.PersonID, 5307) as PrimaryContactPersonID, 0 as IsFeatured
from dbo.NTA n
join dbo.TaxonomyLeaf tl on n.[Primary RPA_(TaxonomyLeafCode)] = tl.TaxonomyLeafCode and tl.TenantID = 11
join dbo.ProjectStage ps on n.Stage = ps.ProjectStageDisplayName
join dbo.FundingType ft on n.[Funding Type] = ft.FundingTypeDisplayName
left join dbo.Person p on n.[Primary Contact_(email address)] = p.Email and p.TenantID = 11

insert into dbo.SecondaryProjectTaxonomyLeaf(TenantID, ProjectID, TaxonomyLeafID)
select 11 as TenantID, p.ProjectID, tl.TaxonomyLeafID
from dbo.[NTA SecondaryRPA] n
join dbo.Project p on n.NTAID = p.NTAID
join dbo.TaxonomyLeaf tl on n.[Secondary RPAs] = tl.TaxonomyLeafCode
where p.TenantID = 11

insert into dbo.ProjectOrganization(TenantID, RelationshipTypeID, ProjectID, OrganizationID)
select 11 as TenantID, 36 as RelationshipTypeID, p.ProjectID, n.[Owner Organization] as OrganizationID
from dbo.NTA n
join dbo.Project p on n.NTAID = p.NTAID
where p.TenantID = 11

insert into dbo.ProjectOrganization(TenantID, RelationshipTypeID, ProjectID, OrganizationID)
select 11 as TenantID, 38 as RelationshipTypeID, p.ProjectID, n.[Partner] as OrganizationID
from dbo.[NTA Partners] n
join dbo.Project p on n.NTAID = p.NTAID
join dbo.Organization o on n.Partner = o.OrganizationID
where p.TenantID = 11

insert into dbo.ProjectClassification(TenantID, ProjectID, ClassificationID)
select 11 as TenantID, p.ProjectID, c.ClassificationID
from dbo.NTA n
join dbo.Project p on n.NTAID = p.NTAID
join dbo.Classification c on n.[Activity Types] = c.ClassificationID
where [Activity Types] is not null

insert into dbo.ProjectFundingSourceRequest(TenantID, ProjectID, FundingSourceID, SecuredAmount)
select 11 as TenantID, p.ProjectID, 8388 as FundingSourceID, n.[Funding Secured] as SecuredAmount
from dbo.NTA n
join dbo.Project p on n.NTAID = p.NTAID
where p.TenantID = 11 and n.[Funding Secured] is not null

insert into dbo.ProjectGeospatialArea(TenantID, ProjectID, GeospatialAreaID)
select 11 as TenantID, p.ProjectID, ga.GeospatialAreaID
from dbo.NTA_LegDistrict n
join dbo.Project p on n.NTAID = p.NTAID
join dbo.GeospatialArea ga on n.[Legislative District] = 'Legislative District ' + ga.GeospatialAreaName and ga.GeospatialAreaTypeID = 13
where ga.TenantID = 11

insert into dbo.ProjectGeospatialArea(TenantID, ProjectID, GeospatialAreaID)
select 11 as TenantID, p.ProjectID, ga.GeospatialAreaID
from dbo.NTA_LocalArea n
join dbo.Project p on n.NTAID = p.NTAID
join dbo.GeospatialArea ga on n.[Local Area] = ga.GeospatialAreaName and ga.GeospatialAreaTypeID = 14

insert into dbo.ProjectGeospatialArea(TenantID, ProjectID, GeospatialAreaID)
select 11 as TenantID, p.ProjectID, ga.GeospatialAreaID
from dbo.NTA_County n
join dbo.Project p on n.NTAID = p.NTAID
join dbo.GeospatialArea ga on n.County = ga.GeospatialAreaName + ' County' and ga.GeospatialAreaTypeID = 19

insert into dbo.ProjectGeospatialArea(TenantID, ProjectID, GeospatialAreaID)
select 11 as TenantID, p.ProjectID, ga.GeospatialAreaID
from dbo.NTA_LeadEntityManagementAreas n
join dbo.Project p on n.NTAID = p.NTAID
join dbo.GeospatialArea ga on n.[Lead Entity] = ga.GeospatialAreaName and ga.GeospatialAreaTypeID = 18

create table #tmpProjectCustomAttribute
(
	ProjectCustomAttributeID int not null identity(1,1),
	ProjectID int not null,
	ProjectCustomAttributeTypeID int not null,
	AttributeValue varchar(1000) not null
)
GO

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Status' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.Status as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.Status is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Activity Progress Barrier' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Activity Progress Barrier] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Activity Progress Barrier] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Activity Progress Comment' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Activity Progress Comment] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Activity Progress Comment] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = '2018 NTA ID' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[2018 NTA ID] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[2018 NTA ID] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Activity Objective' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Activity Objective] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Activity Objective] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = '2018 Ranking Tier' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[2018 Ranking Tier] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[2018 Ranking Tier] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Activity Scope' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Activity Scope] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Activity Scope] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Related Larger Project' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Related Larger Project] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Related Larger Project] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Related Ongoing Program' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Related Ongoing Program] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Related Ongoing Program] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Salmon Recovery 4-Year Workplans' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Salmon Recovery 4-Year Workplans] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Salmon Recovery 4-Year Workplans] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Effectiveness Information' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Effectiveness Information] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Effectiveness Information] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = 'Related Activity' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[Related Activity] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[Related Activity] is not null

insert into #tmpProjectCustomAttribute(ProjectID, ProjectCustomAttributeTypeID, AttributeValue)
select p.ProjectID, (select ProjectCustomAttributeTypeID from dbo.ProjectCustomAttributeType pcat where pcat.ProjectCustomAttributeTypeName = '2016 NTA ID' and pcat.TenantID = 11) as ProjectCustomAttributeTypeID, n.[2016 NTA ID] as AttributeValue
from dbo.NTA_CustomAttributes n
join dbo.Project p on n.NTAID = p.NTAID
where n.[2016 NTA ID] is not null

declare @maxProjectCustomAttributeID int
select @maxProjectCustomAttributeID = isnull(max(ProjectCustomAttributeID), 0) from dbo.ProjectCustomAttribute

set identity_insert dbo.ProjectCustomAttribute on
insert into dbo.ProjectCustomAttribute(TenantID, ProjectCustomAttributeID, ProjectID, ProjectCustomAttributeTypeID)
select 11 as TenantID, @maxProjectCustomAttributeID + t.ProjectCustomAttributeID, t.ProjectID, t.ProjectCustomAttributeTypeID
from #tmpProjectCustomAttribute t
set identity_insert dbo.ProjectCustomAttribute off

insert into dbo.ProjectCustomAttributeValue(TenantID, ProjectCustomAttributeID, AttributeValue)
select 11 as TenantID, @maxProjectCustomAttributeID + t.ProjectCustomAttributeID, t.AttributeValue
from #tmpProjectCustomAttribute t


insert into dbo.ProjectNote(TenantID, ProjectID, CreateDate, CreatePersonID, Note)
select 11 as TenantID, p.ProjectID, n.[Create Date], isnull(pe.PersonID, 5307) as CreatePersonID, n.[Action Note]
from dbo.NTA_Note n
join dbo.Project p on n.NTAID = p.NTAID
left join dbo.Person pe on n.[Create Person] = pe.Email and pe.TenantID = 11
where NoteType != 'Internal'

drop table dbo.NTA
drop table dbo.[NTA Partners]
drop table dbo.[NTA SecondaryRPA]
drop table dbo.NTA_County
drop table dbo.NTA_CustomAttributes
drop table dbo.NTA_LeadEntityManagementAreas
drop table dbo.NTA_LocalArea
drop table dbo.NTA_LegDistrict
drop table dbo.NTA_Note
drop table dbo.PSP_NTA_Attachments_Import

alter table dbo.Project drop column NTAID