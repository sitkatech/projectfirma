CREATE TABLE dbo.TaxonomyLevel(
	TaxonomyLevelID int NOT NULL CONSTRAINT PK_TaxonomyLevel_TaxonomyLevelID PRIMARY KEY,
	TaxonomyLevelName varchar(100) NOT NULL CONSTRAINT AK_TaxonomyLevel_TaxonomyLevelName UNIQUE,
	TaxonomyLevelDisplayName varchar(100) NOT NULL CONSTRAINT AK_TaxonomyLevel_TaxonomyLevelDisplayName UNIQUE
)

alter table dbo.TenantAttribute add TaxonomyLevelID int null
alter table dbo.TenantAttribute add constraint FK_TenantAttribute_TaxonomyLevel_TaxonomyLevelID foreign key (TaxonomyLevelID) references dbo.TaxonomyLevel(TaxonomyLevelID)
ALTER TABLE dbo.TenantAttribute DROP CONSTRAINT CK_TenantAttribute_NumberOfTaxonomyTiersToUseBetweenOneAndThree
GO

insert into dbo.TaxonomyLevel(TaxonomyLevelID, TaxonomyLevelName, TaxonomyLevelDisplayName)
values
(1, 'Leaf', 'Leaf (1 level)'),
(2, 'Branch', 'Branch (2 levels)'),
(3, 'Trunk', 'Trunk (3 levels)')

update dbo.TenantAttribute
set TaxonomyLevelID = NumberOfTaxonomyTiersToUse

alter table dbo.TenantAttribute alter column TaxonomyLevelID int not null
alter table dbo.TenantAttribute drop column NumberOfTaxonomyTiersToUse