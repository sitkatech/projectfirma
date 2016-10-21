if exists (select * from dbo.sysobjects where id = object_id('dbo.vActionPriority'))
	drop view dbo.vActionPriority
go

create view dbo.vActionPriority
as
	select	fa.FocusAreaID, fa.FocusAreaNumber, fa.FocusAreaName, 
			p.ProgramID, p.ProgramNumber, p.ProgramName, concat(fa.FocusAreaNumber, '.', p.ProgramNumber) as ProgramNumberFull,
			ap.ActionPriorityID, ap.ActionPriorityNumber, ap.ActionPriorityName, concat(fa.FocusAreaNumber, '.', p.ProgramNumber, '.', ap.ActionPriorityNumber) as ActionPriorityNumberFull
	from dbo.ActionPriority ap
	join dbo.Program p on ap.ProgramID = p.ProgramID
	join dbo.FocusArea fa on p.FocusAreaID = fa.FocusAreaID
go

/*

select * from dbo.vActionPriority

*/

