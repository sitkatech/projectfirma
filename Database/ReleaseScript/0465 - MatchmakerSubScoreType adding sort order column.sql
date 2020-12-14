--create table dbo.MatchmakerSubScoreType(
--    MatchmakerSubScoreTypeID int not null constraint PK_MatchmakerSubScoreType_MatchmakerSubScoreTypeID primary key,
--    MatchmakerSubScoreTypeName varchar(200) not null,
--    MatchmakerSubScoreTypeDisplayName varchar(200) not null
--)

alter table dbo.MatchmakerSubScoreType
add SortOrder int null;
go

update dbo.MatchmakerSubScoreType
set SortOrder = 10;
go

alter table dbo.MatchmakerSubScoreType
alter column SortOrder int not null