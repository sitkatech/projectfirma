
delete from dbo.ProjectColorByType

insert dbo.ProjectColorByType (ProjectColorByTypeID, ProjectColorByTypeName, ProjectColorByTypeDisplayName, ProjectColorByTypeNameWithIdentifier, SortOrder) values 
(1, 'TaxonomyTrunk', 'Taxonomy Trunk', 'TaxonomyTrunkID', 10),
(2, 'ProjectStage', 'Stage', 'ProjectStageID', 20),
(3, 'TaxonomyBranch', 'Taxonomy Branch', 'TaxonomyBranchID', 11)
