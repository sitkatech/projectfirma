alter table dbo.FirmaHomePageImage alter column Caption varchar(500) null

alter table dbo.ClassificationSystem add ClassificationSystemNamePlural varchar(210) null
go 
update dbo.ClassificationSystem set ClassificationSystemNamePlural = 'Pillars of Resilience' where ClassificationSystemID = 25