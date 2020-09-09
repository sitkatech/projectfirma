alter table dbo.Organization add MatchmakerCash bit null
alter table dbo.Organization add MatchmakerInKindServices bit null
alter table dbo.Organization add MatchmakerCommercialServices bit null

alter table dbo.Organization add MatchmakerCashDescription varchar(300) null
alter table dbo.Organization add MatchmakerInKindServicesDescription varchar(300) null
alter table dbo.Organization add MatchmakerCommercialServicesDescription varchar(300) null
alter table dbo.Organization add MatchmakerConstraints varchar(300) null
alter table dbo.Organization add MatchmakerAdditionalInformation varchar(300) null