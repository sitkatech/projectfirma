
-- Insert zeros for year that are currently ProjectExemptReportingYears
/*  Don't want to insert zeros so we can tell which Projects have not reported andy expenditures based on presence/absence of expenditure records
insert into ProjectFundingSourceExpenditure
select pery.TenantID,
	pery.ProjectID,
	pfse.FundingSourceID,
	pery.CalendarYear,
	0,
	null
from dbo.ProjectExemptReportingYear pery
join (
	select TenantID,
		ProjectID,
		FundingSourceID
	from dbo.ProjectFundingSourceExpenditure
	group by TenantID, ProjectID, FundingSourceID
) as pfse on pery.TenantID = pfse.TenantID and pery.ProjectID = pfse.ProjectID
where ProjectExemptReportingTypeID = 2

insert into ProjectFundingSourceExpenditureUpdate
select peryu.TenantID,
	peryu.ProjectUpdateBatchID,
	pfseu.FundingSourceID,
	peryu.CalendarYear,
	0,
	null
from dbo.ProjectExemptReportingYearUpdate peryu
join (
	select TenantID,
		ProjectUpdateBatchID,
		FundingSourceID
	from dbo.ProjectFundingSourceExpenditureUpdate
	group by TenantID, ProjectUpdateBatchID, FundingSourceID
) as pfseu on peryu.TenantID = pfseu.TenantID and peryu.ProjectUpdateBatchID = pfseu.ProjectUpdateBatchID
where ProjectExemptReportingTypeID = 2
go
*/


-- Delete all examples of ProjectExemptReportingYears for Expenditures
delete from dbo.ProjectExemptReportingYear 
where ProjectExemptReportingTypeID = 2
delete from dbo.ProjectExemptReportingYearUpdate 
where ProjectExemptReportingTypeID = 2
go

-- Delete the ProjectExemptReportingType for Expenditures
delete from dbo.ProjectExemptReportingType
where ProjectExemptReportingTypeID = 2

-- Rename NoExpendituresToReportExplanation to ExpendituresNote to make it a general purpose notes field
EXEC sp_rename 'dbo.Project.NoExpendituresToReportExplanation', 'ExpendituresNote', 'COLUMN';

EXEC sp_rename 'dbo.ProjectUpdateBatch.NoExpendituresToReportExplanation', 'ExpendituresNote', 'COLUMN';

