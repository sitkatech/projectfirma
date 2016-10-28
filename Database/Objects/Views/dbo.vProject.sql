if exists (select * from dbo.sysobjects where id = object_id('dbo.vProject'))
	drop view dbo.vProject
go

create view dbo.vProject
as
	select	
            concat(substring(cast(fa.FocusAreaNumber + 1000 as varchar), 3, 2), '.', substring(cast(prog.ProgramNumber + 1000 as varchar), 3, 2), '.', substring(cast(ap.ActionPriorityNumber + 1000 as varchar), 3, 2), '.', substring(cast(p.ProjectNumber + 100000 as varchar), 3, 4)) as ProjectNumberFull,
            p.ProjectID, p.ActionPriorityID, p.ProjectNumber, p.ProjectName, p.ProjectDescription, ps.ProjectStageID, ps.ProjectStageDisplayName, p.ImplementationStartYear, p.CompletionYear, p.ImplementsMultipleProjects
	from dbo.Project p
    join dbo.ActionPriority ap on p.ActionPriorityID = ap.ActionPriorityID
	join dbo.Program prog on ap.ProgramID = prog.ProgramID
	join dbo.FocusArea fa on prog.FocusAreaID = fa.FocusAreaID
    join dbo.ProjectStage ps on p.ProjectStageID = ps.ProjectStageID
go

/*
select * from dbo.vProject
*/