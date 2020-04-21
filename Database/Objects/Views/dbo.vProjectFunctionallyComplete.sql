if exists (select * from dbo.sysobjects where id = object_id('dbo.vProjectFunctionallyComplete'))
	drop view dbo.vProjectFunctionallyComplete
go

create view dbo.vProjectFunctionallyComplete
as
select p.ProjectID,
       p.ProjectID as PrimaryKey,

cast(case when ps.ProjectStageName = 'Completed' then 1
     when x.HasSubmittedOrApprovedUpdateBatchChangingProjectToCompleted = 1 then 1
     else 0 end as bit) as FunctionallyComplete

 from dbo.Project p
 join dbo.ProjectStage ps on p.ProjectStageID = ps.ProjectStageID
left join (


select p.ProjectID
, cast( case when count(*) > 0 then 1 else 0 end as bit) as HasSubmittedOrApprovedUpdateBatchChangingProjectToCompleted from dbo.Project p
left join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
left join dbo.ProjectUpdateState pus on pub.ProjectUpdateStateID = pus.ProjectUpdateStateID
left join dbo.ProjectUpdate pu on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
left join dbo.ProjectStage ps on pu.ProjectStageID = ps.ProjectStageID
where ps.ProjectStageName = 'Completed' and pus.ProjectUpdateStateName in ('Approved', 'Submitted')
group by p.ProjectID) x on p.ProjectID = x.ProjectID

go

-- select * from dbo.vProjectFunctionallyComplete
