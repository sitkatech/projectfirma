create table dbo.MatchmakerSubScoreType(
    MatchmakerSubScoreTypeID int not null constraint PK_MatchmakerSubScoreType_MatchmakerSubScoreTypeID primary key,
    MatchmakerSubScoreTypeName varchar(200) not null,
    MatchmakerSubScoreTypeDisplayName varchar(200) not null
)