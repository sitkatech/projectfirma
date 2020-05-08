update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3489
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3368
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2020 where ProjectNoFundingSourceIdentifiedUpdateID = 3447
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3636
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3369
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3371
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3370
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3685
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3490
update dbo.ProjectNoFundingSourceIdentifiedUpdate set CalendarYear = 2019 where ProjectNoFundingSourceIdentifiedUpdateID = 3403

delete from dbo.ProjectNoFundingSourceIdentifiedUpdate where ProjectNoFundingSourceIdentifiedUpdateID = 3345 -- delete this row, there already is a row for calendar year 2019 and this is an approved update
delete from dbo.ProjectNoFundingSourceIdentifiedUpdate where ProjectNoFundingSourceIdentifiedUpdateID = 3698 -- delete this row, there already is a row for calendar year 2019 and this is an approved update

-- one update was approved with bad data in ProjectNoFundingSourceIdentifiedUpdate, so need to add the CalendarYear to ProjectNoFundingSourceIdentified
update dbo.ProjectNoFundingSourceIdentified set CalendarYear = 2019 where ProjectID = 13168 and CalendarYear is null
