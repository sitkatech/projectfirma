if exists (select * from dbo.sysobjects where id = object_id('dbo.vProjectDetail'))
	drop view dbo.vProjectDetail
go

create view dbo.vProjectDetail
as
select 

p.ProjectID
, p.ProjectID as PrimaryKey
, p.TenantID
, p.ProjectName
, po.OrganizationID as PrimaryContactOrganizationID
, po.DisplayName as PrimaryContactOrganizationDisplayName
, p.PrimaryContactPersonID
, case when person.PersonID is not null then person.FirstName + ' ' + person.LastName
    else  po.FullNameFirstLast end as PrimaryContactPersonFullNameFirstLast
,  coalesce(person.Email, po.Email) as PrimaryContactPersonEmail
, coalesce(pma.PerformanceMeasureActualCount, 0) as PerformanceMeasureActualCount
, coalesce(pim.ProjectImageCount, 0) as ProjectImageCount
, pso.OrganizationID as CanStewardProjectsOrganizationID
, pso.DisplayName as CanStewardProjectsOrganizationDisplayName
, tl.TaxonomyLeafID 
, case when tl.TaxonomyLeafCode is not null and tl.TaxonomyLeafCode != '' then tl.TaxonomyLeafCode + ': ' + tl.TaxonomyLeafName else tl.TaxonomyLeafName end as TaxonomyLeafDisplayName
, case when coalesce(pps.FinalStatusUpdateCount, 0) > 0 and pendingCompletedBatch.FunctionallyComplete = 1 then 'Submitted'
       when coalesce(pps.FinalStatusUpdateCount, 0) = 0 and pendingCompletedBatch.FunctionallyComplete = 1 then 'Not Submitted'
       else 'n/a' end as FinalStatusReportStatusDescription
, coalesce(pfse.ProjectFundingSourceExpenditureCount,0) as ProjectFundingSourceExpenditureCount
, proposer.OrganizationID as ProposingOrganizationID

 from dbo.Project p
 join dbo.TaxonomyLeaf tl on p.TaxonomyLeafID = tl.TaxonomyLeafID
 join dbo.vProjectFunctionallyComplete pendingCompletedBatch on pendingCompletedBatch.ProjectID = p.ProjectID
 left join dbo.Person proposer on proposer.PersonID = p.ProposingPersonID
 left join dbo.Person person on p.PrimaryContactPersonID = person.PersonID
left join (select 
            o.OrganizationID
            , coalesce(o.OrganizationShortName, o.OrganizationName) as DisplayName
            , po.ProjectID
            , p.PersonID
            , p.FirstName + ' ' + p.LastName as FullNameFirstLast
            , p.Email
                    from    dbo.ProjectOrganization po
                    join    dbo.OrganizationRelationshipType ot on po.OrganizationRelationshipTypeID = ot.OrganizationRelationshipTypeID
                    join    dbo.Organization o on po.OrganizationID = o.OrganizationID
                    left join dbo.Person p on o.PrimaryContactPersonID = p.PersonID
                    where ot.IsPrimaryContact = 1)                  
   po on p.ProjectID = po.ProjectID

   left join (select 
            o.OrganizationID
            , coalesce(o.OrganizationShortName, o.OrganizationName) as DisplayName
            , po.ProjectID
                    from    dbo.ProjectOrganization po
                    join    dbo.OrganizationRelationshipType ot on po.OrganizationRelationshipTypeID = ot.OrganizationRelationshipTypeID
                    join    dbo.Organization o on po.OrganizationID = o.OrganizationID
                    where ot.CanStewardProjects = 1)                  
   pso on p.ProjectID = pso.ProjectID





left join (select pma.ProjectID, count(*) as PerformanceMeasureActualCount from dbo.PerformanceMeasureActual pma group by pma.ProjectID) pma on pma.ProjectID = p.ProjectID
left join (select pim.ProjectID, count(*) as ProjectImageCount from dbo.ProjectImage pim group by pim.ProjectID) pim on pim.ProjectID = p.ProjectID
left join (select pps.ProjectID, count(*) as FinalStatusUpdateCount from dbo.ProjectProjectStatus pps where pps.IsFinalStatusUpdate = 1 group by pps.ProjectID) pps on pps.ProjectID = p.ProjectID
left join (select pfse.ProjectID, count(*) as ProjectFundingSourceExpenditureCount from dbo.ProjectFundingSourceExpenditure pfse group by pfse.ProjectID) pfse on pfse.ProjectID = p.ProjectID




go

-- select * from dbo.vProjectDetail