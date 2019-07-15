
alter table dbo.ProjectUpdate
add FundingTypeID int null constraint FK_ProjectUpdate_FundingType_FundingTypeID foreign key references dbo.FundingType(FundingTypeID)
