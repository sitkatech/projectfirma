
delete from dbo.ProjectColorByType

insert dbo.ProjectColorByType (ProjectColorByTypeID, ProjectColorByTypeName, ProjectColorByTypeDisplayName, ProjectColorByTypeNameWithIdentifier, SortOrder) values 
(1, 'TaxonomyTrunk', 'Taxonomy Trunk', 'TaxonomyTrunkID', 10),
(2, 'ProjectStage', 'Stage', 'ProjectStageID', 20),
(3, 'TaxonomyTierTwo', 'Taxonomy Tier Two', 'TaxonomyTierTwoID', 11)
