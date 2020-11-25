delete from dbo.MatchmakerSubScoreType
go

insert into dbo.MatchmakerSubScoreType(MatchmakerSubScoreTypeID, MatchmakerSubScoreTypeName, MatchmakerSubScoreTypeDisplayName, SortOrder)
values
(1, 'MatchmakerKeyword', 'Keywords', 20),
(2, 'AreaOfInterest', 'Area Of Interest', 10),
(3, 'TaxonomySystem', 'Taxonomy System', 30),
(4, 'Classification', 'Classification', 40),
(5, 'PerformanceMeasure', 'Performance Measures', 50)

