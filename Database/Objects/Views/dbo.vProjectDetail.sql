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
, p.ProjectStageID
, p.ProjectApprovalStatusID
, po.OrganizationID as PrimaryContactOrganizationID
, po.DisplayName as PrimaryContactOrganizationDisplayName
, p.PrimaryContactPersonID
, case when person.PersonID is not null then person.FirstName + ' ' + person.LastName
    else  po.FullNameFirstLast end as PrimaryContactPersonFullNameFirstLast
,  coalesce(person.Email, po.Email) as PrimaryContactPersonEmail
, coalesce(pma.PerformanceMeasureActualCount, 0) as PerformanceMeasureActualCount
, coalesce(pme.PerformanceMeasureExpectedCount, 0) as PerformanceMeasureExpectedCount
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
, pcwcmp.ProjectContactsWhoCanManageProjectConcatenated as ProjectContactsWhoCanManageProjectConcatenated

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
--left join (select pme.ProjectID, count(*) as PerformanceMeasureExpectedCount from dbo.PerformanceMeasureExpected pme group by pme.ProjectID) pme on pme.ProjectID = p.ProjectID
left join 
(
    select suby.ProjectID, count(*) as PerformanceMeasureExpectedCount
    from
    (
        select distinct pme1.ProjectID, pme1.PerformanceMeasureID
        from dbo.PerformanceMeasureExpected as pme1
    ) as suby
    group by suby.ProjectID
) pme on pme.ProjectID = p.ProjectID
left join (select pim.ProjectID, count(*) as ProjectImageCount from dbo.ProjectImage pim group by pim.ProjectID) pim on pim.ProjectID = p.ProjectID
left join (select pps.ProjectID, count(*) as FinalStatusUpdateCount from dbo.ProjectProjectStatus pps where pps.IsFinalStatusUpdate = 1 group by pps.ProjectID) pps on pps.ProjectID = p.ProjectID
left join (select pfse.ProjectID, count(*) as ProjectFundingSourceExpenditureCount from dbo.ProjectFundingSourceExpenditure pfse group by pfse.ProjectID) pfse on pfse.ProjectID = p.ProjectID

left join
(
    SELECT pc.ProjectID, LEFT(pc.ProjectContacts,Len(pc.ProjectContacts)-1) As ProjectContactsWhoCanManageProjectConcatenated
    FROM
        (
            SELECT DISTINCT pc2.ProjectID, 
                (
                    SELECT  cast(pc1.ContactID as VARCHAR(1000)) + ','
                    FROM dbo.ProjectContact pc1
                    join dbo.ContactRelationshipType crt on crt.ContactRelationshipTypeID = pc1.ContactRelationshipTypeID
                    where crt.CanManageProject = 1
                    and pc1.ProjectID = pc2.ProjectID
                    ORDER BY pc1.ProjectID
                    FOR XML PATH ('')
                ) as ProjectContacts
            FROM dbo.ProjectContact pc2
        ) pc
)  pcwcmp on pcwcmp.ProjectID = p.ProjectID


go

/*

select * from dbo.vProjectDetail

*/